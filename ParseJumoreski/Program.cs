// See https://aka.ms/new-console-template for more information

namespace ParseJumoreski
{

    class Program
    {
        static Random r = new();
        public async static Task Main()
        {
            using ApplicationContext db = new();
            {
                int t = db.Jumoreskis.Count();
                int rand = r.Next(1,t);
                Console.WriteLine(db.Jumoreskis.Where(s => s.Id == rand).Select(s => s.Text).Single().ToString());
            }
        }
    }
}