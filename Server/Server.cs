using Application.Config;
using Application.Controller;

namespace Application
{

    public class MyServer
    {
        public static Game Game;
        static void Main(string[] args)
        {

            Game = new Game();

            Game.Run(args);


        }
	}



}