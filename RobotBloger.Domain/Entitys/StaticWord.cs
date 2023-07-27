using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotBloger.Domain.Entitys
{
    public class StaticWord
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid BlogTypeId { get; set; }
        public virtual BlogType BlogType { get; set; }
     
    }
}
