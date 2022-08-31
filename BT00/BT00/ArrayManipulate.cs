namespace BT00;

public class ArrayManipulate
{
    // Nhap gia tri vao
    public static Item InputItem(string ghichu, Store warehouse, bool auto)
    {
        var item = new Item();
        Console.WriteLine(ghichu);
        if (auto)
        {
            item = Sample.RandItem("Tạo hàng tự động", warehouse);
        }
        else
        {
            Print.ShortSeparate();
            Console.Write("B1. Mã lô hàng: ");
            item.Id = Sample.RanId(warehouse.ItemsList);
            Console.WriteLine(item.Id);
            Print.ShortSeparate();
            item.Type = SelectLabel("B2. Loại sản phẩm khả dụng:", warehouse);
            Print.ShortSeparate();
            Console.Write("B3. Tên sản phẩm: ");
            item.Name = Console.ReadLine()!.ToUpper();
            Print.ShortSeparate();
            Console.Write("B4. Số lượng: ");
            item.Qty = int.Parse(Console.ReadLine()!);
            Print.ShortSeparate();
            Console.WriteLine("B5. Ngày sản xuất: ");
            item.Mfg = StringModified.InputDate();
            item.Exp = StringModified.Inputexp(item.Mfg);
            Print.ShortSeparate();
            Console.Write("B6. Công ty: ");
            item.Com = Console.ReadLine()!;
        }

        Console.Write("Đã thêm lô hàng:");
        Print.PrintInfItem(item);

        return item;
    }

    //control chon lable
    public static string? SelectLabel(string note, Store data)
    {
        Console.WriteLine(note);
        var listlabel = data.Label;
        for (var i = 0; i < listlabel.Length; i++)
        {
            var text = $"{i + 1}. {listlabel[i]}";
            Console.WriteLine(text);
        }

        var inputtext = "loại hàng";
        var userchoise = StringModified.Inputnumber(inputtext, 1, listlabel.Length);
        Console.WriteLine($"Loại hàng được lựa chọn: {listlabel[userchoise - 1]}");
        return listlabel[userchoise - 1];
    }

    //nhap nhieu gia tri moi vao kho bang tay
    public static void InsertMultiItem(ref Store data, int noRow)
    {
        Console.WriteLine($"Nhập thêm {noRow} lô hàng vào kho");
        // bool auto = false; //stringmodifine.ChooseYesNo("Bạn muốn tạo lô hàng tự động?")
        for (var i = 0; i < noRow; i++)
        {
            //tang them 1 element cho array
            Print.MidSeparate();
            var newItemsList = new Item[data.ItemsList.Length + 1];
            for (var j = 0; j < data.ItemsList.Length; j++) newItemsList[j] = data.ItemsList[j];

            data.ItemsList = newItemsList;
            data.ItemsList[^1] = InputItem($"Nhập lô hàng thứ {i + 1}", data, false);
        }
    }

    //Them 1 element string vao array co san
    public static void AddNewString(ref string?[] array, string? element)
    {
        var newArray = new string?[array.Length + 1];
        for (var i = 0; i < array.Length; i++) newArray[i] = array[i];

        newArray[^1] = element;
        array = newArray;
    }

    //Thay đổi giá trị unique trong string
    public static void ChangeUniqueValue(string? valueNeedChange, string? newvalue, ref Store data)
    {
        bool duplicate;
        duplicate = Check.DuplicateCheckLabel(newvalue, data);
        if (newvalue == null)
        {
            Console.WriteLine("Giá trị không thay đổi");
        }
        else
        {
            while (duplicate)
            {
                Console.WriteLine("Giá trị đã tồn tại\nGiá trị mới: ");
                newvalue = Console.ReadLine()!.ToUpper();
                duplicate = Check.DuplicateCheckLabel(newvalue, data);
            }

            for (var i = 0; i < data.Label.Length; i++)
                if (data.Label[i] == valueNeedChange)
                {
                    data.Label[i] = newvalue;
                    break;
                }
        }

        Console.WriteLine($"Đã thay đổi loại hàng: {valueNeedChange} thành {newvalue}");
    }

    //Thay doi gia tri Items chi phuc vu cho function thay doi gia tri label trong edit label
    public static void ChangeLabelInEditLabel(ref Item[] packageds, string?[] idStrings, string? newLabel)
    {
        for (var i = 0; i < packageds.Length; ++i)
        {
            bool change;
            foreach (var idItemNeedChange in idStrings)
            {
                change = idItemNeedChange == packageds[i].Id;
                switch (change)
                {
                    case true:

                        Console.WriteLine("Lô hàng thay đổi loại hàng:");
                        Print.PrintInfItem(packageds[i]);
                        packageds[i].Type = newLabel;
                        break;
                }
            }
        }
    }

    //Xoa 1 element string trong array co san
    public static void RemoveString(ref string?[] array, string? target)
    {
        //tim do dai array sau khi da xoa du lieu
        int[] rListIndexremove;
        int count = 0, newindex = 0;
        foreach (var element in array)
            if (element == target)
                count += 1;
        //danh sach id cac element trung trong list
        rListIndexremove = new int[count];
        for (var i = 0; i < array.Length; i++)
            if (array[i] == target)
            {
                rListIndexremove[newindex] = i;
                newindex += 1;
            }

        var newarray = new string?[array.Length - rListIndexremove.Length];
        var indexnewarray = 0;
        for (var i = 0; i < array.Length; i++)
        {
            var countindexremove = 0;
            for (var j = 0; j < rListIndexremove.Length; j++)
                if (i == rListIndexremove[j])
                    countindexremove += 1;

            switch (countindexremove)
            {
                case 0:
                    newarray[indexnewarray] = array[i];
                    indexnewarray += 1;
                    break;
                default:
                    Console.WriteLine($"Giá trị {array[i]} đã bị xóa");
                    break;
            }
        }

        array = newarray;
    }


    //----------------------------
    //Item
    //xoa 1 item trong array list item
    public static void RemoveItem(ref Item[] listItems, string?[] listIdStrings)
    {
        //tim do dai array sau khi xoa item
        var countRemove = 0;
        foreach (var item in listItems)
        foreach (var idString in listIdStrings)
            if (idString == item.Id)
                countRemove += 1;
        var newItemsList = new Item[listItems.Length - countRemove];
        var newindex = 0;
        for (var i = 0; i < listItems.Length; i++)
        {
            var countid = 0;
            for (var j = 0; j < listIdStrings.Length; j++)
                if (listItems[i].Id == listIdStrings[j])
                {
                    countid += 1;
                    Console.Write("Đã xóa lô hàng: ");
                    Print.PrintInfItem(listItems[i]);
                }

            switch (countid)
            {
                case 0:
                    newItemsList[newindex] = listItems[i];
                    newindex += 1;
                    break;
            }
        }

        listItems = newItemsList;
    }

    //Them du lieu co san vao data dung search item
    public static void AddItemtoData(ref Store data, Item newItems)
    {
        var newitItemslist = new Item[data.ItemsList.Length + 1];
        for (var j = 0; j < data.ItemsList.Length; j++) newitItemslist[j] = data.ItemsList[j];

        data.ItemsList = newitItemslist;
        data.ItemsList[^1] = newItems;
    }
}