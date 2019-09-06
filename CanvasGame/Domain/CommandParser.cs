using CanvasGame.Domain.Commands;
using System;

namespace CanvasGame.Domain
{
    public interface ICommandParser
    {
        ICanvasCommand Parse(string input);
    }

    public class CommandParser : ICommandParser
    {
        public ICanvasCommand Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("The input is not a valid command.");
            }
            var commandInput = input.Split(' ');

            CommandType commandType;
            if (!Enum.TryParse(commandInput[0], out commandType))
            {
                throw new ArgumentException("The input is not a valid command.");
            }

            switch (commandType)
            {
                case CommandType.C:
                    return createCanvasCommand(commandInput);
                case CommandType.L:
                    return canvasNewLineCommand(commandInput);
                case CommandType.R:
                    return canvasNewRectangleCommand(commandInput);
                case CommandType.B:
                    return canvasBuketFillCommand(commandInput);
                default:
                    throw new ArgumentException("The input is not a valid command.");

            }
        }

        private ICanvasCommand createCanvasCommand(string[] commandInput)
        {
            int width;
            int height;
            if (commandInput.Length != 3
                || !int.TryParse(commandInput[1], out width)
                || !int.TryParse(commandInput[2], out height))
                throw new ArgumentException("The input is not a valid command.");
            return new NewCanvasCommand(width, height);
        }

        private ICanvasCommand canvasNewLineCommand(string[] commandInput)
        {
            if (commandInput.Length != 5
                        || !int.TryParse(commandInput[1], out int x1)
                        || !int.TryParse(commandInput[2], out int y1)
                        || !int.TryParse(commandInput[3], out int x2)
                        || !int.TryParse(commandInput[4], out int y2)
                        || x1 == x2 && y1 == y2)
                throw new ArgumentException("The input is not a valid command.");
            return new CanvasNewLineCommand(x1, y1, x2, y2);
        }

        private ICanvasCommand canvasNewRectangleCommand(string[] commandInput)
        {
            if (commandInput.Length != 5
                        || !int.TryParse(commandInput[1], out int x1)
                        || !int.TryParse(commandInput[2], out int y1)
                        || !int.TryParse(commandInput[3], out int x2)
                        || !int.TryParse(commandInput[4], out int y2))
                throw new ArgumentException("The input is not a valid command.");
            return new CanvasNewRectangleCommand(x1, y1, x2, y2);
        }

        private ICanvasCommand canvasBuketFillCommand(string[] commandInput)
        {
            if (commandInput.Length != 4
                || !int.TryParse(commandInput[1], out int x)
                || !int.TryParse(commandInput[2], out int y)
                || string.IsNullOrWhiteSpace(commandInput[3]))
                throw new ArgumentException("The input is not a valid command.");
            var color = commandInput[3].ToCharArray()[0];
            return new CanvasBuketFillCommand(x, y, color);
        }
    }
}
