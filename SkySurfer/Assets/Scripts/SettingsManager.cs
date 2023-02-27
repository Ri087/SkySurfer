using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts
{
    public class SettingsManager
    {
        private static SettingsManager _instance = new();

        private RenderWindow _window;

        private Keyboard.Key _jumpKey = Keyboard.Key.Z;

        private Keyboard.Key _shotKey = Keyboard.Key.Space;

        private Keyboard.Key _menuUp = Keyboard.Key.Up;
        private Keyboard.Key _menuDown = Keyboard.Key.Down;
        private Keyboard.Key _menuLeft = Keyboard.Key.Left;
        private Keyboard.Key _menuRight = Keyboard.Key.Right;

        private Keyboard.Key _menuConfirm = Keyboard.Key.Enter;
        private Keyboard.Key _menuBack = Keyboard.Key.Escape;

        public SettingsManager()
        {
            _window = new RenderWindow(new VideoMode(800, 600), "Sky Surfer", Styles.None);
            _window.SetFramerateLimit(60);
        }
        public static SettingsManager GetIntances()
        {
            if (_instance == null)
            {
                _instance = new();
            }
            return _instance;
        }

        public RenderWindow GetWindow()
        {
            return _window;
        }

        public void SetWindow(RenderWindow window)
        {
            _window = window;
        }

        public Keyboard.Key GetJumpKey()
        {
            return _jumpKey;
        }
        public void SetJumpKey(Keyboard.Key jumpKey)
        {
            _jumpKey = jumpKey;
        }
        public Keyboard.Key GetShotKey()
        {
            return _shotKey;
        }
        public void SetShotKey(Keyboard.Key shotKey)
        {
            _shotKey = shotKey;
        }
        public Keyboard.Key GetMenuUpKey()
        {
            return _menuUp;
        }
        public void SetMenuUpKey(Keyboard.Key menuUp)
        {
            _menuUp = menuUp;
        }
        public Keyboard.Key GetMenuDownKey()
        {
            return _menuDown;
        }
        public void SetMenuDownKey(Keyboard.Key menuDown)
        {
            _menuDown = menuDown;
        }
        public Keyboard.Key GetMenuLeftKey()
        {
            return _menuLeft;
        }
        public void SetMenuLeftKey(Keyboard.Key menuLeft)
        {
            _menuLeft = menuLeft;
        }
        public Keyboard.Key GetMenuRightKey()
        {
            return _menuRight;
        }
        public void SetMenuRightKey(Keyboard.Key menuRight)
        {
            _menuRight = menuRight;
        }
        public Keyboard.Key GetMenuConfirmKey()
        {
            return _menuConfirm;
        }
        public void SetMenuConfirmKey(Keyboard.Key menuConfirm)
        {
            _menuConfirm = menuConfirm;
        }
        public Keyboard.Key GetMenuBackKey()
        {
            return _menuBack;
        }
        public void SetMenuBackKey(Keyboard.Key menuBack)
        {
            _menuBack = menuBack;
        }
    }
}
