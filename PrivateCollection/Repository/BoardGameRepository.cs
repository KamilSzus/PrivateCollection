﻿using Microsoft.EntityFrameworkCore;
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
            var existingBoardGame = await GetBoardGameByName(boardGame.Name);

            if (existingBoardGame is null)
            {
                var newBoardGame = new BoardGame()
                {
                    Name = boardGame.Name,
                    PublishingHouse = boardGame.PublishingHouse,
                    Description = boardGame.Description,
                    BoardGameStats = new BoardGameStats() { }
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

        public async Task<BoardGame> DeleteBoardGame(string name)
        {
            var boardGameToDelete = await GetBoardGameByName(name);

            if (boardGameToDelete is null)
                return null;

            this.Context?.Remove(boardGameToDelete);
            this.Context?.SaveChanges();

            return boardGameToDelete;
        }

        public async Task<BoardGame?> GetBoardGameById(long boardGameId)
        {
            return await this.Context.BoardGames
                .Include(bg => bg.BoardGameStats)
                .FirstOrDefaultAsync(bg => bg.Id == boardGameId);
        }

        public async Task<BoardGame?> GetBoardGameByName(string name)
        {
            return await this.Context.BoardGames
                .Include(bg => bg.BoardGameStats)
                .FirstOrDefaultAsync(bg => bg.Name == name);
        }

        public async Task<IEnumerable<BoardGame?>> GetListOfBoardGames()
        {
            return await this.Context.BoardGames
                .Include(bg => bg.BoardGameStats)
                .OrderBy(bg => bg.Name)
                .ToListAsync();
        }

        public async Task<BoardGame> UpdateBoardGameStats(string name, DateTime lastGameDate, TimeSpan gameTime)
        {
            var boardGameToUpdate = await GetBoardGameByName(name);

            if (boardGameToUpdate is null)
                throw new ArgumentException("Given game doesn't exist");

            boardGameToUpdate.BoardGameStats.LastGame = ConvertToDateTimeZone(lastGameDate);
            boardGameToUpdate.BoardGameStats.InGameTime = boardGameToUpdate.BoardGameStats.InGameTime.HasValue
                ? boardGameToUpdate.BoardGameStats.InGameTime.Value.Add(gameTime) : gameTime;
            boardGameToUpdate.BoardGameStats.GameCount++;

            this.Context.Update(boardGameToUpdate);
            this.Context.SaveChanges();

            return boardGameToUpdate;
        }

        //TO DO: move this to helper class
        private DateTime? ConvertToDateTimeZone(DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                return TimeZoneInfo.ConvertTimeToUtc(dateTime.Value.ToLocalTime());
            }

            return null;
        }
    }
}
