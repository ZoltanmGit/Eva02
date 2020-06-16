using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Persistence
{
    public class MineField
    {
        // Properties
        private Int32 _fieldSize;
        private Int32 _mines;
        private Int32[,] _fieldValues;
        private Boolean[,] _fieldReveals;
        private Boolean _bPlayer1Turn;
        private Int32 _revealedFields;
        //Constructors
        public MineField(): this(6,6) { }

        public MineField(Int32 argFieldSize,Int32 argMineNumber)
        {
            _mines = argMineNumber;
            _revealedFields = 0;
            _bPlayer1Turn = true;
            _fieldSize = argFieldSize;
            _fieldValues = new Int32[_fieldSize,_fieldSize];
            _fieldReveals = new bool[_fieldSize, _fieldSize];
        }
        //Gets and Sets
        public Int32 GetFieldSize { get { return _fieldSize; } }
        public Int32 GetMineNumber { get { return _mines; } }
        public Int32 GetFieldValue(Int32 x, Int32 y)
        {
            return _fieldValues[x, y];
        }
        public Boolean GetFieldReveal(Int32 x, Int32 y)
        {
            return _fieldReveals[x, y];
        }
        public Boolean GetPlayerTurn { get { return _bPlayer1Turn; } } //If true, then it's player1's turn
        public Int32 GetRevealedFields { get { return _revealedFields; } }
        public void SetFieldValue(Int32 x, Int32 y, Int32 Value, Boolean bIsRevealed)
        {
            //HANDLING
            _fieldValues[x, y] = Value;
            _fieldReveals[x, y] = bIsRevealed;
        }
        public void SetReveal(Int32 x, Int32 y, Boolean bIsRevealed)
        {
            _fieldReveals[x, y] = bIsRevealed;
        }
        public void SetPlayer1Turn(Boolean argBool)
        {
            _bPlayer1Turn = argBool;
        }
        public void SetRevealedFields(Int32 argRevealedFields)
        {
            _revealedFields = argRevealedFields;
        }
    }
}
