using SFML.Graphics;
using SFML.System;
using SFML.Window;
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
        public override void Draw(RenderWindow window)
        {
            float windowX = window.Size.X;
            float windowY = window.Size.Y;

            for (int i = 0; i < menu.Length; i++)
            {
                TextPrint(window, menu[i], i, windowX, windowY);
            }
        }
        public override void Cleanup()
        {

        }

        public override void Exit()
        {

        }

        public override void HandleInput()
        {

        }

        public override void Init()
        {
        }

        public override void Update(float deltaTime)
        {

        }

        private void TextPrint(RenderWindow window, MainMenu info, int i, float windowX, float windowY)
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
            window.Draw(windowText);
        }
    }
}
