using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO; // Thêm thư viện này để xử lý đường dẫn file
using System.Web;
using System.Web.Mvc;
using Website_ban_quan_ao.Models;

namespace Website_ban_quan_ao.Areas.Admin.Controllers
{
    public class TinTucController : Controller
    {
        private ApplicationDbcontext db = new ApplicationDbcontext();

        // GET: TinTuc
        public ActionResult Index(string searchString = null)
        {
            // Lấy danh sách tin tức từ cơ sở dữ liệu
            var tinTucs = db.TinTuc.AsQueryable();

            // Kiểm tra nếu có từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(searchString))
            {
                // Lọc danh sách theo từ khóa tìm kiếm
                tinTucs = tinTucs.Where(t => t.TieuDe.Contains(searchString) && t.TrangThai);
            }

            // Chuyển đổi kết quả thành danh sách và trả về view
            return View(tinTucs.ToList());
        }

        // GET: TinTuc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tinTuc = db.TinTuc.Find(id);
            if (tinTuc == null)
            {
                return HttpNotFound();
            }
            return View(tinTuc);
        }

        // GET: TinTuc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TinTuc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TieuDe,NoiDung,Anhbia,TrangThai")] TinTuc tinTuc, HttpPostedFileBase Anhbia)
        {
            if (ModelState.IsValid)
            {
                if (Anhbia != null && Anhbia.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(Anhbia.FileName);
                    var path = Path.Combine(Server.MapPath("~/Hinhanh"), fileName);
                    Anhbia.SaveAs(path);
                    tinTuc.Anhbia = fileName; // Lưu tên file vào model
                }

                tinTuc.NgayTao = DateTime.Now;
                db.TinTuc.Add(tinTuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tinTuc);
        }

        // GET: TinTuc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tinTuc = db.TinTuc.Find(id);
            if (tinTuc == null)
            {
                return HttpNotFound();
            }
            return View(tinTuc);
        }

        // POST: TinTuc/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TieuDe,NoiDung,Anhbia,TrangThai")] TinTuc tinTuc, HttpPostedFileBase Anhbia)
        {
            if (ModelState.IsValid)
            {
                if (Anhbia != null && Anhbia.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(Anhbia.FileName);
                    var path = Path.Combine(Server.MapPath("~/Hinhanh"), fileName);
                    Anhbia.SaveAs(path);
                    tinTuc.Anhbia = fileName; // Lưu tên file vào model
                }

                tinTuc.NgayCapNhat = DateTime.Now;
                db.Entry(tinTuc).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tinTuc);
        }

        // GET: TinTuc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tinTuc = db.TinTuc.Find(id);
            if (tinTuc == null)
            {
                return HttpNotFound();
            }
            return View(tinTuc);
        }

        // POST: TinTuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TinTuc tinTuc = db.TinTuc.Find(id);
            db.TinTuc.Remove(tinTuc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
