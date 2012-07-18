/**
 * @file: Controllers/OAuthController.cs
 * @author Korepwx <public@korepwx.com>.
 * The OAuth 2.0 Controller for user verification via Google Service.\
 *
 * Note: The url entering points are:
 * - Login: /OAuth/Login
 * - Logout: /OAuth/Logout
 * - Callback: /OAuth/Callback
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

namespace Saimoe.Controllers
{
    /// <summary>
    /// The Google User object returned by Google+ API.
    /// </summary>
    public class GoogleUser
    {
        /// <summary>
        /// 关联的网页数据。
        /// </summary>
        public class UrlsData
        {
            /// <summary>
            /// 网址。
            /// </summary>
            public string Value { get; set; }
            /// <summary>
            /// 网址类型。一般为 null。只有 Profile 地址本身为"profile".
            /// </summary>
            public string Type { get; set; }
        }
        public class NameData
        {
            /// <summary>
            /// 姓。
            /// </summary>
            public string FamilyName { get; set; }
            /// <summary>
            /// 名。
            /// </summary>
            public string GivenName { get; set; }
        }
        public class ImageData
        {
            public string Url { get; set; }
        }
        public class OrganizationsData
        {
            /// <summary>
            /// （如果是学校）学校名称。
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// （如果是学校）专业名称。
            /// </summary>
            public string Title { get; set; }
            /// <summary>
            /// （如果是学校）"school"。
            /// </summary>
            public string Type { get; set; }
        }
        public class PlacesLivedData
        {
            /// <summary>
            /// 包含城市、国家的完整地名。
            /// </summary>
            public string Value { get; set; }
            public bool Primary { get; set; }
        }

        /// <summary>
        /// 性别。
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 关联的网页（如 Facebook）。
        /// </summary>
        public List<UrlsData> Urls { get; set; }
        /// <summary>
        /// Google+ Profile ID。
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 显示的名称。
        /// Google 会自动调整中亚文字的名称，如鄙人名字显示为“平芜泫”，而不是“泫·平芜”。
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 分隔了姓和名的名称。
        /// </summary>
        public NameData Name { get; set; }

        /// <summary>
        /// Google+ Profile 个人信息页的那一行签名。
        /// </summary>
        public string TagLine { get; set; }
        /// <summary>
        /// 完整的个人叙述。
        /// </summary>
        public string AboutMe { get; set; }
        /// <summary>
        /// Google+ Profile 的地址。
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Google+ 头像的地址（在线）。
        /// </summary>
        public ImageData Image { get; set; }

        /// <summary>
        /// 所属的组织列表。
        /// </summary>
        public List<OrganizationsData> Organizations { get; set; }
        /// <summary>
        /// 所居住过的地方。
        /// </summary>
        public List<PlacesLivedData> PlacesLived { get; set; }
    }

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
