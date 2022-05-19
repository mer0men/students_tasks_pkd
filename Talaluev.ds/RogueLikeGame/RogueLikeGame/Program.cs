using System;

namespace fefu;

class Data
{
    public static List<Monster> monsters1 = new List<Monster>()
    {
        new Monster(10,10,true),
        new Monster(20,15,false),
        new Monster(30,10,true),
        new Monster(12,13,false)
    };
    public static List<Monster> monsters2 = new List<Monster>()
    {
        new Monster(1,6,false),
        new Monster(3,8,false),
        new Monster(5,10,false),
        new Monster(5,12,false),
        new Monster(3,14,false),
        new Monster(1,16,false),
        new Monster(9,5,true),
        new Monster(11,5,true),
        new Monster(13,5,true),
        new Monster(17,5,false),
        new Monster(17,7,false),
        new Monster(17,9,false),
        new Monster(17,11,false),
        new Monster(22,14,false),
        new Monster(22,16,false),
        new Monster(22,1,false),
        new Monster(19,2,false),
        new Monster(16,3,false),
        new Monster(19,11,true),
        new Monster(21,11,true),
        new Monster(24,6,true),
    };
    public static List<Monster> monsters3 = new List<Monster>()
    {
        new Monster(1,7,false),
        new Monster(6,8,false),
        new Monster(8,7,false),
        new Monster(15,8,false),
        new Monster(2,21,true),
        new Monster(3,20,true),
        new Monster(4,19,true),
        new Monster(5,18,true),
        new Monster(6,17,true),
        new Monster(14,10,true),
        new Monster(15,16,true),
        new Monster(14,21,true),
        new Monster(2,23,true),
        new Monster(3,22,true),
        new Monster(4,21,true),
        new Monster(5,20,true),
        new Monster(6,19,true),
        new Monster(7,18,true),
        new Monster(2,23,false),
        new Monster(3,22,false),
        new Monster(4,21,false),
        new Monster(5,20,false),
        new Monster(6,19,false),
        new Monster(7,18,false),
    };
    public static char[,] map1 =
        {
            {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','!','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
        };
    public static char[,] map2 =
        {
            {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#','#','#','#',' ','#','#','#','#','#','#','#','#','#',' ','#','#','#','#',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ','#','#','#'},
            {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ','#',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ','#',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ','#',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ','#',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ','#',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#','#','#','#','#','#',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#','!','#'},
            {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
        };
    public static char[,] map3 =
    {
        {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
        {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
        {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
        {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
        {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
        {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
        {'#','#','#',' ','#','#','#','#',' ','#','#','#','#','#','#','#','#'},
        {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ','#'},
        {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ','#'},
        {'#',' ','#','#','#','#','#','#','#','#','#','#','#','#','#',' ','#'},
        {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ','#',' ',' ','#'},
        {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ','#',' ',' ','#'},
        {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ','#',' ',' ','#'},
        {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ','#',' ',' ','#'},
        {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ','#'},
        {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ','#',' ','#','#'},
        {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ','#',' ',' ','#'},
        {'#',' ',' ',' ',' ',' ',' ','#','#','#',' ','#','#','#',' ',' ','#'},
        {'#',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#',' ',' ','#'},
        {'#',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ','#',' ',' ','#'},
        {'#',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ','#','#',' ','#'},
        {'#',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ','#'},
        {'#',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ','#'},
        {'#','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ','#'},
        {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ','#'},
        {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ','#'},
        {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ','#'},
        {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
        {'#','!',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ','#'},
        {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'}
    };
}
class Player
{
    public static int PlayerX = 1;
    public static int PlayerY = 1;
    public static bool PlayerLive = true;
    public static void PlayerDeath()
    {
        PlayerLive = false;
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        Console.Write("ВЫ ПРОИГРАЛИ(((");
    }
    public static void PlayerMove(char[,] map)
    {
        switch (GetButton())
        {
            case ConsoleKey.UpArrow:
                if (map[Player.PlayerY - 1, Player.PlayerX] != '#')
                {
                    Player.PlayerY--;
                }
                break;
            case ConsoleKey.DownArrow:
                if (map[Player.PlayerY + 1, Player.PlayerX] != '#')
                {
                    Player.PlayerY++;
                }
                break;
            case ConsoleKey.LeftArrow:
                if (map[Player.PlayerY, Player.PlayerX - 1] != '#')
                {
                    Player.PlayerX--;
                }
                break;
            case ConsoleKey.RightArrow:
                if (map[Player.PlayerY, Player.PlayerX + 1] != '#')
                {
                    Player.PlayerX++;
                }
                break;
        }
        Console.Clear();
    }
    public static ConsoleKey GetButton()
    {
        var Button = Console.ReadKey().Key;

        return Button;
    }
}
class Monster
{
    public int MonsterX = 0;
    public int MonsterY = 0;
    public bool MonsterMovingY = false;
    public bool MonsterMovingOtherSide = false;
    public Monster(int MonsterX, int MonsterY, bool MonsterMovingY)
    {
        this.MonsterMovingY = MonsterMovingY;
        this.MonsterX = MonsterX;
        this.MonsterY = MonsterY;
    }
    public static void MonsterMove(char[,] map, List<Monster> monsters)
    {
        for(int i =0; i < monsters.Count; i++)
        {
            if (monsters[i].MonsterMovingY)
            {
                if (monsters[i].MonsterMovingOtherSide)
                {
                    if (map[monsters[i].MonsterY - 1,monsters[i].MonsterX] != '#')
                    {
                        monsters[i].MonsterY--;
                    }
                    else
                    {
                        monsters[i].MonsterMovingOtherSide = false;
                    }
                }
                else
                {
                    if(map[monsters[i].MonsterY + 1,monsters[i].MonsterX] != '#')
                    {
                        monsters[i].MonsterY++;
                    }
                    else
                    {
                        monsters[i].MonsterMovingOtherSide = true;
                    }
                }
            }
            else
            {
                if (monsters[i].MonsterMovingOtherSide)
                {
                    if (map[monsters[i].MonsterY, monsters[i].MonsterX + 1] != '#')
                    {
                        monsters[i].MonsterX++;
                    }
                    else
                    {
                        monsters[i].MonsterMovingOtherSide = false;
                    }
                }
                else
                {
                    if (map[monsters[i].MonsterY, monsters[i].MonsterX - 1] != '#')
                    {
                        monsters[i].MonsterX--;
                    }
                    else
                    {
                        monsters[i].MonsterMovingOtherSide = true;
                    }
                }
            }
            
        }
    }

}
class Map
{
    public static Random random = new Random();
    public static void MapBuild(char[,] map , List<Monster> monsters)
    {
        while (true)
        {
            if (Player.PlayerLive)
            {
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write(map[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.SetCursorPosition(Player.PlayerX, Player.PlayerY);
                Console.Write('@');
                for (int i = 0; i < monsters.Count; i++)
                {
                    Console.SetCursorPosition(monsters[i].MonsterX, monsters[i].MonsterY);
                    Console.Write('M');
                }
                if (map[Player.PlayerY, Player.PlayerX] == '!')
                {
                    Player.PlayerX = 1;
                    Player.PlayerY = 1;
                    Console.Clear();
                    Map.Start();
                }
                else
                {
                    for (int i = 0; i < monsters.Count; i++)
                    {
                        if (Player.PlayerX == monsters[i].MonsterX && Player.PlayerY == monsters[i].MonsterY)
                        {
                            Player.PlayerDeath();
                            return;
                        }
                    }
                }
                Player.PlayerMove(map);
                Monster.MonsterMove(map, monsters);
            }
        }
    }
    public static void Start()
    {
        int number = random.Next(1,4);
        int tmp = 0;
        if (number == 1 && number != tmp)
        {
            Map.MapBuild(Data.map1, Data.monsters1);
        }
        else if(number == 2 && number != tmp)
        {
            Map.MapBuild(Data.map2, Data.monsters2);
        }
        else if (number == 3 && number != tmp)
        {
            Map.MapBuild(Data.map3, Data.monsters3);
        }
        else
        {
            Map.Start();
        }
        tmp = number;
    }
}
class MainClass
{
    public static void Main()
    {
        Console.CursorVisible = false;
        Map.Start();
    }
}
