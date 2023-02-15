using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SkyRunner;
using SkySurfer.Assets.Scripts.Menu.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Menu
{
    class MainMenuGameState : GameBaseState
    {
        private int selected = 0;
        private Color selectedColor = Color.Green;
        private Font font = new("../../../Assets/Fonts/Balbek-Personal.otf");
        private MainMenu[] menu =

            {
                new(text: "Play", x: 0.15f, y: 0.10f),
                new(text: "Settings", x: 0.15f, y: 0.25f),
                new(text: "Credits", x: 0.15f, y: 0.40f),
                new(text: "Exit", x: 0.15f, y: 0.80f),
            };
        public override void Draw()
        {
            float windowX = SettingsManager.GetIntances().GetWindow().Size.X;
            float windowY = SettingsManager.GetIntances().GetWindow().Size.Y;

            for (int i = 0; i < menu.Length; i++)
            {
                TextPrint(menu[i], i, windowX, windowY);
            }
        }
        
        public override void Cleanup()
        {

        }

        public override void Exit()
        {
            SettingsManager.GetIntances().GetWindow().KeyPressed -= MenuSelector;
        }

        public override void HandleInput()
        {

        }

        public override void Init()
        {
            SettingsManager.GetIntances().GetWindow().KeyPressed += MenuSelector;
        }

        public override void Update(float deltaTime)
        {

        }

        private void TextPrint(MainMenu info, int i, float windowX, float windowY)
        {
            Text windowText = new(info.text, font, info.size);
            windowText.Position = new(info.x * windowX, info.y * windowY);
            if (selected == i)
            {
                windowText.FillColor = selectedColor;
            } else
            {
                windowText.FillColor = info.color;
            }
            SettingsManager.GetIntances().GetWindow().Draw(windowText);
        }
        private void MenuSelector(Object? sender , KeyEventArgs e)
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
                Exit();
                GameStateManager.GetInstance().SwitchState(GameStateManager.GetInstance().GetPlayGameBaseState());
                return;
            }
            if (e.Code == Keyboard.Key.Enter && selected == 1)
            {
                Exit();
                GameStateManager.GetInstance().AddState(GameStateManager.GetInstance().GetSettingsGameState());
                return;
            }
            if (e.Code == Keyboard.Key.Enter && selected == 2)
            {
                Exit();
                GameStateManager.GetInstance().AddState(GameStateManager.GetInstance().GetCreditsGameState());
                return;
            }
            if (e.Code == Keyboard.Key.Enter && selected == 3)
            {
                Console.WriteLine("Quit Game !");
                return;
            }
        }
    }
}
