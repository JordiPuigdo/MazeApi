using MazeApi.Interface;
using MazeApi.Model;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MazeApi.Services
{
    public class CalculateDistance : ICalculateDistance
    {
        const int MAXLENGTH = 7;
        const int SOURCEX = 7;
        const int SOURCEY = 0;

        public List<PointMaze> _pointMaze = new List<PointMaze>();

        public List<PointMaze> GetMaze()
        {
            //create objectMaze, source point and destiny
            PointMaze source = new PointMaze(SOURCEX, SOURCEY, 0);
            PointMaze destiny = new PointMaze(0, 0, 0);
            ObjectMaze objectMaze = new ObjectMaze();

            int distance = 0;
            int[,] maze = objectMaze.Maze;

            for (int pointX = 0; pointX < maze.GetLength(0); pointX++)
            {
                for (int pointY = 0; pointY < maze.GetLength(1); pointY++)
                {
                    if (maze[pointX, pointY] != -1)
                    {
                        destiny.x = pointX;
                        destiny.y = pointY;

                        distance = findShortestPathLength(maze, source, destiny);
                    }
                    else
                    {
                        distance = -1;
                    }

                    PointMaze pointMazeInsert = new PointMaze
                    {
                        x = pointX,
                        y = pointY,
                        distance = distance
                    };

                    _pointMaze.Add(pointMazeInsert);
                }
            }

            return _pointMaze;
        }

    

        private int findShortestPathLength(int[,] maze, PointMaze source, PointMaze destiny)
        {
            if (!isValid(source, MAXLENGTH))
            {
                return -1;
            }
            
            int row = maze.GetLength(0);
            int col = maze.GetLength(1);

            bool[,] visited = new bool[row, col];

            for (int distanceX = 0; distanceX < row; distanceX++)
            {
                for (int distanceY = 0; distanceY < col; distanceY++)
                    visited[distanceX, distanceY] = false;
            }

            int distance = Int32.MaxValue;

            distance = findShortestPath(maze, source.x, source.y,
                                    destiny.x, destiny.y, distance, 0, visited);

            if (distance != Int32.MaxValue)
                return distance;

            return -2;
        }

        private int findShortestPath(int[,] mat, int sourcePointX, int sourcePointY,
                               int destinyPointX, int destinyPointY, int miniumDistance,
                               int distance, bool[,] visited)
        {

            if (sourcePointX == destinyPointX && sourcePointY == destinyPointY)
            {
                //return the lowest value between distance and minium distance
                miniumDistance = Math.Min(distance, miniumDistance);
                return miniumDistance;
            }

            //mark as visited
            visited[sourcePointX, sourcePointY] = true;
            
            // go to the bottom cell
            if (isAvailable(mat, visited, sourcePointX + 1, sourcePointY))
            {
                miniumDistance = findShortestPath(mat, sourcePointX + 1, sourcePointY, destinyPointX, destinyPointY,
                                            miniumDistance, distance + 1, visited);
            }
            // go to the right cell
            if (isAvailable(mat, visited, sourcePointX, sourcePointY + 1))
            {
                miniumDistance = findShortestPath(mat, sourcePointX, sourcePointY + 1, destinyPointX, destinyPointY,
                                            miniumDistance, distance + 1, visited);
            }
            // go to the top cell
            if (isAvailable(mat, visited, sourcePointX - 1, sourcePointY))
            {
                miniumDistance = findShortestPath(mat, sourcePointX - 1, sourcePointY, destinyPointX, destinyPointY,
                                            miniumDistance, distance + 1, visited);
            }
            
            // go to the left cell
            if (isAvailable(mat, visited, sourcePointX, sourcePointY - 1))
            {
                miniumDistance = findShortestPath(mat, sourcePointX, sourcePointY - 1, destinyPointX, destinyPointY,
                                            miniumDistance, distance + 1, visited);
            }

            //mark visited as false
            visited[sourcePointX, sourcePointY] = false;

            return miniumDistance;
           
        }


        private bool isAvailable(int[,] mat, bool[,] visited, int x, int y)
        {
            return (x >= 0 && x < mat.GetLength(0) && y >= 0
                    && y < mat.GetLength(1) && mat[x,  y] == 0
                    && !visited[x, y]);
        }

        private bool isValid(PointMaze source, int max)
        {
            return (source.x >= 0) && (source.x <= max) &&
                    (source.y >= 0) && (source.y <= max);
        }

    }
}
