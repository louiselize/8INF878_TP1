
public class Map
    {

        private Dictionary<String, bool>[][] map;
      
        private int robotPosX;
        private int robotPosY;
        private int numberOfRows;  
        private int numberOfColumns;

        public Map(int numberOfRows, int numberOfColumns, int robotPosX, int robotPosY) {
            //Map initialisation
            map = new Dictionary<String, bool>[numberOfRows][];
            this.robotPosX = robotPosX;
            this.robotPosY = robotPosY;
            this.numberOfRows = numberOfRows;
            this.numberOfColumns = numberOfColumns;

            for (int i = 0; i < numberOfRows; ++i)
            {
                map[i] = new Dictionary<String, bool>[numberOfColumns];
                for (int j = 0; j < numberOfColumns; ++j){
                    map[i][j] = new Dictionary<String, bool>
                    {
                        {Items.Dirt, false},
                        {Items.Jewel, false},
                        {Items.Robot, false}, //COMM: GROS ATTENTION JE SUIS PAS SUR DE MEN SERVIR !!!!! et je men suis pas servi partout ça va peut être dégagé et il y aura juste les variable posx et posy

                    };
                } 
            }
            
            map[robotPosX][robotPosY][Items.Robot] = true;
        }

        //Displaying the Map
        public void DisplayMap(){
            string row;
            bool isDirt;
            bool isJewel;

            for (int i = 0; i < map.Length; ++i)
            {
                row ="";

                for (int j = 0; j < map[i].Length; ++j)
                {
                        
                    isDirt = false;
                    isJewel = false;

                    foreach(var kvp in map[i][j]){
                        
                        if(kvp.Key == Items.Dirt && map[i][j][Items.Dirt]){
                            isDirt = true;
                        }
                        if(kvp.Key == Items.Jewel && map[i][j][Items.Jewel]){
                            isJewel = true;
                        }
                    }

                    if(i==robotPosX && j==robotPosY){
                        row += "R ";
                    }

                    else if(isDirt && isJewel){
                        row += "B ";
                    }

                    else if (isDirt){
                        row += "D ";
                    }
                    
                    else if (isJewel){
                        row += "J ";
                    }

                    else {
                        row += "E ";
                    }

                }     

                Console.WriteLine(row);

            }

            Console.WriteLine("---------------");
            Console.WriteLine();
            
        }

    //Suck : +1 if it was Dirt, -1 if it was empty, -2 if it sucks Jewel
        public int Suck(int row, int column){
            foreach(var kvp in map[row][column]){
                    
                //if Robot sucks Jewel, decrease performance 
                if(kvp.Key == Items.Jewel && map[row][column][kvp.Key]){
                    map[row][column][kvp.Key] = false;
                    return -2;
                }

                //if Robot sucks Dirt, increase performance 
                else if(kvp.Key == Items.Dirt && map[row][column][kvp.Key]){
                    map[row][column][kvp.Key] = false;
                    return 1;
                }
            } 

            return -1; // if empty 
        }

        //Collect, +1 if it was Jewel, else -1
        public int Collect(int row, int column){
            foreach(var kvp in map[row][column]){
                    
                //if Robot collect Jewel, increase performance 
                if(kvp.Key == Items.Jewel && map[row][column][kvp.Key]){
                    map[row][column][kvp.Key] = false;
                    return 1;

                }
            } 

            return -1;                   
        }

        //COMM: jsp si on diminue la perf quand on demande d'aller a gauche alors quon peut pas ou quoi
        public bool Left(){
            if(robotPosY>0){
                robotPosY--;
                return true;
            }
            return false;
        }

        public bool Right(){
            if(robotPosY<numberOfColumns-1){
                robotPosY++;
                return true;
            }
            return false;
        }


        public bool Up(){
            if(robotPosX>0){
                robotPosX--;
                return true;
            }
            return false;
        }

        
        public bool Down(){
            if(robotPosX<numberOfRows-1){
                robotPosX++;
                return true;
            }
            return false;
        }


        //return false if contains Jewel or Dirt
        public bool IsMapClean(){
            for (int i = 0; i < map.Length; ++i)
            {
                for (int j = 0; j < map[i].Length; ++j)
                {
                    foreach(var kvp in map[i][j]){
                        if(kvp.Key != Items.Robot && map[i][j][kvp.Key]){
                            return false;
                        }
                    } 
                }
            }
            return true;
        }

        public void Neighbour(int [] cell){
            
        }


        public Dictionary<String, bool>[][] GetMap(){
            return map;
        }

        public Dictionary<String, bool> GetCell(int row, int column){
            return map[row][column];
        }
        
        public int GetNumberOfRows(){
            return numberOfRows;
        }

        public int GetNumberOfColumns(){
            return numberOfColumns;
        }

        public int GetRobotXPosition(){
            return robotPosX;
        }

        public int GetRobotYPosition(){
            return robotPosY;
        }

        public void SetMap(Dictionary<String, bool>[][] map){
            this.map = map;
        }

        public void SetMap(int row, int column, String item, bool value){
            map[row][column][item] = value;
        }


    }