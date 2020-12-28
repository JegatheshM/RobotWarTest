using RobotBusiness.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotBusiness.Model;
using RobotBusiness.Helper;

namespace RobotBusiness.Implementation
{
    public class FindPositionBo : IFindPositionBo
    {

        //This Find used to find the Robot Final Positions
        public FinalPositionModel FindFinalPositions(string InitialPosition, string Instruction)
        {
            RobotMovement robotMov = new RobotMovement();
            RobotSquare sqauretable = new RobotSquare(5, 5);
            FinalPositionModel _finalPos = new FinalPositionModel();

            _finalPos = robotMov.PlaceRobotOnTable(sqauretable, robotMov, InitialPosition, Instruction);

            return _finalPos;

        }

    }
}
