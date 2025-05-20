using System.Windows.Forms;

namespace bob_paint
{
    partial class MyPaint
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ShapeButton = new System.Windows.Forms.Button();
            this.ColorButton = new System.Windows.Forms.Button();
            this.buttonFillColor = new System.Windows.Forms.Button();
            this.buttonREDO = new System.Windows.Forms.Button();
            this.buttonUNDO = new System.Windows.Forms.Button();
            this.menuStripUP = new System.Windows.Forms.MenuStrip();
            this.menuStripUP_FILE = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.contextMenuStripBaseFigure = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.colorDialogPen = new System.Windows.Forms.ColorDialog();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button2 = new System.Windows.Forms.Button();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.add_plugin = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.menuStripUP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.ShapeButton);
            this.panel1.Controls.Add(this.ColorButton);
            this.panel1.Controls.Add(this.buttonFillColor);
            this.panel1.Controls.Add(this.buttonREDO);
            this.panel1.Controls.Add(this.buttonUNDO);
            this.panel1.Location = new System.Drawing.Point(0, 111);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(92, 730);
            this.panel1.TabIndex = 0;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(7, 306);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(82, 56);
            this.textBox3.TabIndex = 12;
            this.textBox3.Text = "Fill\r\nColor";
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(3, 156);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(82, 56);
            this.textBox2.TabIndex = 11;
            this.textBox2.Text = "Line\r\nColor";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(86, 31);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "Shapes";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ShapeButton
            // 
            this.ShapeButton.Location = new System.Drawing.Point(8, 58);
            this.ShapeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ShapeButton.Name = "ShapeButton";
            this.ShapeButton.Size = new System.Drawing.Size(75, 70);
            this.ShapeButton.TabIndex = 0;
            this.ShapeButton.UseVisualStyleBackColor = true;
            this.ShapeButton.Click += new System.EventHandler(this.ShapeButton_Click);
            this.ShapeButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShapeButton_MouseDown);
            // 
            // ColorButton
            // 
            this.ColorButton.BackColor = System.Drawing.Color.Black;
            this.ColorButton.Location = new System.Drawing.Point(13, 221);
            this.ColorButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ColorButton.Name = "ColorButton";
            this.ColorButton.Size = new System.Drawing.Size(64, 59);
            this.ColorButton.TabIndex = 3;
            this.ColorButton.UseVisualStyleBackColor = false;
            this.ColorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // buttonFillColor
            // 
            this.buttonFillColor.BackColor = System.Drawing.Color.White;
            this.buttonFillColor.Location = new System.Drawing.Point(13, 373);
            this.buttonFillColor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonFillColor.Name = "buttonFillColor";
            this.buttonFillColor.Size = new System.Drawing.Size(64, 59);
            this.buttonFillColor.TabIndex = 4;
            this.buttonFillColor.UseVisualStyleBackColor = false;
            this.buttonFillColor.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonREDO
            // 
            this.buttonREDO.Location = new System.Drawing.Point(8, 580);
            this.buttonREDO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonREDO.Name = "buttonREDO";
            this.buttonREDO.Size = new System.Drawing.Size(84, 61);
            this.buttonREDO.TabIndex = 9;
            this.buttonREDO.Text = "ReDo";
            this.buttonREDO.UseVisualStyleBackColor = true;
            this.buttonREDO.Click += new System.EventHandler(this.buttonREDO_Click);
            // 
            // buttonUNDO
            // 
            this.buttonUNDO.Location = new System.Drawing.Point(8, 485);
            this.buttonUNDO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonUNDO.Name = "buttonUNDO";
            this.buttonUNDO.Size = new System.Drawing.Size(84, 61);
            this.buttonUNDO.TabIndex = 8;
            this.buttonUNDO.Text = "UnDo";
            this.buttonUNDO.UseVisualStyleBackColor = true;
            this.buttonUNDO.Click += new System.EventHandler(this.buttonUNDO_Click);
            // 
            // menuStripUP
            // 
            this.menuStripUP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuStripUP.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStripUP.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripUP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripUP_FILE});
            this.menuStripUP.Location = new System.Drawing.Point(0, 0);
            this.menuStripUP.Name = "menuStripUP";
            this.menuStripUP.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStripUP.Size = new System.Drawing.Size(1611, 42);
            this.menuStripUP.TabIndex = 1;
            this.menuStripUP.Text = "menuStrip1";
            this.menuStripUP.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStripUP_ItemClicked);
            // 
            // menuStripUP_FILE
            // 
            this.menuStripUP_FILE.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.menuStripUP_FILE.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuStripUP_FILE.Name = "menuStripUP_FILE";
            this.menuStripUP_FILE.Size = new System.Drawing.Size(71, 36);
            this.menuStripUP_FILE.Text = "FIle";
            this.menuStripUP_FILE.Click += new System.EventHandler(this.menuStripUP_FILE_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(160, 44);
            this.toolStripMenuItem3.Text = "1";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(160, 44);
            this.toolStripMenuItem4.Text = "2";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(160, 44);
            this.toolStripMenuItem5.Text = "3";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(160, 44);
            this.toolStripMenuItem6.Text = "4";
            // 
            // Canvas
            // 
            this.Canvas.BackColor = System.Drawing.SystemColors.Control;
            this.Canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Canvas.Location = new System.Drawing.Point(100, 111);
            this.Canvas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(1337, 729);
            this.Canvas.TabIndex = 2;
            this.Canvas.TabStop = false;
            this.Canvas.Click += new System.EventHandler(this.pictureBox1_Click);
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.Canvas.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // contextMenuStripBaseFigure
            // 
            this.contextMenuStripBaseFigure.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripBaseFigure.Name = "contextMenuStripBaseFigure";
            this.contextMenuStripBaseFigure.Size = new System.Drawing.Size(61, 4);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(425, 47);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBar1.Maximum = 25;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(364, 90);
            this.trackBar1.TabIndex = 6;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1015, 24);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 77);
            this.button2.TabIndex = 11;
            this.button2.Text = "Load";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(104, 47);
            this.trackBar2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBar2.Maximum = 25;
            this.trackBar2.Minimum = 5;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(180, 90);
            this.trackBar2.TabIndex = 12;
            this.trackBar2.Value = 5;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(840, 24);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 77);
            this.button1.TabIndex = 10;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(13, 54);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(72, 31);
            this.textBox4.TabIndex = 13;
            this.textBox4.Text = "Angles";
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(305, 54);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(109, 31);
            this.textBox5.TabIndex = 14;
            this.textBox5.Text = "Thinkness";
            // 
            // add_plugin
            // 
            this.add_plugin.Location = new System.Drawing.Point(1195, 24);
            this.add_plugin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.add_plugin.Name = "add_plugin";
            this.add_plugin.Size = new System.Drawing.Size(122, 77);
            this.add_plugin.TabIndex = 15;
            this.add_plugin.Text = "Add Plugin";
            this.add_plugin.UseVisualStyleBackColor = true;
            this.add_plugin.Click += new System.EventHandler(this.add_plugin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1611, 867);
            this.Controls.Add(this.add_plugin);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Canvas);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStripUP);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.trackBar2);
            this.MainMenuStrip = this.menuStripUP;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Paint";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStripUP.ResumeLayout(false);
            this.menuStripUP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStripUP;
        private System.Windows.Forms.ToolStripMenuItem menuStripUP_FILE;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripBaseFigure;
        private System.Windows.Forms.Button ShapeButton;
        private System.Windows.Forms.ColorDialog colorDialogPen;
        private System.Windows.Forms.Button ColorButton;
        private System.Windows.Forms.Button buttonFillColor;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button buttonUNDO;
        private System.Windows.Forms.Button buttonREDO;
        private System.Windows.Forms.Button button2;
        private TrackBar trackBar2;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Button add_plugin;
    }
}

