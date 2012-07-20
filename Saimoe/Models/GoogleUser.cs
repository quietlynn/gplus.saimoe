using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saimoe.Models
{
    /// <summary>
    /// The Google User object returned by Google+ API, as defined by 
    /// https://developers.google.com/+/api/latest/people#resource
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
}