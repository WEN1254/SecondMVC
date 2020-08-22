using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScendMvc.Models.Paypal
{
    public class PaypalParameterModdel
    {
        public string currency { get; set; }
        public string name { get; set; }
        public string mount { get; set; }
        public string price { get; set; }
        public string shipping_fee { get; set; }
        public string description { get; set; }
    }
}
