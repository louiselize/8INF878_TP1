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
            for (int i = 0; i < NUMBER_ROWS; ++i)
            {
                for (int j = 0; j < NUMBER_COLUMNS; ++j)
                {
                    foreach(var kvp in map[i][j])
                        Console.WriteLine("Row: " + i +" Column: " + j +" = " + kvp);
                    Console.WriteLine();    
                }
                    
            }
        }

        //Displaying the Map
        public Dictionary<String, bool>[][] generateItems(String item){
            
            switch (item) 
            {
                case Items.Dirt:
                    Console.WriteLine("Dirt");
                    break;
                case Items.Jewel:
                    Console.WriteLine("Jewel");
                    break;
                default:
                    Console.WriteLine("Not in enum");
                    break;
            }

            return map;
        }
    }