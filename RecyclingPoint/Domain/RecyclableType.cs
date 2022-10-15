using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclingPoint.Domain
{
    public class RecyclableType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string AcceptanceCondition { get; set; }
        public string StorageCondition { get; set; }
    }
}
