using Raylib_cs;
using System.Data;
using System.Numerics;

namespace dvd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector2 position = new Vector2(100, 100);
            Vector2 direction = new Vector2(1, 0);
            float speed = 30f;


            Raylib.InitWindow(800, 800, "DVD");

            while(Raylib.WindowShouldClose() == false)
            {
                Raylib.ClearBackground(Color.Black);
                Raylib.DrawText(
                position += direction * speed * Raylib.GetFrameTime();

                
            }


        }
    }
}
