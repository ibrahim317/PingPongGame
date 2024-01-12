using Raylib_cs;

namespace Game;

class Program
{


    public static void Main()
    {



        Raylib.InitWindow(Globals.ScreenWidth, Globals.ScreenHieght, "PingPong Game - Ibrahim Aboelsoud");
        Raylib.SetTargetFPS(60);

        while (!Raylib.WindowShouldClose())
        {
            UpdateDrawScreen();
        }

        Raylib.CloseWindow();
    }

    static void UpdateDrawScreen()
    {

        UpdateScreen();
        DrawScreen();


    }
    static void UpdateScreen()
    {


        Globals.BallPosition.X += Globals.BallXSpeed;
        Globals.BallPosition.Y += Globals.BallYSpeed;

        // Walls
        if (Globals.BallPosition.X + Globals.BallRadius >= Globals.ScreenWidth || Globals.BallPosition.X - Globals.BallRadius <= 0)
        {
            Globals.BallXSpeed *= -1;
        }
        // Goals
        if (Globals.BallPosition.Y + Globals.BallRadius >= Globals.ScreenHieght)
        {
            Globals.TopCounter++;
            Globals.BallPosition = new(Globals.BottomBar.X, (Globals.ScreenHieght - Globals.RectangleHieght - 12));
            Globals.BallYSpeed *= -1;
        }
        if (Globals.BallPosition.Y - Globals.BallRadius <= 0)
        {
            Globals.BottomCounter++;
            Globals.BallPosition = new(Globals.TopBar.X + Globals.RectangleWidth / 2, Globals.RectangleHieght + 12);
            Globals.BallYSpeed *= -1;
        }
        // Poince of ball
        if (Raylib.CheckCollisionCircleRec(Globals.BallPosition, Globals.BallRadius, Globals.TopBar) || Raylib.CheckCollisionCircleRec(Globals.BallPosition, Globals.BallRadius, Globals.BottomBar))
        {
            Globals.BallYSpeed *= -1;
        }
        // Bars Movement

        //TopBar Movement
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A) && (Globals.TopBar.X > 0))
        {
            Globals.TopBar.X -= 10;

        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D) && (Globals.TopBar.X < (Globals.ScreenWidth - Globals.RectangleWidth)))
        {
            Globals.TopBar.X += 10;

        }
        //BottomBar Movement
        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT) && (Globals.BottomBar.X > 0))
        {
            Globals.BottomBar.X -= 10;

        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) && (Globals.BottomBar.X < (Globals.ScreenWidth - Globals.RectangleWidth)))
        {
            Globals.BottomBar.X += 10;

        }


    }
    static void DrawScreen()
    {

        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.BLACK);
        Raylib.DrawRectanglePro(Globals.TopBar, Globals.origin, 0, Color.WHITE);
        Raylib.DrawRectanglePro(Globals.BottomBar, Globals.origin, 0, Color.WHITE);
        Raylib.DrawCircleV(Globals.BallPosition, Globals.BallRadius, Color.BLUE);
        Raylib.DrawText(Globals.BottomCounter.ToString(), Globals.ScreenWidth - 100, Globals.ScreenHieght / 2 + 50, 100, Color.WHITE);
        Raylib.DrawText(Globals.TopCounter.ToString(), Globals.ScreenWidth - 100, Globals.ScreenHieght / 2 - 50, 100, Color.WHITE);
        Raylib.EndDrawing();


    }



}