using LabsLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Lab5.Controllers
{
    public class ProgramController : Controller
    {
        private readonly LabRunner _labRunner;

        public ProgramController()
        {
            _labRunner = new LabRunner();
        }

        // Сторінка для Lab1
        [HttpGet]
        public IActionResult RunLab1()
        {
            return View("~/Views/Labs/RunLab1.cshtml");
        }

        [HttpPost]
        public IActionResult RunLab1(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                // Зберігаємо завантажений файл на сервері
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                // Викликаємо метод з LabsLibrary для обробки файлу
                string outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "outputLab1.txt");
                _labRunner.RunLab1(filePath, outputFilePath);

                // Читаємо результат і передаємо на представлення
                string result = System.IO.File.ReadAllText(outputFilePath);
                ViewData["Result"] = result;
            }

            return View();
        }

        // Аналогічно для RunLab2 та RunLab3
        [HttpGet]
        public IActionResult RunLab2()
        {
            return View("~/Views/Labs/RunLab2.cshtml");
        }

        [HttpPost]
        public IActionResult RunLab2(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                string outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "outputLab2.txt");
                _labRunner.RunLab2(filePath, outputFilePath);

                string result = System.IO.File.ReadAllText(outputFilePath);
                ViewData["Result"] = result;
            }

            return View();
        }

        [HttpGet]
        public IActionResult RunLab3()
        {
            return View("~/Views/Labs/RunLab3.cshtml");
        }

        [HttpPost]
        public IActionResult RunLab3(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                string outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "outputLab3.txt");
                _labRunner.RunLab3(filePath, outputFilePath);

                string result = System.IO.File.ReadAllText(outputFilePath);
                ViewData["Result"] = result;
            }

            return View();
        }
    }
}
