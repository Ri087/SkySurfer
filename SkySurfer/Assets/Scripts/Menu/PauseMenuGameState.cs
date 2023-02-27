using SFML.Graphics;
using SFML.Window;
using SkySurfer.Assets.Scripts.Menu.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Menu
{
    class PauseMenuGameState : GameBaseState
    {
        private int selected = 0;
        private Color selectedColor = Color.Green;
        private Font font = new("../../../Assets/Fonts/Balbek-Personal.otf");
        private MainMenu[] menu =

            {
                new(text: "Resume", x: 0.15f, y: 0.10f),
                new(text: "Restart", x: 0.15f, y: 0.25f),
                new(text: "Quit Game", x: 0.15f, y: 0.40f),

            };
        public override void Cleanup()
        {
            //   throw new NotImplementedException();
        }

        public override void Draw()
        {
            float windowX = SettingsManager.GetIntances().GetWindow().Size.X;
            float windowY = SettingsManager.GetIntances().GetWindow().Size.Y;

            for (int i = 0; i < menu.Length; i++)
            {
                PauseMenuPrinte(menu[i], i, windowX, windowY);
            }

        }
    

        public override void Exit()
        {
            SettingsManager.GetIntances().GetWindow().KeyPressed -= QuitPause;
            SettingsManager.GetIntances().GetWindow().KeyPressed -= PauseMenuSelector;
        }

        public override void HandleInput()
        {
        }

        public override void Init()
        {
            SettingsManager.GetIntances().GetWindow().KeyPressed += QuitPause;
            SettingsManager.GetIntances().GetWindow().KeyPressed += PauseMenuSelector;

            

        }

        public override void Update(float deltaTime)
        {
        }
        private void QuitPause(Object? sender, KeyEventArgs e)
        {
            if (e.Code != SettingsManager.GetIntances().GetMenuBackKey())
            {
                return;
            }
            Exit();
            GameStateManager.GetInstance().SwitchState(GameStateManager.GetInstance().GetPlayGameBaseState());
        }

        private void PauseMenuSelector(Object? sender, KeyEventArgs e)
        {
            if (e.Code != SettingsManager.GetIntances().GetMenuUpKey() && e.Code != SettingsManager.GetIntances().GetMenuDownKey() && e.Code != SettingsManager.GetIntances().GetMenuConfirmKey())
            {
                return;
            }

            if (e.Code == SettingsManager.GetIntances().GetMenuUpKey() && selected == 0)
            {
                selected = menu.Length - 1;
                return;
            }
            if (e.Code == SettingsManager.GetIntances().GetMenuUpKey() && selected > 0)
            {
                selected--;
                return;
            }
            if (e.Code == SettingsManager.GetIntances().GetMenuDownKey() && selected == menu.Length - 1)
            {
                selected = 0;
                return;
            }
            if (e.Code == SettingsManager.GetIntances().GetMenuDownKey() && selected < menu.Length - 1)
            {
                selected++;
                return;
            }
            if (e.Code == SettingsManager.GetIntances().GetMenuConfirmKey() && selected == 0)
            {
                Exit();
                GameStateManager.GetInstance().SwitchState(GameStateManager.GetInstance().GetPlayGameBaseState());
                return;
            }
            if (e.Code == SettingsManager.GetIntances().GetMenuConfirmKey() && selected == 1)
            {
                Exit();
                GameStateManager.GetInstance().GetPlayGameBaseState().Exit();
                GameStateManager.GetInstance().SwitchState(GameStateManager.GetInstance().GetPlayGameBaseState());
                return;
            }
            if (e.Code == SettingsManager.GetIntances().GetMenuConfirmKey() && selected == 2)
            {
                Exit();
                GameStateManager.GetInstance().GetPlayGameBaseState().Exit();
                GameStateManager.GetInstance().SwitchState(GameStateManager.GetInstance().GetMainMenuGameState());
                return;
            }
        }

        private void PauseMenuPrinte(MainMenu info, int i, float windowX, float windowY)
        {
            Text windowText = new(info.text, font, info.size);
            windowText.Position = new(info.x * windowX, info.y * windowY);
            if (selected == i)
            {
                windowText.FillColor = selectedColor;
            }
            else
            {
                windowText.FillColor = info.color;
            }
            SettingsManager.GetIntances().GetWindow().Draw(windowText);
        }
    }
}
