using Raylib_cs;
using System.Numerics;

namespace raylib_Testi
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            
            Vector2 A = new Vector2(800 / 2, 0);
            Vector2 B = new Vector2(0, 800 / 2);
            Vector2 C = new Vector2(800, 800 * 3 / 4);

            Vector2 directionA = new Vector2(1, 1);
            Vector2 directionB = new Vector2(1, -1);
            Vector2 directionC = new Vector2(-1, -1);

            float speed = 700f;


            Raylib.InitWindow(800, 800, "Raylib Testi");


            while (Raylib.WindowShouldClose() == false)
         {
          Raylib.BeginDrawing();
          Raylib.ClearBackground(Color.Black);
                Raylib.DrawLineV(A, B, Color.Green);
                Raylib.DrawLineV(B, C, Color.Yellow);
                Raylib.DrawLineV(C, A, Color.Blue);

                Vector2 moveA = directionA * speed * Raylib.GetFrameTime();
                Vector2 moveB = directionB * speed * Raylib.GetFrameTime();
                Vector2 moveC = directionC * speed * Raylib.GetFrameTime();

                A = A + moveA;
                B = B + moveB;
                C = C + moveC;

                if (A.X > 800 || A.X < 0)
                {
                    directionA = directionA * -1;
                }
                if (B.X > 800 || B.X < 0)
                {
                    directionB = directionB * -1;
                }
                if (C.X > 800 || C.X < 0)
                {
                    directionC = directionC * -1;
                }

                if (A.Y > 800 || A.Y < 0)
                {
                    directionA = directionA * -1;
                }
                if (B.Y > 800 || B.Y < 0)
                {
                    directionB = directionB * -1;
                }
                if (C.Y > 800 || C.Y < 0)
                {
                    directionC = directionC * -1;
                }


                Raylib.EndDrawing();
         }
         Raylib.CloseWindow();
            
       
        }
    }
}
