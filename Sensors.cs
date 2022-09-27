using System.Collections;


public class Sensors  
     {  
       private ArrayList cellsToSuck;
       private ArrayList cellsToCollect;

       public Sensors(){
       }

        //Add cells to suck and to collect in an array
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

        public ArrayList GetCellToCollect(){
            return cellsToCollect;
        }

        
        public ArrayList GetCellToSuck(){
            return cellsToSuck;
        }
     }