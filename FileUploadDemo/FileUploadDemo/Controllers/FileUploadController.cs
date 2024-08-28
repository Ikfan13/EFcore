using Microsoft.AspNetCore.Mvc;

namespace FileUploadInMVC.Controllers
{
    public class FileUploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        //[RequestSizeLimit(1000000)] // Limit to 1 MB
        public async Task<IActionResult> SingleFileUpload(IFormFile SingleFile)
        {
            if (SingleFile != null && SingleFile.Length > 10000000) // Limit to 1 MB
            {
                ModelState.AddModelError("", "The file is too large.");
            }

            if (ModelState.IsValid)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", SingleFile.FileName);

                //Using Buffering
                //using (var stream = System.IO.File.Create(filePath))
                //{
                //    // The file is saved in a buffer before being processed
                //    await SingleFile.CopyToAsync(stream);
                //}

                //Using Streaming
                using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    await SingleFile.CopyToAsync(stream);
                }

                // Process the file here (e.g., save to the database, storage, etc.)
                return View("UploadSuccess");
            }

            return View("Index");
        }

    }
}