
using Microsoft.AspNetCore.Http;
using System;
using System.Drawing;
using System.IO;
namespace OE.Service
{
    public class CommonServ: ICommonServ
    {        
        #region "Image Functions"       
        public bool CommImage_ImageFormat(string imgName, IFormFile file, string webRootPath, string dbImgPath, int imgHeight, int imgWidth, string imgExt)
        {
            try
            {
                //[NOTE: Convert FileType into ImageType]
                Image img = Image.FromStream(file.OpenReadStream(), true, true);

                //[NOTE: Create Directory]
                string fullPath = Path.Combine(webRootPath, dbImgPath);
                Directory.CreateDirectory(fullPath);

                //[NOTE: Creating empty canvas]
                var draw_NewImage = new Bitmap(imgHeight, imgWidth);

                //[NOTE: Drawing image inside empty canvas]
                using (var g = Graphics.FromImage(draw_NewImage))
                {
                    g.DrawImage(img, 0, 0, imgHeight, imgWidth);                   
                    draw_NewImage.Save(fullPath + imgName+ imgExt);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string CommImage_WrapperDefaultImage(string path, string imageRootPath, Int64 genderId = 0)
        {
            string returnValue = null;

            //[NOTE: Create Directory]
            string fullPath = Path.Combine(imageRootPath, path);
            //[BR: if path is not emply and image is exit in momery, then return image path]
            if (!string.IsNullOrEmpty(path) && File.Exists(fullPath) == true)
            {
                returnValue = path;
            }
            else if (genderId == 0)
            {
                returnValue = "DataDictionary/images/defaultImages/Common.png";
            }
            else
            {
                switch (genderId)
                {
                    case 1:
                        returnValue = "DataDictionary/images/defaultImages/GenderMale.png";
                        break;
                    case 2:
                        returnValue = "DataDictionary/images/defaultImages/GenderFemale.png";
                        break;
                    case 3:
                        returnValue = "DataDictionary/images/defaultImages/GenderThird.png";
                        break;
                    default:
                        returnValue = "DataDictionary/images/defaultImages/GenderThird.png";
                        break;
                }
            }
            return returnValue;
        }

        #endregion "Image Functions"

        #region "File Functions"
   
        public bool DelFileFromLocation(string path)
        {
            if ((File.Exists(path)))
            {
                File.SetAttributes(path, FileAttributes.Normal);
                File.Delete(path);
                return true;
            }
            else
            {
                return false;
            }
        }

        
        #endregion "File Functions"  
    }
}

