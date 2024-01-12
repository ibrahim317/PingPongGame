using System.Numerics;
using Raylib_cs;

namespace Game;

public class Globals
{

    public static int ScreenWidth = 800;
    public static int ScreenHieght = 600;

    // Ball
    public static int BallRadius = 15;
    public static int BallXSpeed = 5;
    public static int BallYSpeed = 5;
    public static Vector2 BallPosition = new(100.0f, 100.0f);

    // Bars
    public static int RectangleWidth = 80;
    public static int RectangleHieght = 12;
    public static int DefalutX = (ScreenWidth - RectangleWidth) / 2;
    public static Rectangle TopBar = new(DefalutX, 0, RectangleWidth, RectangleHieght);
    public static Rectangle BottomBar = new(DefalutX, ScreenHieght - RectangleHieght, RectangleWidth, RectangleHieght);
    public static Vector2 origin = new(0.0f, 0.0f);

    // Goals Counters
    public static int TopCounter = 0;
    public static int BottomCounter = 0;

}