using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppBox
{
    public class HostPool : IKeyID
    {
        [Key]
        public int ID { get; set; }

        [Required, StringLength(50)]
        public string HostName { get; set; }

        [Required, StringLength(20)]
        public string HostIP { get; set; }

        [Required, StringLength(30)]
        public string Resources { get; set; }

        [Required, StringLength(15)]
        public string PlatFormType { get; set; }

        [Required, StringLength(15)]
        public string Status { get; set; }

        [Required, StringLength(15)]
        public string AutoAppVersion { get; set; }

        [Required]
        public bool Enabled { get; set; }

        [StringLength(30)]
        public string Comments { get; set; }

        public virtual ICollection<Plan> Plans { get; set; }
    }
}