
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ_Assignment_BoilerPlateCode.Repos;
using LINQ_Assignment_BoilerPlateCode.DTOs;
using LINQ_Assignment_BoilerPlateCode.Models;

namespace LINQ_Assignment_BoilerPlateCode
{
    class Program
    {
        static void Main(string[] args)
        {
            // =======================
            // SAMPLE DATA
            // =======================
            var employees = EmployeeRepo.SeedEmployees();
            var projects = ProjectRepo. SeedProjects();

            Console.WriteLine("LINQ Scenario Boilerplate Loaded");
        }

        // =====================================================
        // 🟢 SECTION 1 – HR ANALYTICS
        // =====================================================

        // TODO 1.1: Get employees earning more than 60,000
        static List<Employee> GetHighEarningEmployees(List<Employee> employees)
        {
             return employees.Where(e => e.Salary > 60000).ToList();
            // TODO: Write LINQ query here
            throw new NotImplementedException();
        }

        // TODO 1.2: Get list of employee names only
        static List<string> GetEmployeeNames(List<Employee> employees)
        {
            // TODO: Write LINQ query here
            return employees.Select(e => e.Name).ToList();
            throw new NotImplementedException();
        }

        // TODO 1.3: Check if any employee belongs to HR department
        static bool HasHREmployees(List<Employee> employees)
        {
            // TODO: Write LINQ query here
            return employees.Any(e => e.Department == "HR");
            throw new NotImplementedException();
        }

        // =====================================================
        // 🟡 SECTION 2 – MANAGEMENT INSIGHTS
        // =====================================================

        // TODO 2.1: Get department-wise employee count
        static List<DepartmentCount> GetDepartmentWiseCount(List<Employee> employees)
        {
            // TODO: Write LINQ query here
            return employees.GroupBy(e => e.Department).Select(g => new DepartmentCount{Department = g.Key,Count = g.Count()}).ToList();
            throw new NotImplementedException();
        }

        // TODO 2.2: Find the highest paid employee
        static Employee GetHighestPaidEmployee(List<Employee> employees)
        {
            // TODO: Write LINQ query here
             return employees
                   .OrderByDescending(e => e.Salary)
                   .FirstOrDefault();
            throw new NotImplementedException();
        }

        // TODO 2.3: Sort employees by Salary (DESC), then Name (ASC)
        static List<Employee> SortEmployeesBySalaryAndName(List<Employee> employees)
        {
            // TODO: Write LINQ query here
            return employees.OrderByDescending(e => e.Salary).ThenBy(e => e.Name).ToList();
            throw new NotImplementedException();
        }

        // =====================================================
        // 🔵 SECTION 3 – PROJECT & SKILL INTELLIGENCE
        // =====================================================

        // TODO 3.1: Join employees with projects
        static List<EmployeeProject> GetEmployeeProjectMappings(
            List<Employee> employees,
            List<Project> projects)
        {
            // TODO: Write LINQ query here
            return employees
                   .Join(projects,
                         e => e.Id,
                         p => p.EmployeeId,
                         (e, p) => new EmployeeProject
                         {
                             EmployeeName = e.Name,
                             ProjectName = p.ProjectName
                         })
                   .ToList();
            throw new NotImplementedException();
        }

        // TODO 3.2: Find employees who are NOT assigned to any project
        static List<Employee> GetUnassignedEmployees(
            List<Employee> employees,
            List<Project> projects)
        {
            // TODO: Write LINQ query here
            return employees
                   .Where(e => !projects.Any(p => p.EmployeeId == e.Id))
                   .ToList();
            throw new NotImplementedException();
        }

        // TODO 3.3: Get all unique skills across the organization
        static List<string> GetAllUniqueSkills(List<Employee> employees)
        {
            // TODO: Write LINQ query here
             return employees
                   .Where(e => e.Skills != null)
                   .SelectMany(e => e.Skills)
                   .Distinct()
                   .ToList();
            throw new NotImplementedException();
        }

        // =====================================================
        // 🔴 SECTION 4 – ADVANCED WORKFORCE ANALYTICS
        // =====================================================

        // TODO 4.1: Get top 3 highest-paid employees per department
        static List<DepartmentTopEmployees> GetTopEarnersByDepartment(
            List<Employee> employees)
        {
            // TODO: Write LINQ query here
            return employees
                   .GroupBy(e => e.Department)
                   .Select(g => new DepartmentTopEmployees
                   {
                       Department = g.Key,
                       TopEmployees = g
                           .OrderByDescending(e => e.Salary)
                           .Take(3)
                           .ToList()
                   })
                   .ToList();
            throw new NotImplementedException();
        }

        // TODO 4.2: Remove duplicate employees based on Id
        static List<Employee> RemoveDuplicateEmployees(List<Employee> employees)
        {
            // TODO: Write LINQ query here\
             return employees
                   .GroupBy(e => e.Id)
                   .Select(g => g.First())
                   .ToList();
            throw new NotImplementedException();
        }

        // TODO 4.3: Implement pagination
        static List<Employee> GetEmployeesByPage(
            List<Employee> employees,
            int pageNumber,
            int pageSize = 5)
        {
            // TODO: Write LINQ query here
                return employees.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            throw new NotImplementedException();
        }


    }
}
