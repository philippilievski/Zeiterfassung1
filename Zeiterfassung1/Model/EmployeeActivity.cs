using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiterfassung1.Model
{
    public class EmployeeActivity
    {
        public int EmployeeActivityID { get; set; }
        public DateTime ActivityDate { get; set; }
        public int Hours { get; set; }
        public Activity Activity { get; set; }
        public Employee Employee { get; set; }
    }
}
