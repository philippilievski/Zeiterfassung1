using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeiterfassung1.Model;

namespace Zeiterfassung1.Logic
{
    public class DataLogic
    {
        ZeiterfassungContext ZeiterfassungContext = new ZeiterfassungContext();
        public List<Project> GetProjects()
        {
            var projects = ZeiterfassungContext.Projects
                .Include(p => p.Activities)
                .ToList();

            return projects;
        }

        public List<Activity> GetActivities(Project project)
        {
            var activites = ZeiterfassungContext.Activities
                .Where(a => a.Project == project)
                .ToList();

            return activites;
        }

        public List<Activity> GetActivities()
        {
            var activities = ZeiterfassungContext.Activities
                .Include(a => a.Project)
                .ToList();

            return activities;
        }

        public int SumOfHours()
        {
            var hours = ZeiterfassungContext.EmployeeActivity.Sum(ea => ea.Hours);
            return hours;
        }

        public List<Project> FilterStartDate(DateTime start, DateTime end)
        {
            var startdate = start.Date;
            var enddate = end.Date;
            var dates = ZeiterfassungContext.Projects
                .Where(d => d.Startdate.Date >= startdate && d.Startdate.Date <= enddate).ToList();

            return dates;
        }

        public List<EmployeeActivity> GetEmployeeActivities()
        {
            var emplact = ZeiterfassungContext.EmployeeActivity
                .Include(ea => ea.Activity)
                .ThenInclude(ea => ea.Project)
                .Include(ea => ea.Employee)
                .ToList();

            return emplact;
        }

        public List<EmployeeActivity> GetEmployeeActivitiesBetweenDates(DateTime start, DateTime end)
        {
            var emplact = ZeiterfassungContext.EmployeeActivity
                .Include(ea => ea.Activity)
                .ThenInclude(ea => ea.Project)
                .Include(ea => ea.Employee)
                .Where(ea => ea.ActivityDate >= start && ea.ActivityDate <= end)
                .ToList();

            return emplact;
        }

        public Employee GetEmployeeFromUsername(string username)
        {
            var employee = ZeiterfassungContext.Employees
                .Where(e => e.Username == username)
                .First();

            return employee;
        }

        public void AddEmployeeActivity(EmployeeActivity employeeActivity)
        {
            ZeiterfassungContext.Add(employeeActivity);
            ZeiterfassungContext.SaveChanges();
        }

        public void UpdateEmployeeActivity(EmployeeActivity employeeActivity)
        {
            ZeiterfassungContext.Update(employeeActivity);
            ZeiterfassungContext.SaveChanges();
        }
    }
}
