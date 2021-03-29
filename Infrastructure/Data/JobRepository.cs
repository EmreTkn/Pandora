
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;

namespace Infrastructure.Data
{
    public class JobRepository:IJobRepository
    {
        private readonly PandoraContext _context;

        public JobRepository(PandoraContext context)
        {
            _context = context;
        }

        public Job GetJobById(int id)
        {
            var job= _context.Jobs.FirstOrDefault(x => x.Id == id&x.Taken==false);
            return job;
        }

        public void ChangeToJobs()
        {
            var jobsToChange = _context.Jobs.ToList();
            foreach (var item in jobsToChange)
            {
                item.Taken = false;
            }

            _context.SaveChanges();
        }
    }
}
