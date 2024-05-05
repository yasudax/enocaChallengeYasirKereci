using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Result
    {
        public long Id { get; set; }
        public bool IsSuccess { get; set; }
        public int ResponseCode { get; set; }
        public string ResponseDescription { get; set; }

        public Result()
        {
            IsSuccess = true; ResponseCode = 200; ResponseDescription = "Başarılı";
        }
    }
}
