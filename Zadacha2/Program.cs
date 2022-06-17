using Zadacha2;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;

using (goslingreestrContext db = new goslingreestrContext())
{

    var datas = db.Data.ToList();   // получаем объекты из бд и выводим на консоль
    Console.WriteLine("Список объектов:");
    foreach (Datum d in datas)
    {
        Console.WriteLine($"{d.Id}.{d.Name} - Номер счета: {d.AccNum} - Код операции: {d.SoderzhOper} - Сумма: {d.Summa}.");
    }
    Console.WriteLine("Сохранить в json? y/n");

   if (Console.ReadKey().Key == ConsoleKey.Y)     //сохраняем в json
   {

        string fileName = "data.json";
        using FileStream createStream = File.Create("E:\\\\\\VSProjects\\Wallet\\" + fileName);

        var options = new JsonSerializerOptions //опции json
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true,
        
        };

        string jsonString = JsonSerializer.Serialize(datas, options);
        File.WriteAllText(fileName, jsonString);

        Console.WriteLine("\n" + "Сохранено!");
    }
    else
    {
        Console.ReadKey();
    }

}
