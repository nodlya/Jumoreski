// See https://aka.ms/new-console-template for more information

namespace ParseJumoreski
{

    class Program
    {
        public async static Task Main()
        {
            using ApplicationContext db = new();
            {
                int t = db.Jumoreskis.Count();
                Random r = new();
                Console.WriteLine(db.Jumoreskis.Where(s => s.Id == t).Select(s => s.Text).Take(1));
            }
        }
    }
}