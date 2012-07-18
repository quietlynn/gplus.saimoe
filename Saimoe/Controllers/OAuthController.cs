/**
 * @file: Controllers/OAuthController.cs
 * @author Korepwx <public@korepwx.com>.
 * The OAuth 2.0 Controller for user verification via Google Service.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Saimoe.Models;

namespace Saimoe.Controllers
{
    /// <summary>
    /// The OAuth 2.0 AppKey Settings.
    /// </summary>
    public class OAuthSettings
    {
        // TODO: Please provide formal OAuth 2.0 AppKey and Redirect Url!
        public static readonly string ClientID = "136777643268.apps.googleusercontent.com";
        public static readonly string ClientSecret = "-3GRfU45EoKsH2zftBQWjhLZ";
        public static readonly string ApiKey = "AIzaSyCWL9iC3r2BFjWBin70cxQWBtJmyvhEhRw";
        public static readonly string EmailAddress = "136777643268@developer.gserviceaccount.com";
    }

    /// <summary>
    /// The OAuth 2.0 login controller.
    /// Reference: http://www.cnblogs.com/dudu/archive/2012/04/30/asp_net_mvc_google_oauth_api.html.
    /// </summary>
    public class OAuthController : Controller
    {
        protected string getGoogleCallbackUrl()
        {
            return new Uri(Request.Url, Url.Action("Callback")).AbsoluteUri;
        }

        public ActionResult Login()
        {
            var url = "https://accounts.google.com/o/oauth2/auth?" +
                "scope={0}&state={1}&redirect_uri={2}&response_type=code&client_id={3}&approval_prompt=auto";

            var scope = string.Join("+", new string[] {
                HttpUtility.UrlEncode("https://www.googleapis.com/auth/plus.me")
            });
            var state = "/profile";

            var redirectUri = HttpUtility.UrlEncode(getGoogleCallbackUrl());
            var cilentId = HttpUtility.UrlEncode(OAuthSettings.ClientID);

            return Redirect(string.Format(url, scope, state, redirectUri, cilentId));
        }

        public ActionResult Callback()
        {
            var webRequest = (HttpWebRequest)WebRequest.Create("https://accounts.google.com/o/oauth2/token");
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";

            // 参考 https://developers.google.com/accounts/docs/OAuth2WebServer
            var postData = string.Format("code={0}&client_id={1}&client_secret={2}&redirect_uri={3}" +
                "&grant_type=authorization_code",
                Request.QueryString["code"],
                    OAuthSettings.ClientID,
                    OAuthSettings.ClientSecret,
                    getGoogleCallbackUrl());

            using (var sw = new StreamWriter(webRequest.GetRequestStream()))
            {
                sw.Write(postData);
            }

            var responseJson = "";
            using (var response = webRequest.GetResponse())
            {
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    responseJson = sr.ReadToEnd();
                }
            }

            var accessToken = JsonConvert.DeserializeAnonymousType(responseJson, new { access_token = "" }).access_token;

            // 通过 AccessToken 拿到用户信息
            webRequest = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/plus/v1/people/me?key=" + OAuthSettings.ApiKey);
            webRequest.Method = "GET";
            webRequest.Headers.Add("Authorization", "Bearer " + accessToken);

            using (var response = webRequest.GetResponse())
            {
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    responseJson = sr.ReadToEnd();
                }
            }

            // 取得用户的 Profile 数据。
            // Deserialize this object: https://developers.google.com/+/api/latest/people#resource
            var profile = JsonConvert.DeserializeObject<GoogleUser>(responseJson);
            var debugString = JsonConvert.SerializeObject(profile);

            // TODO: Please store the profile into Database!

            // 写入登陆信息，并返回首页。
            Session["GooglePlusID"] = profile.Id;

            // TODO: Replace following URL with valid HomePage!
            return Redirect("http://blog.korepwx.com/");
        }

        public ActionResult Logout()
        {
            Session.Remove("GooglePlusID");
            // TODO: Replace following URL with valid HomePage!
            return Redirect("http://blog.korepwx.com/");
        }
    }
}
