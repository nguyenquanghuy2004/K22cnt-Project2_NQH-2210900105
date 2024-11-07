using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NQH_project2_2210900105.Models;

namespace NQH_project2_2210900105.Controllers
{
    public class MEMBERsController : Controller
    {
        private webcuahangthethaoEntities db = new webcuahangthethaoEntities();

        // GET: MEMBERs
        public async Task<ActionResult> Index()
        {
            return View(await db.MEMBER.ToListAsync());
        }

        // GET: MEMBERs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBER mEMBER = await db.MEMBER.FindAsync(id);
            if (mEMBER == null)
            {
                return HttpNotFound();
            }
            return View(mEMBER);
        }

        // GET: MEMBERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MEMBERs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "member_id,member_name,member_username,member_pass,dia_chi,member_phone,member_email,ngay_sinh,ngay_cap_nhap,gioi_tinh,tich_diem")] MEMBER mEMBER)
        {
            if (ModelState.IsValid)
            {
                db.MEMBER.Add(mEMBER);
                await db.SaveChangesAsync();
                return RedirectToAction("Login", "Account");
            }

            return View(mEMBER);
        }

        // GET: MEMBERs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBER mEMBER = await db.MEMBER.FindAsync(id);
            if (mEMBER == null)
            {
                return HttpNotFound();
            }
            return View(mEMBER);
        }

        // POST: MEMBERs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "member_id,member_name,member_username,member_pass,dia_chi,member_phone,member_email,ngay_sinh,ngay_cap_nhap,gioi_tinh,tich_diem")] MEMBER mEMBER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mEMBER).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mEMBER);
        }

        // GET: MEMBERs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBER mEMBER = await db.MEMBER.FindAsync(id);
            if (mEMBER == null)
            {
                return HttpNotFound();
            }
            return View(mEMBER);
        }

        // POST: MEMBERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MEMBER mEMBER = await db.MEMBER.FindAsync(id);
            db.MEMBER.Remove(mEMBER);
            await db.SaveChangesAsync();
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
