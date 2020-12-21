using RobotBusiness.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RobotBusiness.Model;

namespace RobotWarTest.Controllers
{
    public class HomeController : Controller
    {

        private IFindPositionBo _IFindPositionBo;

        public HomeController(IFindPositionBo FindPositionBo)
        {
            _IFindPositionBo = FindPositionBo;
        }
       
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult FindPosition(FinalPositionModel finalposition)
        {
            string InitialPosition = finalposition.InitialPosition;
            string Instruction = finalposition.Position;
            var Position = _IFindPositionBo.FindFinalPositions(InitialPosition,Instruction);

            return View(Position);
        }
    }
}