using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class EmployeesJob
    {
       
        public int EmployeesId { get; set; }
        public Employees Employees { get; set; }
        public int JobsId { get; set; }
        public Job Jobs { get; set; }
    }
}
