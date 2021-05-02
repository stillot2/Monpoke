using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        TestInput commands = new TestInput();
        string[] args = new string[1];

        [TestMethod]
        public void Valid()
        {
            args[0] = commands.inputs[(int)TestInput.TestIndex.VALID];
            Assert.AreEqual(0, Monpoke.Program.Main(args));
        }
        [TestMethod]
        public void MoreTeams()
        {
            args[0] = commands.inputs[(int)TestInput.TestIndex.MORETEAMS];
            Assert.AreEqual(1, Monpoke.Program.Main(args));
        }
        [TestMethod]
        public void LessTeams()
        {
            args[0] = commands.inputs[(int)TestInput.TestIndex.LESSTEAMS];
            Assert.AreEqual(1, Monpoke.Program.Main(args));
        }
        [TestMethod]
        public void InvalidMonopokeHp()
        {
            args[0] = commands.inputs[(int)TestInput.TestIndex.INVALIDMONPOKEHP];
            Assert.AreEqual(1, Monpoke.Program.Main(args));
        }
        [TestMethod]
        public void InvalidMonopokeAp()
        {
            args[0] = commands.inputs[(int)TestInput.TestIndex.INVALIDMONPOKEAP];
            Assert.AreEqual(1, Monpoke.Program.Main(args));
        }
        [TestMethod]
        public void EarlyIChooseYou()
        {
            args[0] = commands.inputs[(int)TestInput.TestIndex.EARLYCHOOSE];
            Assert.AreEqual(1, Monpoke.Program.Main(args));
        }
        [TestMethod]
        public void CreateInBattle()
        {
            args[0] = commands.inputs[(int)TestInput.TestIndex.LATECREATE];
            Assert.AreEqual(1, Monpoke.Program.Main(args));
        }
        [TestMethod]
        public void InvalidIChooseYou()
        {
            args[0] = commands.inputs[(int)TestInput.TestIndex.INVALIDCHOOSE];
            Assert.AreEqual(1, Monpoke.Program.Main(args));
        }
        [TestMethod]
        public void InvalidAttack()
        {
            args[0] = commands.inputs[(int)TestInput.TestIndex.INVALIDATTACK];
            Assert.AreEqual(1, Monpoke.Program.Main(args));
        }
    }
    
}
