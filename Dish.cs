namespace Cookbook;

public class Dish
{
    private string _name;
    private string _cuisine;
    private string[] _ingredients;
    private LevelOfDifficulty _difficultyRating;
    private string _instructions;

    public Dish(string name, string cuisine, string[] ingredients, LevelOfDifficulty difficultyRating, string instructions)
    {
        _name = name;
        _cuisine = cuisine;
        _ingredients = ingredients;
        _difficultyRating = difficultyRating;
        _instructions = instructions;
    }

    public string Name => _name;
    public string Cuisine => _cuisine;
    public string[] Ingredients => _ingredients;
    public LevelOfDifficulty DifficultyRating => _difficultyRating;
    public string Instructions => _instructions;
}
