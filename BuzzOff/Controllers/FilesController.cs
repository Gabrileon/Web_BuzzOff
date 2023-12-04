using BuzzOff.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace BuzzOff.Controllers
{
    [Authorize]
    public class FilesController : Controller
    {
        [HttpGet]
        public IActionResult GetPictureData([FromQuery] FileModel fileModel)
        {
            Business.Repository.MidiaConverter.FileAccess fileAccess = new(fileModel.Table, fileModel.Column, fileModel.Id);
            var file = fileAccess.GetFile();

            if (file.Data != null)
            {
                string base64Image = Convert.ToBase64String(file.Data);
                string dataUrl = $"data:image/png;base64,{base64Image}";

                var imageResponse = new ImageResponseModel
                {
                    FileName = file.Name,
                    Data = dataUrl
                };

                return Json(imageResponse);
            }

            return Json(new { FileName = "default.png", Data = "/images/default-image.png" });
        }
    }
}
