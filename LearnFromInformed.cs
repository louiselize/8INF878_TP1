using System.Collections;
using System;

class LearnFromInformed : Exploration {

    private ArrayList performanceData;
    private int endOfLearning = 6;

    public LearnFromInformed(int numberOfRows, int numberOfColumns) : base(numberOfRows,numberOfColumns) {
        this.numberOfActions = 1;
        this.millisecondsToWait = 10000;
        performanceData = new ArrayList();
    }

    override public ArrayList Explore(ArrayList cellsToCollect, ArrayList cellsToSuck, int [] cell){
        Informed informed = new Informed(numberOfRows,numberOfColumns);
        return informed.Explore(cellsToCollect,cellsToSuck,cell);

    }

    public void UpdatePerformanceData(int value){
        performanceData.Add(value);
    }

    public int CountItemsInPerformanceData(){
        return performanceData.Count;
    }

    public void DisplayPerformanceData(){
        String line = "";
        foreach(int value in performanceData){
                line+=value + " ";
        }

        Console.WriteLine(line);
    
    }

    public int GetEndOfLearning(){
        return endOfLearning;
    }


}