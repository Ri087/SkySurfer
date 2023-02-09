using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Menu.Class
{
    class MainMenu
    {
        public string text;
        public uint size;
        public float x;
        public float y;

        public MainMenu(string text, uint size, float x, float y)
        {
            this.text = text;
            this.size = size;
            this.x = x;
            this.y = y;
        }
    }
}
