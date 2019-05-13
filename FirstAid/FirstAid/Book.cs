using System;
using System.Collections.Generic; //https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic?view=netframework-4.8

//Books beinhaltet die gesamten Seiten unseres "Stammbuches".  

namespace FirstAid
{
    public class Book
    {
        private List<Page> pages; //Liste von Seiten. Privat, da nur innerhalb der Klasse auf die Liste zugegriffen werden muss.


        public Book() //Konstruktor
        {
            pages = new List<Page>; //dynamische Erzeugung der Liste.

            //Seite 0 (Eigenschutz)
            pages.Add(new Page() { pageType = PageTypeEnum.confirmation, text = "Achtung Eigenschutz!", hilfetext = "scharfe Gegenstände", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 1 });

            //Seite 1 (Abichern)
            pages.Add(new Page() { pageType = PageTypeEnum.confirmation, text = "Unfallstelle absichern!", hilfetext = "Warndreieck", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 2 });

            //Seite 2 (Bewusstsein)
            pages.Add(new Page() { pageType = PageTypeEnum.query, text = "Opfer bewusstlos?", hilfetext = "Reagiert das Opfer auf Ansprache, Berührung etc. ?", nextIfYes = 3, nextIfNo = 4, nextIfConfirm = 0 });

            //Seite 3 (Atemwege)
            pages.Add(new Page() { pageType = PageTypeEnum.query, text = "Atemwege frei?", hilfetext = "Fremdkörper in Rachen- oder Mundbereich?", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 0 });

            //Seite 4 (Hyperventilation)
            pages.Add(new Page() { pageType = PageTypeEnum.query, text = "Zu schnelle Atmung?", hilfetext = "bei mehr als 12 Atemzüge pro Minute", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 0 });

        }


    }
}
