int[,] maze = new int[10, 50];
Dictionary<string, string> shoudVerifyPos = new Dictionary<string, string>();
Dictionary<string, string> verifiedPostions = new Dictionary<string, string>();
#region initial pos
Random rand = new();
int linhaPartida = rand.Next(1, 9);
maze[linhaPartida, 1] = 2;
shoudVerifyPos.Add(linhaPartida + "/" + 1, linhaPartida + "/" + 1);
#endregion
#region end pos
int linhaObjetivo = rand.Next(1, 9);
maze[linhaObjetivo, 48] = 3;
#endregion
definedObstacles(maze, rand);
showMaze(maze);
await Task.Delay(1000);
Console.WriteLine("Em Real time o robo montará o melhor caminho!");
await Task.Delay(2000);
//Console.Clear();
while(shoudVerifyPos.Count > 0)
{

}
void showMaze(int[,] maze)
{
    for (int i = 0; i < maze.GetLength(0); i++)
    {
        for (int j = 0; j < maze.GetLength(1); j++)
        {
            bool isWall = i == 0 || j == 0 || i == maze.GetLength(0) - 1 || j == maze.GetLength(1) - 1;
            if (maze[i, j] == 2)
            {
                Console.Write("I");
            }
            else if (maze[i, j] == 3)
            {
                Console.Write("F");
            }
            else if (maze[i, j] == -1 || isWall)
            {
                Console.Write("#");
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }
}
void definedObstacles(int[,] maze, Random rand)
{
    int numObstaculos = 50;
    for (int i = 0; i < maze.GetLength(0); i++)
    {
        for (int j = 0; j < maze.GetLength(1); j++)
        {
            bool isWall = i == 0 || j == 0 || i == maze.GetLength(0) - 1 || j == maze.GetLength(1) - 1;

            if (isWall)
            {
                maze[i, j] = -1;
            }
            else if(maze[i, j] != 2 && maze[i, j] != 3 && maze[i, j] != -1)
            {
                maze[i, j] = 1;
            }
        }
    }
    for (int i = 0; i < numObstaculos; i++)
    {
        int linha = rand.Next(1, 8);
        int coluna = rand.Next(1, 48);
        if (maze[linha, coluna] != 2 || maze[linha, coluna] != 3)
        {
            maze[linha, coluna] = -1;
        }
    }
}