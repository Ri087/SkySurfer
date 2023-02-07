using SFML.Graphics;
using SFML.Window;
using SkySurfer.Assets.Scripts;

namespace SkyRunner
{
    class Display
    {
        static void Main(string[] args)
        {
            RenderWindow window = new RenderWindow(VideoMode.DesktopMode, "Sky Surfer", Styles.None);
            window.SetFramerateLimit(60);

            GameStateManager.GetInstance().GetStates().Peek().Init();

            while (window.IsOpen)
            {
                window.DispatchEvents();

                window.Clear();

                GameStateManager.GetInstance().GetStates().Peek().Update(0f);
                GameStateManager.GetInstance().GetStates().Peek().Draw(window);

                window.Display();

                // Ferme la fenêtre
                // window.Close();
            }
        }
    }
}