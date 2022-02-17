using System;
using System.Collections.Generic;

namespace Projeto_DTI.Entities
{
    public class Music
    {
        public string Name{ get; set;}
        public TimeSpan Duration{ get; set;}
        public bool Favorite{ get; set;} = false;
        public string BandName{ get; set;}

        public Music(string name, TimeSpan duration, bool favorite, string bandName)
        {
            Name = name;
            Duration = duration;
            Favorite = favorite;
            BandName = bandName;
        }

        public Music()
        {

        }
    }
}
