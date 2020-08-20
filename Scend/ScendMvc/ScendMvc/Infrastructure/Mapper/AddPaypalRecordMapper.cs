using AutoMapper;
using ScendMvc.Models.Paypal;
using ScendMvc.Models.Paypal.text.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScendMvc.Infrastructure.Mapper
{
    public class AddPaypalRecordMapper : MapperBase
    {
        private static readonly IMapper paypalRecordMapper;

        static AddPaypalRecordMapper()
        {
            paypalRecordMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PaypalRecordPayload, PaypalRecord>();
            }).CreateMapper();
        }

        public PaypalRecord AddPaypalRecord(PaypalRecordPayload paypalRecordPayload)
        {
            PaypalRecord paypalRecord =
                 Create<PaypalRecordPayload, PaypalRecord>(paypalRecordMapper, paypalRecordPayload);
            paypalRecord.companyId = paypalRecordPayload.companyId;
            paypalRecord.createBy = paypalRecordPayload.companyId.ToString();
            paypalRecord.createOn = DateTime.UtcNow;
            return paypalRecord;
        }
    }
}
