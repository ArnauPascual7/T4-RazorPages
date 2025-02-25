using System.ComponentModel.DataAnnotations;

namespace RazorPages.Model
{
    public class Product
    {
        [Required(ErrorMessage = "Aquest camp és obligatori")]
        [Range(1,99999999, ErrorMessage = "L'Id ha de ser de fins a 8 xifres i no pot ser 0")]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{Id}|{Name}|{Amount}|{Price}";
        }
    }
}
