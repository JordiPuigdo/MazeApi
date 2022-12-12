namespace MazeApi.Model
{
    public class PointMaze
    {
        public int x;
        public int y;
        public int distance;

        public PointMaze() { }
        public PointMaze(int x, int y, int distance)
        {
            this.x = x;
            this.y = y;
            this.distance = distance;
        }
    }
}
