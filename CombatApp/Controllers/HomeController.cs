using CombatApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CombatApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var protag = new Character();
            ViewBag.Win = true;
            protag.HP = 15;
            protag.SkillPoints = 10;
            return View(protag);
        }

        [HttpPost]
        public IActionResult Index(Character Protag)
        {
            Protag.SkillPoints += 1;
            Protag.Level += 1;

            var Enemy = new Character();
            Enemy.HP = Protag.Level;
            Enemy.Attack = Protag.Level;
            Enemy.Defense = Protag.Level;

            ViewBag.Win = (Protag.Combat(Enemy) == 0);
            System.Console.WriteLine(Protag.Level);
            return View(Protag);
        }
    }
}
