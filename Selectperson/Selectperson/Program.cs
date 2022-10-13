// See https://aka.ms/new-console-template for more information

using Selectperson;


var list = Input.Importlist();

var Roomlist = Seperatelist.GetRoomcode(list);
Input.ExportRoomlist(Roomlist);

Input.PrintListStaff(list);
