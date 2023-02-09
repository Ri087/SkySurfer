using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SkySurfer.Assets.Scripts;

namespace SkyRunner
{
    class Display
    {
        static void Main(string[] args)
        {
            //RenderWindow window = new RenderWindow(VideoMode.DesktopMode, "Sky Surfer", Styles.None);
            RenderWindow window = new RenderWindow(new VideoMode(800, 600), "Sky Surfer", Styles.None);
            window.SetFramerateLimit(60);

            Clock clock = new Clock();
            float deltaTime = clock.Restart().AsSeconds();

            GameStateManager.GetInstance().GetStates().Peek().Init();

            while (window.IsOpen)
            {

                window.DispatchEvents();

                window.Clear();


                Console.WriteLine(deltaTime);
                GameStateManager.GetInstance().GetStates().Peek().Update(deltaTime);
                GameStateManager.GetInstance().GetStates().Peek().Draw(window);

                window.Display();

                deltaTime = clock.Restart().AsSeconds();

                // Ferme la fenêtre
                // window.Close();
            }
        }
    }
}