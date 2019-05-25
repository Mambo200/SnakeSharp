using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Movement
    {
        public void Move(Player _player, NextDirection _currentDir, NextDirection _nextDir)
        {
            Vector2 headPos = _player.Tails[0].Position;

            bool goforCurrentDir = false;

            switch (_nextDir)
            {
                case NextDirection.NONE:
                    goforCurrentDir = true;
                    break;
                case NextDirection.UP:
                    if (_currentDir != NextDirection.DOWN)
                        headPos.Up();
                    _player.SetCurrentDirection(NextDirection.UP);
                    break;
                case NextDirection.DOWN:
                    if (_currentDir != NextDirection.UP)
                        headPos.Down();
                    _player.SetCurrentDirection(NextDirection.DOWN);
                    break;
                case NextDirection.LEFT:
                    if (_currentDir != NextDirection.RIGHT)
                        headPos.Left();
                    _player.SetCurrentDirection(NextDirection.LEFT);
                    break;
                case NextDirection.RIGHT:
                    if (_currentDir != NextDirection.LEFT)
                        headPos.Right();
                    _player.SetCurrentDirection(NextDirection.RIGHT);
                    break;
            }

            _player.ResetNextDirection();

            if (goforCurrentDir)
            {
                switch (_currentDir)
                {
                    case NextDirection.UP:
                        headPos.Up();
                        break;
                    case NextDirection.DOWN:
                        headPos.Down();
                        break;
                    case NextDirection.LEFT:
                        headPos.Left();
                        break;
                    case NextDirection.RIGHT:
                        headPos.Right();
                        break;
                }
            }

            Vector2 lastTailPos = _player.Tails[0].Position;
            _player.Tails[0].Position = headPos;

            for (int i = 1; i < _player.TailLengh; i++)
            {
                Vector2 tailPos = _player.Tails[i].Position;
                _player.Tails[i].Position = lastTailPos;
                lastTailPos = tailPos;
            }
        }
    }
}
