namespace Cookbook;

public class TomatoSoup : Dish

{
    public TomatoSoup(string name, string cuisine, string[] ingredients, LevelOfDifficulty difficultyRating, string instructions) : base(name,
        cuisine, ingredients, difficultyRating, instructions)
    {
    }
}