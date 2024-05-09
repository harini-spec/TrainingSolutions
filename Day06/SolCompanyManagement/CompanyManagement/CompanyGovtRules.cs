using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement
{
    public class CompanyGovtRules
    {
        public void CalculateBenefits(IGovtRules govtRules, double BasicSalary, int serviceCompleted)
        {
            govtRules.EmployeePF(BasicSalary);
            govtRules.LeaveDetails();
            govtRules.CalculateGratuityAmount(serviceCompleted, BasicSalary);
        }
    }
}
