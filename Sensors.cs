// using System;

//     enum Case
//         {
//             Vide = 0,
//             Jewel = 1,
//             Dirt = 2
//         }

//     public class Sensors  
//     {  
        
//         public static void Main(string[] args)  
//         {  
                                
//             int[,] matrice=new int[5,5];//declaration of 2D array  
            
//             int jewel = Convert.ToInt32(Case.Jewel);
//             int vide = Convert.ToInt32(Case.Vide);
//             int dirt = Convert.ToInt32(Case.Dirt);

//             for(int i=0;i<5;i++){  
//                 for(int j=0;j<5;j++){  
//                     System.Random random = new System.Random();

//                     int number = random.Next(0, 3); 
//                     int[] choices = new int[3] { jewel, dirt , vide }; 
//                     matrice[i, j] = choices[number]; //insert the random value
//                     Console.Write(matrice[i, j]+" "); 

//                 }  
//                 Console.WriteLine();//new line at each row  

//             }
            
//             for(int i=0;i<5;i++){  
//                 for(int j=0;j<5;j++){
//                     if(matrice[i,j] == 0) {}                  

//                     else if(matrice[i,j] == 1){
//                         Console.WriteLine("il faut aspirer ");
//                     }

//                     else{
//                         Console.WriteLine("il faut ramasser");
//                     }
//                 }
//             }
              
//         }  
//     }
