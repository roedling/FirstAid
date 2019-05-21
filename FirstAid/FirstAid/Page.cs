using System;

//Page sind die einzelnen Seiten unseres Buches. In dieser wird der jeweilige Seiteninhalt gespeichert.
//C# Coding Standards and Naming Conventions: https://github.com/ktaranov/naming-convention/blob/master/C%23%20Coding%20Standards%20and%20Naming%20Conventions.md

namespace FirstAid
{ 

//Enum ist eine Reihe von Nummern, welche wir aber beliebig benennen können.
public enum PageTypeEnum { query, confirmation, end }

    public class Page
    {
        public string text { get; set; }
        public string helpText { get; set; }
        public PageTypeEnum pageType { get; set; }
        public int nextIfYes { get; set; }
        public int nextIfNo { get; set; }
        public int nextIfConfirm { get; set; }
    }
}
