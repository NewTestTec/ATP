using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppBox
{
    public class Report : IKeyID
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int Year { get; set; }
        
        [Required]
        public int Month { get; set; }

        //[Required]
        //public int Day { get; set; }

        //[Required,StringLength(500)]
        //public string Path { get; set; }
        [Required]
        public byte[] Image { get; set; }

        [Required,StringLength(500)]
        public string FileName { get; set; }
    }
}