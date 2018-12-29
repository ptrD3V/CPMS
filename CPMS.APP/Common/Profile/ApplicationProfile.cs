using System;
using System.Collections.Generic;
using System.Text;
using CPMS.APP.Models;
using CPMS.BL.Entities;
using CPMS.DAL.DTO;

namespace CPMS.BL.Common.Profile
{
    public class ApplicationProfile : AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Address, AddressDTO>()
                .ReverseMap();

            CreateMap<Address, AddressModel>()
                .ReverseMap();

            CreateMap<TaskItem, TaskDTO>()
                .ReverseMap();

            CreateMap<TaskItem, TaskModel>()
                .ReverseMap();

            CreateMap<Project, ProjectDTO>()
                .ReverseMap();

            CreateMap<Project, ProjectModel>()
                .ReverseMap();
        }
    }
}
