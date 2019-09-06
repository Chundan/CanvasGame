using CanvasGame.Domain;

namespace CanvasGame.Domain.Commands
{
    public interface ICanvasCommand
    {
        void Execute(ICanvas canvas);
    }
}
