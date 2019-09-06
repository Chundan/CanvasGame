
namespace CanvasGame.Domain.Commands
{
    public class NewCanvasCommand : ICanvasCommand
    {
        private readonly int _width;
        private readonly int _height;

        public NewCanvasCommand(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public void Execute(ICanvas canvas)
        {
            canvas.Create(_width, _height);
            canvas.Print();
        }

    }
}
