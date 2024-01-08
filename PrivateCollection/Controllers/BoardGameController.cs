using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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


    }
}
