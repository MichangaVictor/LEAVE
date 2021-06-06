using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELMS.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentShortName { get; set; }
        public string DepartmentFullName { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfUpdation { get; set; }

    }
}
