/**
 * @file: Infra/ModelMappingUtil.cs
 * @author: Tsinghua <mytsingh@gmail.com>.
 * @description:
 * The model mapping register utility
 * 
 */
using System;

using AutoMapper;
using Saimoe.Models;
using ContestantProfile = Saimoe.Models.EF.Profile;

namespace Saimoe.Infra
{
    public class ModelMappingUtil
    {
        /// <summary>
        /// Register model mappings
        /// </summary>
        public static void RegisterMapping()
        {
            var contestantMap = Mapper.CreateMap<ContestantRegistration, ContestantProfile>()
                .ForMember(profile => profile.JoinedDate, opt => opt.MapFrom(r => new DateTime(r.JoiningDateYear, r.JoiningDateMonth, 1)));

            var contestantRegistrationMap = Mapper.CreateMap<ContestantProfile, ContestantRegistration>()
                .ForMember(cr => cr.JoiningDateYear, opt => opt.MapFrom(r => r.JoinedDate.Year))
                .ForMember(cr => cr.JoiningDateMonth, opt => opt.MapFrom(r => r.JoinedDate.Month));
        }
    }
}