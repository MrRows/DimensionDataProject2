using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace itdevfinalproject.Models
{
    public partial class WorkExperience
    {

        [Key]
        public int WorkExepienceId { get; set; }
        public int? YearsSinceLastPromotion { get; set; }
        public int? YearsWithCurrentManager { get; set; }
        public int? YearsInCurrentRole { get; set; }
        public int? YearsAtCompany { get; set; }
        public int EmployeeNumber { get; set; }
    }
}
