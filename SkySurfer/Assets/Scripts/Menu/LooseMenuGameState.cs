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
            SettingsManager.GetIntances().GetWindow().KeyPressed -= MenuSelector;
        }

        public override void HandleInput()
        {
            //throw new NotImplementedException();
        }

        public override void Init()
        {
            SettingsManager.GetIntances().GetWindow().KeyPressed += MenuSelector;
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
            Text scoreText = new(score + PlayerStateManager.GetInstance().GetPlayer().GetScore(), font, 60);
            scoreText.Position = new(windowX * 0.15f, windowY * 0.10f);
            scoreText.FillColor = Color.Red;
            SettingsManager.GetIntances().GetWindow().Draw(scoreText);


        }
        private void MenuSelector(Object? sender, KeyEventArgs e)
        {
            if (e.Code != Keyboard.Key.Up && e.Code != Keyboard.Key.Down && e.Code != Keyboard.Key.Enter)
            {
                return;
            }

            if (e.Code == Keyboard.Key.Up && selected == 0)
            {
                selected = menu.Length - 1;
                return;
            }
            if (e.Code == Keyboard.Key.Up && selected > 0)
            {
                selected--;
                return;
            }
            if (e.Code == Keyboard.Key.Down && selected == menu.Length - 1)
            {
                selected = 0;
                return;
            }
            if (e.Code == Keyboard.Key.Down && selected < menu.Length - 1)
            {
                selected++;
                return;
            }
            if (e.Code == Keyboard.Key.Enter && selected == 0)
            {
                GameStateManager.GetInstance().GetStates().Peek().Exit();
                GameStateManager.GetInstance().SwitchState(GameStateManager.GetInstance().GetPlayGameBaseState());
                return;
            }
            if (e.Code == Keyboard.Key.Enter && selected == 1)
            {
                Exit();
                GameStateManager.GetInstance().SwitchState(GameStateManager.GetInstance().GetMainMenuGameState());
                return;
            }
        }

    }
}
