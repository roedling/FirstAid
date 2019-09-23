using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.Wearable.Views;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.Wearable.Activity;
using Java.Interop;
using Android.Views.Animations;

namespace FirstAid
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]

    public class MainActivity : WearableActivity
    {
        
        private int currentViewId = -1; //Aktuelle Id unseres Layouts. Setzen auf -1, da die Id der Layouts meist eine positive Zahl ist (vielleicht auch 0) -> nicht existierendes Layout
        private Page currentPage;

        private Book book = new Book(); //new, da Standardkonstruktor automatisch aufgerufen wird

        //Anwendung wird gestartet
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState); //Startinfo an Basisklasse (MainActivity)

            ShowPage(book.GetCurrentPage()); //Display zeigt die erste Seite

            SetAmbientEnabled(); 
        }


        private void SetContentViewToConfirmation()
        {
            if (currentViewId != Resource.Layout.layout_confirmation) //Resource.Layout.layout_confirmation liefert die Id des Layouts
            {
                currentViewId = Resource.Layout.layout_confirmation;
                SetContentView(Resource.Layout.layout_confirmation); //Methode SetContentView bildet das gewünschte Layout auf dem Bildschirm ab

                FindViewById<Button>(Resource.Id.confirmationButton).Click += ClickedConfirmation; //übergebe referenz. Pointer auf Methode wird dazu gepackt. Button führt Liste. Button kann mehrere Methoden aufrufen. = wäre das ersetzen der Click Methode
                FindViewById<TextView>(Resource.Id.confirmationText).Click += ClickedHelp;
            }
        }

        private void SetContentViewToQuery()
        {
            if (currentViewId != Resource.Layout.layout_query)
            {
                currentViewId = Resource.Layout.layout_query;
                SetContentView(Resource.Layout.layout_query);

                FindViewById<Button>(Resource.Id.yesButton).Click += ClickedYes; //Buttons werden Methoden zugeordnet
                FindViewById<Button>(Resource.Id.noButton).Click += ClickedNo;
                FindViewById<TextView>(Resource.Id.queryText).Click += ClickedHelp;

            }
        }

        private void SetContentViewToEnd()
        {
            if (currentViewId != Resource.Layout.layout_end)
            {
                currentViewId = Resource.Layout.layout_end;
                SetContentView(Resource.Layout.layout_end);

                FindViewById<TextView>(Resource.Id.endText).Click += ClickedHelp;
                FindViewById<Button>(Resource.Id.backToStartButton).Click += ClickedBackToStart;
            }
        }

        private void SetContentViewToHelp()
        {
            if (currentViewId != Resource.Layout.layout_help)
            {
                currentViewId = Resource.Layout.layout_help;
                SetContentView(Resource.Layout.layout_help);

                FindViewById<Button>(Resource.Id.backButton).Click += ClickedBack;
                FindViewById<TextView>(Resource.Id.helpText).Click += ClickedBack;
            }
        }

        void ClickedConfirmation(object Button, EventArgs a) //Callback Methode braucht die Argumente object und EventArgs (EventHandler)
        {
            ShowPage(book.GetNextPage(AnswerType.Confirmation));
        }

        void ClickedYes(object Button, EventArgs a)
        {
            ShowPage(book.GetNextPage(AnswerType.Yes));
        }

        void ClickedNo(object Button, EventArgs a)
        {
            ShowPage(book.GetNextPage(AnswerType.No));
        }

        void ClickedHelp(object Button, EventArgs a)
        {
            currentPage = book.GetCurrentPage(); //Aktuelle Abfrageseite speichern
            SetContentViewToHelp(); //Bildschirm auf das Layout für den Hilfetext stellen
            FindViewById<TextView>(Resource.Id.helpText).Text = currentPage.helpText; //Hilfetext der aktuellen Seite aufrufen
        }

        void ClickedBack(object Button, EventArgs a)
        {
            ShowPage(book.GetCurrentPage()); //Zurück auf die aktuelle Seite
        }

        void ClickedBackToStart(object Button, EventArgs a)
        {
            SetContentViewToConfirmation(); //Da erste Seite Confirmation, Bildschirmlayout auf Confirmation setzen
            book.Reset(); //Buchseite auf 0 setzen
            ShowPage(book.GetCurrentPage()); //Methode ShowPage mit der 1 Seite (in diesem Fall die "0") aufrufen
        }



        void ShowPage(Page page)
        {
            if(page.pageType == PageType.Confirmation)
            {
                SetContentViewToConfirmation();
                FindViewById<TextView>(Resource.Id.confirmationText).Text = page.text;
            }

            else if(page.pageType == PageType.Query)
            {
                SetContentViewToQuery();
                FindViewById<TextView>(Resource.Id.queryText).Text = page.text;
            }

            else if (page.pageType == PageType.End)
            {
                SetContentViewToEnd();
                FindViewById<TextView>(Resource.Id.endText).Text = page.text;
            }

            else
            { }
        }

    }
}



