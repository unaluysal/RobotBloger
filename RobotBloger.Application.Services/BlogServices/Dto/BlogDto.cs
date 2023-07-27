using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotBloger.Application.Services.BlogServices.Dto
{
    public class BlogDto
    {
        public Guid Id { get; set; }
        public string? Header { get; set; }
       
        public string? Description { get; set; }
        public string? Content { get; set; }

        public string? SmallPhoto { get; set; }
        public string? BigPhoto { get; set; }
        public string? Url { get; set; }
        public string? AltTag { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime RelaseTime { get; set; }
        public bool Status { get; set; }
       

        public Guid BlogTypeId { get; set; }
        public BlogTypeDto? BlogTypeDto { get; set; }


    }
}
