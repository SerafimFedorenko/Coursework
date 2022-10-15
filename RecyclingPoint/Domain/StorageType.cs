using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclingPoint.Domain
{
    public class StorageType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Temperatue { get; set; }
        public int Humidity { get; set; }
        public string Requirements { get; set; }
        public string Equipments { get; set; }
    }
}
