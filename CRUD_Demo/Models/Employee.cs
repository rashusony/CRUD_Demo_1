using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Demo.Models
{
    public class Employee
    {
        [Key]
        [DisplayName("Employee Id")]
        public int EmployeeId { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(250)")]
        [RegularExpression(@"^[a-zA-Z]+\s[a-zA-Z]*$",ErrorMessage ="Name must contain only alphabets")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(250)")]

        [Required]
        [DisplayName("Employee Code")]
        public string EmpCode { get; set; }
        [RegularExpression(@"([a-zA-Z]+\s[a-zA-Z]*\s*)*")]
        [DisplayName("Office Address")]
        public string OfficeLocation { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Position { get; set; }

      
    }

    
}
