namespace MazeApi.Model
{
    public class ObjectMaze
    {
        //maze hardcoded
        private int[,] _maze = {
            {  0, 0, 0, 0, 0, 0, 0, 0 },
            {  0,-1, 0,-1, 0,-1,-1, 0 },
            { -1,-1, 0,-1,-1,-1, 0, 0 },
            {  0, 0, 0, 0, 0, 0, 0,-1 },
            {  0,-1,-1, 0,-1,-1, 0, 0 },
            {  0, 0, 0, 0,-1,-1,-1, 0 },
            { -1, 0,-1, 0,-1, 0, 0, 0 },
            {  0, 0,-1, 0, 0, 0,-1, 0 },
        };

        public int[,] Maze
        {
            get => _maze;
        }
    }
}
