using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWarTest;
using RobotWarTest.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using RobotBusiness.Implementation;
using RobotBusiness.Interface;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace RobotWarTest.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private IFindPositionBo _FindpositionBoSubstitute;
        public HomeController InitializeSut()
        {
            _FindpositionBoSubstitute = Substitute.For<IFindPositionBo>();

            return new HomeController(_FindpositionBoSubstitute);
        }

        [TestMethod]
        public void Index()
        {
            var sut = InitializeSut();
            // Act
            ViewResult result = sut.About() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

    }
}
