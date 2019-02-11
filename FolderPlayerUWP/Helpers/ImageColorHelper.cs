using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace FolderPlayerUWP.Helpers
{
    public static class ImageColorHelper
    {
        public static async Task<Color> GetDominantColorFromImageAsync(Image imageToUse)
        {
            BitmapImage bitmapImage = imageToUse.Source as BitmapImage;
            var streamReference = RandomAccessStreamReference.CreateFromUri(bitmapImage.UriSource);
            using (IRandomAccessStream stream = await streamReference.OpenReadAsync())
            {
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);

                var myTransform = new BitmapTransform { ScaledHeight = 1, ScaledWidth = 1 };

                //Get the pixel provider
                var pixels = await decoder.GetPixelDataAsync(
                    BitmapPixelFormat.Rgba8,
                    BitmapAlphaMode.Ignore,
                    myTransform,
                    ExifOrientationMode.IgnoreExifOrientation,
                    ColorManagementMode.DoNotColorManage);

                //Get the bytes of the 1x1 scaled image
                var bytes = pixels.DetachPixelData();

                //read the color 
                var colorToReturn = Windows.UI.Color.FromArgb(255, bytes[0], bytes[1], bytes[2]);

                return colorToReturn;

            }
        }

        public static async Task<Color> GetDominantColorFromStream(IRandomAccessStream stream)
        {
            using (stream)
            {
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);

                var myTransform = new BitmapTransform { ScaledHeight = 1, ScaledWidth = 1 };

                //Get the pixel provider
                var pixels = await decoder.GetPixelDataAsync(
                    BitmapPixelFormat.Rgba8,
                    BitmapAlphaMode.Ignore,
                    myTransform,
                    ExifOrientationMode.IgnoreExifOrientation,
                    ColorManagementMode.DoNotColorManage);

                //Get the bytes of the 1x1 scaled image
                var bytes = pixels.DetachPixelData();

                //read the color 
                var colorToReturn = Windows.UI.Color.FromArgb(255, bytes[0], bytes[1], bytes[2]);

                return colorToReturn;
            }

        }


    }
}
