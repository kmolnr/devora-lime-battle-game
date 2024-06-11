using DevoraLime.BattleGame.Types;
using Moq;
using NUnit.Framework.Internal;

namespace DevoraLime.BattleGame.Tests
{
    [TestFixture]
    public class HeroTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AttackTest()
        {
            // Archer attacker

            var random1 = new Mock<Random>();
            random1.Setup(x => x.NextDouble()).Returns(0.3);

            var h1 = new Hero(1, HeroType.Archer);
            var h2 = new Hero(2, HeroType.Knight);

            h1.Attack(h2, random1.Object);

            Assert.True(h1.IsAlive);
            Assert.False(h2.IsAlive);

            var random2 = new Mock<Random>();
            random2.Setup(x => x.NextDouble()).Returns(0.6);

            var h3 = new Hero(3, HeroType.Archer);
            var h4 = new Hero(4, HeroType.Knight);

            h3.Attack(h4, random2.Object);

            Assert.True(h3.IsAlive);
            Assert.True(h4.IsAlive);

            var h5 = new Hero(5, HeroType.Archer);
            var h6 = new Hero(6, HeroType.Swordsman);

            h5.Attack(h6, random1.Object);

            Assert.True(h5.IsAlive);
            Assert.False(h6.IsAlive);

            var h7 = new Hero(7, HeroType.Archer);
            var h8 = new Hero(8, HeroType.Archer);

            h7.Attack(h8, random1.Object);

            Assert.True(h7.IsAlive);
            Assert.False(h8.IsAlive);

            // Swordsman attacker

            var h9 = new Hero(9, HeroType.Swordsman);
            var h10 = new Hero(10, HeroType.Knight);

            h9.Attack(h10, random1.Object);

            Assert.True(h9.IsAlive);
            Assert.True(h10.IsAlive);

            var h11 = new Hero(11, HeroType.Swordsman);
            var h12 = new Hero(12, HeroType.Swordsman);

            h11.Attack(h12, random1.Object);

            Assert.True(h11.IsAlive);
            Assert.False(h12.IsAlive);

            var h13 = new Hero(13, HeroType.Swordsman);
            var h14 = new Hero(14, HeroType.Archer);

            h13.Attack(h14, random1.Object);

            Assert.True(h13.IsAlive);
            Assert.False(h14.IsAlive);

            // Knight attacker

            var h15 = new Hero(15, HeroType.Knight);
            var h16 = new Hero(16, HeroType.Knight);

            h15.Attack(h16, random1.Object);

            Assert.True(h15.IsAlive);
            Assert.False(h16.IsAlive);

            var h17 = new Hero(17, HeroType.Knight);
            var h18 = new Hero(18, HeroType.Swordsman);

            h17.Attack(h18, random1.Object);

            Assert.False(h17.IsAlive);
            Assert.True(h18.IsAlive);

            var h19 = new Hero(19, HeroType.Knight);
            var h20 = new Hero(20, HeroType.Archer);

            h19.Attack(h20, random1.Object);

            Assert.True(h19.IsAlive);
            Assert.False(h20.IsAlive);
        }
    }
}
