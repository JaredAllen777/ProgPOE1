using System;
namespace ProgPOE { 

//___________________________________________________Start Of File______________________________________________________________\\

    class Recipe
    {
        //Creating array ans variables
        private string[] ingrediants;
        private string[] units;
        private double[] quantity;
        private string[] steps;

//_______________________________________________________________________________________________________________________________\\
        public Recipe()
    {
        //Adding the variables to the array 
        ingrediants = new string[0];
        units = new string[0];
        quantity = new double[0];
        steps = new string[0];
    }

        //_____________________________________________________________________________________________________________________________\\
        public void EnterDetails()
        {

            // Prompting the user to enter the number of ingredients for the recipe
            Console.WriteLine("Please Enter The Number of Ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            // Initializing arrays to store ingredient details
            ingrediants = new string[numIngredients];
            units = new string[numIngredients];
            quantity = new double[numIngredients];

            // Loop to input details for each ingredient
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Please Enter The Details For The Ingredient #{i + 1}: ");
                Console.Write("Name Of Ingredient: ");
                ingrediants[i] = Console.ReadLine();
                Console.Write("Quantity: ");
                quantity[i] = double.Parse(Console.ReadLine());
                Console.Write("Unit Of Measurement: ");
                units[i] = Console.ReadLine();
            }

            // Prompting the user to enter the number of steps for the recipe
            Console.Write("Please Enter The Number Steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            // Initializing array to store recipe steps
            steps = new string[numSteps];

            // Loop to input details for each step
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Please Enter Step#{i + 1}: ");
                steps[i] = Console.ReadLine();
            }
        }


        //_____________________________________________________________________________________________________________________________\\
        //Method that displays the recipe
        public void DisplayRecipe()
    {
        //Displaying the quantities and ingrediants
        Console.WriteLine("Ingrediants");
        for (int i = 0; i < ingrediants.Length; i++)
        {
            Console.WriteLine($"- {quantity[i]} {units[i]} of {ingrediants[i]}");
        }

        //Displaying the steps
        Console.WriteLine("Steps:");
        for (int i = 0; i < steps.Length; i++)
        {
            Console.WriteLine($"- {steps[i]}");

        }
    }

//_____________________________________________________________________________________________________________________________\\
    //Method to scale the recipe 
    public void ScaleRecipe(double factor)
    {
        //Multiplying all the quantities by the scaling factor
        for (int i = 0; i < quantity.Length; i++)
        {
            quantity[i] *= factor;
        }
    }

//_____________________________________________________________________________________________________________________________\\
    //Method to reste quantities to half
    public void ResetQuantity()
    {
        //Resetting all the quantities to their original values
        for (int i = 0; i < quantity.Length; i++)
        {
            quantity[i] /= 2;
        }
    }

//_____________________________________________________________________________________________________________________________\\
    //Method to clear recipe
    public void ClearRecipe()
    {
        //Restting all the arrays to empty
        ingrediants = new string[0];
        quantity = new double[0];
        units = new string[0];
        steps = new string[0];
       }
    }
}


//____________________________________________________________End Of File_____________________________________________________\\