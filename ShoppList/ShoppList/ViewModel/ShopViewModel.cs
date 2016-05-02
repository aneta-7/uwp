using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppList.ViewModel
{
    class ShopViewModel
    {

        public ShopViewModel(Nullable<DateTime> date, String value, String description, String category, int user_id)
        {
            Date = date;
            Value = value;
            Descripion = description;
            Category = category;
            User_id = user_id;
        }

        public ShopViewModel()
        {
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public Nullable<DateTime> Date { get; set; }
        [Required]
        public String Value { get; set; }
        public String Descripion { get; set; }
        [Required]
        public String Category { get; set; }
        [Required]
        public int User_id { get; set; }

        public Nullable<DateTime> From { get; set; }
        public Nullable<DateTime>  To { get; set; }

    }
}
