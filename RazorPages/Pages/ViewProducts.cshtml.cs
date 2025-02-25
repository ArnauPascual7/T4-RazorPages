using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Model;
using System.Diagnostics;
using System.Globalization;
using FileWorking = System.IO;

namespace RazorPages.Pages
{
    public class ViewProductsModel : PageModel
    {
        public string MsgFileError;
        public List<Product> Products { get; set; } = new List<Product>();
        public void OnGet()
        {
            string fileName = "products.txt";
            //Debug.WriteLine(Path.GetFullPath(fileName));
            string filePath = @"ModelData\" + fileName;
            if (FileWorking.File.Exists(filePath))
            {
                string[]? lines = FileWorking.File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split("|");
                    if (parts.Length == 4)
                    {
                        Product product = new Product
                        {
                            Id = int.Parse(parts[0]),
                            Name = parts[1],
                            Amount = int.Parse(parts[2]),
                            Price = decimal.Parse(parts[3], CultureInfo.InvariantCulture)
                        };
                        Products.Add(product);
                    }
                    else
                    {
                        MsgFileError = "Error de càrrega dels atributs d'un producte";
                    }
                }
            }
            else
            {
                MsgFileError = "Error de càrrega de dades";
            }
        }
    }
}
