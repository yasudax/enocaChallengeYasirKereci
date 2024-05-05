using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Order
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        [JsonIgnore]
        public virtual Company? Company { get; set; }
        public int ProductId { get; set; }
        [JsonIgnore]
        public virtual Product? Product { get; set; }
        public string CustomerName { get; set; }
        [JsonIgnore]
        public DateTime OrderDate { get; set; }
    }
}
