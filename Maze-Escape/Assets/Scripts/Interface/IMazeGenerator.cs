namespace MazeEscape
{
    public interface IMazeGenerator
    {
        MazeGeneratorWalls[,] GenerateMaze();
        MazeGeneratorWalls GetFarthestCell();
    }
}