using RobotBusiness.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotBusiness.Model;

namespace RobotBusiness.Implementation
{
    public class FindPositionBo : IFindPositionBo
    {

        //This Find used to find the Robot Final Positions
        public FinalPositionModel FindFinalPositions(string InitialPosition, string Instruction)
        {

            string[] InitialPos = InitialPosition.Split(',');

            int start = InitialPosition[0];

            string Movement = InitialPosition[2].ToString();

            string MovementInstruction = Instruction;

            FinalPositionModel finalPos = new FinalPositionModel();
            int pcnt = 0;
            int length = MovementInstruction.Length;
            int countNorth = 0, countSouth = 0;
            int countLeft = 0, countRight = 0;

            for (int i = start; i < length; i++)
            {
                if (MovementInstruction[i] == 'N')
                    countNorth++;

                else if (MovementInstruction[i] == 'S')
                    countSouth++;

                else if (MovementInstruction[i] == 'L')
                    countLeft++;

                else if (MovementInstruction[i] == 'R')
                    countRight++;

                finalPos.Penality = !isPenality(i, length,  MovementInstruction ) ? pcnt : pcnt++;


            }

            finalPos.Position = "Final Position: (" + (countRight - countLeft) + ", " + (countNorth - countSouth) + ")";

            return finalPos;

        }


        // Thsi function will returns boolean value. if position is right then true else false.
        bool isPenality(int N, int M, string str)
        {

            int coll = 0, colr = 0, rowu = 0, rowd = 0;

            for (int i = 0; i < str.Length; i++)
            {

                // If current move is "Left" then increase the counter of coll 
                if (str[i] == 'L')
                {
                    coll++;
                    if (colr > 0)
                    {
                        colr--;
                    }

                    if (coll == M)
                    {
                        break;
                    }
                }

                // If current move is "Right" then increase the counter of colr 
                else if (str[i] == 'R')
                {
                    colr++;
                    if (coll > 0)
                    {
                        coll--;
                    }

                    if (colr == M)
                    {
                        break;
                    }
                }

                // If current move is "North" then ncrease the counter of rowu 
                else if (str[i] == 'N')
                {
                    rowu++;
                    if (rowd > 0)
                    {
                        rowd--;
                    }

                    if (rowu == N)
                    {
                        break;
                    }
                }

                // If current move is "South" then increase the counter of rowd 
                else if (str[i] == 'S')
                {
                    rowd++;
                    if (rowu > 0)
                    {
                        rowu--;
                    }
                    if (rowd == N)
                    {
                        break;
                    }
                }
            }

            // If robot is within the bounds of the grid 
            if (Math.Abs(rowd) < N && Math.Abs(rowu) < N
                && Math.Abs(coll) < M && Math.Abs(colr) < M)
            {
                return true;
            }

            //Penality 
            return false;
        }

    }
}
