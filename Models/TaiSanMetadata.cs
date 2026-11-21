using System.ComponentModel.DataAnnotations;
namespace PhamBaTuanTu_24123080_3.Models
{
    public class TaiSanMetadata
    {
        [Display(Name ="Loai tai san")]
        public int MaLoai { get; set; }

        [Display(Name = "Ten tai san")]
        [Required(ErrorMessage = "Ten tai san khong duoc de trong")]
        public string TenTs { get; set; } = null!;

        [Display(Name = "Nguyen gia(trieu)")]
        [Required(ErrorMessage = "Nguyen gia khong duoc de trong")]
        [Range(1,2000,ErrorMessage ="Nguyen gia phai la so trong khoang tu 1 den 2000")]
        public decimal? NguyenGia { get; set; }

        [Display(Name = "Anh")]
        [Required(ErrorMessage = "Ten file anh khong duoc de trong")]
        [RegularExpression(@"(?i)^.+\.(jpg|jpeg|png|webp)$", ErrorMessage ="ten file anh sai dinh dang")]
        public string? Anh { get; set; }
    }
}
