using System;
using Raylib_cs;

namespace BoxGame
{
    class Program
    {
        static void Main(string[] args)
        {

            Raylib.InitWindow(1200, 800, "Hello World");
            Raylib.SetTargetFPS(60);
            Random generator = new Random();





            Rectangle door = new Rectangle(250, 200, 40, 40);

            Rectangle player = new Rectangle(10, 10, 40, 40);

            Rectangle key = new Rectangle(generator.Next(0, 1200), generator.Next(0, 800), 40, 40);


            bool carryKey = false;
            string gameState = "inGame";

            int speed = 5;

            while (!Raylib.WindowShouldClose())
            {

                if (gameState == "inGame")
                {

                    Raylib.BeginDrawing();

                    Raylib.ClearBackground(Color.WHITE);




                    Raylib.DrawRectangleRec(player, Color.GREEN);

                    Raylib.DrawRectangleRec(door, Color.BROWN);

                    Raylib.DrawRectangleRec(key, Color.GOLD);



                    Raylib.DrawText("Player", (int)player.x - 10, (int)player.y - 30, 20, Color.BLACK);
                    Raylib.DrawText("Key", (int)key.x - 10, (int)key.y - 30, 20, Color.BLACK);
                    Raylib.DrawText("DaDoor", (int)door.x - 10, (int)door.y - 30, 20, Color.BLACK);

                    if (Raylib.CheckCollisionRecs(player, key))
                    {

                        carryKey = true;
                    }
                    if (Raylib.CheckCollisionRecs(door, key))
                    {

                        gameState = "win";
                    }



                    if (player.x >= 1200)
                    {
                        player.x = 1;
                    }

                    if (player.x <= 0)
                    {
                        player.x = 1199;
                    }


                    if (player.y >= 800)
                    {
                        player.y = 1;
                    }

                    if (player.y <= 0)
                    {
                        player.y = 799;
                    }




                    if (key.x >= 1200)
                    {
                        key.x = 1;
                    }

                    if (key.x <= 0)
                    {
                        key.x = 1199;
                    }


                    if (key.y >= 800)
                    {
                        key.y = 1;
                    }

                    if (key.y <= 0)
                    {
                        key.y = 799;
                    }



                    if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
                    {
                        player.x += speed;

                        if (carryKey)
                        {
                            key.x += speed;

                        }


                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
                    {
                        player.x -= speed;

                        if (carryKey)
                        {
                            key.x -= speed;

                        }


                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
                    {
                        player.y -= speed;

                        if (carryKey)
                        {
                            key.y -= speed;

                        }


                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
                    {
                        player.y += speed;

                        if (carryKey)
                        {
                            key.y += speed;

                        }


                    }

                    Raylib.EndDrawing();
                }

                else if (gameState == "win")
                {
                    Raylib.BeginDrawing();


                    Raylib.ClearBackground(Color.WHITE);
                    Raylib.DrawText("You Win!!", 200, 250, 70, Color.BLACK);
                    Raylib.DrawText("Press Space To play again", 200, 400, 70, Color.BLACK);
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                    {
                        carryKey = false;
                        key.x = generator.Next(0, 1200);
                        key.y = generator.Next(0, 800);
                        gameState = "inGame";
                        player.x = 10;
                        player.y = 10;


                    }


                    Raylib.EndDrawing();
                }




            }



        }
    }
}
