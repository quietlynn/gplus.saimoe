﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM 关系源元数据

[assembly: EdmRelationshipAttribute("Saimoe.Models", "ContestantProfile", "Contestant", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Saimoe.Models.Contestant), "Profile", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Saimoe.Models.Profile))]

#endregion

namespace Saimoe.Models
{
    #region 上下文
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    public partial class SaimoeContext : ObjectContext
    {
        #region 构造函数
    
        /// <summary>
        /// 请使用应用程序配置文件的“SaimoeContext”部分中的连接字符串初始化新 SaimoeContext 对象。
        /// </summary>
        public SaimoeContext() : base("name=SaimoeContext", "SaimoeContext")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// 初始化新的 SaimoeContext 对象。
        /// </summary>
        public SaimoeContext(string connectionString) : base(connectionString, "SaimoeContext")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// 初始化新的 SaimoeContext 对象。
        /// </summary>
        public SaimoeContext(EntityConnection connection) : base(connection, "SaimoeContext")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region 分部方法
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet 属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        public ObjectSet<Contestant> Contestants
        {
            get
            {
                if ((_Contestants == null))
                {
                    _Contestants = base.CreateObjectSet<Contestant>("Contestants");
                }
                return _Contestants;
            }
        }
        private ObjectSet<Contestant> _Contestants;
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        public ObjectSet<Profile> Profiles
        {
            get
            {
                if ((_Profiles == null))
                {
                    _Profiles = base.CreateObjectSet<Profile>("Profiles");
                }
                return _Profiles;
            }
        }
        private ObjectSet<Profile> _Profiles;

        #endregion
        #region AddTo 方法
    
        /// <summary>
        /// 用于向 Contestants EntitySet 添加新对象的方法，已弃用。请考虑改用关联的 ObjectSet&lt;T&gt; 属性的 .Add 方法。
        /// </summary>
        public void AddToContestants(Contestant contestant)
        {
            base.AddObject("Contestants", contestant);
        }
    
        /// <summary>
        /// 用于向 Profiles EntitySet 添加新对象的方法，已弃用。请考虑改用关联的 ObjectSet&lt;T&gt; 属性的 .Add 方法。
        /// </summary>
        public void AddToProfiles(Profile profile)
        {
            base.AddObject("Profiles", profile);
        }

        #endregion
    }
    

    #endregion
    
    #region 实体
    
    /// <summary>
    /// test
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Saimoe.Models", Name="Contestant")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Contestant : EntityObject
    {
        #region 工厂方法
    
        /// <summary>
        /// 创建新的 Contestant 对象。
        /// </summary>
        /// <param name="id">Id 属性的初始值。</param>
        /// <param name="googlePlusId">GooglePlusId 属性的初始值。</param>
        /// <param name="createdDate">CreatedDate 属性的初始值。</param>
        /// <param name="lastLoginDate">LastLoginDate 属性的初始值。</param>
        public static Contestant CreateContestant(global::System.Int32 id, global::System.String googlePlusId, global::System.DateTime createdDate, global::System.DateTime lastLoginDate)
        {
            Contestant contestant = new Contestant();
            contestant.Id = id;
            contestant.GooglePlusId = googlePlusId;
            contestant.CreatedDate = createdDate;
            contestant.LastLoginDate = lastLoginDate;
            return contestant;
        }

        #endregion
        #region 基元属性
    
        /// <summary>
        /// test
        /// </summary>
        /// <LongDescription>
        /// testtest
        /// </LongDescription>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String GooglePlusId
        {
            get
            {
                return _GooglePlusId;
            }
            set
            {
                OnGooglePlusIdChanging(value);
                ReportPropertyChanging("GooglePlusId");
                _GooglePlusId = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("GooglePlusId");
                OnGooglePlusIdChanged();
            }
        }
        private global::System.String _GooglePlusId;
        partial void OnGooglePlusIdChanging(global::System.String value);
        partial void OnGooglePlusIdChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime CreatedDate
        {
            get
            {
                return _CreatedDate;
            }
            set
            {
                OnCreatedDateChanging(value);
                ReportPropertyChanging("CreatedDate");
                _CreatedDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CreatedDate");
                OnCreatedDateChanged();
            }
        }
        private global::System.DateTime _CreatedDate;
        partial void OnCreatedDateChanging(global::System.DateTime value);
        partial void OnCreatedDateChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime LastLoginDate
        {
            get
            {
                return _LastLoginDate;
            }
            set
            {
                OnLastLoginDateChanging(value);
                ReportPropertyChanging("LastLoginDate");
                _LastLoginDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LastLoginDate");
                OnLastLoginDateChanged();
            }
        }
        private global::System.DateTime _LastLoginDate;
        partial void OnLastLoginDateChanging(global::System.DateTime value);
        partial void OnLastLoginDateChanged();

        #endregion
    
        #region 导航属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Saimoe.Models", "ContestantProfile", "Profile")]
        public Profile Profile
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Profile>("Saimoe.Models.ContestantProfile", "Profile").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Profile>("Saimoe.Models.ContestantProfile", "Profile").Value = value;
            }
        }
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Profile> ProfileReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Profile>("Saimoe.Models.ContestantProfile", "Profile");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Profile>("Saimoe.Models.ContestantProfile", "Profile", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Saimoe.Models", Name="Profile")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Profile : EntityObject
    {
        #region 工厂方法
    
        /// <summary>
        /// 创建新的 Profile 对象。
        /// </summary>
        /// <param name="id">Id 属性的初始值。</param>
        /// <param name="interest">Interest 属性的初始值。</param>
        /// <param name="characteristic">Characteristic 属性的初始值。</param>
        /// <param name="actingCute">ActingCute 属性的初始值。</param>
        /// <param name="tagline">Tagline 属性的初始值。</param>
        /// <param name="joinedDate">JoinedDate 属性的初始值。</param>
        public static Profile CreateProfile(global::System.Int32 id, global::System.String interest, global::System.String characteristic, global::System.String actingCute, global::System.String tagline, global::System.DateTime joinedDate)
        {
            Profile profile = new Profile();
            profile.Id = id;
            profile.Interest = interest;
            profile.Characteristic = characteristic;
            profile.ActingCute = actingCute;
            profile.Tagline = tagline;
            profile.JoinedDate = joinedDate;
            return profile;
        }

        #endregion
        #region 基元属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Interest
        {
            get
            {
                return _Interest;
            }
            set
            {
                OnInterestChanging(value);
                ReportPropertyChanging("Interest");
                _Interest = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Interest");
                OnInterestChanged();
            }
        }
        private global::System.String _Interest;
        partial void OnInterestChanging(global::System.String value);
        partial void OnInterestChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Characteristic
        {
            get
            {
                return _Characteristic;
            }
            set
            {
                OnCharacteristicChanging(value);
                ReportPropertyChanging("Characteristic");
                _Characteristic = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Characteristic");
                OnCharacteristicChanged();
            }
        }
        private global::System.String _Characteristic;
        partial void OnCharacteristicChanging(global::System.String value);
        partial void OnCharacteristicChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String ActingCute
        {
            get
            {
                return _ActingCute;
            }
            set
            {
                OnActingCuteChanging(value);
                ReportPropertyChanging("ActingCute");
                _ActingCute = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("ActingCute");
                OnActingCuteChanged();
            }
        }
        private global::System.String _ActingCute;
        partial void OnActingCuteChanging(global::System.String value);
        partial void OnActingCuteChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String RegistrationPost
        {
            get
            {
                return _RegistrationPost;
            }
            set
            {
                OnRegistrationPostChanging(value);
                ReportPropertyChanging("RegistrationPost");
                _RegistrationPost = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("RegistrationPost");
                OnRegistrationPostChanged();
            }
        }
        private global::System.String _RegistrationPost;
        partial void OnRegistrationPostChanging(global::System.String value);
        partial void OnRegistrationPostChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Tagline
        {
            get
            {
                return _Tagline;
            }
            set
            {
                OnTaglineChanging(value);
                ReportPropertyChanging("Tagline");
                _Tagline = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Tagline");
                OnTaglineChanged();
            }
        }
        private global::System.String _Tagline;
        partial void OnTaglineChanging(global::System.String value);
        partial void OnTaglineChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime JoinedDate
        {
            get
            {
                return _JoinedDate;
            }
            set
            {
                OnJoinedDateChanging(value);
                ReportPropertyChanging("JoinedDate");
                _JoinedDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("JoinedDate");
                OnJoinedDateChanged();
            }
        }
        private global::System.DateTime _JoinedDate;
        partial void OnJoinedDateChanging(global::System.DateTime value);
        partial void OnJoinedDateChanged();

        #endregion
    
        #region 导航属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Saimoe.Models", "ContestantProfile", "Contestant")]
        public Contestant Contestant
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Contestant>("Saimoe.Models.ContestantProfile", "Contestant").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Contestant>("Saimoe.Models.ContestantProfile", "Contestant").Value = value;
            }
        }
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Contestant> ContestantReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Contestant>("Saimoe.Models.ContestantProfile", "Contestant");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Contestant>("Saimoe.Models.ContestantProfile", "Contestant", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}