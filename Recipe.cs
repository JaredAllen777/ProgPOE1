using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ProgPOE
//______________________________________________________________________Start Of File_________________________________________________________________________________________\\
{
    class Recipe
    {
        // Properties to store recipe name, ingredients, and steps
        public string Name { get; set; }
        private List<Ingredient> ingredients = new List<Ingredient>();
        private List<string> steps = new List<string>();

        // Delegate for notifying high calorie count
        public delegate void HighCalorieWarning(string message);
        public event HighCalorieWarning OnHighCalorie;

        // Constructor subscribing a method to the event
        public Recipe()
        {
            OnHighCalorie += message => Console.WriteLine(message);
        }

//_____________________________________________________________________________________________________________________________________________________________________________________\\

        // Method to add an ingredient to the recipe
        public void AddIngredient(Ingredient ingredient)
        {
            ingredients.Add(ingredient);
        }

//_____________________________________________________________________________________________________________________________________________________________________________________\\

        // Method to add a step to the recipe
        public void AddStep(string step)
        {
            steps.Add(step);
        }

//_____________________________________________________________________________________________________________________________________________________________________________________\\

        // Method to enter details of the recipe
        public void EnterDetails()
        {
            // Enter recipe name
            Console.Write("Recipe Name: ");
            Name = Console.ReadLine();

            // Enter number of ingredients and details for each ingredient
            Console.Write("Number of Ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Ingredient {i + 1}:");
                Ingredient ingredient = new Ingredient();
                ingredient.EnterDetails();
                ingredients.Add(ingredient);
            }

            // Enter number of steps and details for each step
            Console.Write("Number of Steps: ");
            int numSteps = int.Parse(Console.ReadLine());
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Step {i + 1}: ");
                steps.Add(Console.ReadLine());
            }
        }

//_____________________________________________________________________________________________________________________________________________________________________________________\\

        // Method to display the recipe details
        public void DisplayRecipe()
        {
            Console.WriteLine($"Recipe: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
            }
            Console.WriteLine("Steps:");
            foreach (var step in steps)
            {
                Console.WriteLine($"- {step}");
            }
            Console.WriteLine();
        }

//_____________________________________________________________________________________________________________________________________________________________________________________\\

        // Method to manage the recipe, including options to display, scale, reset, clear, and calculate calories
        public void ManageRecipe()
        {
            while (true)
            {
                Console.WriteLine("Manage Recipe:");
                Console.WriteLine("1. Display The Recipe");
                Console.WriteLine("2. Scale Recipe");
                Console.WriteLine("3. Reset All Quantities");
                Console.WriteLine("4. Clear The Recipe");
                Console.WriteLine("5. Calculate Total Calories");
                Console.WriteLine("6. Return to Main Menu");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        DisplayRecipe();
                        break;
                    case "2":
                        Console.Write("Enter the Scaling Factor (0.5, 2, or 3): ");
                        if (!double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out double factor))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                            break;
                        }
                        ScaleRecipe(factor);
                        Console.WriteLine("Recipe scaled successfully.");
                        Console.WriteLine();
                        break;
                    case "3":
                        ResetAllQuantities();
                        Console.WriteLine("All quantities reset to original values.");
                        Console.WriteLine();
                        break;
                    case "4":
                        Console.Write("Are you sure you want to clear the recipe? (yes/no): ");
                        string confirmation = Console.ReadLine().ToLower();
                        if (confirmation == "yes" || confirmation == "y")
                        {
                            ClearRecipe();
                            Console.WriteLine("Recipe cleared successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Clear operation canceled.");
                        }
                        Console.WriteLine();
                        break;
                    case "5":
                        CalculateTotalCalories();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.WriteLine();
                        break;
                }
            }
        }

//_____________________________________________________________________________________________________________________________________________________________________________________\\

        // Method to scale the quantities of ingredients in the recipe
        public void ScaleRecipe(double factor)
        {
            if (factor <= 0)
            {
                Console.WriteLine("Scaling factor must be greater than zero.");
                return;
            }

            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

//_____________________________________________________________________________________________________________________________________________________________________________________\\

        // Method to reset all ingredient quantities to their original values
        public void ResetAllQuantities()
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.ResetQuantity();  // Reset each ingredient's quantity
            }
        }

//_____________________________________________________________________________________________________________________________________________________________________________________\\

        // Method to clear the recipe by removing all ingredients and steps
        public void ClearRecipe()
        {
            ingredients.Clear();
            steps.Clear();
        }

//_____________________________________________________________________________________________________________________________________________________________________________________\\

        // Method to calculate the total calories of the recipe and notify if it exceeds 300 calories
        public void CalculateTotalCalories()
        {
            int totalCalories = ingredients.Sum(i => i.Calories);
            Console.WriteLine($"Total Calories: {totalCalories}");
            if (totalCalories > 300)
            {
                OnHighCalorie?.Invoke("Warning: Total calories exceed 300!");
            }
            Console.WriteLine();
        }
    }
}

//_____________________________________________________________________________________________________________________________________________________________________________________\\

class Ingredient
{
    // Properties to store ingredient details
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }
    public int Calories { get; set; }
    public string FoodGroup { get; set; }
    private double OriginalQuantity { get; set; }  // Store original quantity

//_____________________________________________________________________________________________________________________________________________________________________________________\\

    // Constructor
    public Ingredient()
    {
    }

    // Method to enter ingredient details
    public void EnterDetails()
    {
        Console.Write("Name: ");
        Name = Console.ReadLine();

        Console.Write("Quantity: ");
        Quantity = double.Parse(Console.ReadLine());
        OriginalQuantity = Quantity;  // Set original quantity

        Console.Write("Unit: ");
        Unit = Console.ReadLine();

        Console.Write("Calories: ");
        Calories = int.Parse(Console.ReadLine());

        Console.Write("Food Group: ");
        FoodGroup = Console.ReadLine();
    }

    // Method to reset the ingredient quantity to the original value
    public void ResetQuantity()
             {
        Quantity = OriginalQuantity;  // Reset to original quantity
             }
         }

//______________________End Of File___________________________End Of File_________________________End Of File_________________End Of File____________________End Of File_____________\\