using System;
using System.Collections.Generic;

namespace ScendMvc.Models
{
    public partial class FeedBack
    {
        public decimal? FeedbackAmount { get; set; }
        public string FeedbackSummary { get; set; }
        public string FeedbackCover { get; set; }
        public string FeedbackType { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public string FeedbackLimit { get; set; }
        public int FeedbackId { get; set; }
        public int? ProposalId { get; set; }
    }
}
