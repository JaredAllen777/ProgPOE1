using ProgPOE;
/*Welcome to my program, this program was designed under the specifications to be able to take in a users input of a recipe. 
 * The user will be prompted to enter recipe details like how many apples are needed etc. 
 * Next the program is designed to be able to display the recipe once all parameters have been filled.
 * The next step was to add scalling to the program, this allows the user to scale their recipe
 * by either 0.5, 1.5, or by 2.0
 * After this i added a remove function that will remove all the quantities of the recipe. 
 * Lastly i added another remove function that allows for the user to completely remove the entirity of the recipe. 
 * 
 */

//______________________________________________________________________Start Of File_____________________________________________________________________________________________\\

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ProgPOE

//_____________________________________________________________________________________________________________________________________________________________________________________\\

{
    class Program
    {
        static void Main(string[] args)
        {
            List<Recipe> recipes = new List<Recipe>();

            while (true)
            {
                //Displays menu options
                Console.WriteLine("Welcome to Recipe Manager");
                Console.WriteLine("1. Enter a New Recipe");
                Console.WriteLine("2. Display All Recipes");
                Console.WriteLine("3. Select Recipe by Name");
                Console.WriteLine("4. Exit");

                //Prompts user to make a choice
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

//____________________________________________________________________________________________________________________________________________________________________________________\\

                //Processes Users choice
                switch (choice)
                {
                    case "1":
                        //Option 1: User can enter a new recipee
                        Console.WriteLine("Enter Recipe Details:");
                        Recipe newRecipe = new Recipe();
                        newRecipe.EnterDetails();
                        recipes.Add(newRecipe);
                        Console.WriteLine("Recipe added successfully.");
                        Console.WriteLine();
                        break;
                    case "2":
                        //Option 2:Displays all recipes
                        if (recipes.Count == 0)
                        {
                            Console.WriteLine("No recipes found.");
                        }
                        else
                        {
                            // Sort recipes alphabetically by name before displaying
                            var sortedRecipes = recipes.OrderBy(r => r.Name);
                            foreach (var r in sortedRecipes)
                            {
                                r.DisplayRecipe();
                            }
                        }
                        Console.WriteLine();
                        break;
                    case "3":
                        //Option 3: User can select recipe by name
                        Console.Write("Enter the name of the recipe: ");
                        string recipeName = Console.ReadLine();
                        Recipe selectedRecipe = recipes.Find(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
                        if (selectedRecipe != null)
                        {
                            Console.WriteLine("Selected Recipe:");
                            selectedRecipe.ManageRecipe();
                        }
                        else
                        {
                            Console.WriteLine("Recipe not found.");
                        }
                        Console.WriteLine();
                        break;
                    case "4":
                        //Exits application
                        Console.WriteLine("Exiting the application...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}

//_____________________________________________________________________________________________________________________________________________________________________________________\\

/*
 * REFRENCE LIST
 * https://stackoverflow.com/questions/5678216/all-possible-array-initialization-syntaxes
 * https://www.geeksforgeeks.org/c-sharp-int32-struct/
 * https://stackoverflow.com/questions/21796119/use-a-list-instead-of-an-array-in-c 
 * https://www.delftstack.com/howto/csharp/exit-application-in-csharp/#:~:text=To%20use%20the%20Environment.Exit%28%29%20method%2C%20you%20simply%20call,passing%20an%20appropriate%20exit%20code%20as%20an%20argument.
 * https://stackoverflow.com/questions/188141/listt-orderby-alphabetical-order
 * https://stackoverflow.com/questions/3801748/select-method-in-listt-collection#:~:text=var%20query1%20%3D%20list.Where%28person%20%3D%3E%20person.Age%20%3E%2030%29%3B,person%27s%20name%20var%20query2%20%3D%20list.Select%28person%20%3D%3E%20person.Name%29%3B
 * https://advtechonline.sharepoint.com/:w:/r/sites/TertiaryStudents/_layouts/15/Doc.aspx?sourcedoc=%7B755177B9-FEE4-4F9B-832D-6B093222C730%7D&file=PROG6221POE.docx&action=default&mobileredirect=true
 * 
 */

//______________________End Of File___________________________End Of File_________________________End Of File_________________End Of File____________________End Of File_____________\\