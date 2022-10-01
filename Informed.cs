using System.Collections;

class Informed : Exploration {

    public Informed(int numberOfRows, int numberOfColumns) : base(numberOfRows,numberOfColumns) {
            
    }

    override public ArrayList Explore(ArrayList cellsToCollect, ArrayList cellsToSuck, int [] cell){
        Console.WriteLine("explore informed");
        return new ArrayList();
    }
}
