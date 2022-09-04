using AngleSharp;
using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParseJumoreski
{
    public static class FillDB
    {
        public static async Task FillAsync() {
            var html = File.ReadAllText(@"C:\Users\user\Downloads\Telegram Desktop\ChatExport_2022-09-02\messages8.html");

            var config = Configuration.Default;
            using var context = BrowsingContext.New(config);
            using var doc = await context.OpenAsync(req => req.Content(html));
            List<string?> jumoreski = new();
            var classes = doc.QuerySelectorAll("div");

            foreach (var element in classes)
            {
                var t = element.Text().TrimEnd();
                if (!(t == "" || Regex.IsMatch(t, @"\d{2}:\d{2}", RegexOptions.IgnoreCase)
                    || Regex.IsMatch(t, @"\s*М\s*") || Regex.IsMatch(t, @"\d+\D*\d{4}")
                    || Regex.IsMatch(t, @"Sticker") || Regex.IsMatch(t, @"KB")
                    || Regex.IsMatch(t, @"Channel photo changed")
                    || Regex.IsMatch(t, @"Not included, change data exporting settings to download.")
                    || Regex.IsMatch(t, @"<\S*>")))
                    jumoreski.Add(t.TrimStart('\n'));
            }

            foreach (var t in jumoreski)
            {
                Console.WriteLine(t);
            }

            using ApplicationContext db = new();
            for (int i = 0; i < jumoreski.Count; i++)
            {
                Jumoreski t = new(jumoreski[i]);
                db.Jumoreskis.Add(t);
            }
            db.SaveChanges();
        }
    } 
}
