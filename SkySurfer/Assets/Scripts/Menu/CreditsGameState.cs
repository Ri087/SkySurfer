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
    class CreditsGameState : GameBaseState
    {

        private RenderWindow? window;
        private Font font = new("../../../Assets/Fonts/Balbek-Personal.otf");
        private string creditsText = "Hello le monde";
        private int FONT_SIZE = 20;



        public override void Draw(RenderWindow window)
        {
                TextPrint(window, creditsText, font, FONT_SIZE);
        }

        public override void Cleanup()
        {

        }

        public override void Exit()
        {
            window.KeyPressed -= QuitCredits;
        }

        public override void HandleInput()
        {

        }

        public override void Init()
        {
         this.window =  GameStateManager.GetInstance().GetWindow();
         window.KeyPressed += QuitCredits;

        }

        public override void Update(float deltaTime)
        {

        }

        private void TextPrint(RenderWindow window, string text, Font font, int FONT_SIZE)
        {
            Text windowText = new(text, font);
            windowText.FillColor = Color.White;
            windowText.Position = new Vector2f(window.Size.X / 2 - FONT_SIZE * 3, window.Size.Y / 2 - FONT_SIZE * 2);
            window.Draw(windowText);
        }
        private void QuitCredits(Object? sender, KeyEventArgs e)
        {
            if (e.Code != Keyboard.Key.Escape)
            {
                return;
            }

            if (e.Code == Keyboard.Key.Escape)
            {
                Exit();
                GameStateManager.GetInstance().ReturnState();
                return;
            }

          
        }
    }
}
