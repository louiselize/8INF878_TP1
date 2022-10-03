using System.Collections;

public abstract class Exploration {

    protected int numberOfRows;
    protected int numberOfColumns;
    protected int numberOfActions = -1;
    protected int millisecondsToWait = 2000;
    protected int numberOfIterationsToLearn = 3;

    public Exploration(int numberOfRows, int numberOfColumns){
        this.numberOfRows = numberOfRows;
        this.numberOfColumns = numberOfColumns;
    }
   
    public abstract ArrayList Explore(ArrayList cellsToCollect, ArrayList cellsToSuck, int [] cell);

    //for a cell given, return its neighbours
    public ArrayList Neighbour(int [] cell){
        ArrayList neighbourList = new ArrayList();
        if(cell[0]>0){
            int [] neighbour = new int[2];
            neighbour[0] = cell[0] - 1;
            neighbour[1] = cell[1];
            neighbourList.Add(neighbour);
        }

        if(cell[1]>0){
            int [] neighbour = new int[2];
            neighbour[0] = cell[0];
            neighbour[1] = cell[1] - 1;
            neighbourList.Add(neighbour);
        }

        if(cell[0] < numberOfRows - 1){
            int [] neighbour = new int[2];
            neighbour[0] = cell[0] + 1;
            neighbour[1] = cell[1];
            neighbourList.Add(neighbour);
        }

        
        if(cell[1] < numberOfColumns - 1){
            int [] neighbour = new int[2];
            neighbour[0] = cell[0];
            neighbour[1] = cell[1] + 1;
            neighbourList.Add(neighbour);
        }

        return neighbourList;
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

    public int GetNumberOfActions(){
        return numberOfActions;
    }
    
    public void SetNumberOfActions(int numberOfActions){
        this.numberOfActions = numberOfActions;
    }

    public int GetMillisecondsToWait(){
        return millisecondsToWait;
    }
    
    public void SetMillisecondsToWait(int millisecondsToWait){
        this.millisecondsToWait = millisecondsToWait;
    }

    public int GetNumberOfIterationsToLearn(){
        return numberOfIterationsToLearn;
    }
    
    public void SetNumberOfIterationsToLearn(int numberOfIterationsToLearn){
        this.numberOfIterationsToLearn = numberOfIterationsToLearn;
    }
}