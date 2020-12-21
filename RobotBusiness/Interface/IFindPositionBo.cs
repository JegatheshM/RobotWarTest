using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotBusiness.Model;

namespace RobotBusiness.Interface
{
    public interface IFindPositionBo
    {
        FinalPositionModel FindFinalPositions(string InitialPosition, string Instruction);
    }
}
