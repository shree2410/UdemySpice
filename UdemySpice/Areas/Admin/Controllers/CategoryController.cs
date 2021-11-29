using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UdemySpice.Data;

namespace UdemySpice.Areas.Admin.Controllers
{
    [Area("Admin")] //telling this controller is for admin.
    public class CategoryController : Controller
    {
        /*to retrieve everything inside dbcontext from category and display,
        D.I play integral part to fetch data.In startup.cs in services
        that's why we added ApplicationDbContext in Connection String*/

        private readonly ApplicationDbContext _db;//local obj to retrieve(AppDbcon db)

        //create Ctor(fetch from the ioc container)
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;//this will retrieve value
        }
        //Get everything from db and pass it to view
        public async Task<IActionResult> Index()
        {
            return View(await _db.Category.ToListAsync());
        }
    }
}
