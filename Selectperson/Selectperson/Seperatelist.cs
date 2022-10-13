namespace Selectperson;

public class Seperatelist
{
    public static bool isfull(Person[] liststaff, Stack<int> listMale, Stack<int> listFemale)
    {
        foreach (Person person in liststaff)
        {
            if (listMale.Contains(person.Code)|| listFemale.Contains(person.Code))
            {
                return false;
            }
        }

        return true;

    }

    public static List<int[]> GetRoomcode(Person[] listmember)
    {
        List<int[]> Roomlist = new List<int[]>();
        List<Person> Member = new List<Person>();
        foreach (Person person in listmember)
        {
            Member.Add(person);
        }
        Stack<int> Male = new Stack<int>();
        Stack<int> Female = new Stack<int>();
        bool Alllist = false;
        while (Member.Count>0)
        {
            
            Random no = new Random();
            int indexlist = no.Next(0, Member.Count);
            switch (Member[indexlist].Gender)
            {
                case "M":
                    Male.Push(Member[indexlist].Code);
                    Member.RemoveAt(indexlist);
                    break;
                case "F":
                    Female.Push(Member[indexlist].Code);
                    Member.RemoveAt(indexlist);
                    break;
            }

            // Alllist = isfull(listmember, Male, Female);
        }

        while (Male.Count>0)
        {
            List<int> Roomate = new List<int>();
            if (Male.Count==3)
            {
                for (int i = 0; i < 3; i++)
                {
                    Roomate.Add(Male.Pop());
                }
                Roomate.Sort();
                Roomlist.Add(Roomate.ToArray());
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    Roomate.Add(Male.Pop());
                }
                Roomate.Sort();
                Roomlist.Add(Roomate.ToArray());
            }
        }
        while (Female.Count>0)
        {
            List<int> Roomate = new List<int>();
            if (Male.Count==3)
            {
                for (int i = 0; i < 3; i++)
                {
                    Roomate.Add(Female.Pop());
                }
                Roomate.Sort();
                Roomlist.Add(Roomate.ToArray());
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    Roomate.Add(Female.Pop());
                }
                Roomate.Sort();
                Roomlist.Add(Roomate.ToArray());
            }
        }
        
        return Roomlist;
    }
}