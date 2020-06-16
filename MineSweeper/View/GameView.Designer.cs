namespace MineSweeper.View
{
    partial class GameView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_NewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItem_LoadGame = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_SaveGame = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItem_Quit = new System.Windows.Forms.ToolStripMenuItem();
            this.Panel_PlayerTurn = new System.Windows.Forms.Panel();
            this.Label_PlayerTurn = new System.Windows.Forms.Label();
            this._saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this._openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_File});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(349, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItem_File
            // 
            this.MenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_NewGame,
            this.toolStripSeparator1,
            this.MenuItem_LoadGame,
            this.MenuItem_SaveGame,
            this.toolStripSeparator2,
            this.MenuItem_Quit});
            this.MenuItem_File.Name = "MenuItem_File";
            this.MenuItem_File.Size = new System.Drawing.Size(37, 20);
            this.MenuItem_File.Text = "File";
            // 
            // MenuItem_NewGame
            // 
            this.MenuItem_NewGame.Name = "MenuItem_NewGame";
            this.MenuItem_NewGame.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_NewGame.Text = "New Game";
            this.MenuItem_NewGame.Click += new System.EventHandler(this.MenuItem_NewGame_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // MenuItem_LoadGame
            // 
            this.MenuItem_LoadGame.Name = "MenuItem_LoadGame";
            this.MenuItem_LoadGame.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_LoadGame.Text = "Load Game...";
            this.MenuItem_LoadGame.Click += new System.EventHandler(this.MenuItem_LoadGame_Click);
            // 
            // MenuItem_SaveGame
            // 
            this.MenuItem_SaveGame.Name = "MenuItem_SaveGame";
            this.MenuItem_SaveGame.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_SaveGame.Text = "Save Game...";
            this.MenuItem_SaveGame.Click += new System.EventHandler(this.MenuItem_SaveGame_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // MenuItem_Quit
            // 
            this.MenuItem_Quit.Name = "MenuItem_Quit";
            this.MenuItem_Quit.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_Quit.Text = "Quit";
            this.MenuItem_Quit.Click += new System.EventHandler(this.MenuItem_Quit_Click);
            // 
            // Panel_PlayerTurn
            // 
            this.Panel_PlayerTurn.Location = new System.Drawing.Point(44, 0);
            this.Panel_PlayerTurn.Name = "Panel_PlayerTurn";
            this.Panel_PlayerTurn.Size = new System.Drawing.Size(25, 25);
            this.Panel_PlayerTurn.TabIndex = 1;
            // 
            // Label_PlayerTurn
            // 
            this.Label_PlayerTurn.AutoSize = true;
            this.Label_PlayerTurn.Location = new System.Drawing.Point(74, 5);
            this.Label_PlayerTurn.Name = "Label_PlayerTurn";
            this.Label_PlayerTurn.Size = new System.Drawing.Size(35, 13);
            this.Label_PlayerTurn.TabIndex = 2;
            this.Label_PlayerTurn.Text = "label1";
            // 
            // _openFileDialog
            // 
            this._openFileDialog.FileName = "openFileDialog1";
            // 
            // GameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(349, 292);
            this.Controls.Add(this.Label_PlayerTurn);
            this.Controls.Add(this.Panel_PlayerTurn);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GameView";
            this.Text = "Mine Sweeper";
            this.Load += new System.EventHandler(this.GameView_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_NewGame;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_LoadGame;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_SaveGame;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Quit;
        private System.Windows.Forms.Panel Panel_PlayerTurn;
        private System.Windows.Forms.Label Label_PlayerTurn;
        private System.Windows.Forms.SaveFileDialog _saveFileDialog;
        private System.Windows.Forms.OpenFileDialog _openFileDialog;
    }
}