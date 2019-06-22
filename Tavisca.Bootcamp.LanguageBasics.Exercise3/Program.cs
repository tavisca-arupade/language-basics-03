using System;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            //Author : Aditi Rupade

            // for final index for each individual
            int[] index = new int[dietPlans.Length];

            //itersting loop for each individual and for each meal value
            for (int i = 0; i < index.Length; i++)
            {
                for (int j = 1; j < protein.Length; j++)
                {
                    if (getIndex(protein, carbs, fat, dietPlans[i], j, index[i]))
                    {
                        index[i] = j;
                    }
                }
            }
            return index;
        }
        
        public static Boolean getIndex(int [] protein, int[] carbs, int[] fat, String dietPlan,int next, int curr)
        {
            for (int i = 0; i < dietPlan.Length; i++)
            {
                char criteria = dietPlan[i];
                 if (criteria == 'P' || criteria == 'p')
                {
                    if (protein[next] == protein[curr])
                    {
                        continue;
                    }
                    if (criteria == 'P')
                    {
                        return protein[next] > protein[curr];
                    }
                    else
                    {
                        return protein[next] < protein[curr];
                    }
                }
                else if (criteria == 'C' || criteria == 'c')
                {
                    if (carbs[next] == carbs[curr])
                    {
                        continue;
                    }
                    if (criteria == 'C')
                    {
                        return carbs[next] > carbs[curr];
                    }
                    else
                    {
                        return carbs[next] < carbs[curr];
                    }
                }
               
                else if (criteria == 'F' || criteria == 'f')
                {
                    if (fat[next] == fat[curr])
                    {
                        continue;
                    }
                    if (criteria == 'F')
                    {
                        return fat[next] > fat[curr];
                    }
                    else
                    {
                        return fat[next] < fat[curr];
                    }
                }
                else
                {
                    int calorie1 = calcCalorie(protein[next], carbs[next], fat[next]);
                    int calorie2 = calcCalorie(protein[curr], carbs[curr], fat[curr]);
                    if (calorie1 == calorie2)
                    {
                        continue;
                    }
                    if (criteria == 'T')
                    {
                        return calorie1 > calorie2;
                    }
                    else
                    {
                        return calorie1 < calorie2;
                    }
                }
            }
            return false;
        }

        public static int calcCalorie(int protein, int carbs, int fat)
        {
            return protein * 5 + carbs * 5 + fat * 9;
        }
    }
}
