using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DI_07_Controls
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        String cadena = "";
        public MainPage()
        {
            this.InitializeComponent();
            Inicio.MinDate =DateTime.Today;
        }
        /// <summary>
        /// Evento que controla que checkbox se ha seleccionado y muestra en pantalla
        /// un mensaje con el checkbox que muestras en pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void go_Click(object sender, RoutedEventArgs e)
        {
            
            MessageDialog md = new MessageDialog("Has pulsado "+cadena);
            await md.ShowAsync();
        }

        private void Checked(object sender, RoutedEventArgs e)
        {
            cadena = "";
            RadioButton rb = sender as RadioButton;
            cadena = rb.Name;

        }
        

        private void Inicio_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            Fin.MinDate=sender.SelectedDates.ElementAt(0).AddDays(1);
        }
        /* Con dos calendarios, simular uan reserva en un hotel
* El día inicial no puede ser anterior a hoy
* El día final no puede ser anterior al día siguiente al de inicio de reserva
*/

    }
}
