using System;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Presentation.Extensions;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.LightSwitch.Threading;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
namespace LightSwitchApplication
{
    public partial class FrmPictureViewer
    {
        partial void FrmPictureViewer_Activated()
        {

            

        }

        partial void Method_Execute()
        {
            Dispatchers.Main.BeginInvoke(() =>
            {
                //Image img = new Image();
                //Uri url = new Uri("people.jpg", UriKind.RelativeOrAbsolute);
                //ImageSource newImage = new System.Windows.Media.Imaging.BitmapImage(url);
                //img.SetValue(Image.SourceProperty, newImage);
                
                MyImg = GetImageByName("people.jpg");
                this.OpenModalWindow("ModalImage");
                
            });
        }

        private byte[] GetImageByName(string filename)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream(typeof(LightSwitchApplication.FrmPictureViewer).Namespace + ".Images." + filename);
            return GetStreamAsByteArray(stream);
        }

        private byte[] GetStreamAsByteArray(System.IO.Stream stream)
        {
            int streamLength = Convert.ToInt32(stream.Length);
            byte[] fileData = new byte[streamLength];
            stream.Read(fileData, 0, streamLength);
            stream.Close();
            return fileData;
        }
    }
}
