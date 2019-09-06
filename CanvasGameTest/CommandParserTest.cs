using System;
using CanvasGame.Domain;
using CanvasGame.Domain.Commands;
using NUnit.Framework;

namespace CanvasGameTest
{
    [TestFixture]
    public class CommandParserTests
    {
        private CommandParser target = new CommandParser();

        [Test]
        public void ShouldParseCreateCommand()
        {
            var input = "C 10 20";
            var result = target.Parse(input);

            Assert.AreEqual(true, (result is NewCanvasCommand));
        }

        [Test]
        public void ShouldParseAddLineCommand()
        {
            var input = "L 1 2 3 4";
            var result = target.Parse(input);

            Assert.AreEqual(true, (result is CanvasNewRectangleCommand));
        }

        [Test]
        public void ShouldParseAddRectangleCommand()
        {
            var input = "R 1 2 3 4";
            var result = target.Parse(input);

            Assert.AreEqual(true, (result is CanvasNewRectangleCommand));
        }


        [Test]
        public void ShouldParseBuketFillCommand()
        {
            var input = "B 5 6 o";
            var result = target.Parse(input);

            Assert.AreEqual(true, (result is CanvasBuketFillCommand));
        }
    }
}
