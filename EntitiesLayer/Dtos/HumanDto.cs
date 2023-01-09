using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Dtos
{
    public class HumanDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Count { get; set; }
        public string StageOfLife { get; set; }
        public int AverageAge { get; set; }
        public bool IsSystemCheck { get; set;}
    }
}
