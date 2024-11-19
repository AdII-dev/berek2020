using berek2020;
using System.Text;


List<Berek> BerekList = new List<Berek>();

using StreamReader sr = new("..\\..\\..\\src\\berek2020.txt", Encoding.UTF8);
sr.ReadLine();
while (!sr.EndOfStream)
{
    BerekList.Add(new(sr.ReadLine()));
}



Console.WriteLine($"3.\n{BerekList.Count}");

double totalSalary = BerekList.Sum(b => b.Salary);
double averageSalary = totalSalary / BerekList.Count;
double roundedAverageSalary = Math.Round(averageSalary / 1000, 1);
Console.WriteLine($"4.\nAz átlagbér: {roundedAverageSalary} ezer forint.");


Console.Write("5.\nKérem, adja meg a részleg nevét: ");
string sectionName = Console.ReadLine().Trim();


Console.WriteLine("6.");
var sectionWorkers = BerekList.Where(b => b.Section.Equals(sectionName, StringComparison.OrdinalIgnoreCase)).ToList();
if (sectionWorkers.Any())
{
    var highestSalaryWorker = sectionWorkers.OrderByDescending(b => b.Salary).First();
    Console.WriteLine($"A legnagyobb bérrel rendelkező dolgozó a {sectionName} részlegen:");
    Console.WriteLine($"Név: {highestSalaryWorker.Name}, Neme: {highestSalaryWorker.Gender}, Részleg: {highestSalaryWorker.Section}, Belépés: {highestSalaryWorker.Entry}, Bér: {highestSalaryWorker.Salary}");
}
else
{
    Console.WriteLine($"A megadott részleg nem létezik a cégnél!");
}


Console.WriteLine("7.\nRészlegek dolgozóinak száma:");
var sectionStats = BerekList.GroupBy(b => b.Section)
                            .Select(group => new { Section = group.Key, Count = group.Count() })
                            .OrderBy(group => group.Section);

foreach (var stat in sectionStats)
{
    Console.WriteLine($"{stat.Section}: {stat.Count} fő");
}
