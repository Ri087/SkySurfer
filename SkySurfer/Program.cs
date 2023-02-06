using SFML.Graphics;
using SFML.Window;

namespace SkyRunner
{
    class Game
    {
        static void Main(string[] args)
        {
            // Create the window
            RenderWindow window = new RenderWindow(new VideoMode(800, 500), "My game");

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