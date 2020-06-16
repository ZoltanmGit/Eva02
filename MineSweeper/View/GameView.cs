using System;
using System.Drawing;
using System.Windows.Forms;
using MineSweeper.Model;
using MineSweeper.Persistence;

namespace MineSweeper.View
{
    public partial class GameView : Form
    {
        //Properties
        private IMineSweeperDataAccess _dataAccess;
        private Button[,] _buttonGrid;
        private GameModel _model;

        public GameView()
        {
            InitializeComponent();
        }

        private void Game_GameOver(Object sender, MineSweeperEventArgs e)
        {
            MenuItem_SaveGame.Enabled = false;
            foreach (Button button in _buttonGrid) // kikapcsoljuk a gombokat
                button.Enabled = false;
            UpdateView(); //For Big B
            if (e.IsDraw)
            {
                MessageBox.Show("The game is a draw","Game Over",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
            else if(e.Player1Won)
            {
                MessageBox.Show("Player 1 / Blue won", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if(!e.Player1Won)
            {
                MessageBox.Show("Player 2 / Red won", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Unhandleded", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void MenuItem_Quit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Mine Sweeper", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // ha igennel válaszol
                Close();
            }
        }

        private void GameView_Load(object sender, EventArgs e)
        {
            _dataAccess = new MineSweeperFileDataAccess();
            InputForm IF = new InputForm();
            IF.ShowDialog();
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _model = new GameModel(_dataAccess);
            _model.GameOver += new EventHandler<MineSweeperEventArgs>(Game_GameOver);
            _model.NewGame(IF.ChosenMapSize, IF.ChosenMineNumber);
            
            GenerateTable();
            UpdateView();
        }

        private void GenerateTable()
        {
            _buttonGrid = new Button[_model.Field.GetFieldSize, _model.Field.GetFieldSize];
            for (Int32 i = 0; i < _model.Field.GetFieldSize; i++)
                for (Int32 j = 0; j < _model.Field.GetFieldSize; j++)
                {
                    _buttonGrid[i, j] = new Button();
                    _buttonGrid[i, j].Location = new Point(5 + 50 * j, 25 + 50 * i); // elhelyezkedés
                    _buttonGrid[i, j].Size = new Size(50, 50); // méret
                    _buttonGrid[i, j].Font = new Font(FontFamily.GenericSansSerif, 25, FontStyle.Bold); // betűtípus
                    _buttonGrid[i, j].Enabled = true;
                    _buttonGrid[i, j].TabIndex = 100 + i * _model.Field.GetFieldSize + j; // a gomb számát a TabIndex-ben tároljuk
                    _buttonGrid[i, j].FlatStyle = FlatStyle.Flat; // lapított stípus
                    _buttonGrid[i, j].MouseClick += new MouseEventHandler(ButtonGrid_MouseClick);
                    _buttonGrid[i, j].TabStop = false;

                    Controls.Add(_buttonGrid[i, j]);
                    // felevesszük az ablakra a gombot
                }
        }
        private void ButtonGrid_MouseClick(Object sender, MouseEventArgs e)
        {
            Int32 x = ((sender as Button).TabIndex - 100) / _model.Field.GetFieldSize;
            Int32 y = ((sender as Button).TabIndex - 100) % _model.Field.GetFieldSize;
            _buttonGrid[x, y].Enabled = false;
            _model.RevealField(x, y);
            UpdateView();
        }

        private void UpdateView()
        {
            
            if(_model.Field.GetPlayerTurn)
            {
                Panel_PlayerTurn.BackColor = Color.LightBlue;
                Label_PlayerTurn.Text = "Turn: Player1 / Blue";
            }
            else
            {
                Panel_PlayerTurn.BackColor = Color.IndianRed;
                Label_PlayerTurn.Text = "Turn: Player2 / Red";
            }
            for (int i = 0; i < _model.Field.GetFieldSize; i++)
            {
                for (int j = 0; j < _model.Field.GetFieldSize; j++)
                {

                    if (_model.Field.GetFieldValue(i, j) == -1 && _model.Field.GetFieldReveal(i, j))
                    {
                        _buttonGrid[i, j].BackColor = Color.DarkRed;
                        _buttonGrid[i, j].Text = "B";
                    }
                    else if(_model.Field.GetFieldValue(i,j)==-2)
                    {
                        _buttonGrid[i, j].BackColor = Color.Red;
                        _buttonGrid[i, j].Text = "B";
                    }
                    else if(_model.Field.GetFieldReveal(i,j))
                    {
                        _buttonGrid[i, j].Enabled = false;
                        _buttonGrid[i, j].BackColor = Color.White;
                        _buttonGrid[i, j].Text = _model.Field.GetFieldValue(i, j).ToString();
                    }
                    else
                    {
                        _buttonGrid[i, j].BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void MenuItem_NewGame_Click(object sender, EventArgs e)
        {
            InputForm IF = new InputForm();
            IF.ShowDialog();
            foreach (Button button in _buttonGrid) // kikapcsoljuk a gombokat
            {
                Controls.Remove(button);
            }
            MenuItem_SaveGame.Enabled = true;
            _model.NewGame(IF.ChosenMapSize, IF.ChosenMineNumber);
            GenerateTable();
            UpdateView();
        }

        private async void MenuItem_SaveGame_Click(object sender, EventArgs e)
        {
            if (_saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // játé mentése
                    await _model.SaveGameAsync(_saveFileDialog.FileName);
                }
                catch (MineSweeperDataException)
                {
                    MessageBox.Show("Játék mentése sikertelen!" + Environment.NewLine + "Hibás az elérési út, vagy a könyvtár nem írható.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void MenuItem_LoadGame_Click(object sender, EventArgs e)
        {
            if (_openFileDialog.ShowDialog() == DialogResult.OK) // ha kiválasztottunk egy fájlt
            {
                try
                {
                    // játék betöltése
                    await _model.LoadGameAsync(_openFileDialog.FileName);
                    MenuItem_SaveGame.Enabled = true;
                    foreach (Button button in _buttonGrid) // kikapcsoljuk a gombokat
                    {
                        Controls.Remove(button);
                    }
                    GenerateTable();
                    UpdateView();
                }
                catch (MineSweeperDataException)
                {
                    MessageBox.Show("Játék betöltése sikertelen!" + Environment.NewLine + "Hibás az elérési út, vagy a fájlformátum.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    _model.NewGame(6,6);
                    MenuItem_SaveGame.Enabled = true;
                }
            }
        }
    }
}
