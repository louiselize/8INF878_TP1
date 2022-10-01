using System.Collections;

class Uninformed : Exploration {

    public Uninformed(int numberOfRows, int numberOfColumns) : base(numberOfRows,numberOfColumns) {
            
    }

    override public ArrayList Explore(ArrayList cellsToCollect, ArrayList cellsToSuck, int [] cell){
        
        ArrayList pathList = new ArrayList();
        ArrayList path = new ArrayList();
        path.Add(cell);
        pathList.Add(path);
        return PossiblePath(pathList, cellsToCollect, cellsToSuck);

    }

    /*  
        This method creates the tree of possible path and stops when it finds a line with all the cells to collect and suck 
        possiblePathList  = array of possible path, ex : [[(1,0),(1,1),(1,2)],[(1,0),(0,0),(0,1)]];
        path = one of the possible path in possiblePathList, ex : [(1,0),(1,1),(1,2)];
        neighbourList = neighbour of the last cell of the path array (here, last cell is (1,2), then neighbourList is [(1,1),(1,3),(0,2),(2,2)])
    */
    public ArrayList PossiblePath(ArrayList pathList, ArrayList cellsToCollect, ArrayList cellsToSuck){
        
        ArrayList possiblePathList = new ArrayList();
        
        foreach(ArrayList path in pathList){
            int [] lastCell = LastCell(path);
            ArrayList neighbourList = Neighbour(lastCell); 
                
            foreach(int [] neighbourCell in neighbourList){
                    ArrayList newPath = new ArrayList();
                    
                    foreach(int [] cell in path){
                        //copy the cell of the previous path in a new ArrayList
                        newPath.Add(new int [2] {cell[0],cell[1]});
                    }

                    //Add the neighbour in the end of this new ArrayList
                    newPath.Add(new int [2] {neighbourCell[0],neighbourCell[1]});
                    possiblePathList.Add(newPath);
                    if(isAllCellsToCollectAndSuckInAPath(newPath,cellsToCollect,cellsToSuck)){
                        return newPath;
                    }
                        
                }
            }

             //display the array
            /*foreach(ArrayList cellList in possiblePathList){
                Console.WriteLine("----------");

                    foreach(int [] cell in cellList){
                        Console.WriteLine("last cell " + cell[0] + cell[1]);
                    } 
                    Console.WriteLine("----------");   

            }*/

            return PossiblePath(possiblePathList, cellsToCollect, cellsToSuck);

        }

        //return the last cell of an array
        public int [] LastCell(ArrayList arrayList){
            int index = 0;
            int [] lastCell = new int [2];

            foreach(int [] cell in arrayList){
                    if(index==arrayList.Count-1){
                        lastCell = cell;
                        //Console.WriteLine("last cell " + lastCell[0] + lastCell[1]);
                    }
                    index ++;
            }

            return lastCell;
        }

        public bool isAllCellsToCollectAndSuckInAPath(ArrayList path, ArrayList cellsToCollect, ArrayList cellsToSuck){
            bool isCellTheSame;

            //verification with cells to COLLECT
            foreach(int [] cellToCollect in cellsToCollect){
                isCellTheSame = false;
                foreach(int [] cellInPath in path){
                    if(cellToCollect[0] == cellInPath[0] && cellToCollect[1] == cellInPath[1]){
                        isCellTheSame = true;
                    }
                }
                if(!isCellTheSame){
                    return false;
                }
            } 


            //verification with cells to SUCK
            foreach(int [] cellToSuck in cellsToSuck){
                isCellTheSame = false;
                foreach(int [] cellInPath in path){
                    if(cellToSuck[0] == cellInPath[0] && cellToSuck[1] == cellInPath[1]){
                        isCellTheSame = true;
                    }
                }
                if(!isCellTheSame){
                    return false;
                }
            }

            return true;
        }

              



}
