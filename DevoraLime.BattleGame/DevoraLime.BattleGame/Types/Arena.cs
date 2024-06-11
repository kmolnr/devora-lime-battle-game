namespace DevoraLime.BattleGame.Types
{
    public class Arena
    {
        public int Id { get; set; }

        public List<Hero> Heroes { get; set; } = new();

        public List<string> History { get; set; } = new();

        public Arena(
            int id,
            List<Hero> heroes)
        {
            this.Id = id;
            this.Heroes = heroes;
        }

        public void Battle(
            Random random)
        {
            while (1 < this.Heroes.Count(hero => hero.IsAlive))
            {
                var aliveHeroes = this.Heroes
                    .Where(hero => hero.IsAlive)
                    .ToList();

                var attacker = aliveHeroes[random.Next(aliveHeroes.Count)];
                var defender = aliveHeroes[random.Next(aliveHeroes.Count)];

                while (attacker == defender)
                {
                    defender = aliveHeroes[random.Next(aliveHeroes.Count)];
                }

                attacker.Attack(defender, random);

                if (attacker.CurrentHealth < attacker.MaxHealth / 4)
                {
                    attacker.CurrentHealth = 0;
                }

                if (defender.CurrentHealth < defender.MaxHealth / 4)
                {
                    defender.CurrentHealth = 0;
                }

                this.History.Add(
                    $"Round {this.History.Count + 1}: " +
                    $"{attacker.Type} {attacker.Id} attacked {defender.Type} {defender.Id}. (" +
                    $"Attacker health: {attacker.CurrentHealth} / " +
                    $"Defender health: {defender.CurrentHealth})");

                foreach (var hero in Heroes)
                {
                    if (hero.IsAlive &&
                        hero != attacker &&
                        hero != defender)
                    {
                        hero.IncreaseHealth(10);
                    }
                }
            }
        }
    }
}
