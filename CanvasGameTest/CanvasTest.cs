using System;
using CanvasGame.Domain;
using NUnit.Framework;

namespace CanvasGameTest
{
    [TestFixture]
    public class CanvasTests
    {
        private ICanvas target = new Canvas();


        [Test]
        public void ShouldCreateCanvas()
        {
            var width = 5;
            var height = 4;

            target.Create(width, height);

            var points = target.Points;

            Assert.AreEqual(6, target.Points.GetLength(0));
            Assert.AreEqual(7, target.Points.GetLength(1));
        }
        [Test]
        public void ShouldAddLineToCanvas()
        {
            target.Create(20, 4);

            target.AddLine(new Point(1, 2), new Point (6, 2));

            var points = target.Points;
            for(var x = 1; x < 7; x++)
            {
                Assert.AreEqual('x', points[2, x]);
            }
        }

        [Test]
        public void ShouldCreateRectangleToCanvas()
        {
            target.Create(20, 4);

            target.CreateRectangle(new Point(14, 1), new Point(18, 3));

            var points = target.Points;
            for (var x = 14; x < 19; x++)
            {
                Assert.AreEqual('x', points[1, x]);
                Assert.AreEqual('x', points[3, x]);
            }
            for(var y = 1; y < 4; y++)
            {
                Assert.AreEqual('x', points[y, 14]);
                Assert.AreEqual('x', points[y, 18]);
            }
        }

        [Test]
        public void ShouldFillBucketInCanvas()
        {
            target.Create(20, 4);
            target.AddLine(new Point(1, 2), new Point(6, 2));
            target.AddLine(new Point(6, 3), new Point(6, 4));
            target.CreateRectangle(new Point(14, 1), new Point(18, 3));

            target.FillBucket(new Point(10, 3), 'o');

            var points = target.Points;
            for (var x = 1; x < points.GetLength(1) - 1; x++)
            {
                if (x < 14 || x > 18)
                {
                    Assert.AreEqual('o', points[1, x]);
                }
                if(x > 6 && x < 14 || x > 18)
                {
                    Assert.AreEqual('o', points[2, x]);
                    Assert.AreEqual('o', points[3, x]);
                }
                if(x > 6)
                {
                    Assert.AreEqual('o', points[4, x]);
                }

             }
           

        }
    }
}
