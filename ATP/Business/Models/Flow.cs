using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppBox
{
    public class Flow : IKeyID
    {
        [Key]
        public int ID { get; set; }

        [Required, StringLength(64)]
        public string Name { get; set; }

        [Required, StringLength(16)]
        public string Project { get; set; }

        [Required, StringLength(16)]
        public string Version { get; set; }

        [Required]
        public DateTime ModifyTime { get; set; }

        [Required]
        public bool Enabled { get; set; }
        public virtual ICollection<Script> Scripts { get; set; }
        public virtual ICollection<Plan> Plans { get; set; }
    }
}