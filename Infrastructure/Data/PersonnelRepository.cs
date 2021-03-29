using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class PersonnelRepository:IPersonnelRepository
    {
        private readonly PandoraContext _context;

        public PersonnelRepository(PandoraContext context)
        {
            _context = context;
        }
        public List<Employees> GetPersonnelList()
        {
            var employees = _context.Employeeses
                .Include(x=>x.EmployeesJobs).ToList();
            return employees;
        }

        public bool AddJobs(Employees employee,Job job)
        {
            var list= _context.EmployeesJobs
                .FirstOrDefault(x => x.EmployeesId == employee.Id && x.JobsId == job.Id);
            if (list==null)
            {
                job.Taken = true;

                var entity = new EmployeesJob()
                {
                    Employees = employee,
                    EmployeesId = employee.Id,
                    Jobs = job,
                    JobsId = job.Id
                };
                _context.EmployeesJobs.Add(entity);
                _context.SaveChanges();
                return true;
            }

            return false;

        }

        public int GetEmployeesJobs()
        {
            return _context.EmployeesJobs.Count();
        }

        public void DeleteTable(EmployeesJob employeesJob)
        {
            _context.EmployeesJobs.Remove(employeesJob);
            _context.SaveChanges();
        }

        public void DeleteAll()
        {
            var entity = _context.EmployeesJobs.ToList();
            _context.EmployeesJobs.RemoveRange(entity);
            _context.SaveChanges();
        }

        public List<EmployeesJob> GetEmployeesJobEntity(int employeeId)
        {
            var employee = _context.Employeeses
                .Include(x => x.EmployeesJobs)
                .FirstOrDefault(x => x.Id == employeeId);
            return employee.EmployeesJobs.ToList();
        }

        public List<EmployeesJob> GetAllEmployeesJobs()
        {
            return _context.EmployeesJobs
                .Include(x => x.Jobs)
                .Include(x => x.Employees).ToList();
        }
    }
}
