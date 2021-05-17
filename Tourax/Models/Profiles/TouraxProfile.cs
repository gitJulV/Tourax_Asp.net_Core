using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tourax.Data.Entities;

namespace Tourax.Models.Profiles
{
    public class TouraxProfile : Profile
    {
        public TouraxProfile()
        {
            CreateMap<BobineModel, BobineEntity>();

            CreateMap<BobineEntity, BobineModel>()
                .ForMember(b => b.LibelleMatiere, opt => opt.MapFrom(b => b.Matiere.LibelleMatiere));
        }
    }
}
