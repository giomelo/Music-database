using System;
using Projeto_DTI.Models;
using Projeto_DTI.Entities;
using System.Collections.Generic;


namespace Projeto_DTI.Controllers
{
    class Controller
    {
        public static void ReadInput(int number)
        {
            switch(number)
            {
                case 1:
                View.ShowCreateAlbum();
                break;

                case 2:
                View.ShowSearchAlbum();
                break;
                
                case 3:
                View.ShowSearchMusic();
                break;
                case 4:
                CreatePlaylist();
                break;
                case 5:
                Close();
                break;

                default:
                View.ShowMenu();
                break;
            }
        }

        public static void CreateAlbum(string title, List<Music> musics, int releasedeYear, string bandName)
        {
            Model.CreateAlbum(title, musics, releasedeYear, bandName);
        }

        public static void SearchAlbumYear(int year)
        {
            List<Album> albuns = Model.SearchAlbumYear(year);
            if(albuns.Count > 0)
            {
                //View.Clear();
                foreach(Album album in albuns)
                {
                    View.ShowAlbum(album); 
                }
                
            }else{
                //View.Clear();
                View.ErrorMessage(Enum.ErrorMessage.SEARCH);
            }
            
        }
        public static void SearchAlbumString(string info)
        {
           List<Album> albuns = Model.SearchString(info);
            if(albuns.Count > 0)
            {
                //View.Clear();
                foreach(Album album in albuns)
                {
                    View.ShowAlbum(album); 
                }
                
            }else{
                //View.Clear();
                View.ErrorMessage(Enum.ErrorMessage.SEARCH);
            }
        }

        public static void SearchMusic(string info)
        {
            List<Music> musicsAux = Model.SearchMusic(info);
            if(musicsAux.Count > 0)
            {
                //View.Clear();
                foreach(Music music in musicsAux)
                {
                    View.ShowMusic(music); 
                }

            }else{
               // View.Clear();
                View.ErrorMessage(Enum.ErrorMessage.SEARCH);
            }
        }

        static void CreatePlaylist()
        {
            //List<Music> teste = Model.CreatePlaylist();
            View.ShowPlaylist(Model.CreatePlaylist());
        }

        static void Close()
        {
            Environment.Exit(0);
        }
    }
}
