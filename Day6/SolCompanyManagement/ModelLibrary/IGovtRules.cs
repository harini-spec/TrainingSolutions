using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    internal interface IGovtRules
    {
        public double EmployeePF(double basicSalary);
        public string LeaveDetails();
        public double CalculateGratuityAmount(double serviceCompleted, double basicSalary);
    }
}
