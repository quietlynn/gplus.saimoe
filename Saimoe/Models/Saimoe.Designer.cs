﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("Saimoe.Models", "ContestantProfile", "Contestant", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Saimoe.Models.Contestant), "Profile", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Saimoe.Models.Profile))]
[assembly: EdmRelationshipAttribute("Saimoe.Models", "ContestantVoting", "Contestant", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Saimoe.Models.Contestant), "Voting", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Saimoe.Models.Voting))]
[assembly: EdmRelationshipAttribute("Saimoe.Models", "ProfileUserCache", "Profile", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Saimoe.Models.Profile), "UserCache", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Saimoe.Models.UserCache))]

#endregion

namespace Saimoe.Models
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class SaimoeContext : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new SaimoeContext object using the connection string found in the 'SaimoeContext' section of the application configuration file.
        /// </summary>
        public SaimoeContext() : base("name=SaimoeContext", "SaimoeContext")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new SaimoeContext object.
        /// </summary>
        public SaimoeContext(string connectionString) : base(connectionString, "SaimoeContext")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new SaimoeContext object.
        /// </summary>
        public SaimoeContext(EntityConnection connection) : base(connection, "SaimoeContext")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
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
        /// No Metadata Documentation available.
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
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Administrator> Administrators
        {
            get
            {
                if ((_Administrators == null))
                {
                    _Administrators = base.CreateObjectSet<Administrator>("Administrators");
                }
                return _Administrators;
            }
        }
        private ObjectSet<Administrator> _Administrators;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Voting> Votings
        {
            get
            {
                if ((_Votings == null))
                {
                    _Votings = base.CreateObjectSet<Voting>("Votings");
                }
                return _Votings;
            }
        }
        private ObjectSet<Voting> _Votings;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<UserCache> UserCaches
        {
            get
            {
                if ((_UserCaches == null))
                {
                    _UserCaches = base.CreateObjectSet<UserCache>("UserCaches");
                }
                return _UserCaches;
            }
        }
        private ObjectSet<UserCache> _UserCaches;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Contestants EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToContestants(Contestant contestant)
        {
            base.AddObject("Contestants", contestant);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Profiles EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToProfiles(Profile profile)
        {
            base.AddObject("Profiles", profile);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Administrators EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToAdministrators(Administrator administrator)
        {
            base.AddObject("Administrators", administrator);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Votings EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToVotings(Voting voting)
        {
            base.AddObject("Votings", voting);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the UserCaches EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToUserCaches(UserCache userCache)
        {
            base.AddObject("UserCaches", userCache);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Saimoe.Models", Name="Administrator")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Administrator : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Administrator object.
        /// </summary>
        /// <param name="googlePlusId">Initial value of the GooglePlusId property.</param>
        public static Administrator CreateAdministrator(global::System.String googlePlusId)
        {
            Administrator administrator = new Administrator();
            administrator.GooglePlusId = googlePlusId;
            return administrator;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String GooglePlusId
        {
            get
            {
                return _GooglePlusId;
            }
            set
            {
                if (_GooglePlusId != value)
                {
                    OnGooglePlusIdChanging(value);
                    ReportPropertyChanging("GooglePlusId");
                    _GooglePlusId = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("GooglePlusId");
                    OnGooglePlusIdChanged();
                }
            }
        }
        private global::System.String _GooglePlusId;
        partial void OnGooglePlusIdChanging(global::System.String value);
        partial void OnGooglePlusIdChanged();

        #endregion

    
    }
    
    /// <summary>
    /// test
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Saimoe.Models", Name="Contestant")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Contestant : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Contestant object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="googlePlusId">Initial value of the GooglePlusId property.</param>
        /// <param name="createdDate">Initial value of the CreatedDate property.</param>
        /// <param name="lastLoginDate">Initial value of the LastLoginDate property.</param>
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

        #region Primitive Properties
    
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
        /// No Metadata Documentation available.
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
        /// No Metadata Documentation available.
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
        /// No Metadata Documentation available.
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

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
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
        /// No Metadata Documentation available.
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
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Saimoe.Models", "ContestantVoting", "Voting")]
        public EntityCollection<Voting> Votings
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Voting>("Saimoe.Models.ContestantVoting", "Voting");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Voting>("Saimoe.Models.ContestantVoting", "Voting", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Saimoe.Models", Name="Profile")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Profile : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Profile object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="interest">Initial value of the Interest property.</param>
        /// <param name="characteristic">Initial value of the Characteristic property.</param>
        /// <param name="actingCute">Initial value of the ActingCute property.</param>
        /// <param name="tagline">Initial value of the Tagline property.</param>
        /// <param name="joinedDate">Initial value of the JoinedDate property.</param>
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

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
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
        /// No Metadata Documentation available.
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
        /// No Metadata Documentation available.
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
        /// No Metadata Documentation available.
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
        /// No Metadata Documentation available.
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
        /// No Metadata Documentation available.
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
        /// No Metadata Documentation available.
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

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
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
        /// No Metadata Documentation available.
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
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Saimoe.Models", "ProfileUserCache", "UserCache")]
        public UserCache UserCaches
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserCache>("Saimoe.Models.ProfileUserCache", "UserCache").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserCache>("Saimoe.Models.ProfileUserCache", "UserCache").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<UserCache> UserCachesReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserCache>("Saimoe.Models.ProfileUserCache", "UserCache");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<UserCache>("Saimoe.Models.ProfileUserCache", "UserCache", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Saimoe.Models", Name="UserCache")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class UserCache : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new UserCache object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        /// <param name="photo">Initial value of the Photo property.</param>
        public static UserCache CreateUserCache(global::System.Int32 id, global::System.String name, global::System.Byte[] photo)
        {
            UserCache userCache = new UserCache();
            userCache.Id = id;
            userCache.Name = name;
            userCache.Photo = photo;
            return userCache;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
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
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Byte[] Photo
        {
            get
            {
                return StructuralObject.GetValidValue(_Photo);
            }
            set
            {
                OnPhotoChanging(value);
                ReportPropertyChanging("Photo");
                _Photo = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Photo");
                OnPhotoChanged();
            }
        }
        private global::System.Byte[] _Photo;
        partial void OnPhotoChanging(global::System.Byte[] value);
        partial void OnPhotoChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Saimoe.Models", "ProfileUserCache", "Profile")]
        public Profile Profile
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Profile>("Saimoe.Models.ProfileUserCache", "Profile").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Profile>("Saimoe.Models.ProfileUserCache", "Profile").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Profile> ProfileReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Profile>("Saimoe.Models.ProfileUserCache", "Profile");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Profile>("Saimoe.Models.ProfileUserCache", "Profile", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Saimoe.Models", Name="Voting")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Voting : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Voting object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        /// <param name="createdDate">Initial value of the CreatedDate property.</param>
        /// <param name="deadline">Initial value of the Deadline property.</param>
        /// <param name="description">Initial value of the Description property.</param>
        /// <param name="status">Initial value of the Status property.</param>
        public static Voting CreateVoting(global::System.Int32 id, global::System.String name, global::System.DateTime createdDate, global::System.DateTime deadline, global::System.String description, global::System.Byte status)
        {
            Voting voting = new Voting();
            voting.Id = id;
            voting.Name = name;
            voting.CreatedDate = createdDate;
            voting.Deadline = deadline;
            voting.Description = description;
            voting.Status = status;
            return voting;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
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
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
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
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime Deadline
        {
            get
            {
                return _Deadline;
            }
            set
            {
                OnDeadlineChanging(value);
                ReportPropertyChanging("Deadline");
                _Deadline = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Deadline");
                OnDeadlineChanged();
            }
        }
        private global::System.DateTime _Deadline;
        partial void OnDeadlineChanging(global::System.DateTime value);
        partial void OnDeadlineChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                OnDescriptionChanging(value);
                ReportPropertyChanging("Description");
                _Description = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Description");
                OnDescriptionChanged();
            }
        }
        private global::System.String _Description;
        partial void OnDescriptionChanging(global::System.String value);
        partial void OnDescriptionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Byte Status
        {
            get
            {
                return _Status;
            }
            set
            {
                OnStatusChanging(value);
                ReportPropertyChanging("Status");
                _Status = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Status");
                OnStatusChanged();
            }
        }
        private global::System.Byte _Status;
        partial void OnStatusChanging(global::System.Byte value);
        partial void OnStatusChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Saimoe.Models", "ContestantVoting", "Contestant")]
        public EntityCollection<Contestant> Contestants
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Contestant>("Saimoe.Models.ContestantVoting", "Contestant");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Contestant>("Saimoe.Models.ContestantVoting", "Contestant", value);
                }
            }
        }

        #endregion

    }

    #endregion

    
}
