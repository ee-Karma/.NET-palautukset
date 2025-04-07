using Raylib_cs;
using System.Numerics;

class Program
{
    static void Main()
    {
        
        Raylib.InitWindow(800, 600, "DVD");
        Raylib.SetTargetFPS(60);

      
        Vector2 position = new Vector2(Raylib.GetScreenWidth() / 2 - 50, Raylib.GetScreenHeight() / 2 - 10);
        Vector2 direction = new Vector2(1, 1); 
        float speed = 30.0f;

       
        int screenWidth = Raylib.GetScreenWidth();
        int screenHeight = Raylib.GetScreenHeight();

        
        int textWidth = Raylib.MeasureText("DVD", 40);
        int textHeight = 40; 

        while (!Raylib.WindowShouldClose())
        {
            float deltaTime = Raylib.GetFrameTime();

           
            position += direction * speed * deltaTime;

            
            if (position.X + textWidth > screenWidth)
            {
                position.X = screenWidth - textWidth;
                direction.X *= -1; 
            }

           
            if (position.X < 0)
            {
                position.X = 0;
                direction.X *= -1; 
            }

            
            if (position.Y + textHeight > screenHeight)
            {
                position.Y = screenHeight - textHeight;
                direction.Y *= -1; 
            }

            
            if (position.Y < 0)
            {
                position.Y = 0;
                direction.Y *= -1; 
            }

            
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

           
            Raylib.DrawText("DVD", (int)position.X, (int)position.Y, 40, Color.Yellow);

            Raylib.EndDrawing();
        }

        
        Raylib.CloseWindow();
    }
}
