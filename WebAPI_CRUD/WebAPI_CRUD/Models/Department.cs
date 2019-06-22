using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_CRUD.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(100)")]
        [Remote(action: "VerifyName", controller: "Department")]
        public string DepartmentName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Location { get; set; }

        public List<Worker> Workers { get; set; }
    }
}
