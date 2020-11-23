using System;
using System.Collections.Generic;

namespace itdevfinalproject.Models
{
    public partial class Job
    {
        public int JobId { get; set; }
        public string BusinessTravel { get; set; }
        public int? JobLevel { get; set; }
        public int? JobInvolvement { get; set; }
        public int? EmployeeNumber { get; set; }
    }
}
