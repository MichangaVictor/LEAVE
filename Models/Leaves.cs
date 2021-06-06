using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELMS.Models
{
    public class Leaves
    {
        public int Id { get; set; }
        public string LeaveType { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string AdminRemark { get; set; }
        public string Status { get; set; }
        
    }
}
