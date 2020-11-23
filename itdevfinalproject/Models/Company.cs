using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace itdevfinalproject.Models
{
    public partial class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public int? EmployeeCount { get; set; }
        public int? WorkLifeBalance { get; set; }
        public int? TrainingTimesLastYear { get; set; }
        public int? RelationshipSatisfaction { get; set; }
        public int? EnvironmentSatisfaction { get; set; }
        public int? EmployeeNumber { get; set; }
    }
}
