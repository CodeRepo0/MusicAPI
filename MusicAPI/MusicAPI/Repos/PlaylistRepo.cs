using AutoMapper;
using MusicAPI.Dto;
using MusicAPI.Models;
using System.Security.Cryptography.X509Certificates;

namespace MusicAPI.Repos
{
    public class PlaylistRepo :DataBase, IPlaylistRepo
    {
        private readonly IMapper _mapper;

        public PlaylistRepo(IMapper mapper) {
            _mapper = mapper;
        }
        public int? AddPlaylist(PlaylistModel playlist)
        {
            if (!PlaylistData.Where(s => s.PlaylistName == playlist.PlaylistName).Any())
            {
                int? op = 1;
                int num = playlist.SongsName.Count();
                for(int i = 0; i < num; i++)
                {
                    if(!SongData.Where(s=>s.SongName == playlist.SongsName[i]).Any())
                    {
                        op = null;
                    }
                }
                if(op != null)
                {
                    PlaylistData.Add(playlist);
                    return op;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        public PlayListViewModel GetPlayListObj(PlaylistModel Playlist)
        {
            var obj = _mapper.Map<PlayListViewModel>(Playlist);
            var List = new List<SongModel>();
            foreach (var song in Playlist.SongsName)
            {
                var temp = SongData.FirstOrDefault(c => c.SongName == song);
                if(temp != null)
                {
                    List.Add(temp);
                }
            }
            obj.SongsList = List;
            return obj;
        }
        public List<PlayListViewModel> GetPlaylist()
        {
            List<PlayListViewModel> Temp = new List<PlayListViewModel>();
            int count = PlaylistData.Count;
            for(int i = 0; i< count;i++)
            {
                Temp.Add(GetPlayListObj(PlaylistData[i]));
            }
            return Temp;
        }
    }
}
