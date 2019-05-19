using System;
using System.Collections.Generic; //https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic?view=netframework-4.8

//Books beinhaltet die gesamten Seiten unseres "Stammbuches".  

namespace FirstAid
{
    public enum AnswerTypeEnum { Yes, No, Confirmation } //nur in der Klasse oder auch Main?

    public class Book
    {
        private List<Page> pages; //Liste von Seiten. Privat, da nur innerhalb der Klasse auf die Liste zugegriffen werden muss.
        private int currentPage = 0;

        public Book() //Konstruktor
        {
            pages = new List<Page>(); //dynamische Erzeugung der Liste.

            //Seite 0 (Eigenschutz)
            pages.Add(new Page() { pageType = PageTypeEnum.confirmation, text = "Achtung Eigenschutz!", helpText = "scharfe Gegenstände", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 1 });

            //Seite 1 (Abichern)
            pages.Add(new Page() { pageType = PageTypeEnum.confirmation, text = "Unfallstelle absichern!", helpText = "Warndreieck", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 2 });

            //Seite 2 (Bewusstsein)
            pages.Add(new Page() { pageType = PageTypeEnum.query, text = "Opfer bewusstlos?", helpText = "Reagiert das Opfer auf Ansprache, Berührung etc. ?", nextIfYes = 3, nextIfNo = 4, nextIfConfirm = 0 });

            //Seite 3 (Atemwege)
            pages.Add(new Page() { pageType = PageTypeEnum.query, text = "Atemwege frei?", helpText = "Fremdkörper in Rachen- oder Mundbereich?", nextIfYes = 5, nextIfNo = 12, nextIfConfirm = 0 });

            //Seite 4 (Hyperventilation)
            pages.Add(new Page() { pageType = PageTypeEnum.query, text = "Zu schnelle Atmung?", helpText = "Bei mehr als 12 Atemzüge pro Minute", nextIfYes = 14, nextIfNo = 15, nextIfConfirm = 0 });

            //Seite 5 (Atmung)
            pages.Add(new Page() { pageType = PageTypeEnum.query, text = "Atmet das Opfer?", helpText = "Hebt sich der Brustkörper? Ist eine Atmung zu hören?", nextIfYes = 6, nextIfNo = 10, nextIfConfirm = 0 });

            //Seite 6 (Blutungen)
            pages.Add(new Page() { pageType = PageTypeEnum.confirmation, text = "Sichtbare Blutungen stoppen", helpText = "Kleine Blutungen durch Verband, große Blutungen durch einen Druckverband", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 7 });

            //Seite 7 (stabile Seitenlage)
            pages.Add(new Page() { pageType = PageTypeEnum.confirmation, text = "Stabile Seitenlage", helpText = "...", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 8 }); 

            //Seite 8 (Wohlbefinden)
            pages.Add(new Page() { pageType = PageTypeEnum.confirmation, text = "Für Wohlbefinden sorgen (Decke, Sonnenschutz)", helpText = "Dafür sorge leisten, dass das Opfer nicht friert oder sich einen Sonnenstich zuzieht", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 9 });

            //Seite 9 (Warten(Notruf))
            pages.Add(new Page() { pageType = PageTypeEnum.confirmation, text = "Warten! Regelmäßige Pulskontrolle", helpText = "Pulskontrolle beispielsweise am Handgelenk", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 0 });

            //Seite 10 (Kopf überstrecken)
            pages.Add(new Page() { pageType = PageTypeEnum.confirmation, text = "Kopf des Opfers überstrecken", helpText = "Kopf soweit überstrecken, sodass Zunge nicht die Atmenwege versperrt", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 11 });

            //Seite 11 (Puls)
            pages.Add(new Page() { pageType = PageTypeEnum.query, text = "Ist ein Puls vorhanden?", helpText = "Überprüfung des Puls am Handgelenk oder Hals", nextIfYes = 6, nextIfNo = 13, nextIfConfirm = 0 });

            //Seite 12 (Atemwege befreien)
            pages.Add(new Page() { pageType = PageTypeEnum.confirmation, text = "Atemwege befreien", helpText = "Atemwege von möglichen z.B verschluckten Teilen befreien", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 5 });

            //Seite 13 (Reanimation)
            pages.Add(new Page() { pageType = PageTypeEnum.confirmation, text = "Herz-Druck-Massage beginnen", helpText = "30 mal drücken, 2 mal beatmen", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 0 });

            //Seite 14 (beruhigen)
            pages.Add(new Page() { pageType = PageTypeEnum.confirmation, text = "Opfer beruhigen", helpText = "Falls Tüte vorhanden, Opfer in die Tüte atmen lassen", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 15 });

            //Seite 15 (Blutungen)
            pages.Add(new Page() { pageType = PageTypeEnum.confirmation, text = "Sichtbare Blutungen stoppen", helpText = "Kleine Blutungen durch Verband, große Blutungen durch einen Druckverband", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 16 });

            //Seite 16 (Kommunikation)
            pages.Add(new Page() { pageType = PageTypeEnum.confirmation, text = "Frag Opfer: Wie heißen Sie?", helpText = "Opfer durch Kommunikation beruhigen", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 17 });

            //Seite 17 (Reaktion)
            pages.Add(new Page() { pageType = PageTypeEnum.query, text = "Kurze Reaktionszeit & logische Antwort?", helpText = "Antwortet das Opfer nach kurzer Zeit und ist die Antwort logisch?", nextIfYes = 18, nextIfNo = 20, nextIfConfirm = 0 });

            //Seite 18 (Kommunikation 2)
            pages.Add(new Page() { pageType = PageTypeEnum.confirmation, text = "Frag Opfer: Haben Sie Schmerzen?", helpText = "Opfer nach möglichen (unsichtbaren) Verletzungen fragen", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 19 });

            //Seite 19 (Schmerzen)
            pages.Add(new Page() { pageType = PageTypeEnum.confirmation, text = "Schmerzen lokalisieren & überprüfen", helpText = "Schmerzstelle überprüfen und eventuell versorgen", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 8 });

        }


        public Page GetNextPage(AnswerTypeEnum answer)
        {
            int nextPage;

            if( answer == AnswerTypeEnum.Yes)
            {
                nextPage = pages[currentPage].nextIfYes;
            }

            else if( answer == AnswerTypeEnum.No)
            {
                nextPage = pages[currentPage].nextIfNo;
            }

            else
            {
                nextPage = pages[currentPage].nextIfConfirm;
            }

            currentPage = nextPage;
            return (pages[nextPage]);
        }




    }
}
