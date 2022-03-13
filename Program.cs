using System;
using System.Collections.Generic;
using System.Linq;

namespace CityDistance_Calculator
{
    class Program
    {
        public static int manhattanDistance(int x1, int x2, int y1, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }
        public static int findMinimumDistance(List<string> c, List<int> x, List<int> y, int index){
            int minimiumDistance = int.MaxValue;
            for(int j = 0; j < c.Count; j++){
                //Comparing same city
                if(index==j){continue;}
                
                if((x[index] == x[j] || y[index] == y[j]) && (manhattanDistance(x[index],x[j],y[index],y[j])<= minimiumDistance)){
                    minimiumDistance = manhattanDistance(x[index], x[j], y[index], y[j]);
                }
                
            }
            return minimiumDistance;
        }
        public static int findIndexOfQueriedCity(string queryCity, List<string> cities){
            for(int i=0; i<cities.Count; i++){
                if(queryCity == cities[i]){
                    return i;
                }
            }
            return -1;
        }
        public static List<string> closestStraightCity(List<string> c, List<int> x, List<int> y, List<string> q){
            //Function Compexity(O(mn))

            List<string> nearestCities = new List<string>();
            //Checking Constraints
            if(1<= c.Count && q.Count <= 100000 && c.Count == c.Distinct().Count()){
                //O(m)
                for(int t = 0; t < q.Count; t++){
                    //Find index to access coordinates (O(n))
                    int i = findIndexOfQueriedCity(q[t], c);

                    //Checking Constraints
                    if(c[i].Length >= 1 && c[i].Length <= 10 && 1 <= x[i] && x[i] <= 1000000000 && 1 <= y[i] && y[i] <= 1000000000 ){
                        List<string> minimumDistanceCities = new List<string>();
                        int minimiumDistance = int.MaxValue;

                        //Finding minimum distance so we can group together minimum distance cities in order to sort them alphabatically later (O(n))
                        minimiumDistance = findMinimumDistance(c, x, y, i);

                        //O(n)
                        for(int j = 0; j < c.Count; j++){
                            //Comparing same city
                            if(i==j){continue;}
                            
                            //Grouping together minimum distance(calculated earlier) cities
                            if((x[i] == x[j] || y[i] == y[j]) && (manhattanDistance(x[i],x[j],y[i],y[j]) == minimiumDistance)){
                                minimumDistanceCities.Add(c[j]);
                            }
                        }
                        if(minimumDistanceCities.Count == 0){
                            nearestCities.Add("NONE");
                        }
                        else{
                            //Sorting array alphabatically
                            string[] minimumCitiesArray = minimumDistanceCities.ToArray();
                            Array.Sort(minimumCitiesArray, (xCoordinate,yCoordinate) => String.Compare(xCoordinate, yCoordinate));
                            nearestCities.Add(minimumCitiesArray[0]);
                        }

                    }
                    
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
            foreach(string city in closestStraightCity(c, x, y, q)){
                Console.WriteLine(city);
            }
        }
    }
}
