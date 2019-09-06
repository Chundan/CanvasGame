namespace CanvasGame.Domain.Commands
{
    public class CanvasBuketFillCommand : ICanvasCommand
    {
        private readonly int _x;
        private readonly int _y;
        private readonly char _color;

        public CanvasBuketFillCommand(int x, int y, char color)
        {
            _x = x;
            _y = y;
            _color = color;
        }

        public void Execute(ICanvas canvas)
        {
            var connectedPoint = new Point(_x, _y);
            canvas.FillBucket(connectedPoint, _color);
            canvas.Print();
        }
    }
}
