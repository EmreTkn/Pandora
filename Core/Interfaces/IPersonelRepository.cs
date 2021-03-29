
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IPersonnelRepository
    {
        List<Employees> GetPersonnelList();
        bool AddJobs(Employees employees,Job job);
        int GetEmployeesJobs();
        void DeleteTable(EmployeesJob employees);
        void DeleteAll();
        List<EmployeesJob> GetEmployeesJobEntity(int employeeId);
        List<EmployeesJob> GetAllEmployeesJobs();
    }
}
