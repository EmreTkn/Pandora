using System.Collections.Generic;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IJobRepository
    {
        Job GetJobById(int id);
        void ChangeToJobs();
    }
}
