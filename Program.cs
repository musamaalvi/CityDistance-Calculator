using System;
using System.Collections.Generic;
namespace CityDistance_Calculator
{
    class Program
    {
        public static int manhattanDistance(int x1, int x2, int y1, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        public static List<string> closestStraightCity(List<string> c, List<int> x, List<int> y, List<string> q){
            List<string> nearestCities = new List<string>();
            for(int i = 0; i < c.Count; i++){
                List<string> minimumDistanceCities = new List<string>();
                int minimiumDistance = int.MaxValue;
                for(int j = 0; j < c.Count; j++){
                    //Comparing same city
                    if(i==j){continue;}
                    
                    if((x[i] == x[j] || y[i] == y[j]) && (manhattanDistance(x[i],x[j],y[i],y[j])<= minimiumDistance)){
                        minimiumDistance = manhattanDistance(x[i],x[j],y[i],y[j]);
                        minimumDistanceCities.Add(c[j]);
                    }
                    
                }
                if(minimumDistanceCities.Count == 0){
                    nearestCities.Add("NONE");
                }
                else{
                    string[] minimumCitiesArray = minimumDistanceCities.ToArray();
                    Array.Sort(minimumCitiesArray, (xCoordinate,yCoordinate) => String.Compare(xCoordinate, yCoordinate));
                    nearestCities.Add(minimumCitiesArray[0]);
                }
            }
            
            return nearestCities;

        }
        static void Main(string[] args)
        {

            List<string> c = new List<string>(){
                "fastcity",
                "bigbanana",
                "xyz"
            };
            List<int> x = new List<int>(){
                23,
                23,
                23
            };
             List<int> y = new List<int>(){
                1,
                10,
                20
            };
            List<string> q = new List<string>(){
                "fastcity",
                "bigbanana",
                "xyz"
            };
            foreach(string city in closestStraightCity(c,x,y,q)){
                Console.WriteLine(city);
            }
        }
    }
}
