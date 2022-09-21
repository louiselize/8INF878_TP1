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
}

public class Environment
    {
        const int NUMBER_ROWS = 5;
        const int NUMBER_COLUMNS = 5;
        const double DIRT_PERCENTAGE  = 0.8;
        //const double JEWEL_PERCENTAGE = 1 - DIRT_PERCENTAGE;

        private Dictionary<String, bool>[][] map = new Dictionary<String, bool>[NUMBER_ROWS][];

        public Environment(){
            //Map initialisation
            for (int i = 0; i < NUMBER_ROWS; ++i)
            {
                map[i] = new Dictionary<String, bool>[NUMBER_COLUMNS];
                for (int j = 0; j < NUMBER_COLUMNS; ++j){
                    map[i][j] = new Dictionary<String, bool>
                    {
                        {Items.Dirt, false},
                        {Items.Jewel, false},
                    };
                }
            }
        }

        public Dictionary<String, bool>[][] getMap(){
            return map;
        }

        //Displaying the Map
        public void displayMap(){
            string row;
            bool isDirt;
            bool isJewel;

            for (int i = 0; i < NUMBER_ROWS; ++i)
            {
                row ="";

                for (int j = 0; j < NUMBER_COLUMNS; ++j)
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

                    if(isDirt && isJewel){
                        row += "B ";
                    }

                    else if (isDirt){
                        row += "D ";
                    }
                    
                    else if (isJewel){
                        row += "J ";
                    }
                    //prevoir robot quand on saura comment on l'instancie sur la map

                    else {
                        row += "E ";
                    }

                }     

                Console.WriteLine(row);

            }
            
            Console.WriteLine();    
            Console.WriteLine();    

        }

        //Choose which items to generate
        public void generate(){
            Random rd = new Random();
            bool cellChosen = false;
            
            while(!cellChosen){
                double i = rd.Next(100);
                if(i<=DIRT_PERCENTAGE*100){
                    cellChosen = generateItems(Items.Dirt);
                }

                else{
                    cellChosen = generateItems(Items.Jewel);
                }
            }
           
        }

        //Generate item on map
        public bool generateItems(String item){

            Random rd = new Random();
            int i;
            int j;

            i = rd.Next(NUMBER_ROWS);
            j = rd.Next(NUMBER_COLUMNS);
           
            bool value;
            if(map[i][j].TryGetValue(item, out value)){
                if(!value){
                        map[i][j][item] = true;
                        Console.WriteLine(item + " case " + i + " " + j);
                        displayMap();
                        return true;
                    }
            }

            return false;
                
        }

    
}