using System;
using System.Collections.Generic;
using System.Linq;
using Projeto_DTI.Entities;

namespace Projeto_DTI.Models
{
    class Model
    {
        public static List<Album> albuns = new List<Album>();

        public static void CreateAlbum(string title, List<Music> musics, int releasedeYear, string bandName)
        {
            Album a = new Album(title, musics, releasedeYear,bandName);
            albuns.Add(a);
        }

        public static List<Album> SearchAlbumYear(int year)
        {
            List<Album> aux = new List<Album>();
            foreach(Album a in albuns)
            {
                System.Console.WriteLine(a.ReleasedeYear);
                if(a.ReleasedeYear.Equals(year))
                {
                    aux.Add(a);
                }
            }
            return aux;
        }
        public static List<Album> SearchString(string info)
        {
            List<Album> aux = new List<Album>();
            foreach(Album a in albuns)
            {
                if(a.Title.ToLower().Equals(info))
                {
                    aux.Add(a);
                }
            }
            foreach(Album a in albuns)
            {
                if(a.BandName.ToLower().Equals(info))
                {
                   aux.Add(a);
                }
            }
            return aux;
        }


        public static List<Music> SearchMusic(string info)
        {
            List<Music> musics = new List<Music>();
            //search by name
            foreach(Album album in albuns)
            {
                foreach (var music in album.Musics.Where(music => music.Name.Equals(info)).Where(music => !musics.Contains(music)))
                {
                    musics.Add(music);
                }
            }
            //search by band
            foreach(Album album in albuns)
            {
                if (!album.BandName.Equals(info)) continue;
                foreach(Music music in album.Musics)
                {
                    if(!musics.Contains(music))
                    {
                        musics.Add(music);
                    }
                }
            }

            return musics;
        }

        public static List<Music> CreatePlaylist()
        {
            Random rand = new Random();
            List<Music> playlist = new List<Music>();
            List<Music> allMusics = new List<Music>();
            TimeSpan maxDuration = new TimeSpan(1,0,0);
            TimeSpan currentDuration = new TimeSpan();
            bool fav = true;
            bool hasFav = false;
            foreach(Album album in albuns)
            {
                foreach(Music music in album.Musics)
                {
                    if(!allMusics.Contains(music))
                    {
                        allMusics.Add(music);
                    }
                }
            }
            do{
                    hasFav = false;
                    foreach(Music music in allMusics)
                    {
                        if(music.Favorite == fav)
                        {
                            hasFav = true;
                        }
                    }
                    if(!hasFav)
                    {
                        fav = !fav;
                    }
                    
                    Music aux = new Music();
                    int index = (int)rand.Next(0, allMusics.Count);
                    Music m = allMusics[index];
                    if(m.Favorite == fav)
                    {
                        aux = m;
                        allMusics.Remove(m);
                        currentDuration = currentDuration.Add(m.Duration);
                        playlist.Add(m);
                        fav = false;
                    }
                    
                
            }while(currentDuration <= maxDuration && allMusics.Count > 0);

            return playlist;
        }
        

    }
}
