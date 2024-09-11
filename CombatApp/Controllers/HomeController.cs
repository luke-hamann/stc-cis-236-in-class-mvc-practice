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
            Enemy.HP = 99;
            Enemy.Attack = 99;
            Enemy.Defense = 99;
            if (Protag.Combat(Enemy) == 0)
            {
                ViewBag.Win = true;
            }
            else
            {
                ViewBag.Win = false;
            }
            return View(Protag);
        }
    }
}
