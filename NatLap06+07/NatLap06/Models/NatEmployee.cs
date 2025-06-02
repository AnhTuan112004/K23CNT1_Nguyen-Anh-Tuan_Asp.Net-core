using System;
using System.ComponentModel.DataAnnotations;

namespace NatLap06.Models
{
    public class NatEmployee
    {
        public int NatId { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống")]
        public string NatName { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        public DateTime NatBirthDay { get; set; }

        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string NatEmail { get; set; }

        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string NatPhone { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Lương phải là số dương")]
        public double NatSalary { get; set; }

        public bool NatStatus { get; set; }
    }
}
