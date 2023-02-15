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
    }
}
