namespace Cookbook;

public class FishnChips : Dish
{
    public FishnChips(string name, string cuisine, string[] ingredients, LevelOfDifficulty difficultyRating, string instructions) : base(name,
        cuisine, ingredients, difficultyRating, instructions)
    {
    }
}