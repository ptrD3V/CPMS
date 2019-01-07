using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CPMS.BL.Entities;
using CPMS.DAL.DTO;

namespace CPMS.BL.Factories
{
    public interface ITaskFactory : IBaseFactory<TaskDTO>
    {
        TaskItem Create(TaskDTO item);
    }
}
