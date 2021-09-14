using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiterfassung1.Model
{
    public class Activity
    {
        public int ActivityID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Project Project { get; set; }
        public List<EmployeeActivity> EmployeeActivities { get; set; }
    }
}
