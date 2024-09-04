using AbstratFix.Entities;
using System.Globalization;
internal class Program
{
    private static void Main(string[] args)
    {
        List<TaxPayer> list = new List<TaxPayer>();

        Console.Write("Enter the number of tax payers: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"Tax payer #{i} data:");
            Console.Write("Individual or company (i/c)? ");
            char ch = char.Parse(Console.ReadLine());
            
            switch (ch)
            {
                case 'i':
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Anual income: ");
                    double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Health expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    list.Add(new Individual(name, anualIncome, healthExpenditures));
                break;

                case 'c':
                    Console.Write("Name: ");
                    string name1 = Console.ReadLine();
                    Console.Write("Anual income: ");
                    double anualIncome1 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Number of employees: ");
                    int numberOfEmployees = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    list.Add(new Company(name1, anualIncome1, numberOfEmployees));
                break;
            }           
        }

        Console.WriteLine("TAXES PAID:");
        double sum = 0.0;
        double tax = 0.0;
        foreach (TaxPayer taxP in list)
        {
            tax = taxP.Tax();
            Console.WriteLine(taxP);
            sum += tax;
        }
        Console.WriteLine("");
        Console.WriteLine("TOTAL TAXES: $" + sum.ToString("F2", CultureInfo.InvariantCulture));
    }
}