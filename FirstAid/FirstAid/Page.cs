using System;

//Page sind die einzelnen Seiten unseres Buches. In dieser wird der jeweilige Seiteninhalt gespeichert.
//C# Coding Standards and Naming Conventions: https://github.com/ktaranov/naming-convention/blob/master/C%23%20Coding%20Standards%20and%20Naming%20Conventions.md

namespace FirstAid
{ 

//Enum ist eine Reihe von Nummern, welche wir aber beliebig benennen können.
public enum PageType { Query, Confirmation, End }

    public class Page
    {
        public string Text { get; set; }
        public string HelpText { get; set; }
        public PageType PageType { get; set; }
        public int NextIfYes { get; set; }
        public int NextIfNo { get; set; }
        public int NextIfConfirm { get; set; }
    }
}


