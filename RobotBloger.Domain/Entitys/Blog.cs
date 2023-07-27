using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotBloger.Domain.Entitys
{
    public class Blog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 1)]
        public Guid Id { get; set; }
        public string Header { get; set; }
       
        public string Content { get; set; }
        public string SmallPhoto { get; set; }
        public string BigPhoto { get; set; }

        public string AltTag { get; set; }

        public string Url { get; set; }
        public bool Status { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime CreateTime { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime RelaseTime { get; set; }
      

        public Guid BlogTypeId { get; set; }
        public BlogType BlogType { get; set; }


    }
}
