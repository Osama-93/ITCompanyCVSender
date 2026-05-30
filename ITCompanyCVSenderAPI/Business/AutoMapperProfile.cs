using AutoMapper;
using DataAccessTier.DataAccessModel;
using ITCompanyCVSenderAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;

namespace ITCompanyCVSenderAPI.Business
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Company, CompanyAPI>();
           // CreateMap<Company, CompaniesEmailSentVM>();
            CreateMap<CompanyAPI, Company>();
            CreateMap<EmailsSent, EmailsSentAPI>();
            CreateMap<EmailsSentAPI, EmailsSent>();
           // CreateMap<UserVM, User>()
          // .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
          // CreateMap<User, UserVM>()
          //    .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
          //  CreateMap<Role, RolesVM>();
          //  CreateMap<RolesVM, Role>();
           // CreateMap<newsLetter, newsLetterVM>();
          //  CreateMap<newsLetterVM, newsLetter>();
        }
    }
}