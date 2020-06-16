using System;
using System.Threading.Tasks;
using MineSweeper.Persistence;

namespace MineSweeper.Model
{
    public class GameModel
    {
        //Properties
        private MineField _Field;
        private IMineSweeperDataAccess _dataAccess;
        //Events
        public event EventHandler<MineSweeperEventArgs> GameOver;

        public GameModel(IMineSweeperDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        void SetupValues()
        {
            if(_Field != null)
            {
                //Fill with 0-s
                for(int i =0; i<_Field.GetFieldSize;i++)
                {
                    for(int j = 0; j<_Field.GetFieldSize;j++)
                    {
                        _Field.SetFieldValue(i, j, 0, false);
                    }
                }
                //Place Mines
                Int32 Mines = _Field.GetMineNumber;
                Random random = new Random();
                while (Mines != 0)
                {
                    Int32 x = random.Next(0, _Field.GetFieldSize - 1);
                    Int32 y = random.Next(0, _Field.GetFieldSize - 1);
                    if(_Field.GetFieldValue(x,y) != -1)
                    {
                        _Field.SetFieldValue(x, y, -1, false);
                        Mines--;
                    }
                }
                //Count neighbouring mines
                for (int i = 0; i < _Field.GetFieldSize; i++)
                {
                    for (int j = 0; j < _Field.GetFieldSize; j++)
                    {
                        if(_Field.GetFieldValue(i,j) != -1)
                        {
                            CountMines(i, j);
                        }
                    }
                }
            }
            

        }
        public void RevealField(Int32 x, Int32 y)
        {
            _Field.SetPlayer1Turn(!_Field.GetPlayerTurn);
            if(_Field.GetFieldValue(x,y) == 0)
            {
                CheckNeighbor0(x, y);
            }
            else if(_Field.GetFieldValue(x,y) == -1)
            {
                _Field.SetFieldValue(x, y, -2,true);
                RevealBombs();
                if(GameOver != null)
                {
                    if(_Field.GetPlayerTurn)
                    {
                        GameOver(this, new MineSweeperEventArgs(false, true, _Field.GetRevealedFields));
                    }
                    else
                    {
                        GameOver(this, new MineSweeperEventArgs(false,false, _Field.GetRevealedFields));
                    }
                }
            }
            else
            {
                _Field.SetReveal(x, y, true);
                _Field.SetRevealedFields(_Field.GetRevealedFields + 1);
            }
            if (_Field.GetRevealedFields == _Field.GetFieldSize * _Field.GetFieldSize - _Field.GetMineNumber)
            {
                GameOver(this, new MineSweeperEventArgs(true, false, _Field.GetRevealedFields));
            }
        }
        private void RevealBombs()
        {
            for (int i = 0; i < _Field.GetFieldSize; i++)
            {
                for (int j = 0; j < _Field.GetFieldSize; j++)
                {
                    if (_Field.GetFieldValue(i, j) == -1)
                    {
                        _Field.SetReveal(i, j, true);
                    }
                }
            }
        }
        public void NewGame(Int32 argFieldSize, Int32 argMineNumber)
        {
            if(argFieldSize != 0)
            {
                _Field = new MineField(argFieldSize, argMineNumber);
            }
            else
            {
                _Field = new MineField();
            }
            SetupValues();
        }
        private void CountMines(Int32 x, Int32 y)
        {
            Int32 Mines = 0;
            Int32 RowStart;
            if (x > 0)
            {
                RowStart = x - 1;
            }
            else
            {
                RowStart = 0;
            }
            Int32 ColStart;
            if (y > 0)
            {
                ColStart = y - 1;
            }
            else
            {
                ColStart = 0;
            }
            for (int RowNum = RowStart; RowNum <= x + 1; RowNum++)
            {
                for (int ColNum = ColStart; ColNum <= y + 1; ColNum++)
                {
                    if (!(RowNum == x && ColNum == y) && (RowNum < _Field.GetFieldSize && ColNum < _Field.GetFieldSize))
                    {
                        if (_Field.GetFieldValue(RowNum, ColNum) == -1)
                        {
                            Mines++;
                        }
                    }
                }
            }
            _Field.SetFieldValue(x, y, Mines,false);

        }
        private void CheckNeighbor0(Int32 x, Int32 y)
        {
            _Field.SetReveal(x, y, true);
            _Field.SetRevealedFields(_Field.GetRevealedFields+1);
            Int32 RowStart;
            if (x > 0)
            {
                RowStart = x - 1;
            }
            else
            {
                RowStart = 0;
            }
            Int32 ColStart;
            if (y > 0)
            {
                ColStart = y - 1;
            }
            else
            {
                ColStart = 0;
            }
            for (int RowNum = RowStart; RowNum <= x + 1; RowNum++)
            {
                for (int ColNum = ColStart; ColNum <= y + 1; ColNum++)
                {
                    if (!(RowNum == x && ColNum == y) && (RowNum < _Field.GetFieldSize && ColNum < _Field.GetFieldSize))
                    {
                        if ((_Field.GetFieldValue(RowNum,ColNum) == 0) && !_Field.GetFieldReveal(RowNum,ColNum))
                        {
                            CheckNeighbor0(RowNum, ColNum);
                        }
                    }
                }
            }
        }
        public MineField Field { get { return _Field; } }

        public async Task LoadGameAsync(String path)
        {
            if (_dataAccess == null)
                throw new InvalidOperationException("No data access is provided.");

            _Field = await _dataAccess.LoadAsync(path);
        }

        public async Task SaveGameAsync(String path)
        {
            if (_dataAccess == null)
                throw new InvalidOperationException("No data access is provided.");

            await _dataAccess.SaveAsync(path, _Field);
        }
    }
}
