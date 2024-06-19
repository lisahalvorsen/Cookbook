namespace Cookbook;

public class PokeBowl : Dish
{
    public PokeBowl(string name, string cuisine, string[] ingredients, LevelOfDifficulty difficultyRating, string instructions) : base(name,
        cuisine, ingredients, difficultyRating, instructions)
    {
    }
}