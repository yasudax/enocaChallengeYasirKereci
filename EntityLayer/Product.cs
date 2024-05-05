using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EntityLayer  
{
    public class Product
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }

        [JsonIgnore]
        public virtual Company? Company { get; set; }
        public string Name { get; set; }
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }
    }
}
