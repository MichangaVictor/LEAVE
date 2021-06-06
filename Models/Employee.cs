using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELMS.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmployeeCode { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

    }
}
