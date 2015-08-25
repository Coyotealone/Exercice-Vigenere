using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;

// Pour en savoir plus sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=391641

namespace Exercice
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoqué lorsque cette page est sur le point d'être affichée dans un frame.
        /// </summary>
        /// <param name="e">Données d’événement décrivant la manière dont l’utilisateur a accédé à cette page.
        /// Ce paramètre est généralement utilisé pour configurer la page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: préparer la page pour affichage ici.

            // TODO: si votre application comporte plusieurs pages, assurez-vous que vous
            // gérez le bouton Retour physique en vous inscrivant à l’événement
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed.
            // Si vous utilisez le NavigationHelper fourni par certains modèles,
            // cet événement est géré automatiquement.
        }

        private void btn_click_decrypt(object sender, RoutedEventArgs e)
        {
            Fonctions fc = new Fonctions();
            //DB database = new DB();
            if (txt_chiffre.Text.Length > 0 && txt_clef.Text.Length > 0)
            {
                txt_clair.Text = fc.Decrypt(txt_chiffre.Text, txt_clef.Text);
                /*database.Clair = txt_clair.Text;
                database.Clef = txt_clef.Text;
                database.Crypte = txt_chiffre.Text;
                database.Type = true;
                fc.InsertDB(database);*/
            }
            else
            {
                if (txt_chiffre.Text.Length == 0)
                {
                    txt_clair_error.Text = "Veuillez remplir le champ ci-dessus";
                    txt_clair_error.Visibility = Visibility;
                }
                if (txt_clef.Text.Length == 0)
                {
                    txt_clef_error.Text = "Veuillez remplir le champ ci-dessus";
                    txt_clef_error.Visibility = Visibility;
                }
            }
        }

        private void btn_click_crypt(object sender, RoutedEventArgs e)
        {
            Fonctions fc = new Fonctions();
            //DB database = new DB();
            if (txt_clair.Text.Length > 0 && txt_clef.Text.Length > 0)
            {
                txt_chiffre.Text = fc.Crypt(txt_clair.Text, txt_clef.Text);
                //database.Clair = txt_clair.Text;
                //database.Clef = txt_clef.Text;
                //database.Crypte = txt_chiffre.Text;
                //database.Type = false;
                //fc.InsertDB(database);
            }
            else
            {
                if (txt_clair.Text.Length == 0)
                {
                    txt_clair_error.Text = "Veuillez remplir le champ ci-dessus";
                    txt_clair_error.Visibility = Visibility;
                }
                if (txt_clef.Text.Length == 0)
                {
                    txt_chiffre_error.Text = "Veuillez remplir le champ ci-dessus";
                    txt_chiffre_error.Visibility = Visibility;
                }
            }
        }
        private void btn_click_clean(object sender, RoutedEventArgs e)
        {
            txt_chiffre.Text = "";
            txt_clair.Text = "";
            txt_clef.Text = "";
        }

        private void txt_clair_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_clair_error.Visibility = Visibility.Collapsed;
            txt_clair_error.Text = "";
        }

        private void txt_clef_error_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_clef_error.Visibility = Visibility.Collapsed;
            txt_clef_error.Text = "";
        }

        private void txt_crypt_error_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_chiffre_error.Visibility = Visibility.Collapsed;
            txt_chiffre_error.Text = "";
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Exercice.Accueil));
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Exercice.Accueil));
        }
    }
}
