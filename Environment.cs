using System.Collections.Generic;
using System;

/*
L’environnement dans lequel évolue l’agent Aspirobot T-0.1 sera constitué d’une carte
contenant 25 pièces disposées telles qu’illustrées ci-dessous. Tel que défini au cours,
l’environnement devrait contenir tous les éléments passifs de votre programme (carte,
poussière, bijoux, etc.). L’environnement devrait aussi contenir minimalement une mesure de
performance que l’agent peut consulter (via ses capteurs). L’environnement devrait être une
boucle infinie (ou encore un événement programmé pour s’exécuter sporadiquement) qui
aléatoirement génère soit de la poussière dans une case aléatoire ou encore un bijou. C’est à
vous de décider des probabilités. Une case peut contenir à la fois de la poussière et un bijou.
*/


public static class Items {
    //Apparemment enum ça n existe pas en C#
    public const string Dirt = "DIRT";
    public const string Jewel = "JEWEL";
    public const string Robot = "ROBOT";
}

public class Environment
    {
        const int NUMBER_ROWS = 5;
        const int NUMBER_COLUMNS = 5;
        const double DIRT_PERCENTAGE  = 0.1;

        private int robotPosX = 0;
        private int robotPosY = 0;
        private int performance = 0;
        

        private Map map;

        public Environment(){
            map = new Map(NUMBER_ROWS, NUMBER_COLUMNS, robotPosX, robotPosY);
        }


        
        //Choose which item to generate
        public void Generate(){
            Random rd = new Random();
            bool cellChosen = false;
            
            while(!cellChosen){
                double i = rd.Next(100);
                if(i<=DIRT_PERCENTAGE*100){
                    cellChosen = GenerateItems(Items.Dirt);
                }

                else{
                    cellChosen = GenerateItems(Items.Jewel);
                }
            }
           
        }

        //Generate item on map
        public bool GenerateItems(String item){

            Random rd = new Random();
            int i;
            int j;

            i = rd.Next(NUMBER_ROWS);
            j = rd.Next(NUMBER_COLUMNS);
           
            bool value;
            if(map.GetCell(i,j).TryGetValue(item, out value)){
                if(!value){
                        map.SetMap(i,j,item,true);
                        Console.WriteLine(item + " case " + i + " " + j);
                        map.DisplayMap();
                        return true;
                    }
                }
   
            return false;
                
        }

        public Map GetMap(){
            return map;
        }

        
        public int GetRobotXPosition(){
            return robotPosX;
        }

        public void SetRobotXPosition(int X){
            robotPosX = X;
        }

        public int GetRobotYPosition(){
            return robotPosY;
        }

        public void SetRobotYPosition(int Y){
            robotPosY = Y;
        }

        public int GetPerformance(){
            return performance;
        }

        public void SetPerformance(int performance){
            performance = performance;
        }
        

    
}