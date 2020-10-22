using System;
using Raylib_cs;
namespace Pong
{
    class Program
    {
        static void Main(string[] args)
        {
            float xposB = 0;
            float yposB = 0;
            int yposS1 = 0;
            float yposS2 = 0;
            float speedx = 0.3f;
            float speedy = 0.1f;
            bool directionx = true;
            bool directiony = true;
            int Score1 = 0;
            int Score2 = 0;

            Raylib.InitWindow(800, 600, "Pong");

            while (!Raylib.WindowShouldClose())
            {

                Random generator = new Random();
                int width = Raylib.GetScreenWidth();
                int height = Raylib.GetScreenHeight();
                //Plattor rörelse
                yposS1 = Raylib.GetMouseY();

                if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                {
                    yposS2 += 0.4f;
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                {
                    yposS2 -= 0.4f;
                }

                //Gör rektanglar
                Rectangle boll = new Rectangle((int)xposB, (int)yposB, 30, 30);
                Rectangle S1 = new Rectangle(0, (int)yposS1, 10, 100);
                Rectangle S2 = new Rectangle(width - 10, (int)yposS2, 10, 100);

                //Kollision
                bool isColliding = Raylib.CheckCollisionRecs(S1, boll);
                bool isColliding2 = Raylib.CheckCollisionRecs(S2, boll);

                if (isColliding == true)
                {
                    directionx = true;
                    speedx += 0.01f;
                }
                if (isColliding2 == true)
                {
                    directionx = false;
                    speedx += 0.01f;
                }

                if (yposB <= 0)
                {
                    directiony = true;
                }
                if (yposB >= height - 30)
                {
                    directiony = false;
                }
                //Rörese
                yposB = posb(speedy, directiony, yposB);
                xposB = posb(speedx, directionx, xposB);

                //Score

                if (xposB >= width)
                {
                    Score1++;
                    xposB = width / 2;
                    yposB = height / 2;
                    speedx = 0.3f;
                }
                if (xposB <= 0)
                {
                    Score2++;
                    xposB = width / 2;
                    yposB = height / 2;
                    speedx = 0.3f;
                }

                //Rita upp
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                Raylib.DrawRectangleRec(S1, Color.WHITE);
                Raylib.DrawRectangleRec(S2, Color.WHITE);
                Raylib.DrawRectangleRec(boll, Color.WHITE);
                Raylib.DrawText("" + Score1, 100, 50, 20, Color.ORANGE);
                Raylib.DrawText("" + Score2, width - 100, 50, 20, Color.ORANGE);
                Raylib.EndDrawing();

            }

        }
        static float posb(float speed, bool direction, float posB)
        {


            if (direction == true)
            {
                posB = posB + speed;
            }
            else if (direction == false)
            {
                posB = posB - speed;
            }

            return posB;
        }
    }
}
