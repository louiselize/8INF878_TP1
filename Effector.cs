using System.Collections;
using System.Threading;

class Effector
    {
        public void DoAction(ArrayList path, ArrayList cellsToCollect, ArrayList cellsToSuck, Environment ev, int numberOfActions, int millisecondsToWait){
            foreach(int [] cellInPath in path){

                if(numberOfActions < 0|| (ev.GetRobotXPosition()!=cellInPath[0] && ev.GetRobotYPosition()!=cellInPath[1])){
                    int [] robotCell = new int [2] {ev.GetRobotXPosition(),ev.GetRobotYPosition()};

                //Move the robot
                if(isTheCellAToTheLeftOfCellB(robotCell,cellInPath)){
                    Console.WriteLine("Effector : Robot, go RIGHT!");
                    ev.GetMap().Right();
                    ev.SetPerformance(ev.GetPerformance()-1); 
                }

                
                else if(isTheCellAToTheRightOfCellB(robotCell,cellInPath)){
                    Console.WriteLine("Effector : Robot, go LEFT!");
                    ev.GetMap().Left();
                    ev.SetPerformance(ev.GetPerformance()-1); 
                }

                
                else if(isTheCellAAboveCellB(robotCell,cellInPath)){
                    Console.WriteLine("Effector : Robot, go DOWN!");
                    ev.GetMap().Down();
                    ev.SetPerformance(ev.GetPerformance()-1);
                }

                
                else if(isTheCellABelowCellB(robotCell,cellInPath)){
                    Console.WriteLine("Effector : Robot, go UP!");
                    ev.GetMap().Up();                    
                    ev.SetPerformance(ev.GetPerformance()-1);
                }

                ev.GetMap().DisplayMap();

                numberOfActions--;

                if(numberOfActions==0){
                    return;
                }

                //verification with cells to COLLECT
                foreach(int [] cellToCollect in cellsToCollect){
                    if(cellToCollect[0] == cellInPath[0] && cellToCollect[1] == cellInPath[1]){
                        Console.WriteLine("Effector : Robot, COLLECT cell (" + cellInPath[0] + "," + cellInPath[1] + ") !");
                        ev.GetMap().Collect(cellInPath[0],cellInPath[1]); 
                        ev.SetPerformance(ev.GetPerformance()-1);
                        ev.GetMap().DisplayMap();
                        cellToCollect[0]=-1;
                        cellToCollect[1]=-1;
                        numberOfActions--;
                        if(numberOfActions==0){
                            return;
                        }
                    }
                } 


                //verification with cells to SUCK
                foreach(int [] cellToSuck in cellsToSuck){
                    if(cellToSuck[0] == cellInPath[0] && cellToSuck[1] == cellInPath[1]){
                        Console.WriteLine("Effector : Robot, SUCK cell (" + cellInPath[0] + "," + cellInPath[1] + ") !");
                        ev.GetMap().Suck(cellInPath[0],cellInPath[1]); 
                        ev.SetPerformance(ev.GetPerformance()-1);
                        ev.GetMap().DisplayMap();
                        cellToSuck[0]=-1;
                        cellToSuck[1]=-1;
                        if(numberOfActions==0){
                            return;
                        }

                    }
                }

                Thread.Sleep(millisecondsToWait); 

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