namespace P06E09.PokemonTrainer;

public class Trainer
{
    public Trainer(string trainerName)
    {
        this.TrainerName = trainerName;
        this.Badges = 0;
        Pokemon = new List<Pokemon>();
    }

    public string TrainerName { get; set; }
    public int Badges { get; set; }
    public List<Pokemon> Pokemon { get; set; }
}