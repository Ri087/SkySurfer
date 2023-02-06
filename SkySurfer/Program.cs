using SFML.Graphics;
using SFML.Window;

namespace SkyRunner
{
    class Game
    {
        static void Main(string[] args)
        {
            // Create the window (mode: Borderless Windowed)
            RenderWindow window = new RenderWindow(VideoMode.DesktopMode, "Sky Surfer", Styles.None);

            // Run the game loop
            while (window.IsOpen)
            {
                // Handle events
                window.DispatchEvents();

                // Update the game

                // Draw the game
                window.Clear();

                // ... draw your game here ...
                window.Display();
            }
        }
    }
}