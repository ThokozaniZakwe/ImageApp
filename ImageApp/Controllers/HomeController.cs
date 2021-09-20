using ImageApp.DataAccess;
using ImageApp.DataAccess.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using ImageApp.Models;

namespace ImageApp.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment hostEnvironment;

        public HomeController(IUnitOfWork unit, IWebHostEnvironment environment)
        {
            unitOfWork = unit;
            hostEnvironment = environment;
        }
        public IActionResult Index()
        {
            return View(unitOfWork.Person.GetAll());
        }

        public IActionResult Detail(int id)
        {
            var objFromDB = unitOfWork.Person.Get(id);
            if(objFromDB == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(objFromDB);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var objFromDB = unitOfWork.Person.Get(id);
            if (objFromDB != null)
            {
                return View(objFromDB);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if (files.Count() > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images");
                    var extension = Path.GetExtension(files[0].FileName);

                    if (person.ImgeUrl != null)
                    {
                        var imagePath = Path.Combine(webRootPath, person.ImgeUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStreams);
                    }
                    person.ImgeUrl = @"\images\" + fileName + extension;

                    unitOfWork.Person.Update(person);
                    unitOfWork.Save();
                }              
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Person() { ImgeUrl = "No Image"});
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                if (files.Count > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images");
                    var extension = Path.GetExtension(files[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStreams);
                    }
                    person.ImgeUrl = @"\images\" + fileName + extension;
                }
                unitOfWork.Person.Add(person);
                unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var objFromDb = unitOfWork.Person.Get(id);
            if(objFromDb == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(objFromDb);
        }

        [HttpPost]
        public IActionResult Delete(Person person)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Person.Delete(person);
                unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
