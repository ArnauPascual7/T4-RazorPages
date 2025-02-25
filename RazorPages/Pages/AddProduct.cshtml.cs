using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Model;
using FileWorking = System.IO;

namespace RazorPages.Pages
{
    public class AddProductModel : PageModel
    {
        public string MsgFileError;
        [BindProperty]
        public Product NewProduct { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string fileName = "products.txt";
            //Debug.WriteLine(Path.GetFullPath(fileName));
            string filePath = @"ModelData\" + fileName;
            if (FileWorking.File.Exists(filePath))
            {
                FileWorking.File.AppendAllText(filePath, $"\n{NewProduct.ToString()}");
            }
            else
            {
                MsgFileError = "Error de càrrega de dades";
            }
            return Page();
        }
    }
}
