using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using PhamBaTuanTu_24123080_3.Models;
using System.Diagnostics;

namespace PhamBaTuanTu_24123080_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly QltaiSanContext _context;
        public HomeController(QltaiSanContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var danhSach = LayTaiSan(maLoai);
            return View(danhSach);
        }
        public IActionResult Loc(int? id)
        {
            var danhSach = LayTaiSan(id);
            return PartialView("PhamBaTuanTu_MainContent", danhSach);
        }
        private List<TaiSan> LayTaiSan(int? maLoai)
        {
            if (maLoai.HasValue)
            {
                ViewData["TieuDe"] = _context.LoaiTaiSans.Where(l => l.MaLoai == maLoai.Value).Select(l = > l.TenLoai)
                    .FirstOrDefault() ?? "";
                return _context.TaiSans.Where(t => t.MaLoai == maLoai.Value && t.NguyenGia != null).ToList();
            }

            ViewData["TieuDe"] = "Pham Ba Tuan Tu";
            return _context.TaiSans.Where(t => t.NguyenGia >= 20).ToList();
        }
    }
}
