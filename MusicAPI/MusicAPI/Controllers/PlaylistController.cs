using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicAPI.Models;
using MusicAPI.Repos;

namespace MusicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistRepo _repo;
        public PlaylistController(IPlaylistRepo repo)
        {

            _repo = repo;
        }
        [HttpPost]
        public IActionResult AddPlayList(PlaylistModel playlist)
        {
            int? op = _repo.AddPlaylist(playlist);
            if(op != null)
            {
                return Ok("PlayList Added");
            }
            return BadRequest("Try again");
        }
        [HttpGet]
        public IActionResult GetPlayList()
        {
            return Ok(_repo.GetPlaylist());
        }
    }
}
