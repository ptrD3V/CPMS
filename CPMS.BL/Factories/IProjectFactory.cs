﻿using System.Threading.Tasks;
using CPMS.BL.Entities;
using CPMS.DAL.DTO;

namespace CPMS.BL.Factories
{
    public interface IProjectFactory : IBaseFactory<ProjectDTO>
    {
        Task<Project> Create(ProjectDTO item);
    }
}
