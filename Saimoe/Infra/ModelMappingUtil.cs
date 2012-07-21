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
        }
    }
}