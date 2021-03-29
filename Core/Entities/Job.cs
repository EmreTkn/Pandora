
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
   public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public bool Taken { get; set; }
        public List<EmployeesJob> EmployeesJobs { get; set; }


    }
}
