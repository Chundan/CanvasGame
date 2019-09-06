namespace CanvasGame.Domain.Commands
{
    public class CanvasNewRectangleCommand : ICanvasCommand
    {
        private readonly int _x1;
        private readonly int _y1;
        private readonly int _x2;
        private readonly int _y2;

        public CanvasNewRectangleCommand(int x1, int y1, int x2, int y2)
        {
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
        }

        public void Execute(ICanvas canvas)
        {
            var point1 = new Point(_x1, _y1);
            var point2 = new Point(_x2, _y2);
            canvas.CreateRectangle(point1, point2);
            canvas.Print();
        }
    }
}
