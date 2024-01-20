using PrivateCollection.Dto;
using PrivateCollection.Models;

namespace PrivateCollection.Interfaces
{
    public interface IBoardGameRepository
    {
        public Task<IEnumerable<BoardGame?>> GetListOfBoardGames();
        public Task<BoardGame?> GetBoardGameById(long boardGameId);
        public Task<BoardGame?> GetBoardGameByName(string name);
        public Task<BoardGame> CreateBoardGame(BoardGameDto boardGame);
        public Task<BoardGame> DeleteBoardGame(string name);
        public Task<BoardGame> UpdateBoardGameStats(string name, DateTime lastGameDate, TimeSpan gameTime);
    }
}
