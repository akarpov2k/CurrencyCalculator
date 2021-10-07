using Calc.GameModels;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

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
        [Test]
        public void CreateGameField_MustBeOk()
        {
            var field = GameCellGenerator.Generate( 16 );
            var li = new List<int>();
            foreach(var col in field.Field)
            {
                foreach(var cell in col )
                {
                    li.Add( cell.Value.Value );
                }
            }
            var group = li.GroupBy( x => x );
            Assert.True( group.All( g => g.Count() == 2 ));
        }
    }
}