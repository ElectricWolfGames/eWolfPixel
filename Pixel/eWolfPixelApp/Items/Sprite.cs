using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWolfPixelApp.Items
{
    public class Sprite
    {
    }

    public class Animation
    {
        private List<Sprite> _sprites = new List<Sprite>();
    }

    public class Charactor
    {
        private List<Animation> _animations = new List<Animation>();
    }
}
