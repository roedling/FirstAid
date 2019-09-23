using System;
using System.Collections.Generic; //https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic?view=netframework-4.8

//Books beinhaltet die gesamten Seiten unseres "Stammbuches".  

namespace FirstAid
{
    public enum AnswerType { Yes, No, Confirmation } //Enum für die Antwortmöglichkeiten

    public class Book
    {
        private List<Page> pages; //Liste von Seiten. Privat, da nur innerhalb der Klasse auf die Liste zugegriffen werden muss.
        private int currentPage = 0;


        public Book() //Konstruktor
        {
            pages = new List<Page>(); //dynamische Erzeugung der Liste.

            //Seite 0 (Eigenschutz)
            pages.Add(new Page() { pageType = PageType.Confirmation, text = "Achtung Eigenschutz!", helpText = "Achten Sie auf Gefahren aus der Umgebung (fahrende Autos, entflammbare und scharfe Gegenstände) sowie auf ein mögliches Infektionsrisiko (Körperflüssigkeiten)", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 1 });

            //Seite 1 (Abichern)
            pages.Add(new Page() { pageType = PageType.Confirmation, text = "Unfallstelle absichern!", helpText = "Gegebenenfalls Warndreieck aufstellen, sich selbst und das Opfer aus der Gefahrenzone bringen", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 2 });

            //Seite 2 (Bewusstsein)
            pages.Add(new Page() { pageType = PageType.Query, text = "Opfer bewusstlos?", helpText = "Person ansprechen und berühren. Wenn das Opfer nicht reagiert bestätigen Sie mit JA", nextIfYes = 3, nextIfNo = 4, nextIfConfirm = 0 });

            //Seite 3 (Atemwege)
            pages.Add(new Page() { pageType = PageType.Query, text = "Atemwege frei?", helpText = "Rachen- oder Mundbereich auf Fremdkörper überprüfen", nextIfYes = 5, nextIfNo = 12, nextIfConfirm = 0 });

            //Seite 4 (Hyperventilation)
            pages.Add(new Page() { pageType = PageType.Query, text = "Zu schnelle Atmung?", helpText = "Bei mehr als 12 Atemzügen pro Minute atmet das Opfer zu schnell", nextIfYes = 14, nextIfNo = 15, nextIfConfirm = 0 });

            //Seite 5 (Atmung)
            pages.Add(new Page() { pageType = PageType.Query, text = "Atmet das Opfer?", helpText = "Hebt sich der Brustkorb? Ist eine Atmung zu hören?", nextIfYes = 6, nextIfNo = 10, nextIfConfirm = 0 });

            //Seite 6 (Blutungen)
            pages.Add(new Page() { pageType = PageType.Confirmation, text = "Sichtbare Blutungen stoppen", helpText = "Druckverband: Sterile Kompresse auf die Wunde auflegen, mit Verband umwickeln, wenn möglich Gegenstand auf Wunde drücken und weiter mit Verband umwickeln. Wenn kein Verbandmaterial vorhanden nach sauberer Alternative suchen", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 7 });

            //Seite 7 (stabile Seitenlage)
            pages.Add(new Page() { pageType = PageType.Confirmation, text = "Stabile Seitenlage", helpText = "...", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 8 });

            //Seite 8 (Wohlbefinden)
            pages.Add(new Page() { pageType = PageType.Confirmation, text = "Für Wohlbefinden sorgen", helpText = "Opfer vor Auskühlen, Sonnenstich etc. schützen", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 9 });

            //Seite 9 (Warten(Notruf))
            pages.Add(new Page() { pageType = PageType.End, text = "Warten! Regelmäßige Pulskontrolle", helpText = "Mit Zeige- und Mittelfinger an der Innenseite des Handgelenks, durch Ausüben von Druck, den Puls ertasten", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 0 });

            //Seite 10 (Kopf überstrecken)
            pages.Add(new Page() { pageType = PageType.Confirmation, text = "Kopf des Opfers überstrecken", helpText = "Kopf gerade zur Wirbelsäule ausrichten, Kinn anheben und Mund öffnen", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 11 });

            //Seite 11 (Puls)
            pages.Add(new Page() { pageType = PageType.Query, text = "Puls tastbar?", helpText = "Mit Zeige- und Mittelfinger an der Innenseite des Handgelenks, durch Ausüben von Druck, den Puls ertasten", nextIfYes = 6, nextIfNo = 13, nextIfConfirm = 0 });

            //Seite 12 (Atemwege befreien)
            pages.Add(new Page() { pageType = PageType.Confirmation, text = "Atemwege befreien", helpText = "Fremdkörper entfernen", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 5 });

            //Seite 13 (Reanimation)
            pages.Add(new Page() { pageType = PageType.Confirmation, text = "Herz-Druck-Massage beginnen", helpText = "30 mal drücken und anschließend 2 mal beatmen. (Herzdruckmassage: Neben Patienten knien, Hände übereinander auf die Mitte des Brustkörpers legen, mit gestreckten Armen ca. 5cm tief drücken. Das Lied stayin’ alive gibt den Takt an. Beatmung: Nase es Opfers schließen, normal einatmen, mit den Lippen den Mund des Opfers abdecken und gleichmäßig ausatmen)", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 0 });

            //Seite 14 (beruhigen)
            pages.Add(new Page() { pageType = PageType.Confirmation, text = "Opfer beruhigen", helpText = "Mit Opfer reden. Falls Tüte vorhanden, Opfer in die Tüte atmen lassen", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 15 });

            //Seite 15 (Blutungen)
            pages.Add(new Page() { pageType = PageType.Confirmation, text = "Sichtbare Blutungen stoppen", helpText = "Druckverband: Sterile Kompresse auf die Wunde auflegen, mit Verband umwickeln, wenn möglich Gegenstand auf Wunde drücken und weiter mit Verband umwickeln. Wenn kein Verbandmaterial vorhanden nach sauberer Alternative suchen", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 16 });

            //Seite 16 (Kommunikation)
            pages.Add(new Page() { pageType = PageType.Confirmation, text = "Frag Opfer: Wie heißen Sie?", helpText = "Opfer befragen, um Reaktionszeit und logische Antwort zu überprüfen", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 17 });

            //Seite 17 (Reaktion)
            pages.Add(new Page() { pageType = PageType.Query, text = " Kurze Reaktionszeit & logische Antwort?", helpText = "Antwortet das Opfer logisch und nach angemessener Zeit?", nextIfYes = 18, nextIfNo = 8, nextIfConfirm = 0 });

            //Seite 18 (Kommunikation 2)
            pages.Add(new Page() { pageType = PageType.Confirmation, text = "Frag Opfer: Haben Sie Schmerzen?", helpText = "Opfer nach möglichen nicht sichtbaren Verletzungen fragen", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 19 });

            //Seite 19 (Schmerzen)
            pages.Add(new Page() { pageType = PageType.Confirmation, text = "Schmerzen lokalisieren & überprüfen", helpText = "Schmerzstelle finden und wenn möglich versorgen", nextIfYes = 0, nextIfNo = 0, nextIfConfirm = 8 });

        }


        public Page GetNextPage(AnswerType answer) //Methode welche die nächste richtige Seite zurück gibt
        {
            int nextPage;

            if (answer == AnswerType.Yes)
            {
                nextPage = pages[currentPage].nextIfYes;
            }

            else if (answer == AnswerType.No)
            {
                nextPage = pages[currentPage].nextIfNo;
            }

            else
            {
                nextPage = pages[currentPage].nextIfConfirm;
            }

            currentPage = nextPage; //weist die aktuelle Seite der Variablen currentPage zu 
            return (pages[nextPage]);
        }

        public Page GetCurrentPage() //Methode welche die aktuelle Seite zurück gibt
        {
            return pages[currentPage];
        }

        public void Reset()
        {
            currentPage = 0;
        }
    }
}
