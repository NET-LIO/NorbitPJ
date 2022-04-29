using System;
using System.Collections.Generic;
using System.Linq;

namespace Norbit.Crm.Hodeshenas.TaskSeven
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TestLINQ();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void TestLINQ()
        {
            var hackers = new List<Hacker>
            {
                new Hacker(
                        "Kevin Mitnick",
                         new DateTime(1963, 08, 06, 11, 30, 10, DateTimeKind.Utc),
                        "Attack on the American network, attack on the national security alert systems.",
                        10),
                new Hacker(
                        "Jonathan James",
                        new DateTime(1983, 12, 12, 11, 30, 10, DateTimeKind.Utc),
                        "\nHacking NASA networks at a young age.",
                        9),
                new Hacker(
                        "Guccifer 2.0(Marcel Lazare)",
                        new DateTime(1996, 09, 06, 11, 30, 10, DateTimeKind.Utc),
                        "Hacked into the network of the US Democratic National Committee",
                        2),
                new Hacker(
                        "ANONYMOUS",
                        new DateTime(2003, 06, 09, 00, 30, 10, DateTimeKind.Utc),
                        "Attacked many organizations and systems such as PayPal, Amazon, Westboro Baptist Church, Sony, Deep Web sites.",
                        1)
            };

            //Выбираем имена хакеров, рейтинг которых ниже 3.
            var hackersName = from Hacker x in hackers
                         where x.Popularity < 3
                         select x.Name;

            Hacker.Write(hackersName);

            //Выбираем имя, рейтинг и дату рождения.
            var groupingResult = hackers
                .Distinct()
                .GroupBy(x => x.Name)
                .Select(x => new 
                { 
                    Name = x.Key,
                    Achievements = x.Sum(a => a.Popularity),
                    Birthday = x.First().Birthday
                });

            Hacker.Write(groupingResult);

            //Выбираем имена хакеров и пропускаем 1 элемент.
            var sortingResult = hackers
                .Distinct()
                .OrderBy(x => x.Popularity)
                .Skip(1).Select(x => x.Name)
                .ToArray();

            Hacker.Write(sortingResult);

            //Выбираем последнего в списке.
            var highestPrice = hackers.OrderByDescending(x => x.Popularity).Last();

            Console.WriteLine($"{highestPrice} \n");

            ///Выбираем хакера, репутация которого равна 10.
            var place = from Hacker x in hackers
                        where x.Popularity == 10
                        select x.Name;

            if (place.Any())
            {
                //Записываем результат, для дальнейшего вывода.
                var result = hackers.Any(x => x.Popularity == 10)
                    ? $"На 10 месте по популярности находится {place.FirstOrDefault()}\n"
                    : "Нету информации про 10 место по популярности\n";
                Console.WriteLine(result);
            }
        }
    }
}
