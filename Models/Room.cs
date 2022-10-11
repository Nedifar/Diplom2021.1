using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Room
    {
        [Key]
        public int Id_Room { get; set; }
        [StringLength(50, MinimumLength =3)]
        public string Room_Name { get; set; }
        public int? Size_Room { get; set; }
        public int? Price_Room { get; set; }
        public int? Floor_Room { get; set; }
        [MaxLength(500)]
        public string Destriction { get; set; }
        [MinLength(1)]
        public string Image { get; set; }
        public int? Id_Contract { get; set; }
        public Contract Contract { get; set; }
        [NotMapped]
        public string getImage
        {
            get
            {
                return $@"{System.AppDomain.CurrentDomain.BaseDirectory}Resources\{Image}";
            }
        }
        public string getPrice
        {
            get { return Price_Room + "Р в месяц"; }
        }
        public string GetArea
        {
            get { return "Площадь: " + Size_Room + "м2"; }
        }
        public string GetFloor
        {
            get { return "Этаж: " + Floor_Room; }
        }
        public string GetName
        {
            get { return "Наименование: " + Room_Name; }
        }
        public string GetSpec
        {
            get { return "Описание: " + Destriction; }
        }
        public string GetContract
        {
            get { return "Договор№ " + Id_Contract; }
        }
    }
}
