using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Contract
    {
        [Key]
        public int Id_Contract { get; set; }
        public DateTime? Date_Start { get; set; }
        public DateTime? Date_Finish { get; set; }
        public int Id_Org { get; set; }
        public int Srokk { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();
        public Organization Organization { get; set; }
        DateTime _date { get; set; }
        public string DaystoEnd
        {
            get
            {
                if (Date_Finish != null && DateTime.Today < Date_Finish)
                {
                    _date = (DateTime)Date_Finish;
                    string a = _date.Subtract(DateTime.Today).ToString();
                    return "До конца договора " + a.Replace(".00:00:00", "") + " дней";
                }
                else
                    return "Договор не заключен";
            }
        }
        public string Srok
        {
            get
            {
                if (Date_Finish != null)
                {
                    _date = (DateTime)Date_Finish;
                    return "Договор закночится " + _date.ToShortDateString();
                }
                else
                    return "Договор не заключен";
            }
        }
        public string GetContract
        {
            get { return "Договор№ " + Id_Contract; }
        }
    }
}
