using System.ComponentModel.DataAnnotations;

namespace WorldCups.Models
{
    public class Categories
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="يرجى ادخال اسم الفئة")]

        public string Name { get; set; }
        [Required(ErrorMessage = "يرجى ادخال وصف الفئة")]
        public string Description { get; set; }
        [Required(ErrorMessage = "يرجى ادخال الايقونة ")]
        public string  Icon { get; set; }
        [Required(ErrorMessage = "يرجى ادخال الرابط ")]
        public string Url { get; set; }

        
    }
}
