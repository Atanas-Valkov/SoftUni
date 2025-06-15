namespace CocktailBar
{
    public class Cocktail
    {
        private List<string> _ingredients;

        public Cocktail(string ingredients)
        {
            _ingredients = ingredients.Split(", ").ToList();
        }

        public List<string> Ingredients { get => _ingredients; }
    }
}
