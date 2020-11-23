using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace itdevfinalproject.Models
{
    public partial class Employee
    {
        [Key]
        public int EmployeeNumber { get; set; }
        public int? Age { get; set; }
        public string Over18 { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public int? DistanceFromHome { get; set; }
        public int? Education { get; set; }
        public string EducationField { get; set; }
        public int? PerformanceRating { get; set; }
        public int? TotalWorkingYears { get; set; }
    }
}
