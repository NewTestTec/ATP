using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppBox
{
    public class Project : IKeyID
    {
        [Key]
        public int ID { get; set; }

        [Required, StringLength(50)]
        public string DomainName { get; set; }

        [Required, StringLength(50)]
        public string ProjectName { get; set; }

        [Required, StringLength(25)]
        public string Owner { get; set; }

        [Required, StringLength(25)]
        public string DeptRegion { get; set; }
        
        [Required]
        public bool Enabled { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }

        [StringLength(50)]
        public string Comments { get; set; }

    }
}