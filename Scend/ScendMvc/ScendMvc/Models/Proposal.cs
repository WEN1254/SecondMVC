using System;
using System.Collections.Generic;

namespace ScendMvc.Models
{
    public partial class Proposal
    {
        public int ProposalId { get; set; }
        public bool? IsFavorite { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ProjectCover { get; set; }
        public DateTime? TimeStart { get; set; }
        public DateTime? TimeEnd { get; set; }
        public string Category { get; set; }
        public int? Target { get; set; }
        public string Video { get; set; }
        public string Content { get; set; }
        public string Principal { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Identity { get; set; }
        public string ImgTeam { get; set; }
        public string DisplayName { get; set; }
        public string Resume { get; set; }
        public string FanPage { get; set; }
        public string Web { get; set; }
        public int? CurrentAmount { get; set; }

        public string Game_show { get; set; }

       
    }
}
