using AutoMapper;
using DataAccessTier.DataAccessModel;
using ITCompanyCVSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITCompanyCVSender.Business
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Company, CompanyVM>();
            CreateMap<Company, CompaniesEmailSentVM>();
            CreateMap<CompanyVM, Company>();
            CreateMap<EmailsSent, EmaisSentVM>();
            CreateMap<EmaisSentVM, EmailsSent>();
            CreateMap<UserVM, User>()
           .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
            CreateMap<User, UserVM>()
          .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
            CreateMap<Role, RolesVM>();
            CreateMap<RolesVM, Role>();
            CreateMap<newsLetter, newsLetterVM>();
            CreateMap<newsLetterVM, newsLetter>();
        }
    }
}