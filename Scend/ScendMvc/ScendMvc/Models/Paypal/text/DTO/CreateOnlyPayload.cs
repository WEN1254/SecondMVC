using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScendMvc.Models.Paypal.text.DTO
{
    public class CreateOnlyPayload
    {
        public DateTime createOn { get; set; }
        public string createBy { get; set; }
        public string createOnStr { get; set; }
    }
}
