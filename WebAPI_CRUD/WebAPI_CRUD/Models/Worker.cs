using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_CRUD.Models
{
    public class Worker
    {
        [Key]
        public int WorkerId { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(30)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string Mail { get; set; }
        [Required]
        [Column(TypeName = "datetime2(0)")]
        public DateTime EmploymentDate { get; set; }

        //navigation
        [Required]
        public int DepartmentId { get; set; }

    }
}
