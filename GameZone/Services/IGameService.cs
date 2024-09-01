namespace GameZone.Services
{
    public interface IGameService
    {
        Task CreateAsync(CreateGameFormViewModel game);

        IEnumerable<Game> GetAllGames();

        Game? GetGameById(int id);

        Task<Game?> EditAsync(EditGameFormViewModel game);

        bool Delete(int id);
    }
}
