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