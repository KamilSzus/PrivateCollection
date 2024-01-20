using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PrivateCollection.Dto;
using PrivateCollection.Interfaces;
using PrivateCollection.Repository;

namespace PrivateCollection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoardGameController : ControllerBase
    {
        private readonly IBoardGameRepository BoardGameRepository;
        private readonly IMapper Mapper;
        public BoardGameController(IBoardGameRepository boardGameRepository, IMapper mapper)
        {

            this.BoardGameRepository = boardGameRepository;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Return list of Board games
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BoardGameDto>))]
        public async Task<IEnumerable<BoardGameDto>> GetBoardGames()
        {
            var boardGames = await this.BoardGameRepository.GetListOfBoardGames();

            return this.Mapper.Map<IEnumerable<BoardGameDto>>(boardGames);
        }

        /// <summary>
        /// Return Board game by id
        /// </summary>
        /// <param name="boardGameId"></param>
        /// <returns></returns>
        [HttpGet("{boardGameId}")]
        [ProducesResponseType(200, Type = typeof(BoardGameDto))]
        public async Task<BoardGameDto> GetBoardGameById(int boardGameId)
        {
            var boardGame = await this.BoardGameRepository.GetBoardGameById(boardGameId);

            return this.Mapper.Map<BoardGameDto>(boardGame);
        }

        /// <summary>
        /// Return Board game by name
        /// </summary>
        /// <param name="boardGameName"></param>
        /// <returns></returns>
        [HttpGet("name/{boardGameId}")]
        [ProducesResponseType(200, Type = typeof(BoardGameDto))]
        public async Task<BoardGameDto> GetBoardGameByName(string boardGameName)
        {
            var boardGame = await this.BoardGameRepository.GetBoardGameByName(boardGameName);

            return this.Mapper.Map<BoardGameDto>(boardGame);
        }

        /// <summary>
        /// Create new board game
        /// </summary>
        /// <param name="boardGame"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(BoardGameDto))]
        public async Task<BoardGameDto> CreateBoardGame(BoardGameDto boardGame)
        {
            var newBoardGame = await this.BoardGameRepository.CreateBoardGame(boardGame);

            return this.Mapper.Map<BoardGameDto>(newBoardGame);
        }

        /// <summary>
        /// Delete Board Game
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(BoardGameDto))]
        public async Task<BoardGameDto> DeleteBoardGamek(string name)
        {
            var boardGameToDelete = await this.BoardGameRepository.DeleteBoardGame(name);

            if (boardGameToDelete is null)
                return null;

            return this.Mapper.Map<BoardGameDto>(boardGameToDelete);
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(BoardGameDto))]
        public async Task<BoardGameDto> UpdateBoardGameStat([BindRequired][FromQuery] string boardGameTitle,
            [BindRequired][FromQuery] DateTime lastGameDate, [BindRequired][FromQuery] string gameTime)
        {
            var isCorrectFormat = TimeSpan.TryParse(gameTime, out var time);

            if (!isCorrectFormat)
                throw new ArgumentException("Given game time is incorrect");

            var boardGameToUpdate = await this.BoardGameRepository.UpdateBoardGameStats(boardGameTitle, lastGameDate, time);

            return this.Mapper.Map<BoardGameDto>(boardGameToUpdate);
        }
    }
}
