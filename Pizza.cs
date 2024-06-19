namespace Cookbook;

public class Pizza : Dish
{
    public Pizza(string name, string cuisine, string[] ingredients, LevelOfDifficulty difficultyRating, string instructions) : base(name,
        cuisine, ingredients, difficultyRating, instructions)
    {
    }
}