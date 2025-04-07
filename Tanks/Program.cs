using Raylib_cs;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Tanks
{
    class Program
    {

        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 600, "Tanks Game");
            Raylib.SetTargetFPS(60);

            
            Tank player1 = new Tank(100, 100, Color.Red);
            Tank player2 = new Tank(600, 100, Color.Blue);
            Ammo player1Ammo = null;
            Ammo player2Ammo = null;

            Wall wall1 = new Wall(300, 200, 100, 20);  
            Wall wall2 = new Wall(400, 400, 100, 20);

            void resetPlayers()
            {
                player1.x = 100; player1.y = 100;
                player2.x = 600; player2.y = 100;

                player1Ammo = null;
                player2Ammo = null;
            } 
           
            float lastShootTime1 = 0;
            float lastShootTime2 = 0;
            float shootInterval = 1f;

            
            int player1Score = 0;
            int player2Score = 0;

            
            bool gameOver = false;
            string winner = "";

            while (!Raylib.WindowShouldClose())
            {
                if (gameOver)
                {
                    
                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.Black);
                    Raylib.DrawText("Game Over!", 320, 200, 40, Color.White);
                    Raylib.DrawText($"Winner: {winner}", 320, 250, 30, Color.White);
                    Raylib.DrawText("Press R to Restart", 280, 300, 30, Color.White);
                    Raylib.EndDrawing();

                    if (Raylib.IsKeyPressed(KeyboardKey.R))
                    {
                        
                        player1 = new Tank(100, 100, Color.Red);
                        player2 = new Tank(600, 100, Color.Blue);
                        player1Score = 0;
                        player2Score = 0;
                        gameOver = false;
                    }

                    continue;
                }

                float currentTime = (float)Raylib.GetTime();

                
                player1.Update(KeyboardKey.W, KeyboardKey.A, KeyboardKey.S, KeyboardKey.D, KeyboardKey.Q, KeyboardKey.E);
                player2.Update(KeyboardKey.Up, KeyboardKey.Left, KeyboardKey.Down, KeyboardKey.Right, KeyboardKey.PageUp, KeyboardKey.PageDown);

                if (Raylib.IsKeyPressed(KeyboardKey.Space) && currentTime - lastShootTime1 > shootInterval)
                {
                    player1Ammo = new Ammo(player1.x, player1.y, player1.turretX, player1.turretY);
                    lastShootTime1 = currentTime;
                }

                if (Raylib.IsKeyPressed(KeyboardKey.Enter) && currentTime - lastShootTime2 > shootInterval)
                {
                    player2Ammo = new Ammo(player2.x, player2.y, player2.turretX, player2.turretY);
                    lastShootTime2 = currentTime;
                }

                
                player1Ammo?.Update();
                player2Ammo?.Update();

                
                if (player1Ammo != null && Raylib.CheckCollisionRecs(player1Ammo.GetRect(), player2.GetRect()))
                {
                    resetPlayers();
                    player1Score++;
                    winner = "Player 1";
                    gameOver = true;
                }

                if (player2Ammo != null && Raylib.CheckCollisionRecs(player2Ammo.GetRect(), player1.GetRect()))
                {
                    resetPlayers();
                    player2Score++;
                    winner = "Player 2";
                    gameOver = true;
                }

                if (player1Ammo != null && Raylib.CheckCollisionRecs(player1Ammo.GetRect(), wall1.GetRect()))
                    player1Ammo = null;
                if (player2Ammo != null && Raylib.CheckCollisionRecs(player2Ammo.GetRect(), wall2.GetRect()))
                    player2Ammo = null;

                if (Raylib.CheckCollisionRecs(player1.GetRect(), wall1.GetRect()) || Raylib.CheckCollisionRecs(player1.GetRect(), wall2.GetRect()))
                    resetPlayers();

                if (Raylib.CheckCollisionRecs(player2.GetRect(), wall1.GetRect()) || Raylib.CheckCollisionRecs(player2.GetRect(), wall2.GetRect()))
                    resetPlayers();

               
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);

                wall1.Draw();
                wall2.Draw();
                player1.Draw();
                player2.Draw();
                player1Ammo?.Draw();
                player2Ammo?.Draw();

                
                Raylib.DrawText($"Player 1 Score: {player1Score}", 10, 10, 20, Color.Red);
                Raylib.DrawText($"Player 2 Score: {player2Score}", 600, 10, 20, Color.Blue);

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }

    public class Tank
    {
        public float x, y, speed, rotation, turretX, turretY;
        public Color color;

        public Tank(float x, float y, Color color)
        {
            this.x = x;
            this.y = y;
            this.speed = 2;
            this.rotation = 0;
            this.color = color;
        }

        public void Update(KeyboardKey forward, KeyboardKey left, KeyboardKey backward, KeyboardKey right, KeyboardKey rotateLeft, KeyboardKey rotateRight)
        {
            if (Raylib.IsKeyDown(forward)) { y -= speed; turretY = -1; turretX = 0; }
            if (Raylib.IsKeyDown(backward)) { y += speed; turretY = 1; turretX = 0; }
            if (Raylib.IsKeyDown(left)) { x -= speed; turretX = -1; turretY = 0; }
            if (Raylib.IsKeyDown(right)) { x += speed; turretX = 1; turretY = 0; }
            
        }

        

        public void Draw()
        {
            Raylib.DrawRectangle((int)x - 20, (int)y - 10, 40, 20, color);

            
            Raylib.DrawCircle((int)(x + turretX * 10), (int)(y + turretY * 10) , 10, Color.DarkBlue);

            
           
          
            float cannonX = x;
            float cannonY = y;

           
           

            
           
        }

        public Raylib_cs.Rectangle GetRect()
        {
            return new Raylib_cs.Rectangle(x - 20, y - 10, 40, 20);
        }
    }

    

    public class Wall
    {
        public float x, y, width, height;

        public Wall(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            Raylib.DrawRectangle((int)x, (int)y, (int)width, (int)height, Color.Gray);
        }

        public Raylib_cs.Rectangle GetRect()
        {
            return new Raylib_cs.Rectangle(x, y, width, height);
        }
    }
}