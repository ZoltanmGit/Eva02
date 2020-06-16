using System;

namespace MineSweeper.Persistence
{
    public class MineSweeperEventArgs :EventArgs
    {
        private Boolean _bIsDraw;
        private Boolean _bPlayer1Won;
        private Int32 _revealedFields;

        public Int32 RevealedFields { get {return _revealedFields; } }
        public Boolean IsDraw { get { return _bIsDraw; } }
        public Boolean Player1Won { get { return _bPlayer1Won; } }
        public MineSweeperEventArgs(Boolean isDraw, Boolean Player1Won, Int32 revealedFields)
        {
            _bPlayer1Won = Player1Won;
            _bIsDraw = isDraw;
            _revealedFields = revealedFields;
        }
    }
}
