using SFML.Graphics;
using SFML.Window;
using SkySurfer.Assets.Scripts.Entities;
using SkySurfer.Assets.Scripts.Menu.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Menu
{
    class LooseMenuGameState : GameBaseState
    {
        private int selected = 0;
        private Color selectedColor = Color.Green;
        private Font font = new("../../../Assets/Fonts/Balbek-Personal.otf");
        private string score = "LOOSE ! Your score: ";
        private MainMenu[] menu =

            {
                new(text: "Restart", x: 0.15f, y: 0.25f),
                new(text: "Menu", x: 0.15f, y: 0.40f),
            };
        public override void Cleanup()
        {
            //throw new NotImplementedException();
        }

        public override void Draw()
        {
            float windowX = SettingsManager.GetIntances().GetWindow().Size.X;
            float windowY = SettingsManager.GetIntances().GetWindow().Size.Y;
            ScorePrint(windowX, windowY);

            for (int i = 0; i < menu.Length; i++)
            {
                MenuPrint(menu[i], i, windowX, windowY);
            }

        }

        public override void Exit()
        {
            PlayerStateManager.GetInstance().GetPlayer().SetScore(0);
            PlayerStateManager.GetInstance().GetPlayer().SetPositionY(0.8f);
            SettingsManager.GetIntances().GetWindow().KeyPressed -= LooseMenuSelector;
        }

        public override void HandleInput()
        {
            //throw new NotImplementedException();
        }

        public override void Init()
        {
            SettingsManager.GetIntances().GetWindow().KeyPressed += LooseMenuSelector;
        }

        public override void Update(float deltaTime)
        {
            //  throw new NotImplementedException();
        }
        private void MenuPrint(MainMenu info, int i, float windowX, float windowY)
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
        private void ScorePrint(float windowX, float windowY)
        {
            Text scoreText = new(score + Math.Floor(PlayerStateManager.GetInstance().GetPlayer().GetScore()).ToString(), font, 60);
            scoreText.Position = new(windowX * 0.15f, windowY * 0.10f);
            scoreText.FillColor = Color.Red;
            SettingsManager.GetIntances().GetWindow().Draw(scoreText);
        }
        private void LooseMenuSelector(Object? sender, KeyEventArgs e)
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
                GameStateManager.GetInstance().SwitchState(GameStateManager.GetInstance().GetMainMenuGameState());
                return;
            }
        }

    }
}
