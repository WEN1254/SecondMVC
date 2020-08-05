using System;
using System.Collections.Generic;

namespace ScendMvc.Models
{
    public partial class Favorite
    {
        public int FavoriteId { get; set; }
        public string UserName { get; set; }
        public int? ProjectId { get; set; }
    }
}
