using System;
using System.Linq;

namespace CanvasGame.Domain
{
    public interface ICanvas
    {
        void Create(int width, int height);
        void AddLine(Point p1, Point p2);
        void CreateRectangle(Point p1, Point p2);
        char[,] Points { get; }

        void Print();
        void FillBucket(Point point, char color);
    }
    public class Canvas : ICanvas
    {
        private char _defaultLinePoint = 'x';
        public char[,] Points { get; private set; }

        public void Create(int width, int height)
        {
            var canvasWidth = width + 2;
            var canvasHeight = height + 2;
            Points = new char[canvasHeight, canvasWidth];
            var xPoints = Enumerable.Range(0, canvasWidth);
            var yPoints = Enumerable.Range(0, canvasHeight);

            foreach (var y in yPoints)
            {
                foreach (var x in xPoints)
                {
                    if (y == 0 || y == canvasHeight - 1) Points[y, x] = '-';
                    else if (x == 0 || x == canvasWidth - 1) Points[y, x] = '|';
                    else
                    {
                        Points[y, x] = ' ';
                    }

                }
            }
        }

        public void AddLine(Point p1, Point p2)
        {
            if (!IsCanvasCreated()) throw new CommandErrorException("No canvas created! Please create canvas first!");
            if (!IsPointValid(p1) || !IsPointValid(p2)) throw new ArgumentOutOfRangeException("Input points are out of canvas area!");
            if (p1.X != p2.X && p1.Y != p2.Y) throw new CommandErrorException("Not supported yet!");

            if (p1.X == p2.X)
            {
                var lineStart = Math.Min(p1.Y, p2.Y);
                var lineEnd = Math.Max(p1.Y, p2.Y);
                for (var y = lineStart; y < lineEnd + 1; y++)
                {
                    Points[y, p1.X] = _defaultLinePoint;
                }
            }
            if (p1.Y == p2.Y)
            {
                var lineStart = Math.Min(p1.X, p2.X);
                var lineEnd = Math.Max(p1.X, p2.X);
                for (var x = lineStart; x < lineEnd + 1; x++)
                {
                    Points[p1.Y, x] = _defaultLinePoint;
                }
            }
        }

        public void CreateRectangle(Point p1, Point p2)
        {
            if (!IsCanvasCreated()) throw new CommandErrorException("No canvas created! Please create canvas first!");
            if (!IsPointValid(p1) || !IsPointValid(p2)) throw new ArgumentOutOfRangeException("Input points are out of canvas area!");

            var xlineStart = Math.Min(p1.X, p2.X);
            var xlineEnd = Math.Max(p1.X, p2.X);
            var ylineStart = Math.Min(p1.Y, p2.Y);
            var ylineEnd = Math.Max(p1.Y, p2.Y);
            for (var x = xlineStart; x < xlineEnd + 1; x++)
            {
                Points[ylineStart, x] = _defaultLinePoint;
                Points[ylineEnd, x] = _defaultLinePoint;
            }
            for (var y = ylineStart; y < ylineEnd + 1; y++)
            {
                Points[y, xlineStart] = _defaultLinePoint;
                Points[y, xlineEnd] = _defaultLinePoint;
            }
        }

        public void FillBucket(Point point, char color)
        {
            if (!IsCanvasCreated()) throw new CommandErrorException("No canvas created! Please create canvas first!");
            if (!IsPointValid(point)) throw new ArgumentOutOfRangeException("Input point is out of canvas area!");

            var x = point.X;
            var y = point.Y;

            fill(x, y, color);

        }

        private void fill(int x, int y, char color)
        {
            if (x == 0
                || x == Points.GetLength(1) - 1
                || y == 0
                || y == Points.GetLength(0) - 1
                || Points[y, x] != ' ')
            {
                return;
            }
            Points[y, x] = color;
            fill(x, y - 1, color);
            fill(x, y + 1, color);
            fill(x - 1, y, color);
            fill(x + 1, y, color);
        }

        public bool IsCanvasCreated()
        {
            return Points != null;
        }

        public bool IsPointValid(Point point)
        {
            return point.X >= 0 && point.X <= Points.GetLength(1) - 1
                && point.Y >= 0 && point.Y <= Points.GetLength(0) - 1;
        }

        public void Print()
        {
            for (var y = 0; y < Points.GetLength(0); y++)
            {
                for (var x = 0; x < Points.GetLength(1); x++)
                {
                    Console.Write(Points[y, x]);
                }
                Console.WriteLine();
            }
        }
    }
}
