using System.Security.Cryptography;

Dictionary<string, string> PhoneBook = new Dictionary<string, string>();

string path = @"F:\gu.sy.on.ok\SoftServe\C#.Net Fundamentals\hw7\phones.txt.txt";
string phonesPath = @"F:\gu.sy.on.ok\SoftServe\C#.Net Fundamentals\hw7\PhonesOnly.txt.txt";
string newPath = @"F:\gu.sy.on.ok\SoftServe\C#.Net Fundamentals\hw7\New.txt.txt";


try
{
    using(StreamReader sr = new StreamReader(path))
    {
        using (StreamWriter sw = new StreamWriter(phonesPath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] strings = line.Split(' ');
                PhoneBook.Add(strings[0], strings[1]);
                sw.WriteLine(strings[0]);
            }
        }
    }

    foreach (var entry in PhoneBook)
    {
        Console.WriteLine($"{entry.Key}: {entry.Value}");
    }

    Console.WriteLine("Enter name that you need: ");
    string name = Console.ReadLine();
    bool flag = false;
    foreach (var entry in PhoneBook)
    {
        if(name == entry.Value)
        {
            Console.WriteLine(($"{entry.Key}: {entry.Value}"));
            flag = true;
        }
    }
    if(!flag)
    {
        Console.WriteLine("This name does not exist :( ");
    }

    using (StreamWriter sw = new StreamWriter(newPath))
    {
        foreach (var entry in PhoneBook)
        {
            if (entry.Key.StartsWith('8'))
            {
                string newNumber = "+3" + entry.Key;
                sw.WriteLine($"{newNumber}: {entry.Value}");
            }
            else
            {
                sw.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }
    }
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}