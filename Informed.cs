using System.Collections;
using System;

class Informed : Exploration {

    public Informed(int numberOfRows, int numberOfColumns) : base(numberOfRows,numberOfColumns) {
            
    }

    override public ArrayList Explore(ArrayList cellsToCollect, ArrayList cellsToSuck, int [] cell){
        
        ArrayList pathList = new ArrayList();
        pathList.Add(cell);

        ArrayList cellsToCollectCopy = new ArrayList(cellsToCollect);
        ArrayList cellsToSuckCopy = new ArrayList(cellsToSuck);

        return FindPath(pathList, cellsToCollectCopy, cellsToSuckCopy);

    }


    public ArrayList FindPath(ArrayList pathList, ArrayList cellsToCollect, ArrayList cellsToSuck){
        
        if(cellsToCollect.Count == 0 && cellsToSuck.Count == 0){
            return pathList;
        }

        int [] lastCell = LastCell(pathList);
        
        ArrayList pathBetweenActualCellAndNextOne = new ArrayList();
        pathBetweenActualCellAndNextOne = GreedySearch(lastCell,cellsToCollect,cellsToSuck);

        foreach(int [] cell in pathBetweenActualCellAndNextOne){
            pathList.Add(cell);
        }

        return FindPath(pathList,cellsToCollect,cellsToSuck);

    }

    public ArrayList GreedySearch(int [] cell, ArrayList cellsToCollect, ArrayList cellsToSuck){
       
            ArrayList neighbourList = Neighbour(cell); 
            ArrayList path = new ArrayList();
            int [] nearestCellToCollectOrSuck = NearestCellToCollectOrSuck(cell,cellsToCollect,cellsToSuck);
            int [] cellToAddInPath = new int [2];
            int smallestDistance = -1;
            bool nodeReached = false;

            cellsToCollect.Remove(nearestCellToCollectOrSuck);
            cellsToSuck.Remove(nearestCellToCollectOrSuck);

            //Console.WriteLine("Cells to suck or collect : " + nearestCellToCollectOrSuck[0] + " " + nearestCellToCollectOrSuck[1]);
            
            if(cell[0]==nearestCellToCollectOrSuck[0] && cell[1]==nearestCellToCollectOrSuck[1]){
                path.Add(cell);
                return path;
            }
              
            while(!nodeReached){
                
                foreach(int [] neighbourCell in neighbourList){            
                    if(smallestDistance==-1||ManhattanDistance(nearestCellToCollectOrSuck,neighbourCell)<smallestDistance){
                        cellToAddInPath = neighbourCell;
                        smallestDistance = ManhattanDistance(nearestCellToCollectOrSuck,neighbourCell);
                    }         
                }

                path.Add(cellToAddInPath);
                neighbourList = Neighbour(cellToAddInPath);

                if(cellToAddInPath[0]==nearestCellToCollectOrSuck[0] && cellToAddInPath[1]==nearestCellToCollectOrSuck[1]){
                    nodeReached = true;
                }
            }
             

        return path;
    }

    public int ManhattanDistance(int [] cellA, int [] cellB){
        return Math.Abs(cellB[0] - cellA[0]) + Math.Abs(cellB[1] - cellA[1]);
    }

    public int [] NearestCellToCollectOrSuck(int [] cell, ArrayList cellsToCollect, ArrayList cellsToSuck){
        int smallestDistance = -1;
        int [] nearestCellToCollectOrSuck = new int [2];
        
        foreach(int [] cellToCollect in cellsToCollect){ 
        //Console.WriteLine("manathan de (" + cell[0] + " " + cell[1] + ") et (" + cellToCollect[0] + " " + cellToCollect[1] + ") : " + ManhattanDistance(cell,cellToCollect));
            if(smallestDistance==-1||ManhattanDistance(cell,cellToCollect)<smallestDistance){
                nearestCellToCollectOrSuck = cellToCollect;
                smallestDistance = ManhattanDistance(cell,cellToCollect); 
            }
        }

        foreach(int [] cellToSuck in cellsToSuck){
            if(smallestDistance==-1||ManhattanDistance(cell,cellToSuck)<smallestDistance){
                nearestCellToCollectOrSuck = cellToSuck;
                smallestDistance = ManhattanDistance(cell,cellToSuck); 
            }
        }

        return nearestCellToCollectOrSuck;
    }



}
