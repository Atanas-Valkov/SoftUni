using System;
using System.Linq;
using System.Collections.Generic;
namespace P06E09.PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            string input;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] parts = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = parts[0];
                string pokemonName = parts[1];
                string pokemonElement = parts[2];
                int pokemonHealth = int.Parse(parts[3]);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers[trainerName] = new Trainer(trainerName);
                }

                Trainer trainer = trainers[trainerName];
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                trainer.Pokemon.Add(pokemon);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                foreach (Trainer trainer in trainers.Values)
                {
                    if (trainer.Pokemon.Any(p => p.Element == input))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        for (int i = trainer.Pokemon.Count - 1; i >= 0; i--)
                        {
                            if (trainer.Pokemon[i].Health <= 10)
                            {
                                trainer.Pokemon.RemoveAt(i);
                            }
                            else
                            {
                                trainer.Pokemon[i].Health -= 10;
                            }
                        }
                    }
                }
            }

            foreach (Trainer trainer in trainers.Values.OrderByDescending(t => t.Badges))
            {
                Console.WriteLine($"{trainer.TrainerName} {trainer.Badges} {trainer.Pokemon.Count}");
            }
        }
    }
}
