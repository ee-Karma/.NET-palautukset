using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Ammo
    {
        public float x, y, speed, dirX, dirY;

        public Ammo(float x, float y, float dirX, float dirY)
        {
            this.x = x;
            this.y = y;
            this.dirX = dirX;
            this.dirY = dirY;
            this.speed = 300f;
        }

        public void Update()
        {
            x += (float) dirX * speed * Raylib.GetFrameTime();
            y += (float) dirY * speed * Raylib.GetFrameTime();
        }

        public void Draw()
        {
            Raylib.DrawCircle((int)x, (int)y, 5, Color.Yellow);
        }

        public Raylib_cs.Rectangle GetRect()
        {
            return new Raylib_cs.Rectangle(x - 5, y - 5, 10, 10);
        }
    }
}
