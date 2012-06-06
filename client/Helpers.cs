using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

namespace DocketPlaceClient
{
	public static class Helpers
	{
		/// <summary>
		/// Used for encoding receipt content before sending to server. This removes http issue with esc characters.
		/// </summary>
		/// <param name="toEncode"></param>
		/// <returns></returns>
		public static string EncodeToBase64(string toEncode)
		{
			byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);

			string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);

			return returnValue;
		}

		/// <summary>
		/// Used for decoding header and footer data.
		/// </summary>
		/// <param name="encodedData"></param>
		/// <returns></returns>
		public static string DecodeFromBase64(string encodedData)
		{
			byte[] encodedDataAsBytes
			    = System.Convert.FromBase64String(encodedData);
			string returnValue =
			   System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
			return returnValue;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="inputBase64EncodedImage"></param>
		/// <returns></returns>
		public static Bitmap ConvertPNGDataToBitmap(string inputBase64EncodedPNG)
		{
			byte[] data = Convert.FromBase64String(inputBase64EncodedPNG);
			MemoryStream ms = new MemoryStream(data);
			Image PNGImage = Image.FromStream(ms);

			Bitmap BMPRawImage = new Bitmap(PNGImage);
							
			//Need to run it through base64 filter so that the printbitmap method likes it.	
			Bitmap BMPFinalImage = DecodeAd(EncodeAd(BMPRawImage));

			return BMPFinalImage;
		}

		public static Bitmap ConvertPNGToBitmap(Image PNGImage)
		{
			Bitmap BMPRawImage = new Bitmap(PNGImage);

			//Need to run it through base64 filter so that the printbitmap method likes it.	
			Bitmap BMPFinalImage = DecodeAd(EncodeAd(BMPRawImage));

			return BMPFinalImage;
		}

		private static string EncodeAd(Bitmap new_ad)
		{
			MemoryStream stream = new MemoryStream();
			new_ad.Save(stream, ImageFormat.Png);

			byte[] bitmapData = stream.ToArray();
			string outputBase64EncodedImage = Convert.ToBase64String(bitmapData);

			return outputBase64EncodedImage;
		}

		private static Bitmap DecodeAd(string inputBase64EncodedBMP)
		{
			byte[] data = Convert.FromBase64String(inputBase64EncodedBMP);
			MemoryStream ms = new MemoryStream(data);

			Bitmap img = (Bitmap)Image.FromStream(ms);
			return img;
		}

	}
}
