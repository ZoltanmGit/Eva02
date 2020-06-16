using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MineSweeper.Model;

namespace MineSweeperTest
{
    [TestClass]
    public class UnitTest1
    {
        private GameModel _model;
        [TestInitialize]
        public void Initialize()
        {
            _model = new GameModel(null);
        }
        [TestMethod]
        public void TestNewGame()
        {
            _model.NewGame(10, 9);
            Assert.AreEqual(9, _model.Field.GetMineNumber);
            Assert.AreEqual(10, _model.Field.GetFieldSize);
            Assert.AreEqual(true, _model.Field.GetPlayerTurn);
            Assert.AreEqual(0, _model.Field.GetRevealedFields);

            Boolean InLimit = true;
            Boolean AllHidden = true;

            for (int i = 0; i < _model.Field.GetFieldSize; i++)
            {
                for (int j = 0; j < _model.Field.GetFieldSize; j++)
                {
                    if(_model.Field.GetFieldValue(i,j) < -1 || _model.Field.GetFieldValue(i, j) > 8)
                    {
                        InLimit = false;
                    }
                    if(_model.Field.GetFieldReveal(i,j))
                    {
                        AllHidden = false;
                    }
                }
            }
            Assert.AreEqual(true, InLimit);
            Assert.AreEqual(true, AllHidden);
        }
        [TestMethod]
        public void TestReveal()
        {
            _model.NewGame(10, 10);
            Int32 x = 5;
            Int32 y = 4;

            
            Assert.AreEqual(false, _model.Field.GetFieldReveal(x, y)); //Hidden at start
            _model.RevealField(x, y); //Reveal the field
            Assert.AreEqual(true, _model.Field.GetFieldReveal(x, y)); //it's now revealed



        }
        [TestMethod]
        public void TestPlayerTurns()
        {
            _model.NewGame(10, 10);
            Assert.AreEqual(true, _model.Field.GetPlayerTurn);
            _model.RevealField(1, 1);
            Assert.AreEqual(false, _model.Field.GetPlayerTurn);
        }
    }
}
