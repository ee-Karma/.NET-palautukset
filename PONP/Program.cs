using Raylib_cs;
using System;
using System.Numerics;
namespace PONP;
class Program
{
    
    const int screenWidth = 800;
    const int screenHeight = 600;

    const int paddleWidth = 20;
    const int paddleHeight = 100;
    const int ballSize = 30;

    static void Main()
    {
        Raylib.InitWindow(screenWidth, screenHeight, "Pong Game");
        Raylib.SetTargetFPS(60);

        
        Rectangle player1 = new Rectangle(50, screenHeight / 2 - paddleHeight / 2, paddleWidth, paddleHeight);
        Rectangle player2 = new Rectangle(screenWidth - 50 - paddleWidth, screenHeight / 2 - paddleHeight / 2, paddleWidth, paddleHeight);
        Vector2 ballPosition = new Vector2(screenWidth / 2, screenHeight / 2);
        Vector2 ballSpeed = new Vector2(5, 5);

        
        int player1Score = 0;
        int player2Score = 0;

        
        while (!Raylib.WindowShouldClose())
        {
            
            if (Raylib.IsKeyDown(KeyboardKey.W) && player1.Y > 0) player1.Y -= 7; 
            if (Raylib.IsKeyDown(KeyboardKey.S) && player1.Y < screenHeight - paddleHeight) player1.Y += 7; 

            if (Raylib.IsKeyDown(KeyboardKey.Up) && player2.Y > 0) player2.Y -= 7; 
            if (Raylib.IsKeyDown(KeyboardKey.Down) && player2.Y < screenHeight - paddleHeight) player2.Y += 7; 

            
            ballPosition.X += ballSpeed.X;
            ballPosition.Y += ballSpeed.Y;

            
            if (ballPosition.Y <= 0 || ballPosition.Y >= screenHeight) ballSpeed.Y = -ballSpeed.Y;

            
            if (Raylib.CheckCollisionRecs(player1, new Rectangle(ballPosition.X - ballSize / 2, ballPosition.Y - ballSize / 2, ballSize, ballSize)))
            {
                ballSpeed.X = -ballSpeed.X; 
            }

            if (Raylib.CheckCollisionRecs(player2, new Rectangle(ballPosition.X - ballSize / 2, ballPosition.Y - ballSize / 2, ballSize, ballSize)))
            {
                ballSpeed.X = -ballSpeed.X; 
            }

            
            if (ballPosition.X <= 0)
            {
                player2Score++; 
                ballPosition = new Vector2(screenWidth / 2, screenHeight / 2); 
                ballSpeed = new Vector2(5, 5);
            }
            if (ballPosition.X >= screenWidth)
            {
                player1Score++; 
                ballPosition = new Vector2(screenWidth / 2, screenHeight / 2); 
                ballSpeed = new Vector2(5, 5); 
            }

            
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.DarkBlue);

            
            Raylib.DrawRectangleRec(player1, Color.SkyBlue);
            Raylib.DrawRectangleRec(player2, Color.Orange);

            
            Raylib.DrawCircleV(ballPosition, ballSize / 2, Color.White);

            
            Raylib.DrawText($"Player 1: {player1Score}", 50, 20, 20, Color.SkyBlue);
            Raylib.DrawText($"Player 2: {player2Score}", screenWidth - 150, 20, 20, Color.Orange);

            Raylib.EndDrawing();
        }

        
        Raylib.CloseWindow(); 
    }
}
