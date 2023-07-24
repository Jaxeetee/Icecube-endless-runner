using System.Data;
using System.Linq.Expressions;

public static class StringManager
{
    //This is for Object Pooling
    public static readonly string[] ITEM_KEYS = new string[]
    {
        "Ice Cube",
        "Fire"
    };

    public const string ITEM_ICE = "Ice";
    public const string ITEM_OBSTACLE = "Obstacle";


    public const string ACTIONMAP_MAINGAME = "Main Game";
    public const string INPUT_SIDEMOVEMENT = "SideMovement";

    public const string UIPAGE_MAINMENU = "Main Menu";
    public const string UIPAGE_MAINGAME = "Main Game";
    public const string UIPAGE_POSTGAME = "Post Game";
}

