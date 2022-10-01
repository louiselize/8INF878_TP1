using System.Collections;

class Effector
    {
        public void DoAction(ArrayList path, ArrayList cellsToCollect, ArrayList cellsToSuck, Environment ev){
            foreach(int [] cellInPath in path){

                int [] robotCell = new int [2] {ev.GetRobotXPosition(),ev.GetRobotYPosition()};

                //Move the robot
                if(isTheCellAToTheLeftOfCellB(robotCell,cellInPath)){
                    Console.WriteLine("Sensor : Robot, go RIGHT!");
                    ev.GetMap().Right();
                }

                
                if(isTheCellAToTheRightOfCellB(robotCell,cellInPath)){
                    Console.WriteLine("Sensor : Robot, go LEFT!");
                    ev.GetMap().Left();
                }

                
                if(isTheCellAAboveCellB(robotCell,cellInPath)){
                    Console.WriteLine("Sensor : Robot, go DOWN!");
                    ev.GetMap().Down();
                }

                
                if(isTheCellABelowCellB(robotCell,cellInPath)){
                    Console.WriteLine("Sensor : Robot, go UP!");
                    ev.GetMap().Up();
                }

                ev.GetMap().DisplayMap();

                //verification with cells to COLLECT
                foreach(int [] cellToCollect in cellsToCollect){
                    if(cellToCollect[0] == cellInPath[0] && cellToCollect[1] == cellInPath[1]){
                        Console.WriteLine("Sensor : Robot, COLLECT cell (" + cellInPath[0] + "," + cellInPath[1] + ") !");
                        ev.GetMap().Collect(cellInPath[0],cellInPath[1]); 
                        ev.GetMap().DisplayMap();
                    }
                } 


                //verification with cells to SUCK
                foreach(int [] cellToSuck in cellsToSuck){
                    if(cellToSuck[0] == cellInPath[0] && cellToSuck[1] == cellInPath[1]){
                        Console.WriteLine("Sensor : Robot, SUCK cell (" + cellInPath[0] + "," + cellInPath[1] + ") !");
                        ev.GetMap().Suck(cellInPath[0],cellInPath[1]); 
                        ev.GetMap().DisplayMap();

                    }
                }

            }
        }

        public bool isTheCellAToTheLeftOfCellB(int [] cellA, int [] cellB){
            return cellA[1] == (cellB[1]-1);
        }

        public bool isTheCellAToTheRightOfCellB(int [] cellA, int [] cellB){
            return cellA[1] == (cellB[1]+1);
        }

        public bool isTheCellAAboveCellB(int [] cellA, int [] cellB){
            return cellA[0] == (cellB[0]-1);
        }

        public bool isTheCellABelowCellB(int [] cellA, int [] cellB){
            return cellA[0] == (cellB[0]+1);
        }
    
    
    }