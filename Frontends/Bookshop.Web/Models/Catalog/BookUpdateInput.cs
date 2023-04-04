using System.ComponentModel.DataAnnotations;

namespace Bookshop.Web.Models.Catalog
{
    public class BookUpdateInput
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? UserId { get; set; }
        public string? Picture { get; set; }


        public FeatureViewModel Feature { get; set; }

        public string CategoryId { get; set; }
        [Display(Name = "Kurs Resim")]
        public IFormFile? PhotoFormFile { get; set; }
    }
}
