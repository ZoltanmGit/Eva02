using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper.View
{
    public partial class InputForm : Form
    {
        private Int32 _chosenMapSize;
        private Int32 _chosenMineNumber;
        public InputForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _chosenMapSize = 10;
            _chosenMineNumber = 12;
        }

        private void InputForm_Load(object sender, EventArgs e)
        {
            _chosenMapSize = 0;
            button1.DialogResult = DialogResult.OK;
            button2.DialogResult = DialogResult.OK;
            button3.DialogResult = DialogResult.OK;
        }
        public Int32 ChosenMapSize { get { return _chosenMapSize;} }
        public Int32 ChosenMineNumber { get { return _chosenMineNumber; } }

        private void button1_Click(object sender, EventArgs e)
        {
            _chosenMapSize = 6;
            _chosenMineNumber = 6;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _chosenMapSize = 16;
            _chosenMineNumber = 24;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
