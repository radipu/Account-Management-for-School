
using Microsoft.AspNetCore.Http;
using System;
namespace OE.Service
{
    public interface ICommonServ
    {     

        #region "Image Function Definitions"
        bool CommImage_ImageFormat(string imgName, IFormFile file, string webRootPath, string dbImgPath, int imgHeight, int imgWidth, string imgExt);
        string CommImage_WrapperDefaultImage(string path,string imageRootPath, Int64 genderId);
        #endregion "Image Function Definitions"

        #region "File Function Definitions"    
        bool DelFileFromLocation(string path);
        #endregion "File Function Definitions"
    }
}

