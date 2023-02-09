using SFML.Graphics;
using SFML.System;
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
        private Font font = new("../../../Assets/Fonts/Balbek-Personal.otf");
        public override void Cleanup()
        {

        }

        public override void Draw(RenderWindow window)
        {
            float windowX = window.Size.X;
            float windowY = window.Size.Y;
            MainMenu[] menu =
            {
                new("Play", 50, windowX * 0.15f, windowY  * 0.10f),
                new("Settings", 50, windowX * 0.15f, windowY * 0.25f),
                new("Credits", 50, windowX * 0.15f, windowY * 0.40f),
                new("Exit", 50, windowX * 0.15f, windowY * 0.80f),
            };

            foreach (MainMenu info in menu)
            {
                TextPrint(window, info);
            }
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

        private void TextPrint(RenderWindow window, MainMenu info)
        {
            Text windowText = new(info.text, font, info.size);
            windowText.Position = new(info.x, info.y);
            window.Draw(windowText);
        }
    }
}
