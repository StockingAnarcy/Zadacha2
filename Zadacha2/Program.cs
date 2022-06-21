using Zadacha2;
using System.Text;
using System.Linq;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
 
using (goslingreestrContext db = new goslingreestrContext())
{
    var datas = db.Data.ToList();   // получаем объекты из бд 
    var histories = db.Histories.ToList();

    Console.WriteLine("Нажмите Enter чтобы начать");

    if (Console.ReadKey().Key == ConsoleKey.Enter)
    {
        Main();
    }

    void Main()
    {
        Console.WriteLine("Список объектов:");
        foreach (Datum d in datas)
        {
            Console.WriteLine($"{d.Id}.{d.Name} - Номер счета: {d.AccNum} - Код операции: {d.SoderzhOper} - Сумма: {d.Summa}.");
        }
        Console.WriteLine("Сохранить в json или открыть историю операций? y/n");
        //Console.ReadKey();
        if (Console.ReadKey().Key == ConsoleKey.Y)
        {
            SaveMain();
        }
        if (Console.ReadKey().Key == ConsoleKey.N)
        {
            Environment.Exit(0);
        }
        if (Console.ReadKey().Key == ConsoleKey.Q)
        {
            Console.Clear();
            Second();
        }
        else
        {
            //Console.ReadKey();
        }
    }


    void SaveMain()
    {
        string fileName = "data.json";
        using FileStream createStream = File.Create("E:\\\\\\VSProjects\\Zadacha2\\" + fileName);

        var options = new JsonSerializerOptions //опции json
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };

        string jsonString = JsonSerializer.Serialize(datas, options);
        File.WriteAllText(fileName, jsonString);

        Console.WriteLine("\n" + "Сохранено в " + fileName + "!");
    }

    void Second()
    {
        foreach (Datum d in datas)
        {
            Console.WriteLine($"Общая сумма зачислений {d.Name}:");
            double? total = 0;
            for (int i = 0; i < histories.Count; i++)
            {
                if (d.Id == histories[i].DataId)
                {
                   total = histories.Where(h => h.DataId == histories[i].DataId).Sum(h => h.Summ);
                }
            }        
            Console.WriteLine($"{total}.");
            
           
        }
        Console.WriteLine("Сохранить в json? y/n");
        if (Console.ReadKey().Key == ConsoleKey.Y)
        {
            SaveSecond();
        }
        if (Console.ReadKey().Key == ConsoleKey.N)
        {
            Environment.Exit(0);
        }
    }

    void SaveSecond()
    {
        string fileName = "dataSecond.json";
        using FileStream createStream = File.Create("E:\\\\\\VSProjects\\Wallet\\" + fileName);

        var options = new JsonSerializerOptions //опции json
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };

        string jsonString = JsonSerializer.Serialize(histories, options);
        File.WriteAllText(fileName, jsonString);

        Console.WriteLine("\n" + "Сохранено в " + fileName + "!");
    }

}

