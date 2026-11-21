using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhamBaTuanTu_24123080_3.Models;
namespace PhamBaTuanTu_24123080_3.Controllers
{
    public class TaiSanController : Controller
    {
        private readonly QltaiSanContext _context;
        public TaiSanController(QltaiSanContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(_context.LoaiTaiSans, "MaLoai", "TenLoai");
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("MaLoai, TenTs, NguyenGia, Anh")] TaiSan taiSan)
        {
            if (ModelState.IsValid)
            {
                _context.TaiSans.Add(taiSan);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.MaLoai = new SelectList(_context.LoaiTaiSans, "MaLoai", "TenLoai", taiSan.MaLoai);
            return View(taiSan);
        }
       
    }
}
