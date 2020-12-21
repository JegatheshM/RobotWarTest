using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RobotWarTest.Models
{
    public class FinalPositionModel
    {
        public string InitialPosition { get; set; }
        public string Position { get; set; }
        public int Penality { get; set; }
        public string FinalPosition { get; set; }
    }
}