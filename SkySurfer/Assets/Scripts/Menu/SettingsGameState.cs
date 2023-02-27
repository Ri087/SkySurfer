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
    class SettingsGameState : GameBaseState
    {
        private int _selected = 0;
        private int _keySelected = -1;
        private Color _selectedColor = Color.Green;
        private Font _font = new("../../../Assets/Fonts/Balbek-Personal.otf");
        private MainMenu[] _keysName =
            {
                new(text: "Up", size: 25, x: 0.15f, y: 0.20f),
                new(text: "Down", size: 25, x: 0.15f, y: 0.25f),
                new(text: "Left", size: 25, x: 0.15f, y: 0.30f),
                new(text: "Right", size: 25, x: 0.15f, y: 0.35f),
                new(text: "Confirm", size: 25, x: 0.15f, y: 0.40f),
                new(text: "Back", size: 25, x: 0.15f, y: 0.45f),
                new(text: "Jump", size: 25, x: 0.15f, y: 0.65f),
                new(text: "Shot", size: 25, x: 0.15f, y: 0.70f),
                new(text: "Return", x: 0.15f, y: 0.85f),

            };
        private MainMenu[] _titles =
            {
                new(text: "Menu keys", size: 40, x: 0.15f, y: 0.10f),
                new(text: "In game keys", size: 40, x: 0.15f, y: 0.55f),
            };
        public override void Cleanup()
        {

        }

        public override void Draw()
        {
            float windowX = SettingsManager.GetIntances().GetWindow().Size.X;
            float windowY = SettingsManager.GetIntances().GetWindow().Size.Y;

            for (int i = 0; i < _keysName.Length; i++)
            {
                TextPrint(_keysName[i], i, windowX, windowY);
            }
            foreach (MainMenu title in _titles)
            {
                TextPrint(title, -1, windowX, windowY);
            }
            MainMenu[] _keys =
            {
                new(text: SettingsManager.GetIntances().GetMenuUpKey().ToString(), size: 25, x: 0.27f, y: 0.20f),
                new(text: SettingsManager.GetIntances().GetMenuDownKey().ToString(), size: 25, x: 0.27f, y: 0.25f),
                new(text: SettingsManager.GetIntances().GetMenuLeftKey().ToString(), size: 25, x: 0.27f, y: 0.30f),
                new(text: SettingsManager.GetIntances().GetMenuRightKey().ToString(), size: 25, x: 0.27f, y: 0.35f),
                new(text: SettingsManager.GetIntances().GetMenuConfirmKey().ToString(), size: 25, x: 0.27f, y: 0.40f),
                new(text: SettingsManager.GetIntances().GetMenuBackKey().ToString(), size: 25, x: 0.27f, y: 0.45f),
                new(text: SettingsManager.GetIntances().GetJumpKey().ToString(), size: 25, x: 0.27f, y: 0.65f),
                new(text: SettingsManager.GetIntances().GetShotKey().ToString(), size: 25, x: 0.27f, y: 0.70f),

            };
            for (int i = 0; i < _keys.Length; i++)
            {
                TextPrint2(_keys[i], i, windowX, windowY);
            }
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
            Text windowText = new(info.text, _font, info.size);
            windowText.Position = new(info.x * windowX, info.y * windowY);
            if (_selected == i)
            {
                windowText.FillColor = _selectedColor;
            }
            else
            {
                windowText.FillColor = info.color;
            }
            SettingsManager.GetIntances().GetWindow().Draw(windowText);
        }
        private void TextPrint2(MainMenu info, int i, float windowX, float windowY)
        {
            Text windowText = new(info.text, _font, info.size);
            windowText.Position = new(info.x * windowX, info.y * windowY);
            if (_keySelected == i)
            {
                windowText.FillColor = _selectedColor;
            }
            else
            {
                windowText.FillColor = info.color;
            }
            SettingsManager.GetIntances().GetWindow().Draw(windowText);
        }
        private void MenuSelector(Object? sender, KeyEventArgs e)
        {
            if (_keySelected >= 0)
            {
                _keySelected = -1;
                switch (_selected)
                {
                    case 0:
                        SettingsManager.GetIntances().SetMenuUpKey(e.Code);
                        break;
                    case 1:
                        SettingsManager.GetIntances().SetMenuDownKey(e.Code);
                        break;
                    case 2:
                        SettingsManager.GetIntances().SetMenuLeftKey(e.Code);
                        break;
                    case 3:
                        SettingsManager.GetIntances().SetMenuRightKey(e.Code);
                        break;
                    case 4:
                        SettingsManager.GetIntances().SetMenuConfirmKey(e.Code);
                        break;
                    case 5:
                        SettingsManager.GetIntances().SetMenuBackKey(e.Code);
                        break;
                    case 6:
                        SettingsManager.GetIntances().SetJumpKey(e.Code);
                        break;
                    case 7:
                        SettingsManager.GetIntances().SetShotKey(e.Code);
                        break;
                }
                return;
            }
            if (e.Code != SettingsManager.GetIntances().GetMenuUpKey() && e.Code != SettingsManager.GetIntances().GetMenuDownKey() && e.Code != SettingsManager.GetIntances().GetMenuConfirmKey())
            {
                return;
            }

            if (e.Code == SettingsManager.GetIntances().GetMenuUpKey() && _selected == 0)
            {
                _selected = _keysName.Length - 1;
                return;
            }
            if (e.Code == SettingsManager.GetIntances().GetMenuUpKey() && _selected > 0)
            {
                _selected--;
                return;
            }
            if (e.Code == SettingsManager.GetIntances().GetMenuDownKey() && _selected == _keysName.Length - 1)
            {
                _selected = 0;
                return;
            }
            if (e.Code == SettingsManager.GetIntances().GetMenuDownKey() && _selected < _keysName.Length - 1)
            {
                _selected++;
                return;
            }
            if (e.Code == SettingsManager.GetIntances().GetMenuConfirmKey())
            {
                if (_selected == _keysName.Count() - 1)
                {
                    Exit();
                    GameStateManager.GetInstance().SwitchState(GameStateManager.GetInstance().GetMainMenuGameState());
                }
                _keySelected = _selected;
            }
        }
    }
}