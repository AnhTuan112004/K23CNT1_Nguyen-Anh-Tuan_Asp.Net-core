using System.ComponentModel.DataAnnotations;

namespace NatLap08.Models
{
    public class NatCategory
    {
        public int NatId { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "Tên danh mục phải từ 6 đến 150 ký tự")]
        public string NatName { get; set; }
    }
}
