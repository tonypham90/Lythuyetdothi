namespace Selectperson;

public class Input
{
    public static Person[] Importlist()
    {
        var liststaff = new List<Person>();
        StreamReader file = new StreamReader("/Users/tonypham/Documents/GitHub/Lythuyetdothi/Selectperson/Selectperson/Data/NoRoomate.txt");
        var data =  file.ReadToEnd();
        var list = data.Split("\n");
        foreach (var line in list)
        {
            Person staff = new Person();
            var element = line.Split("\t");
            staff.Code = Convert.ToInt32(element[0]);
            staff.Gender = element[1].Trim();
            liststaff.Add(staff);
        }

        return liststaff.ToArray();
    }

    public static void PrintListStaff(Person[] listOfStaff)
    {
        foreach (Person person in listOfStaff)
        {
            string text = String.Empty;
            text = $"Code:{person.Code} - Gender:{person.Gender}";
            Console.WriteLine(text);
        }
    }

    public static void ExportRoomlist(List<int[]> Roomlist)
    {
        string text = String.Empty;
        foreach (int[] Roommate in Roomlist)
        {
            if (Roommate.Length==3)
            {
                text += $"\n{Roommate[0]}|{Roommate[1]}|{Roommate[2]}";
            }
            else
            {
                text += $"\n{Roommate[0]}|{Roommate[1]}";
            }
        }

        StreamWriter file = new StreamWriter("/Users/tonypham/Documents/GitHub/Lythuyetdothi/Selectperson/Selectperson/Data/Roommate.txt");
        file.Write(text);
        file.Close();
    }
}