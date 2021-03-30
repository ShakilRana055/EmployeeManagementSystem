using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.HelperAndConstant
{
    public static class AutoGenerate
    {
        public static string EmployeeId(string employeeId, string code)
        {
            string employeeNumber;
            int idLength = 6;
            if(employeeId == "0")
            {
                employeeNumber = "1";
            }
            else
            {
                List<string> separate = employeeId.Split("-").ToList();
                employeeNumber = (Convert.ToInt32(separate[1]) + 1).ToString();
            }
            string employee = code + '-';
            for (int i = 0; i < idLength - employeeNumber.Length; i++)
            {
                employee += '0';
            }
            return employee += employeeNumber;
        }
    }
}
