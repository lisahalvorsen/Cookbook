namespace Cookbook;

public static class DishManager
{
    private static List<Dish> _dishes = [];

    static DishManager()
    {
        _dishes.Add(new Pizza("Pizza", "Italian", ["pizza sauce", "dough", "cheese", "ham", "mozzarella"],
            LevelOfDifficulty.Easy,
            "Spread tomato sauce on the dough, add pizza sauce, ham, mozzarella and then cheese."));
        _dishes.Add(new Carbonara("Carbonara", "pasta", ["spaghetti", "bacon", "egg", "parmesan", "salt", "pepper"],
            LevelOfDifficulty.Medium, "Boil the spaghetti, fry bacon, and then add everything together. Enjoy!"));
        _dishes.Add(new Hamburger("Hamburger", "American", [
                "hamburger", "buns", "tomato", "lettuce", "ketchup", "hamburger dressing", "cheese", "bacon"
            ], LevelOfDifficulty.Easy,
            "Grill the hamburger. Once finished, put it on the bun and then add rest of the ingredients. Enjoy!"));
        _dishes.Add(new PokeBowl("Pokebowl", "Asian",
            ["rice", "cucumber", "mango", "avocado", "tomato", "salmon", "ponzu sauce", "sesame seeds"],
            LevelOfDifficulty.Easy,
            "Cook the rice. Dice the other ingredients. Put the rice in a bowl, add the diced ingredients and then pour ponzu sauce on top. Enjoy!"));
        _dishes.Add(new FishnChips("Fish and chips", "British",
            ["fish", "pommes frites", "salt", "pepper", "tartar sauce"],
            LevelOfDifficulty.Medium,
            "Fry the fish. Fry the pommes frites. Put in on a plate, add tartar sauce on the side. Enjoy!"));
        _dishes.Add(new TomatoSoup("Tomato soup", "Spanish", [
                "onion", "tomato paste", "canned tomatoes", "water", "spices", "egg", "macaroni"
            ], LevelOfDifficulty.Easy,
            "In a saucepan, boil canned tomatoes, tomato paste, onion and water. Add salt and pepper. Boil eggs and macaroni. Enjoy!"));
        _dishes.Add(new Lasagna("Lasagna", "Italian", [
                "pasta sauce", "cheese sauce", "meat", "lasagna plates", "cheese"
            ], LevelOfDifficulty.Hard,
            "Fry the meat. Add the pasta sauce. In a suitable container, layer meat, pasta sauce, cheese sauce and lasagna plates. Add cheese on top, and enjoy!"));
    }

    public static void MainMenu()
    {
        while (true)
        {
            Console.WriteLine("Hello! What do you want to do today? :)");
            Console.WriteLine("1. See all dishes \n2. Find dish based on cuisine");
            Console.WriteLine("3. Find dish based on ingredient \n4. Find dish based on the level of difficulty");
            Console.WriteLine("5. Find recipe and instructions for a dish \n6. Log out \n");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    PrintAllDishes();
                    break;
                case "2":
                    FindDishCuisine();
                    break;
                case "3":
                    FindDishIngredient();
                    break;
                case "4":
                    FindDishLevelOfDifficulty();
                    break;
                case "5":
                    PrintRecipeAndInstructions();
                    break;
                case "6":
                    Console.WriteLine("Logging out.");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nInvalid input, please try again.\n");
                    break;
            }
        }
    }

    public static void PrintAllDishes()
    {
        Console.Clear();
        if (_dishes != null && _dishes.Count > 0)
        {
            List<string> dishNames = [];
            foreach (var dish in _dishes)
            {
                dishNames.Add(dish.Name);
            }

            string dishNameString = string.Join(", ", dishNames);
            Console.WriteLine($"In the cookbook you can find recipes for: {dishNameString}.\n");
        }
        else
        {
            Console.WriteLine("There are no dishes to show.\n");
        }
    }

    public static void FindDishCuisine()
    {
        Console.Clear();
        Console.WriteLine("To see the dish(es) from a certain cuisine, type in a cuisine (Example: Italian).");
        string cuisine = Console.ReadLine();
        var dishByCuisine = _dishes.Where(dish => dish.Cuisine == cuisine);
        if (dishByCuisine.Any())
        {
            List<string> dishNames = [];
            foreach (var dish in dishByCuisine)
            {
                dishNames.Add(dish.Name);
            }

            string dishNamesString = string.Join(", ", dishNames);
            Console.WriteLine($"\nIn the {cuisine} cuisine there are: {dishNamesString}.\n");
        }
        else
        {
            Console.WriteLine("\nThe cuisine you're looking for doesn't exist in the cookbook, please try again.\n");
        }
    }

    public static void FindDishIngredient()
    {
        Console.Clear();
        Console.WriteLine(
            "To see which dish(es) that contain a certain ingredient, type in the ingredient (Example: cheese).");
        string ingredient = Console.ReadLine();
        var dishByIngredient = _dishes.Where(dish => dish.Ingredients.Contains(ingredient));
        if (dishByIngredient.Any())
        {
            List<string> dishNames = [];
            foreach (var dish in dishByIngredient)
            {
                dishNames.Add(dish.Name);
            }

            string dishNamesString = string.Join(", ", dishNames);
            Console.WriteLine($"\nThe dish(es) that contain this ingredients are: {dishNamesString}.\n");
        }
        else
        {
            Console.WriteLine("\nNo dish(es) contain the ingredient(s) you were looking for.\n");
        }
    }

    public static void FindDishLevelOfDifficulty()
    {
        Console.Clear();
        Console.WriteLine(
            "To see dish(es) based on the level of difficulty, type in the difficulty level (Example: Easy).");
        string difficultyLevel = Console.ReadLine();

        LevelOfDifficulty parseLevelOfDifficulty;

        if (Enum.TryParse<LevelOfDifficulty>(difficultyLevel, true, out parseLevelOfDifficulty))
        {
            var dishByDifficultyLevel = _dishes.Where(dish => dish.DifficultyRating == parseLevelOfDifficulty);
            if (dishByDifficultyLevel.Any())
            {
                List<string> dishNames = [];
                foreach (var dish in dishByDifficultyLevel)
                {
                    dishNames.Add(dish.Name);
                }

                Console.WriteLine(
                    $"\nThe dish(es) that are on the {difficultyLevel} level are: {string.Join(", ", dishNames)}.\n");
            }
            else
            {
                Console.WriteLine($"\nNo dishes were found with the difficulty level, {difficultyLevel}.\n");
            }
        }
        else
        {
            Console.WriteLine($"Invalid difficulty level, please try again.");
        }
    }

    public static void PrintRecipeAndInstructions()
    {
        Console.Clear();
        Console.WriteLine("Which dish do you want to see the recipe and instructions for? (Example: Lasagna)");
        string dishRecipe = Console.ReadLine();

        var foundDish = _dishes.FirstOrDefault(dish => dish.Name == dishRecipe);

        if (foundDish != null)
        {
            Console.WriteLine(
                $"\nThe ingredients needed for {dishRecipe} are: {string.Join(", ", foundDish.Ingredients)}.");
            Console.WriteLine($"\nInstructions: {foundDish.Instructions}\n");
        }
        else
        {
            Console.WriteLine(
                "\nLooks like there is no recipe for the dish you are looking for, please try another dish.\n");
        }
    }
}