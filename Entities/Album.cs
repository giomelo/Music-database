using System;
using System.Collections.Generic;

namespace Projeto_DTI.Entities
{
    internal class Album
    {
        public string Title { get; set;}
        public List<Music> Musics = new List<Music>(); 
        public int ReleasedeYear{ get; set;}
        public string BandName{ get; set;}


        public Album(string title, List<Music> musics, int releasedeYear, string bandName)
        {
            Title = title;
            Musics = musics;
            ReleasedeYear = releasedeYear;
            BandName = bandName;
        }
    }
}
