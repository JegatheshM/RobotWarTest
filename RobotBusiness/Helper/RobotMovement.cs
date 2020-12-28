using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotBusiness.Model;

namespace RobotBusiness.Helper
{
    public class RobotMovement
    {
        int pCount = 0;

        public enum Directions
        {
            N,
            E,
            S,
            W
        };

        private int robotXPosition;
        private int robotYPosition;
        private int robotDirection;
        public RobotMovement()
        {
            Initialize();
        }

        private void Initialize()
        {
            robotXPosition = 0;
            robotYPosition = 0;
            robotDirection = 0;
        }
        public void PlaceRobot(int xPosition, int yPosition, int direction)
        {
            robotXPosition = xPosition;
            robotYPosition = yPosition;
            robotDirection = direction;
        }

        public void MoveForward(RobotSquare robotSquare)
        {
            switch (robotDirection)
            {
                case (int)Directions.N:
                    MoveTowardsNorth(robotSquare);
                    break;
                case (int)Directions.E:
                    MoveTowardsEast(robotSquare);
                    break;
                case (int)Directions.S:
                    MoveTowardsSouth(robotSquare);
                    break;
                case (int)Directions.W:
                    MoveTowardsWest(robotSquare);
                    break;
            }
        }

        public void Rotate(string direction)
        {
            switch (direction)
            {
                case "LEFT":
                    robotDirection = (robotDirection == 0 ? 3 : robotDirection - 1);
                    break;
                case "RIGHT":
                    robotDirection = (robotDirection == 3 ? 0 : robotDirection + 1);
                    break;
            }
        }

        

        private void MoveTowardsNorth(RobotSquare robotSquare)
        {
            if (robotYPosition + 1 < robotSquare.RowCount)
            {
                robotYPosition++;
            }
        }

        private void MoveTowardsEast(RobotSquare robotSquare)
        {
            if (robotXPosition + 1 < robotSquare.ColumnCount)
            {
                robotXPosition++;
            }

        }

        private void MoveTowardsSouth(RobotSquare robotSquare)
        {
            if (robotYPosition > 0)
            {
                robotYPosition--;
            }
        }

        private void MoveTowardsWest(RobotSquare robotSquare)
        {
            if (robotXPosition > 0)
            {
                robotXPosition--;
            }
        }


        private static int GetDirectionIndex(string direction)
        {
            return (int)Enum.Parse(typeof(RobotMovement.Directions), direction);
        }
        public FinalPositionModel PlaceRobotOnTable(RobotSquare table, RobotMovement robot, string startPosition,string inputInstruction)
        {
            FinalPositionModel finalPos = new FinalPositionModel();

            string[] placeArgs = startPosition.Split(',');
            int xPosition = Convert.ToInt16(placeArgs[0]);
            int yPosition = Convert.ToInt16(placeArgs[1]);
            int direction = GetDirectionIndex(placeArgs[2]);

            if (table.IsPositionExists(xPosition, yPosition))
            {
                PlaceRobot(xPosition, yPosition, direction);

                StartMoving(robot, table, inputInstruction);
            }
            else
                pCount++;


            string FinalDir = robotDirection == 0 ? "N" : robotDirection == 1 ? "E" : robotDirection == 2 ? "S" : "W";

            finalPos.Position = "Final Position: (" + robotXPosition + ", " + robotYPosition + "," + FinalDir + ")";

            finalPos.Penality =  pCount;

            return finalPos;


        }

        /// Robot starts moving on the table
        private static void StartMoving(RobotMovement robot, RobotSquare table, string inputCommand)
        {
            char[] inputchar = new char[inputCommand.Length];
            inputchar = inputCommand.ToCharArray();
            foreach (char c in inputchar)
            {
                switch (c)
                {
                    case 'M':
                        robot.MoveForward(table);
                        break;
                    case 'L':
                        robot.Rotate("LEFT");
                        break;
                    case 'R':
                        robot.Rotate("RIGHT");
                        break;
                }
            }
        }
       
    }
}
