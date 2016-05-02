using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ShopList.Models
{
    public class Settings
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool Week { get; set; }
        public bool Month { get; set; }
        public Nullable<DateTime> From { get; set; }
        public Nullable<DateTime> To { get; set; }
        public Double Limit { get; set; }
        public int User_id { get; set; }
    }
}