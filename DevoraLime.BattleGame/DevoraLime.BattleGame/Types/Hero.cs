namespace DevoraLime.BattleGame.Types
{
    public class Hero
    {
        public int Id { get; set; }

        public HeroType Type { get; set; }

        public int CurrentHealth { get; set; }

        public int MaxHealth { get; set; }

        public bool IsAlive => 0 < this.CurrentHealth;

        public Hero(
            int id,
            HeroType type)
        {
            this.Id = id;

            this.Type = type;

            this.MaxHealth = type switch
            {
                HeroType.Archer => 100,
                HeroType.Knight => 150,
                HeroType.Swordsman => 120,
                _ => throw new ArgumentOutOfRangeException(),
            };

            this.CurrentHealth = this.MaxHealth;
        }

        public void Attack(
            Hero defender,
            Random random)
        {
            switch (this.Type)
            {
                case HeroType.Archer:
                    if ((defender.Type == HeroType.Knight && random.NextDouble() <= 0.4) ||
                        defender.Type != HeroType.Knight)
                    {
                        defender.CurrentHealth = 0;
                    }
                    break;
                case HeroType.Swordsman:
                    if (defender.Type != HeroType.Knight)
                    {
                        defender.CurrentHealth = 0;
                    }
                    break;
                case HeroType.Knight:
                    if (defender.Type == HeroType.Swordsman)
                    {
                        this.CurrentHealth = 0;
                    }
                    else
                    {
                        defender.CurrentHealth = 0;
                    }
                    break;
            }

            this.CurrentHealth = this.CurrentHealth / 2;
            defender.CurrentHealth = defender.CurrentHealth / 2;
        }

        public void IncreaseHealth(
            int extraHealth)
        {
            this.CurrentHealth =
                Math.Min(
                    this.CurrentHealth + extraHealth,
                    this.MaxHealth);
        }
    }
}
