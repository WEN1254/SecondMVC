using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScendMvc.Models.Paypal
{
    public class AddApiTransactionResponse : IApiResponse
    {
        public string correlationId { get; set; }

        public ApiResponseMeta meta { get; set; }

        public long apiTransactionId { get; set; }

        public string transactionNumber { get; set; }
    }
}
