using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool ApprovalStatus { get; set; }
        public string OrderPermissionStartTime { get; set; }
        public string OrderPermissionEndTime { get; set; }

    }
}
