using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppBox
{
    public class Script : IKeyID
    {
        [Key]
        public int ID { get; set; }

        [Required, StringLength(64)]
        public string Name { get; set; }

        [Required, StringLength(64)]
        public string FileName { get; set; }

        [Required, StringLength(512)]
        public string Path { get; set; }

        [Required, StringLength(16)]
        public string Project { get; set; }
        
        [Required, StringLength(16)]
        public string Version { get; set; }

        [Required, StringLength(10)]
        public string Size { get; set; }

        [Required,StringLength(32)]
        public string Language { get; set; }

        [Required, StringLength(32)]
        public string Creater { get; set; }

        [Required]
        public DateTime ModifyTime { get; set; }

        [Required]
        public bool Enabled { get; set; }
        public virtual ICollection<Flow> Flows { get; set; }
       
    }
}