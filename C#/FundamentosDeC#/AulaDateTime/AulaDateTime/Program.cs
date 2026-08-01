using System.Globalization;

namespace AulaDateTime {
    internal class Program {
        static void Main(string[] args) {

            DateTime data = DateTime.Now;
            /*
            // Um construtor padrão de DateTime ano/mes/dia hora:minuto:segundo
            DateTime data1 = new DateTime(2024, 12, 31, 8, 29, 18);

            // Para mim a melhor forma de formatar uma data
            string data2 = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
            Console.WriteLine(data2);
            // Não gostei dessa formatação abaixo
            DateTime data3 = DateTime.Now;
            string formatada = String.Format("{0:yyyy/MM/dd HH:mm:ss zzz}", data3);
            Console.WriteLine(formatada);
            

            // Maneira correta de somar dia/meses/anos ao seu valor
            var data4 = DateTime.Now;
            Console.WriteLine(data4);
            Console.WriteLine(data4.AddDays(-5));
            Console.WriteLine(data4.AddMonths(1));
            Console.WriteLine(data4.AddYears(1));

            // Como coparar data
            if (data.Date == DateTime.Now.Date) {
                Console.WriteLine("É IGUAL " + data.Date );
            }
            

            // Aprendendo o CUlture Info
            var br = new CultureInfo("pt-BR");
            var pt = new CultureInfo("pt-pt");
            var en = new CultureInfo("en-US");
            var de = new CultureInfo("de-DE");
            Console.WriteLine(DateTime.Now.ToString("D", pt));
            

            // Mostrando como converter um GMT0 para qualquer horario do mundo
            DateTime data5 = DateTime.UtcNow;
            Console.WriteLine(data5); // horario utc 0
            Console.WriteLine(data5.ToLocalTime()); //convertendo pro meu GMT-3

            TimeZoneInfo timezoneAustralia = TimeZoneInfo.FindSystemTimeZoneById("Pacific/Auckland"); //criando um timezone diferente do da minha localidade

            Console.WriteLine(timezoneAustralia);

            var horaAustralia = TimeZoneInfo.ConvertTimeFromUtc(data5, timezoneAustralia);
            Console.WriteLine(horaAustralia);

            // Listando todos os UTCs do mundo
            var timezones = TimeZoneInfo.GetSystemTimeZones();
            foreach (var timezone in timezones) {
                Console.WriteLine(timezone.Id);
                Console.WriteLine(timezone);
                Console.WriteLine(TimeZoneInfo.ConvertTimeFromUtc(data5, timezone));
                Console.WriteLine("---------------------------");
            }
            

            // TimeSpan
            TimeSpan timespan = new TimeSpan();
            Console.WriteLine(timespan);

            TimeSpan timeSpanNanoSegundos = new TimeSpan(1);
            Console.WriteLine(timeSpanNanoSegundos);

            TimeSpan horaMinutoSegundo = new TimeSpan(5, 12, 8);
            Console.WriteLine(horaMinutoSegundo);

            TimeSpan anoDiaHoraMinutoSegundo = new TimeSpan(3, 5, 50, 10);
            Console.WriteLine(anoDiaHoraMinutoSegundo);

            TimeSpan anoDiaHoraMinutoSegundoMilissegundo = new TimeSpan(15, 12, 55, 8, 100);
            Console.WriteLine(anoDiaHoraMinutoSegundoMilissegundo);

            Console.WriteLine(horaMinutoSegundo - anoDiaHoraMinutoSegundo);
            Console.WriteLine(anoDiaHoraMinutoSegundo.Days);
            Console.WriteLine(anoDiaHoraMinutoSegundo.Add(new TimeSpan(12,0,0)));
            */

            // Alguns metodos muito usados com datetime
            Console.WriteLine(DateTime.DaysInMonth(2024, 2)); //pegar quantos dias tem em um mês especifico
            Console.WriteLine(IsWeekDay(DateTime.Now.DayOfWeek)); // com o método abaixo conseguimos ver se hoje é final de semana
            Console.WriteLine(DateTime.Now.IsDaylightSavingTime()); // Saber se estamos em horario de verão

            
        }

        static bool IsWeekDay(DayOfWeek today) {
            return today == DayOfWeek.Saturday || today == DayOfWeek.Sunday;
        }
    }
}

