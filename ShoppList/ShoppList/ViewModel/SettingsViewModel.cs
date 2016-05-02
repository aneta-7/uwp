using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppList.ViewModel
{
    class SettingsViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool Week { get; set; }
        public bool Month { get; set; }
        public Double Limit { get; set; }
        public int User_id { get; set; }


        public Nullable<DateTime> From { get; set; }
        public Nullable<DateTime> To { get; set; }
        public void chooseDate(int user_id)
        {
            if (Week == true)
                To = DateTime.Today.AddDays(7);
            else if (Month == true)
                To = DateTime.Today.AddDays(30);
        }
    }
}
