using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Application = Microsoft.Office.Interop.Word.Application;

namespace Project
{
    public class DifferentsOddities
    {
        public static MainWindow MainWindow;

        public static bool admin = false;

        public static Models.Organization org = new Models.Organization();

        public static void Contract(Models.Room room, string fullInfo, string NameRP, int Srok, DateTime selecteddate )
        {
            Models.Contract contract = new Models.Contract() { Id_Org = org.Id_Org, Date_Finish = selecteddate.AddYears(Srok), Date_Start = selecteddate, Srokk = Srok };
            Models.context.AgetDB().Contracts.Add(contract);
            Models.context.AgetDB().SaveChanges();
            List<Models.Contract> contracts = Models.context.AgetDB().Contracts.ToList();
            contract = contracts[contracts.Count - 1];
            object path = $@"{System.AppDomain.CurrentDomain.BaseDirectory}Resources\contract.doc";
            object newPath = $@"{System.AppDomain.CurrentDomain.BaseDirectory}Contracts\contract №{contract.Id_Contract}.doc";
            Application app = new Application();
            app.Documents.Open(path);
            Object missing = Type.Missing;
            Find find = app.Selection.Find;
            findandreplace("[дата]", DateTime.Now.ToShortDateString());
            findandreplace("[РПимя]", NameRP);
            findandreplace("[площадь]", room.Size_Room.ToString());
            findandreplace("[адрес]", "Мало-Луговая, 3/1, Оренбург");
            findandreplace("[срок]", Srok.ToString());
            findandreplace("[начало срока]", selecteddate.ToShortDateString());
            findandreplace("[цена]", (room.Price_Room/room.Size_Room).ToString());
            findandreplace("[реквизиты]", fullInfo);
            findandreplace("[имя]", org.fullName);
            app.ActiveDocument.SaveAs(newPath);
            app.ActiveDocument.Close();
            app.Quit();
            void findandreplace(string text, string replacmenttext)
            {
                find.ClearFormatting();
                find.Replacement.ClearFormatting();
                find.Text = text;
                find.Replacement.Text = replacmenttext;
                object replaceAll = WdReplace.wdReplaceAll;
                find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref replaceAll, ref missing, ref missing, ref missing, ref missing);
            }
            room.Id_Contract= contract.Id_Contract;
            Models.context.AgetDB().SaveChanges();
            MessageBox.Show("Операция успешно совершена");
            DifferentsOddities.MainWindow.Back(new Forms.Сatalog());
        }

        public static void prodlit(int Srok, Models.Room property)
        {
            object path = $@"{System.AppDomain.CurrentDomain.BaseDirectory}Contracts\contract №{property.Id_Contract}.doc";
            Application app = new Application();
            app.Documents.Open(path);
            Object missing = Type.Missing;
            Find find = app.Selection.Find;
            find.ClearFormatting();
            find.Replacement.ClearFormatting();
            find.Text = $"{property.Contract.Srokk} года";
            find.Replacement.Text = $"{Srok + property.Contract.Srokk} года";
            object replaceAll = WdReplace.wdReplaceAll;
            find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing,
            ref replaceAll, ref missing, ref missing, ref missing, ref missing);
            app.ActiveDocument.Save();
            app.ActiveDocument.Close();
            app.Quit();
            Models.Contract contract = Models.context.AgetDB().Contracts.Where(p => p.Id_Contract == property.Id_Contract).FirstOrDefault();
            contract.Srokk += Srok;
            DateTime _date = (DateTime)contract.Date_Finish;
            contract.Date_Finish = _date.AddYears(Srok);
            Models.context.AgetDB().Entry(contract).State = System.Data.Entity.EntityState.Modified;
            Models.context.AgetDB().SaveChanges();
            MessageBox.Show("Операция успешно совершена");
        }
    }
}
