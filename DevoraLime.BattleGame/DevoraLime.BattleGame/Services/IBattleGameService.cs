namespace DevoraLime.BattleGame.Services
{
    public interface IBattleGameService
    {
        int GenerateHeroes(int heroCount);

        List<string>? GetBattleHistory(int arenaId);
    }
}
