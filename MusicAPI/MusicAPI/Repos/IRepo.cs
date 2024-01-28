﻿using MusicAPI.Dto;
using MusicAPI.Models;

namespace MusicAPI.Repos
{
    public interface IArtistRepo
    {
        int AddArtist(ArtistModel artist);
        List<ArtistModel> GetArtistList();
        void DeleteArtist(string artist);
        int? UpdateArtist(string artistnName, ArtistModel artist);
        int? DeleteArtistSongs(string ArtistName);
        int? ReplaceArtistOfSong(string oldArtist, string newArtist);
    }
    public interface IUserRepo {
        int? AddUser(UserModel User);
        UserViewModel GetListOfUserList(UserModel user); 
        PlayListViewModel GetPlayListObj(PlaylistModel Playlist);
        List<UserViewModel> GetUserList();
    }
    public interface ISongRepo {
        int? AddSong(SongModel song);
        List<SongModel> GetSongs();
        int? DeleteSong(string songName);
        int? EditSong(string OldSong, SongModel NewSong);


    }
    public interface IPlaylistRepo {
        int? AddPlaylist(PlaylistModel playlist);
        List<PlayListViewModel> GetPlaylist();
    }
}