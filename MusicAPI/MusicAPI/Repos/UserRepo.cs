using AutoMapper;
using MusicAPI.Dto;
using MusicAPI.Models;

namespace MusicAPI.Repos
{
    public class UserRepo :DataBase, IUserRepo
    {
        private readonly IMapper _mapper;
        public UserRepo(IMapper mapper) { 
            _mapper = mapper;
        }
        public int? AddUser(UserModel User)
        {

            if(!UserData.Where(s=>s.Name == User.Name).Any())
            {
                int? op = 1;
                int count = User.Playlist.Count;
                for(int i = 0; i < count; i++)
                {
                    if (!PlaylistData.Where(s => s.PlaylistName == User.Playlist[i]).Any()) {
                        op = null;
                    }
                }
                if(op != null) { 
                    UserData.Add(User);
                }
                return op;
            }
            return null;
        }

       

        public UserViewModel GetListOfUserList(UserModel user)
        {
            var obj = _mapper.Map<UserViewModel>(user);
            var list = new List<PlayListViewModel>();
            foreach (var item in user.Playlist) {
                var temp = PlaylistData.FirstOrDefault(c => c.PlaylistName == item);
                if(temp != null)
                {
                    list.Add(GetPlayListObj(temp));
                }
            }
            obj.UserPlayList = list;
            return obj;
        }
        public PlayListViewModel GetPlayListObj(PlaylistModel Playlist)
        {
            var obj = _mapper.Map<PlayListViewModel>(Playlist);
            var List = new List<SongModel>();
            foreach (var song in Playlist.SongsName)
            {
                var temp = SongData.FirstOrDefault(c => c.SongName == song);
                if (temp != null)
                {
                    List.Add(temp);
                }
            }
            obj.SongsList = List;
            return obj;
        }
        public List<UserViewModel> GetUserList()
        {
            var Temp = new List<UserViewModel>();
            int? count = UserData.Count;
           
            for (int i = 0; i < count; i++)
            {
                Temp.Add(GetListOfUserList(UserData[i]));
            }
            return Temp;
        }
        //public List<PlayListViewModel> GetPlaylist()
        //{
        //    List<PlayListViewModel> Temp = new List<PlayListViewModel>();
        //    int count = PlaylistData.Count;
        //    for (int i = 0; i < count; i++)
        //    {
        //        Temp.Add(GetPlayListObj(PlaylistData[i]));
        //    }
        //    return Temp;
        //}
    }
}
