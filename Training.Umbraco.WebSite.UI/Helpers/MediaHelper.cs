using System;
using System.IO;
using System.Linq;
using System.Web;

namespace Training.Umbraco.WebSite.UI.Helpers
{
    public class MediaHelper
    {
        // format "{ProductId}_{weight}_{height}{.ext}"
        private const string CarouselImageNameFormat = "{0}_800_300{1}";
        private const string PreviewImageNameFormat = "{0}_320_150{1}";
        private const string DetailsImageNameFormat = "{0}_500_500{1}";

        private const string DefaultCarouselImage = "Default_800_300.jpg";
        private const string DefaultPreviewImage = "Default_320_150.jpg";
        private const string DefaultDetailsImage = "Default_500_500.png";

        private const string MediaFolderPath = "/Media";

        //public static void SaveImages(AddOrEditProductViewModel vm, int productId)
        //{
        //    if (vm != null && productId > 0)
        //    {
        //        SaveImage(vm.CarouselImage, productId, CarouselImageNameFormat);
        //        SaveImage(vm.DetailsImage, productId, DetailsImageNameFormat);
        //        SaveImage(vm.PreviewImage, productId, PreviewImageNameFormat);
        //    }
        //}

        public static string GetCarouselImage(int productId)
        {
            return GetImageOrDefault(productId, DefaultCarouselImage, CarouselImageNameFormat);
        }

        public static string GetPreviewImage(int productId)
        {
            return GetImageOrDefault(productId, DefaultPreviewImage, PreviewImageNameFormat);
        }

        public static string GetDetailsImage(int productId)
        {
            return GetImageOrDefault(productId, DefaultDetailsImage, DetailsImageNameFormat);
        }

        public static string GetImageOrDefault(int productId, string defaultFileName, string format)
        {
            var fileName = string.Format(format, productId, string.Empty);
            var images = Directory.GetFiles(GetMediaFolder(), string.Format("{0}.*", fileName), SearchOption.TopDirectoryOnly);

            if (images.Any())
            {
                return ImageLocationToWebLocation(images.First());
            }

            var defaultFileLocation = GetFileLocation(defaultFileName);
            return File.Exists(defaultFileLocation) ? ImageLocationToWebLocation(defaultFileLocation) : string.Empty;
        }

        private static void SaveImage(HttpPostedFileBase file, int productId, string format)
        {
            if (file != null && file.ContentLength > 0)
            {
                byte[] fileData;
                using (var binaryReader = new BinaryReader(file.InputStream))
                {
                    fileData = binaryReader.ReadBytes(file.ContentLength);
                }

                var fileName = string.Format(format, productId, Path.GetExtension(file.FileName));
                File.WriteAllBytes(GetFileLocation(fileName), fileData);
            }
        }

        private static string GetFileLocation(string fileName)
        {
            return Path.Combine(GetMediaFolder(), fileName);
        }

        private static string GetMediaFolder()
        {
            return HttpContext.Current.Server.MapPath(string.Format("~{0}", MediaFolderPath));
        }

        private static string ImageLocationToWebLocation(string location)
        {
            return string.Format("{0}/{1}", MediaFolderPath, location.Split(new[] { "\\" }, StringSplitOptions.None).Last());
        }
    }
}