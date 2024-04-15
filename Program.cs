using System.Runtime.CompilerServices;

/*Welcome to my program, this program was designed under the specifications to be able to take in a users input of a recipe. 
 * The user will be prompted to enter recipe details like how many apples are needed etc. 
 * Next the program is designed to be able to display the recipe once all parameters have been filled.
 * The next step was to add scalling to the program, this allows the user to scale their recipe
 * by either 0.5, 1.5, or by 2.0
 * After this i added a remove function that will remove all the quantities of the recipe. 
 * Lastly i added another remove function that allows for the user to completely remove the entirity of the recipe. 
 * 
 */

namespace ProgPOE
{
    //__________________________________________Start Of File____________________________________________________\\

    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            while (true)
            {
                //Creating Menu options for the user that will allow them to do either of the following 
                Console.WriteLine("Enter: 1 to Enter Recipe Details");
                Console.WriteLine("Enter: 2 to Display The Recipe");
                Console.WriteLine("Enter: 3 to Scale Recipe");
                Console.WriteLine("Enter: 4 to Reset All Quantities");
                Console.WriteLine("Enter: 5 to Clear The Recipe");
                Console.WriteLine("Enter: 6 to Exit App");

//______________________________________________________________________________________________________________________________\\

                //Creating switch case for the menu items
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        recipe.EnterDetails();
                        break;
                    case "2":
                        recipe.DisplayRecipe();
                        break;
                    case "3":
                        Console.WriteLine("Enter the Scalling Factor (0.5, 2, or 3): ");
                        double factor = double.Parse(Console.ReadLine());
                        recipe.ScaleRecipe(factor);
                        break;
                    case "4":
                        recipe.ResetQuantity();
                        break;
                    case "5":
                        recipe.ClearRecipe();
                        break;
                    case "6":
                        Console.WriteLine("Invalid Choice");
                        break;

                }
            }
        }
    }
}
/*
 * BIBLIOGRAPHY
 * https://stackoverflow.com/questions/5678216/all-possible-array-initialization-syntaxes
 * https://www.geeksforgeeks.org/c-sharp-int32-struct/
 * 
 */ 

//____________________________________________End Of File________________________________________________________\\