using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScendMvc.Models.Paypal
{
    public class ApiResponse
    {
        public string correlationId { get; set; }

        public ApiResponseMeta meta { get; set; }
    }
}
