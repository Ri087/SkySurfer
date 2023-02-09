using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Menu.Class
{
    class MainMenu
    {
        public string text = "Placeholder";
        public uint size = 55;
        public float x;
        public float y;
        public Color color = Color.White;
        public MainMenu(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public MainMenu(string text, float x, float y)
        {
            this.text = text;
            this.x = x;
            this.y = y;
        }

        public MainMenu(string text, float x, float y, Color color)
        {
            this.text = text;
            this.x = x;
            this.y = y;
            this.color = color;
        }
        public MainMenu(string text, uint size, float x, float y)
        {
            this.text = text;
            this.size = size;
            this.x = x;
            this.y = y;
        }
        public MainMenu(string text, uint size, float x, float y, Color color)
        {
            this.text = text;
            this.size = size;
            this.x = x;
            this.y = y;
            this.color = color;
        }
    }
}
