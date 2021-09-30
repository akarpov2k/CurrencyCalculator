using Calc.GameModels;
using NUnit.Framework;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateGameField()
        {
            var field = GameCellGenerator.Generate( 16 );
            Assert.NotNull( field );
        }
    }
}