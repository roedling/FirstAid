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
            pages.Add(new Page() { PageType = PageType.Confirmation, Text = "Achtung Eigenschutz!", HelpText = '\n' + "Achten Sie auf Gefahren aus der Umgebung (fahrende Autos, entflammbare und scharfe Gegenstände) sowie auf ein mögliches Infektionsrisiko (Körperflüssigkeiten)", NextIfYes = 0, NextIfNo = 0, NextIfConfirm = 1 });

            //Seite 1 (Abichern)
            pages.Add(new Page() { PageType = PageType.Confirmation, Text = "Unfallstelle absichern!", HelpText = '\n' + "Gegebenenfalls Warndreieck aufstellen, sich selbst und das Opfer aus der Gefahrenzone bringen", NextIfYes = 0, NextIfNo = 0, NextIfConfirm = 2 });

            //Seite 2 (Bewusstsein)
            pages.Add(new Page() { PageType = PageType.Query, Text = "Opfer bewusstlos?", HelpText = '\n' + "Person ansprechen und berühren. Wenn das Opfer nicht reagiert bestätigen Sie mit JA", NextIfYes = 3, NextIfNo = 4, NextIfConfirm = 0 });

            //Seite 3 (Atemwege)
            pages.Add(new Page() { PageType = PageType.Query, Text = ("Atemwege" + '\n' + "frei?"), HelpText = '\n' + "Rachen- oder Mundbereich auf Fremdkörper überprüfen", NextIfYes = 5, NextIfNo = 12, NextIfConfirm = 0 });

            //Seite 4 (Hyperventilation)
            pages.Add(new Page() { PageType = PageType.Query, Text = "Zu schnelle Atmung?", HelpText = '\n' + "Bei mehr als 12 Atemzügen pro Minute atmet das Opfer zu schnell", NextIfYes = 14, NextIfNo = 15, NextIfConfirm = 0 });

            //Seite 5 (Atmung)
            pages.Add(new Page() { PageType = PageType.Query, Text = "Atmet das Opfer?", HelpText = '\n' + "Hebt sich der Brustkorb? Ist eine Atmung zu hören?", NextIfYes = 6, NextIfNo = 10, NextIfConfirm = 0 });

            //Seite 6 (Blutungen)
            pages.Add(new Page() { PageType = PageType.Confirmation, Text = ("Sichtbare" + '\n' + "Blutungen" + '\n' + "stoppen"), HelpText = '\n' + "Druckverband: Sterile Kompresse auf die Wunde auflegen, mit Verband umwickeln, wenn möglich Gegenstand auf Wunde drücken und weiter mit Verband umwickeln. Wenn kein Verbandmaterial vorhanden nach sauberer Alternative suchen", NextIfYes = 0, NextIfNo = 0, NextIfConfirm = 7 });

            //Seite 7 (stabile Seitenlage)
            pages.Add(new Page() { PageType = PageType.Confirmation, Text = "Stabile Seitenlage", HelpText = '\n' + "Patient flach auf Boden legen, zu einem hingewandten Arm des Patienten im rechten Winkel vom Körper abwinkeln. Anderen Arm über Patienten legen, Hand unter Kinn. Bein der abgewandten Seite anwinkeln und als Hebel benutzen, um Patienten auf die Seite zu drehen (angewinkelte Bein oben). Kopf überstrecken und regelmäßig Atmung überprüfen", NextIfYes = 0, NextIfNo = 0, NextIfConfirm = 8 });

            //Seite 8 (Wohlbefinden)
            pages.Add(new Page() { PageType = PageType.Confirmation, Text = ("Für" + '\n' + "Wohlbefinden sorgen"), HelpText = '\n' + "Opfer vor Auskühlen, Sonnenstich etc. schützen", NextIfYes = 0, NextIfNo = 0, NextIfConfirm = 9 });

            //Seite 9 (Warten(Notruf))
            pages.Add(new Page() { PageType = PageType.End, Text = "Warten! Regelmäßige Pulskontrolle", HelpText = '\n' + "Mit Zeige- und Mittelfinger an der Innenseite des Handgelenks, durch Ausüben von Druck, den Puls ertasten", NextIfYes = 0, NextIfNo = 0, NextIfConfirm = 0 });

            //Seite 10 (Kopf überstrecken)
            pages.Add(new Page() { PageType = PageType.Confirmation, Text = "Kopf des Opfers überstrecken", HelpText = '\n' + "Kopf gerade zur Wirbelsäule ausrichten, Kinn anheben und Mund öffnen", NextIfYes = 0, NextIfNo = 0, NextIfConfirm = 11 });

            //Seite 11 (Puls)
            pages.Add(new Page() { PageType = PageType.Query, Text = ("Puls" + '\n' + "tastbar?"), HelpText = '\n' + "Mit Zeige- und Mittelfinger an der Innenseite des Handgelenks, durch Ausüben von Druck, den Puls ertasten", NextIfYes = 6, NextIfNo = 13, NextIfConfirm = 0 });

            //Seite 12 (Atemwege befreien)
            pages.Add(new Page() { PageType = PageType.Confirmation, Text = "Atemwege befreien", HelpText = '\n' + "Fremdkörper entfernen", NextIfYes = 0, NextIfNo = 0, NextIfConfirm = 5 });

            //Seite 13 (Reanimation)
            pages.Add(new Page() { PageType = PageType.Confirmation, Text = "Herz-Druck-Massage beginnen", HelpText = '\n' + "30 mal drücken und anschließend 2 mal beatmen. (Herzdruckmassage: Neben Patienten knien, Hände übereinander auf die Mitte des Brustkörpers legen, mit gestreckten Armen ca. 5cm tief drücken. Das Lied stayin’ alive gibt den Takt an. Beatmung: Nase es Opfers schließen, normal einatmen, mit den Lippen den Mund des Opfers abdecken und gleichmäßig ausatmen)", NextIfYes = 0, NextIfNo = 0, NextIfConfirm = 20 });

            //Seite 14 (beruhigen)
            pages.Add(new Page() { PageType = PageType.Confirmation, Text = "Opfer beruhigen", HelpText = '\n' + "Mit Opfer reden. Falls Tüte vorhanden, Opfer in die Tüte atmen lassen", NextIfYes = 0, NextIfNo = 0, NextIfConfirm = 15 });

            //Seite 15 (Blutungen)
            pages.Add(new Page() { PageType = PageType.Confirmation, Text = ("Sichtbare" + '\n' + "Blutungen" + '\n' + "stoppen"), HelpText = '\n' + "Druckverband: Sterile Kompresse auf die Wunde auflegen, mit Verband umwickeln, wenn möglich Gegenstand auf Wunde drücken und weiter mit Verband umwickeln. Wenn kein Verbandmaterial vorhanden nach sauberer Alternative suchen", NextIfYes = 0, NextIfNo = 0, NextIfConfirm = 16 });

            //Seite 16 (Kommunikation)
            pages.Add(new Page() { PageType = PageType.Confirmation, Text = ("Frag Opfer:" + '\n' + "Wie heißen Sie?"), HelpText = '\n' + "Opfer befragen, um Reaktionszeit und logische Antwort zu überprüfen", NextIfYes = 0, NextIfNo = 0, NextIfConfirm = 17 });

            //Seite 17 (Reaktion)
            pages.Add(new Page() { PageType = PageType.Query, Text = " Kurze Reaktionszeit & logische Antwort?", HelpText = '\n' + "Antwortet das Opfer logisch und nach angemessener Zeit?", NextIfYes = 18, NextIfNo = 8, NextIfConfirm = 0 });

            //Seite 18 (Kommunikation 2)
            pages.Add(new Page() { PageType = PageType.Confirmation, Text = "Frag Opfer: Haben Sie Schmerzen?", HelpText = '\n' + "Opfer nach möglichen nicht sichtbaren Verletzungen fragen", NextIfYes = 0, NextIfNo = 0, NextIfConfirm = 19 });

            //Seite 19 (Schmerzen)
            pages.Add(new Page() { PageType = PageType.Confirmation, Text = "Schmerzen lokalisieren & überprüfen", HelpText = '\n' + "Schmerzstelle finden und wenn möglich versorgen", NextIfYes = 0, NextIfNo = 0, NextIfConfirm = 8 });

            //Seite 20 (Reanimation fortführen)
            pages.Add(new Page() { PageType = PageType.End, Text = "Reanimation fortsetzen bis Notarzt ablöst", HelpText = '\n' + "30 mal drücken und anschließend 2 mal beatmen. (Herzdruckmassage: Neben Patienten knien, Hände übereinander auf die Mitte des Brustkörpers legen, mit gestreckten Armen ca. 5cm tief drücken. Das Lied stayin’ alive gibt den Takt an. Beatmung: Nase es Opfers schließen, normal einatmen, mit den Lippen den Mund des Opfers abdecken und gleichmäßig ausatmen)", NextIfYes = 0, NextIfNo = 0, NextIfConfirm = 0 });
        }


        public Page GetNextPage(AnswerType answer) //Methode welche die nächste richtige Seite zurück gibt
        {
            int nextPage;

            if (answer == AnswerType.Yes)
            {
                nextPage = pages[currentPage].NextIfYes;
            }

            else if (answer == AnswerType.No)
            {
                nextPage = pages[currentPage].NextIfNo;
            }

            else
            {
                nextPage = pages[currentPage].NextIfConfirm;
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
