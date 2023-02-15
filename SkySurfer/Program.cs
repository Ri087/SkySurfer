using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SkySurfer.Assets.Scripts;
using SkySurfer.Assets.Scripts.Entities;

namespace SkyRunner
{
    class Display
    {
        static void Main(string[] args)
        {
            SettingsManager.GetIntances();

            Clock clock = new Clock();
            float deltaTime = clock.Restart().AsSeconds();
<<<<<<< HEAD

=======
            GameStateManager.GetInstance().SetWindow(window);
>>>>>>> 2042dd4f7d7025b420583cf7a5a7d2f9106dc563
            GameStateManager.GetInstance().GetStates().Peek().Init();

            while (SettingsManager.GetIntances().GetWindow().IsOpen)
            {

                SettingsManager.GetIntances().GetWindow().DispatchEvents();

                SettingsManager.GetIntances().GetWindow().Clear();

                GameStateManager.GetInstance().GetStates().Peek().Update(deltaTime);
                GameStateManager.GetInstance().GetStates().Peek().Draw();

                SettingsManager.GetIntances().GetWindow().Display();

                deltaTime = clock.Restart().AsSeconds();

                // Ferme la fenêtre
                // window.Close();
            }
        }
    }
}