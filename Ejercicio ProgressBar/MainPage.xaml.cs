using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Ejercicio_ProgressBar
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Picker_Click(object sender, RoutedEventArgs e)
        {
            FolderPicker folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add(".docx"); //Necesario para que no pete.

            Windows.Storage.StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                // Application now has read/write access to all contents in the picked folder
                // (including other sub-folder contents)
                Windows.Storage.AccessCache.StorageApplicationPermissions.
                FutureAccessList.AddOrReplace("PickedFolderToken", folder);
                this.Ruta.Text =folder.Path;
            }
            else
            {
                this.Ruta.Text = "Operation cancelled.";
            }
        }

        private async void Prueba_Click(object sender, RoutedEventArgs e)
        {
            //https://msdn.microsoft.com/es-es/library/cc148994.aspx

            //https://blogs.msdn.microsoft.com/metroapps/2012/07/15/access-your-application-assets-folder/

            string sourcePath = @"Ficheros";
            string targetPath =@Ruta.Text;

            //Esto nos guarda en la carpeta de proyecto bin/x86/debux/appX (no es la mejor solución del mundo, explicar)
            StorageFolder InstallationFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            
            //Seleccionamos el origen y el destino de los ficheros
            StorageFolder origen = await InstallationFolder.GetFolderAsync(sourcePath);
            StorageFolder destino = await StorageFolder.GetFolderFromPathAsync(targetPath);

            //leemos todos los ficheros que hay en el origen
            IReadOnlyList<StorageFile> ficheros =await origen.GetFilesAsync();

            foreach(StorageFile sf in ficheros)
            {
                await sf.CopyAsync(destino);
                /*Puesto que hay 10 ficheros y todos ocupan lo mismo, se le supone el mismo tiempo
                *Un 10% del total, que en este caso es 10%
                */
                Barrita.Value += 0.1*Barrita.Maximum;
            }
        }
    }
}
