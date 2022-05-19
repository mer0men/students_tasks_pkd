using System;
using System.Collections.Generic;
using System.Linq;

namespace RogueLike
{
    internal class Program
    {
        public enum Figures
        {
            StartPosition = 0,
            EmptySpace = -1,
            Destination = -2,
            Path = -3,
            Barrier = -4
        }
        public class Game
        {
            private Field _field;
            private Player _player;
            private Monster _monster;
            public Game()
            {
                _field = new Field();
                _player = new Player(_field.getSize(), _field.getExit());
                _monster = new Monster(_field.getSize(), _field.getExit(), _player.getPos(),1);
            }
            public void Start()
            {
                bool flag = false;
                while (true)
                {
                    int[] p, e;
                    Console.Clear();
                    _field.printField(_player.getPos(), _monster.getPos());
                    Console.WriteLine("HP: " + _player.getHP());
                    Console.WriteLine("wait action up/down/left/right:");
                    if (_player.playerMove(Console.ReadKey().Key, _field.getField()))
                    {
                        p = _player.getPos();
                        e = _field.getExit();
                        if (p[0] == e[0] && p[1] == e[1])
                        {
                            flag = true;
                            break;
                        }
                        if (!_monster.monsterMove(_player, _player.getPos(), _field.getField(), _field.getSize())) break;
                    }
                }

                if (flag)
                {
                    Console.Clear();
                    _field.printField(_player.getPos(), _monster.getPos());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("WIN!");
                    Console.ResetColor();
                }
                else
                {
                    Console.Clear();
                    _field.printField(_player.getPos(), _monster.getPos());
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("LOSE!");
                    Console.ResetColor();
                }
            }
            // private void nextGame()
            // {
            //     
            // }
        }
        public class Field
        {
            private char[,] field;
            private int size;
            private int[] exit = new int[2];
            public Field()
            {
                Random temp = new Random(DateTime.Now.Millisecond);
                switch (temp.Next(1,4))
                {
                    case 1:
                    {
                        this.field = new char[7, 7];
                        this.size = 7;
                        for (int i = 0; i < 7; i++)
                            for (int j = 0; j < 7; j++)
                                if (i == 0 || j == 0 || i == 6 || j == 6) field[i, j] = '#';
                                else field[i, j] = '*';
                        break;
                    }
                    case 2:
                    {
                        this.field = new char[12, 12];
                        this.size = 12;
                        for (int i = 0; i < 12; i++)
                            for (int j = 0; j < 12; j++)
                                if (i == 0 || j == 0 || i == 11 || j == 11) field[i, j] = '#';
                                else field[i, j] = '*';
                        break;
                    }
                    case 3:
                    {
                        this.field = new char[17, 17];
                        this.size = 17;
                        for (int i = 0; i < 17; i++)
                            for (int j = 0; j < 17; j++)
                                if (i == 0 || j == 0 || i == 16 || j == 16) field[i, j] = '#';
                                else field[i, j] = '*';
                        break;
                    }
                }
                this.exit[0] = temp.Next(1, this.size - 1);
                this.exit[1] = temp.Next(1, this.size - 1);
                field[this.exit[0], this.exit[1]] = '>';
            }
            public char[,] getField() => this.field;
            public int getSize() => this.size;
            public int[] getExit() => this.exit;
            public void printField(int[] p, int[] m)
            {
                for (int i = 0; i < this.size; i++)
                {
                    for (int j = 0; j < this.size; j++)
                    {
                        if (i == p[0] && j == p[1])
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("@" + "  ");
                            Console.ResetColor();
                        }
                        else if (i == m[0] && j == m[1])
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("M" + "  ");
                            Console.ResetColor();
                        }
                        else if (i == 0 || j == 0 || i == this.size - 1 || j == this.size - 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(this.field[i, j] + "  ");
                            Console.ResetColor();
                        }
                        else if (i == this.exit[0] && j == this.exit[1])
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(this.field[i, j] + "  ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(this.field[i, j] + "  ");
                            Console.ResetColor();
                        }
                    }
                    Console.Write("\n");
                }
            }
        }
        public class Player
        {
            private int x, y;
            private int HP = 3;
            public Player(int fieldSize, int[] exit)
            {
                Random temp = new Random(DateTime.Now.Millisecond);
                while(true)
                {
                    int tempX = temp.Next(1, fieldSize - 1);
                    int tempY = temp.Next(1, fieldSize - 1);
                    if (exit[0] != tempX || exit[1] != tempY)
                    {
                        this.x = tempX;
                        this.y = tempY;
                        break;
                    }
                }
            }
            public int getHP() => this.HP;
            public int[] getPos()
            {
                int[] temp = new int[2];
                temp[0] = this.x;
                temp[1] = this.y;
                return temp;
            }
            public bool playerMove(ConsoleKey action, char[,] field)
            {
                switch (action)
                {
                    case ConsoleKey.UpArrow:
                    {
                        this.x--;
                        if (field[this.x, this.y] == '#')
                        {
                            this.x++;
                            return false;
                        }
                        break;
                    }
                    case ConsoleKey.DownArrow:
                    {
                        this.x++;
                        if (field[this.x, this.y] == '#')
                        {
                            this.x--;
                            return false;
                        }
                        break;
                    }
                    case ConsoleKey.LeftArrow:
                    {
                        this.y--;
                        if (field[this.x, this.y] == '#')
                        {
                            this.y++;
                            return false;
                        }
                        break;
                    }
                    case ConsoleKey.RightArrow:
                    {
                        this.y++;
                        if (field[this.x, this.y] == '#')
                        {
                            this.y--;
                            return false;
                        }
                        break;
                    }
                    default:
                        return false;
                }
                return true;
            }
            public bool TakeDamage(int dmg)
            {
                this.HP -= dmg;
                if (this.HP <= 0) return false;
                else return true;
            }
        }
        public class Monster
        {
            private int x, y;
            private int DMG = 1;
            public Monster(int fieldSize, int[] exit, int[] playerPos, int count = 1)
            {
                Random temp = new Random(DateTime.Now.Millisecond);
                while(true)
                {
                    int tempX = temp.Next(1, fieldSize - 1);
                    int tempY = temp.Next(1, fieldSize - 1);
                    if (playerPos[0] != tempX && playerPos[1] != tempY && exit[0] != tempX && exit[1] != tempY)
                    {
                        this.x = tempX;
                        this.y = tempY;
                        break;
                    }
                }
            }
            public int[] getPos()
            {
                int[] temp = new int[2];
                temp[0] = this.x;
                temp[1] = this.y;
                return temp;
            }
            public bool getDamage (Player p) => p.TakeDamage(this.DMG);
            private void afterDamage(int[] p, int size)
            {
                if (this.x == p[0] - 1 && this.y == p[1]) this.x--;
                else if (this.x == p[0] + 1 && this.y == p[1]) this.x++;
                else if (this.x == p[0] && this.y == p[1] - 1) this.y--;
                else if (this.x == p[0] && this.y == p[1] + 1) this.y++;
            }
            public bool monsterMove(Player player, int[] p, char[,] field, int size)
            {
                if ((this.x == p[0] && this.y == p[1]) ||
                    (this.x == p[0] - 1 && this.y == p[1]) ||
                    (this.x == p[0] + 1 && this.y == p[1]) ||
                    (this.x == p[0] && this.y == p[1] + 1) ||
                    (this.x == p[0] && this.y == p[1] - 1))
                {
                    if (getDamage(player)) afterDamage(p, size);
                    else return false;
                    return true;
                }
                int[,] mField = new int[size, size];
                for (int i = 0; i < size; i++)
                    for (int j = 0; j < size; j++)
                    {
                        if (field[i,j] == '#' || field[i,j] == '>') mField[i,j] = (int)Figures.Barrier;
                        else if (field[i, j] == '*' || field[i, j] == '>') mField[i,j] = (int) Figures.EmptySpace;
                    }
                mField[p[0], p[1]] = (int) Figures.Destination;
                mField[this.x, this.y] = (int) Figures.StartPosition;
                LeeAlgorithm li = new LeeAlgorithm(mField);
                foreach (var item in li.Path)
                    if (item == li.Path.Last()) mField[item.Item1, item.Item2] = (int)Figures.StartPosition;
                    else if (item == li.Path.First()) mField[item.Item1, item.Item2] = (int)Figures.Destination;
                    else mField[item.Item1, item.Item2] = (int)Figures.Path;
                if (mField[this.x+1, this.y] == (int)Figures.Path) this.x++;
                else if (mField[this.x-1, this.y] == (int)Figures.Path) this.x--;
                else if (mField[this.x, this.y+1] == (int)Figures.Path) this.y++;
                else if (mField[this.x, this.y-1] == (int)Figures.Path) this.y--;
                if ((this.x == p[0] && this.y == p[1]) || 
                    (this.x == p[0]-1 && this.y == p[1]) || 
                    (this.x == p[0]+1 && this.y == p[1]) || 
                    (this.x == p[0] && this.y == p[1]+1) || 
                    (this.x == p[0] && this.y == p[1]-1))
                {
                    if (getDamage(player)) afterDamage(p, size);
                    else return false;
                    return true;
                }
                return true;
            }
        }
        public class LeeAlgorithm
        {
            public int[,] ArrayGraph { get; }
            public List<Tuple<int, int>> Path { get; private set; }
            public int Width { get; }
            public int Heidth { get; }
            public bool PathFound { get; }

            private int _step;
            private bool _finishingCellMarked;
            private int _finishPointI;
            private int _finishPointJ;
            
            public LeeAlgorithm(int[,] array)
            {
                ArrayGraph = array;
                Width = ArrayGraph.GetLength(0);
                Heidth = ArrayGraph.GetLength(1);
                int startX;
                int startY;
                FindStartCell(out startX, out startY);
                SetStarCell(startX, startY);
                PathFound = PathSearch();

            }
            private void FindStartCell(out int startX, out int startY)
            {
                int w = Width;
                int h = Heidth;

                for (int i = 0; i < w; i++)
                {
                    for (int j = 0; j < h; j++)
                    {
                        if (ArrayGraph[i, j] == (int)Figures.StartPosition)
                        {
                            startX = i;
                            startY = j;
                            return;
                        }
                    }
                }
                throw new AggregateException("Нет начальной точки");
            }
            private void SetStarCell(int startX, int startY)
            {
                if (startX > this.ArrayGraph.GetLength(0) || startX < 0)
                    throw new ArgumentException("Неправильная координата x");
                if (startY > this.ArrayGraph.GetLength(1) || startY < 0)
                    throw new ArgumentException("Неправильная координата x");
                _step = 0;
                ArrayGraph[startX, startY] = _step;
            }
            private bool PathSearch()
            {
                if (WavePropagation())
                    if (RestorePath())
                        return true;

                return false;
            }
            private bool WavePropagation()
            {
                int w = Width;
                int h = Heidth;

                bool finished = false;
                do
                {
                    for (int i = 0; i < w; i++)
                    {
                        for (int j = 0; j < h; j++)
                        {
                            if (ArrayGraph[i, j] == _step)
                            {
                                if (i != w - 1)
                                    if (ArrayGraph[i + 1, j] == (int)Figures.EmptySpace) ArrayGraph[i + 1, j] = _step + 1;
                                if (j != h - 1)
                                    if (ArrayGraph[i, j + 1] == (int)Figures.EmptySpace) ArrayGraph[i, j + 1] = _step + 1;
                                if (i != 0)
                                    if (ArrayGraph[i - 1, j] == (int)Figures.EmptySpace) ArrayGraph[i - 1, j] = _step + 1;
                                if (j != 0)
                                    if (ArrayGraph[i, j - 1] == (int)Figures.EmptySpace) ArrayGraph[i, j - 1] = _step + 1;

                                if (i < w - 1)
                                    if (ArrayGraph[i + 1, j] == (int)Figures.Destination)
                                    {
                                        _finishPointI = i + 1;
                                        _finishPointJ = j;
                                        finished = true;
                                    }
                                if (j < h - 1)
                                    if (ArrayGraph[i, j + 1] == (int)Figures.Destination)
                                    {
                                        _finishPointI = i;
                                        _finishPointJ = j + 1;
                                        finished = true;
                                    }
                                if (i > 0)
                                    if (ArrayGraph[i - 1, j] == (int)Figures.Destination)
                                    {
                                        _finishPointI = i - 1;
                                        _finishPointJ = j;
                                        finished = true;
                                    }
                                if (j > 0)
                                    if (ArrayGraph[i, j - 1] == (int)Figures.Destination)
                                    {
                                        _finishPointI = i;
                                        _finishPointJ = j - 1;
                                        finished = true;
                                    }
                            }

                        }
                    }
                    _step++;
                } while (!finished && _step < w * h);
                _finishingCellMarked = finished;
                return finished;
            }
            private bool RestorePath()
            {
                if (!_finishingCellMarked)
                    return false;

                int w = Width;
                int h = Heidth;
                int i = _finishPointI;
                int j = _finishPointJ;
                Path = new List<Tuple<int, int>>();
                AddToPath(i, j);

                do
                {
                    if (i < w - 1)
                        if (ArrayGraph[i + 1, j] == _step - 1)
                        {
                            AddToPath(++i, j);
                        }
                    if (j < h - 1)
                        if (ArrayGraph[i, j + 1] == _step - 1)
                        {
                            AddToPath(i, ++j);
                        }
                    if (i > 0)
                        if (ArrayGraph[i - 1, j] == _step - 1)
                        {
                            AddToPath(--i, j);
                        }
                    if (j > 0)
                        if (ArrayGraph[i, j - 1] == _step - 1)
                        {
                            AddToPath(i, --j);
                        }
                    _step--;
                } while (_step != 0);
                return true;
            }
            private void AddToPath(int x, int y)
            {
                Path.Add(new Tuple<int, int>(x, y));
            }
        }
        
        public static void Main()
        {
            Game g = new Game();
            g.Start();
        }
    }
}