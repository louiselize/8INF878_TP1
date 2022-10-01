/*
Agent :
L’agent Aspirobot T-0.1 possède un certain nombre de fonctionnalités. Il peut aspirer (ce qui a
pour effet d’aspirer à la fois la poussière et les bijoux), ramasser un élément (pour ramasser un
bijou idéalement!) et se déplacer (haut, bas, gauche et droite). Chacune de ses actions lui coûte
1 unité d’électricité (attention, rappelez-vous que vous êtes un propriétaire de manoir cheap
heum... disons qui n’aime pas gaspiller de l’argent). Le robot peut voir toutes les pièces. Le
robot doit être implémenté sous les principes agents vus en classe. Il doit donc observer
l’environnement avec ses capteurs et agir sur celui-ci avec des effecteurs (je vous conseille
carrément de faire des classes capteurs et effecteurs). Votre robot devrait être de type « basé sur
les buts ». Même si le problème est très simple, il est important que celui-ci contienne les

éléments de base (son état interne devrait contenir un état mental sous la forme BDI « Beliefs-
Desires-Intentions »). Il devrait lui aussi être implémenté comme une boucle infinie respectant

l’idée de base vue en cours (voir pseudo-code simple ci-dessous).


------------ PSEUDO CODE -> AGENT BASÉ SUR LES BUTS ----------------------

function Agent-But ([etat_env, but])

ActionsPossibles = actionDeclanchable(etat_env)  //observe

for i = 1 to taille(ActionsPossibles){
if capable_atteindre(ActionsPossibles[i], but) 

return ActionsPossibles[i]; 

}

returns an action

-------------------------------------------------------------

*/

using System.Collections;

class Agent
    {
        private Sensors sensor; //observe
        private Effector effector; //choose an action
        private Exploration exploration; //uninformed or informed

        public Agent(){
            sensor = new Sensors();
            effector = new Effector();
        }

        public void AgentDoYourJob(Map map, Exploration exploration, Environment ev){
            //1. Beliefs - Observation of the map
            sensor.Observe(map); 

            //2. Desires - look if goal is achieved or not
            if(sensor.GetCellToCollect().Count!=0 || sensor.GetCellToSuck().Count!=0){
                
                Console.WriteLine("Agent : I explore");
                //3. Intentions - do exploration to reach goal state
                
                int [] cell = new int [2] {map.GetRobotXPosition(),map.GetRobotYPosition()};
                ArrayList path = new ArrayList();
                /*foreach(int [] element in exploration.Neighbour(cell)){
                    Console.WriteLine(element[0] + " " + element[1]);
                }*/
                path = exploration.Explore(sensor.GetCellToSuck(),sensor.GetCellToCollect(),cell);
                Console.WriteLine("coup à jouer :");
                foreach(int [] element in path){
                    Console.WriteLine(element[0] + " " + element[1]);
                }
                Console.WriteLine();
                
                //4. Just do it
                effector.DoAction(path, sensor.GetCellToCollect(), sensor.GetCellToSuck(), ev);
            }

            else{
                Console.WriteLine("Agent : I'm waiting (my goal is reached for the moment)");
            }
        }

        public Sensors GetSensor(){
            return sensor;
        }

        public Effector GetEffector(){
            return effector;
        }

        public Exploration GetExploration(){
            return exploration;
        }

    }
