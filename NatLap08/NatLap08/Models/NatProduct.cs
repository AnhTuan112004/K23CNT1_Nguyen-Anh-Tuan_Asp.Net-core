using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http; // để dùng IFormFile

namespace NatLap08.Models
{
    public class NatProduct
    {
        public int NatId { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "Tên sản phẩm phải từ 6 đến 150 ký tự")]
        public string NatName { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn ảnh sản phẩm")]
        public string NatImage { get; set; }  // lưu đường dẫn ảnh

        [Required(ErrorMessage = "Giá sản phẩm không được để trống")]
        [Range(100000, double.MaxValue, ErrorMessage = "Giá sản phẩm phải lớn hơn hoặc bằng 100000")]
        public float NatPrice { get; set; }

        // Bỏ custom validation, kiểm tra ở Controller
        [Range(0, double.MaxValue, ErrorMessage = "Giá khuyến mãi không được âm")]
        public float NatSalePrice { get; set; }

        [StringLength(1500, ErrorMessage = "Mô tả tối đa 1500 ký tự")]
        // Bỏ custom validation kiểm tra từ nhạy cảm, xử lý trong Controller
        public string NatDescription { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn danh mục sản phẩm")]
        public int NatCategoryId { get; set; }

        // Dùng để upload file ảnh khi tạo/sửa sản phẩm
        public IFormFile NatImageFile { get; set; }

        // Navigation property
        public NatCategory NatCategory { get; set; }
    }
}
