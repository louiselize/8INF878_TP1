using System.Collections;

public abstract class Exploration {

    protected int numberOfRows;
    protected int numberOfColumns;

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
}