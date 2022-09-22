using System.Collections;


public class Sensors  
     {  
       public ArrayList cellsToSuck;
       public ArrayList cellsToCollect;

       public Sensors(){
       }

        public void Observe(Map map){
            Dictionary<String, bool>[][] board = map.GetMap();
            
            cellsToSuck = new ArrayList();
            cellsToCollect = new ArrayList();
            
            for (int i = 0; i < board.Length; ++i)
            {
                for (int j = 0; j < board[i].Length; ++j)
                {
                    foreach(var kvp in board[i][j]){ 
                        int[] cell = new int[2];
                        if(kvp.Key == Items.Dirt && board[i][j][Items.Dirt]){
                            cell[0] = i;
                            cell[1] = j;
                            cellsToSuck.Add(cell);
                        }
                        
                        if(kvp.Key == Items.Jewel && board[i][j][Items.Jewel]){
                            cell[0] = i;
                            cell[1] = j;
                            cellsToCollect.Add(cell);
                        }
                    }
                }
            }
        }

     }