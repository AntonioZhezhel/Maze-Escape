namespace MazeEscape
{
    public class MazeGeneratorWalls
    {
        public int x;
        public int y;

        public bool WallLeft = true;
        public bool WallBottom = true;

        public bool passedCell;
        public int distanceFromStart;
    }
}