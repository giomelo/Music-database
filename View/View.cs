using System;
using Projeto_DTI.Controllers;
using Projeto_DTI.Entities;
using System.Collections.Generic;
using Projeto_DTI.Enum;

namespace Projeto_DTI
{
    internal static class View
    {
        public static void ShowMenu()
        {
            try{
                System.Console.WriteLine();
                System.Console.WriteLine("Bem-Vindo ao Banco Musical!");
                System.Console.WriteLine();
                System.Console.WriteLine("Digite um número correspondente a ação que deseja realizar.");
                System.Console.WriteLine("[1]Cadastrar álbum");
                System.Console.WriteLine("[2]Pesquisar álbum");
                System.Console.WriteLine("[3]Pesquisar música");
                System.Console.WriteLine("[4]Gerar PlayList");
                System.Console.WriteLine("[5]Sair");
                int number = int.Parse(Console.ReadLine());
                Controller.ReadInput(number);
            }catch(System.Exception)
            {
                Clear();
                ErrorMessage(Enum.ErrorMessage.INPUT);
                ShowMenu();
            }
           
        }

        public static void ShowCreateAlbum()
        {
            try{
                Clear();
                System.Console.WriteLine("Digite o nome do álbum: ");
                string title = Console.ReadLine();
                System.Console.WriteLine("Digite o ano de lançamento do álbum: ");
                int year = int.Parse(Console.ReadLine());
                System.Console.WriteLine("Digite o nome da banda: ");
                string bandName = Console.ReadLine();
            
                Controller.CreateAlbum(title, ShowCreateSongs(bandName), year, bandName);
                System.Console.WriteLine("Álbum criado!");
                ShowMenu();
               
            }catch(System.Exception)
            {
                Clear();
                ErrorMessage(Enum.ErrorMessage.INPUT);
                ShowMenu();
            }
            
        }

        static List<Music> ShowCreateSongs(string bandName)
        {
            List<Music> musicsAux = new List<Music>();
            
            System.Console.WriteLine("Quantas músicas serão adicionadas nesse álbum? ");
            int amount = int.Parse(Console.ReadLine());
            for(int i = 0; i< amount; i++)
            {
                
                Music musicAux = CreateSong(bandName);
                musicsAux.Add(musicAux);
               
            }
            
            return musicsAux;
        }

        static Music CreateSong(string bandName)
        {
            Music musicAux = new Music();
            try{
                System.Console.WriteLine("Digite o nome da música: ");
            string name = Console.ReadLine();
            System.Console.WriteLine("Digite a duração da música(min:ss):");
            string time = Console.ReadLine();
            string[] dur =  time.Split(':');
            TimeSpan duration = new TimeSpan(0, int.Parse(dur[0]), int.Parse(dur[1]));
            System.Console.WriteLine("Ela é sua favorita? (s/n)");
            char favorite = char.Parse(Console.ReadLine());
            bool fav = false;
                switch(favorite)
                {
                    case 's':
                    fav = true;
                    break;
                    case 'n':
                    fav = false;
                    break;
                }
                musicAux = new Music(name, duration, fav, bandName);
            }catch(SystemException)
            {
                Clear();
                ErrorMessage(Enum.ErrorMessage.INPUT);
                CreateSong(bandName);
            }
            
            return musicAux;
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static void ShowSearchAlbum()
        {
            Clear();
            System.Console.WriteLine("Digite alguma informação sobre o álbum para buscar: ");
            string info = Console.ReadLine();
            int number;
            bool success = Int32.TryParse(info, out number);
            if(success)
            {
                System.Console.WriteLine("oi");
                Controller.SearchAlbumYear(int.Parse(info));
            }else
            {   
                 Controller.SearchAlbumString(info.ToString());
            }
            
        }

        public static void ShowAlbum(Album album)
        {
            System.Console.WriteLine();
            System.Console.Write(album.Title);
            System.Console.WriteLine(" - " + album.ReleasedeYear);
            System.Console.WriteLine(" Músicas do álbum: ");
            foreach(Music music in album.Musics)
            {
                System.Console.WriteLine(music.Name);
            } 
            ShowMenu();
        }

        public static void ShowMusic(Music music)
        {
            System.Console.WriteLine();
            System.Console.Write(music.Name);
            System.Console.Write(" - {0}:{1}", music.Duration.Minutes, music.Duration.Seconds);
        }

        public static void ErrorMessage(Enum.ErrorMessage e)
        {
            switch(e)
            {
                case Enum.ErrorMessage.SEARCH:
                 System.Console.WriteLine("Sua busca não encontrou resultado.");
                break;

                case Enum.ErrorMessage.INPUT:
                System.Console.WriteLine("Input inserido incorreto.");
                break;
            }
        }

        public static void ShowSearchMusic()
        {
            Clear();
            System.Console.WriteLine("Busque pelo nome ou pela banda a música que deseja: ");
            string info = Console.ReadLine();
            Controller.SearchMusic(info);
        }

        public static void ShowPlaylist(List<Music> musics)
        {
            System.Console.WriteLine(musics.Count);
            System.Console.WriteLine("Playlist Criada:");
            foreach(Music m in musics)
            {
                System.Console.Write("{0} - {1} - {2}", m.Name, m.Duration, m.BandName);
                System.Console.WriteLine();
               
            }

            ShowMenu();
        }
    }
}
