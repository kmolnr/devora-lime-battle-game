using DevoraLime.BattleGame.Types;

namespace DevoraLime.BattleGame.Services
{
    public class BattleGameService : IBattleGameService
    {
        private static readonly Dictionary<int, Arena> Arenas = new();

        private static int nextArenaId = 1;

        private static readonly Random random = new();

        public int GenerateHeroes(
            int heroCount)
        {
            var heroes = new List<Hero>();

            for (int i = 0; i < heroCount; i++)
            {
                var newRandomHero = new Hero(i + 1, (HeroType)random.Next(3));

                heroes.Add(newRandomHero);
            }

            var arena = new Arena(nextArenaId++, heroes);

            Arenas[arena.Id] = arena;

            return arena.Id;
        }

        public List<string>? GetBattleHistory(
            int arenaId)
        {
            if (!Arenas.ContainsKey(arenaId))
            {
                return null;
            }

            var arena = Arenas[arenaId];

            arena.Battle(random);

            return arena.History;
        }
    }
}
