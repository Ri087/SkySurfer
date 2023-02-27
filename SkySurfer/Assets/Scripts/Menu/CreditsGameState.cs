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
        private Font font = new("../../../Assets/Fonts/Balbek-Personal.otf");
        private string creditsText = "By Benjou et Jeremoux les bests";
        private int FONT_SIZE = 20;



        public override void Draw()
        {
                TextPrint(creditsText, font, FONT_SIZE);
        }

        public override void Cleanup()
        {

        }

        public override void Exit()
        {
            SettingsManager.GetIntances().GetWindow().KeyPressed -= QuitCredits;
        }

        public override void HandleInput()
        {

        }

        public override void Init()
        {
            SettingsManager.GetIntances().GetWindow().KeyPressed += QuitCredits;
        }

        public override void Update(float deltaTime)
        {

        }

        private void TextPrint(string text, Font font, int FONT_SIZE)
        {
            Text windowText = new(text, font);
            windowText.FillColor = Color.White;
            windowText.Position = new Vector2f(SettingsManager.GetIntances().GetWindow().Size.X / 2 - FONT_SIZE * 3, SettingsManager.GetIntances().GetWindow().Size.Y / 2 - FONT_SIZE * 2);
            SettingsManager.GetIntances().GetWindow().Draw(windowText);
        }
        private void QuitCredits(Object? sender, KeyEventArgs e)
        {
            if (e.Code == SettingsManager.GetIntances().GetMenuBackKey())
            {
                Exit();
                GameStateManager.GetInstance().SwitchState(GameStateManager.GetInstance().GetMainMenuGameState());
                return;
            }
        }
    }
}
