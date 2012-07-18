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
using System.Web.Security;
using System.Collections.Specialized;

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
            var scope = string.Join(" ", new string[] {
                "https://www.googleapis.com/auth/plus.me"
            });

            // FormsAuthentication.GetRedirectUrl accepts any non-null string for the first param,
            // and does not use the second param at all.
            var state = FormsAuthentication.GetRedirectUrl("", true);

            // A trick to get a query string builder. Hacky but elegant.
            var queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString["response_type"] = "code";
            queryString["approval_prompt"] = "auto";
            queryString["scope"] = scope;
            queryString["state"] = state;
            queryString["redirect_uri"] = getGoogleCallbackUrl();
            queryString["client_id"] = OAuthSettings.ClientID;

            // Note: queryString.ToString() is overridden internally to return application/x-www-form-urlencoded.
            var url = "https://accounts.google.com/o/oauth2/auth?" + queryString.ToString();
            return Redirect(url);
        }

        public ActionResult Callback(string code, string state)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create("https://accounts.google.com/o/oauth2/token");
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";

            // A trick to get a query string builder. Hacky but elegant.
            var queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString["code"] = code;
            queryString["client_id"] = OAuthSettings.ClientID;
            queryString["client_secret"] = OAuthSettings.ClientSecret;
            queryString["redirect_uri"] = getGoogleCallbackUrl();
            queryString["grant_type"] = "authorization_code";
            
            using (var sw = new StreamWriter(webRequest.GetRequestStream()))
            {
                // Note: queryString.ToString() is overridden internally to return application/x-www-form-urlencoded.
                sw.Write(queryString.ToString());
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

            var profile = JsonConvert.DeserializeObject<GoogleUser>(responseJson);
            var debugString = JsonConvert.SerializeObject(profile);

            FormsAuthentication.SetAuthCookie(profile.Id, createPersistentCookie: false);
            Session["GoogleUser"] = profile;

            return Redirect(state);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Remove("GoogleUser");
            
            return RedirectToAction("Index", "Home");
        }
    }
}
