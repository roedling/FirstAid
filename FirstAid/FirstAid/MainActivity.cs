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
using Android.Media;

namespace FirstAid
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]

    public class MainActivity : WearableActivity
    {
        
        private int currentViewId = -1; //Aktuelle Id unseres Layouts. Setzen auf -1, da die Id der Layouts meist eine positive Zahl ist (vielleicht auch 0) -> nicht existierendes Layout
        private Page currentPage;

        MediaPlayer MediaPlayer;

        Book book = new Book(); //new, da Standardkonstruktor automatisch aufgerufen wird

        //Anwendung wird gestartet
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState); //Startinfo an Basisklasse (MainActivity)

            ShowPage(book.GetCurrentPage());

            // Load mp3
            MediaPlayer = MediaPlayer.Create(this, Resource.Raw.stayinalive);
            // Play mp3
            MediaPlayer.Start();

            SetAmbientEnabled();  //Sparmodus?
        }


        private void SetContentViewToConfirmation()
        {
            if (currentViewId != Resource.Layout.layout_confirmation) //Resource.Layout.layout_confirmation liefert die Id des Layouts
            {
                currentViewId = Resource.Layout.layout_confirmation;
                SetContentView(Resource.Layout.layout_confirmation); //Methode SetContentView bildet das gewünschte Layout auf dem Bildschirm ab

                FindViewById<Button>(Resource.Id.ConfirmationButton).Click += ClickedConfirmation; //übergebe referenz. Pointer auf Mehtode wird dazu gepackt. Button führt Liste. Button kann mehrere Methoden aufrufen. = wäre das ersetzen der Click Methode
                FindViewById<Button>(Resource.Id.ConfirmationQuestionButton).Click += ClickedHelp;
            }
        }

        private void SetContentViewToQuery()
        {
            if (currentViewId != Resource.Layout.layout_query)
            {
                currentViewId = Resource.Layout.layout_query;
                SetContentView(Resource.Layout.layout_query);

                FindViewById<Button>(Resource.Id.YesButton).Click += ClickedYes;
                FindViewById<Button>(Resource.Id.NoButton).Click += ClickedNo;
                FindViewById<Button>(Resource.Id.QueryQuestionButton).Click += ClickedHelp;

            }
        }

        private void SetContentViewToEnd()
        {
            if (currentViewId != Resource.Layout.layout_end)
            {
                currentViewId = Resource.Layout.layout_end;
                SetContentView(Resource.Layout.layout_end);

                FindViewById<Button>(Resource.Id.BackToStartButton).Click += ClickedBackToStart; 

            }
        }

        private void SetContentViewToHelp()
        {
            if (currentViewId != Resource.Layout.layout_help)
            {
                currentViewId = Resource.Layout.layout_help;
                SetContentView(Resource.Layout.layout_help);

                FindViewById<Button>(Resource.Id.BackButton).Click += ClickedBack;
            }
        }

        void ClickedConfirmation(object Button, EventArgs a) //Callback Methode braucht die Argumente object und EventArgs
        {
            ShowPage(book.GetNextPage(AnswerTypeEnum.Confirmation));
        }

        void ClickedYes(object Button, EventArgs a)
        {
            ShowPage(book.GetNextPage(AnswerTypeEnum.Yes));
        }

        void ClickedNo(object Button, EventArgs a)
        {
            ShowPage(book.GetNextPage(AnswerTypeEnum.No));
        }

        void ClickedHelp(object Button, EventArgs a)
        {
            currentPage = book.GetCurrentPage(); //Aktuelle Abfrageseite speichern
            SetContentViewToHelp(); //Bildschirm auf das Layout für den Hilfetext stellen
            FindViewById<TextView>(Resource.Id.HelpText).Text = currentPage.helpText; //Hilfetext der aktuellen Seite aufrufen
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
            if(page.pageType == PageTypeEnum.confirmation)
            {
                SetContentViewToConfirmation();
                FindViewById<TextView>(Resource.Id.confirmationText).Text = page.text;
            }

            else if(page.pageType == PageTypeEnum.query)
            {
                SetContentViewToQuery();
                FindViewById<TextView>(Resource.Id.queryText).Text = page.text;
            }

            else if (page.pageType == PageTypeEnum.end)
            {
                SetContentViewToEnd();
                FindViewById<TextView>(Resource.Id.queryText).Text = page.text;
            }

            else
            { }
        }

    }
}



