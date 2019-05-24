using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    struct Vector2
    {
        public int x;
        public int y;

        public int positionInTail;

        public Vector2(int _x, int _y)
        {
            x = _x;
            y = _y;
            positionInTail = 0;
        }
        public Vector2(int _x, int _y, int _position)
        {
            x = _x;
            y = _y;
            positionInTail = -_position;
        }

        public void Set(int _x)
        {
            x = _x;
        }

        public void Set(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
        public void Up()
        {
            y += 1;
        }
        public void Down()
        {
            y -= 1;
        }
        public void Right()
        {
            x += 1;
        }
        public void Left()
        {
            x -= 1;
        }

    }
}
