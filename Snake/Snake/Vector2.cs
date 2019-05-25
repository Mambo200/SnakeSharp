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

        #region Operator
        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            return new Vector2(left.x + right.x, left.y + right.y);
        }
        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            return new Vector2(left.x - right.x, left.y - right.y);
        }
        public static Vector2 operator *(Vector2 left, int right)
        {
            return new Vector2(left.x * right, left.y * right);
        }
        public static bool operator ==(Vector2 left, Vector2 right)
        {
            if (left.x == right.x &&
                left.y == right.y)
            {
                return true;
            }
            else
                return false;
        }
        public static bool operator !=(Vector2 left, Vector2 right)
        {
            if (left.x != right.x &&
                left.y != right.y)
            {
                return true;
            }
            else
                return false;
        }
        #endregion
    }
}
