using System;

//Page sind die einzelnen Seiten unseres Buches. In dieser wird der jeweilige Seiteninhalt gespeichert.

namespace FirstAid
{ 

//Enum ist eine Reihe von Nummern, welche wir aber beliebig benennen können.
public enum PageTypeEnum { query, confirmation }

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
