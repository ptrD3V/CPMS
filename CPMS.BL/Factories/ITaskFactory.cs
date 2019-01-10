using CPMS.BL.Entities;
using CPMS.DAL.DTO;

namespace CPMS.BL.Factories
{
    public interface ITaskFactory : IBaseFactory<TaskDTO>
    {
        TaskItem Create(TaskDTO item);
    }
}
