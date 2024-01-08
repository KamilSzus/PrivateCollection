using Microsoft.EntityFrameworkCore;
using PrivateCollection.Data;
using PrivateCollection.Dto;
using PrivateCollection.Interfaces;
using PrivateCollection.Models;
using System.Collections.Immutable;

namespace PrivateCollection.Repository
{
    public class BoardGameRepository : IBoardGameRepository
    {
        private readonly PrivateCollectionContext Context;

        public BoardGameRepository(PrivateCollectionContext context)
        {
            this.Context = context;
        }

        public async Task<BoardGame> CreateBoardGame(BoardGameDto boardGame)
        {
            var existingBoardGame = await this.Context.BoardsGames.FindAsync(boardGame.Id);

            if (existingBoardGame is null)
            {
                var newBoardGame = new BoardGame()
                {
                    Name = boardGame.Name,
                    PublishingHouse = boardGame.PublishingHouse,
                    Description = boardGame.Description
                };
                
                this.Context.Add(newBoardGame);
                this.Context.SaveChanges();

                return newBoardGame;
            }

            existingBoardGame.Name = boardGame.Name;
            existingBoardGame.Description = boardGame.Description;
            existingBoardGame.PublishingHouse = boardGame.PublishingHouse;

            this.Context.Update(existingBoardGame);
            this.Context.SaveChanges();

            return existingBoardGame;
        }

        public async Task<BoardGame?> GetBoardGameById(long boardGameId)
        {
            return await this.Context.BoardsGames.FindAsync(boardGameId);
        }

        public async Task<BoardGame?> GetBoardGameByName(string name)
        {
            return await this.Context.BoardsGames.FirstOrDefaultAsync(bg => bg.Name == name);
        }

        public async Task<IEnumerable<BoardGame?>> GetListOfBoardGames()
        {
            return await this.Context.BoardsGames.OrderBy(bg => bg.Name).ToListAsync();
        }
    }
}
