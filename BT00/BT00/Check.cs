namespace BT00;

public class Check
{
    //kiem tra gia tri trung lap
    public static bool DuplicateCheckId(string? value, Item[] items)
    {
        var count = 0;
        var check = false;
        if (items != null)
            foreach (var element in items)
                if (element.Id == value)
                    count += 1;

        if (count > 0) check = true;

        return check;
    }

    //kiem tra gia tri loai hang trung lap dung cho them lable moi
    public static bool DuplicateCheckLabel(string? value, Store data)
    {
        var count = 0;
        var check = false;
        if (data.Label != null)
            foreach (var element in data.Label)
                if (element == value)
                    count += 1;

        if (count > 0) check = true;

        return check;
    }

    // tim ky tu
    public static bool FindValue(string? valueLookup, string? inText, bool firstLetterEachWord)
    {
        var content = false;
        string textcompare;
        valueLookup = valueLookup?.ToUpper();
        inText = inText?.ToUpper();
        switch (firstLetterEachWord)
        {
            case false:
                if (inText != null)
                    for (var i = 0; i < inText.Length - valueLookup.Length + 1; i++)
                    {
                        textcompare = null;
                        if (inText[i] == valueLookup[0])
                            for (var j = 0; j < valueLookup.Length; j++)
                                textcompare += inText[i + j];


                        if (textcompare == valueLookup)
                        {
                            content = true;
                            break;
                        }
                    }

                break;
            case true:
                var listword = inText.Split(" ");
                string textfirstletter = null;
                foreach (var word in listword) textfirstletter += word[0].ToString();
                for (var i = 0; i < textfirstletter.Length - valueLookup.Length + 1; i++)
                {
                    textcompare = null;
                    if (textfirstletter[i] == valueLookup[0])
                        for (var j = 0; j < valueLookup.Length; j++)
                            textcompare += textfirstletter[i + j];
                    content = textcompare == valueLookup;
                    if (content) break;
                }

                break;
        }

        return content;
    }
}