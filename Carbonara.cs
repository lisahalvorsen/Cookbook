namespace Cookbook;

public class Carbonara : Dish
{
    public Carbonara(string name, string cuisine, string[] ingredients, LevelOfDifficulty difficultyRating, string instructions) : base(name,
        cuisine, ingredients, difficultyRating, instructions)
    {
    }
}