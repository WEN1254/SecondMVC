using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScendMvc.Models.Paypal.text
{
    public class PaypalPayment
    {
        [JsonProperty(PropertyName = "captures")]
        public List<PaypalCapture> paypalCaptureList { get; set; }
    }
}
