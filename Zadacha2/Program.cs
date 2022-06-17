using Zadacha2;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;

using (goslingreestrContext db = new goslingreestrContext())
{

    var datas = db.Data.ToList();   // получаем объекты из бд и выводим на консоль
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
        Console.WriteLine("Сохранить в json? y/n");
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
        using FileStream createStream = File.Create("E:\\\\\\VSProjects\\Wallet\\" + fileName);

        var options = new JsonSerializerOptions //опции json
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };
        
        string jsonString = JsonSerializer.Serialize(datas, options);
        File.WriteAllText(fileName, jsonString);

        Console.WriteLine("\n" + "Сохранено в "+fileName+"!");
    }
    
    void Second()
    {
        
        foreach (Datum d in datas)
        {
            Console.WriteLine($"Список операций {d.Name}:");
            foreach (History h in histories)
            {
                if(h.DataId == d.Id)
                {
                    double? Sum = histories.Sum(o => h.Summ);
                    
                    Console.WriteLine($"{h.Id}.{d.Name} - История операций: {Sum / 3}.");
                }
            }
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

        Console.WriteLine("\n" + "Сохранено в "+fileName+"!");
    }

}

