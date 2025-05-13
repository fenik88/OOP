namespace bob_paint
{
    partial class Form1
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
            this.ShapeButton = new System.Windows.Forms.Button();
            this.menuStripUP = new System.Windows.Forms.MenuStrip();
            this.menuStripUP_FILE = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStripBaseFigure = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EllipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BrokenLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialogPen = new System.Windows.Forms.ColorDialog();
            this.ColorButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.menuStripUP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStripBaseFigure.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.ShapeButton);
            this.panel1.Controls.Add(this.ColorButton);
            this.panel1.Location = new System.Drawing.Point(0, 111);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(92, 730);
            this.panel1.TabIndex = 0;
            // 
            // ShapeButton
            // 
            this.ShapeButton.Location = new System.Drawing.Point(4, 22);
            this.ShapeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ShapeButton.Name = "ShapeButton";
            this.ShapeButton.Size = new System.Drawing.Size(75, 70);
            this.ShapeButton.TabIndex = 0;
            this.ShapeButton.UseVisualStyleBackColor = true;
            this.ShapeButton.Click += new System.EventHandler(this.ShapeButton_Click);
            // 
            // menuStripUP
            // 
            this.menuStripUP.BackColor = System.Drawing.SystemColors.GrayText;
            this.menuStripUP.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStripUP.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripUP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripUP_FILE});
            this.menuStripUP.Location = new System.Drawing.Point(0, 0);
            this.menuStripUP.Name = "menuStripUP";
            this.menuStripUP.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStripUP.Size = new System.Drawing.Size(1456, 42);
            this.menuStripUP.TabIndex = 1;
            this.menuStripUP.Text = "menuStrip1";
            // 
            // menuStripUP_FILE
            // 
            this.menuStripUP_FILE.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.menuStripUP_FILE.Name = "menuStripUP_FILE";
            this.menuStripUP_FILE.Size = new System.Drawing.Size(71, 36);
            this.menuStripUP_FILE.Text = "FIle";
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
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(100, 111);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1337, 729);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // contextMenuStripBaseFigure
            // 
            this.contextMenuStripBaseFigure.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripBaseFigure.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LineToolStripMenuItem,
            this.rectangleToolStripMenuItem,
            this.PolygonToolStripMenuItem,
            this.EllipsToolStripMenuItem,
            this.BrokenLineToolStripMenuItem});
            this.contextMenuStripBaseFigure.Name = "contextMenuStripBaseFigure";
            this.contextMenuStripBaseFigure.Size = new System.Drawing.Size(215, 194);
            // 
            // LineToolStripMenuItem
            // 
            this.LineToolStripMenuItem.Name = "LineToolStripMenuItem";
            this.LineToolStripMenuItem.Size = new System.Drawing.Size(214, 38);
            this.LineToolStripMenuItem.Text = "Line";
            this.LineToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // rectangleToolStripMenuItem
            // 
            this.rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            this.rectangleToolStripMenuItem.Size = new System.Drawing.Size(214, 38);
            this.rectangleToolStripMenuItem.Text = "Rectangle";
            this.rectangleToolStripMenuItem.Click += new System.EventHandler(this.rectangleToolStripMenuItem_Click);
            // 
            // PolygonToolStripMenuItem
            // 
            this.PolygonToolStripMenuItem.Name = "PolygonToolStripMenuItem";
            this.PolygonToolStripMenuItem.Size = new System.Drawing.Size(214, 38);
            this.PolygonToolStripMenuItem.Text = "Polygon";
            this.PolygonToolStripMenuItem.Click += new System.EventHandler(this.PolygonToolStripMenuItem_Click);
            // 
            // EllipsToolStripMenuItem
            // 
            this.EllipsToolStripMenuItem.Name = "EllipsToolStripMenuItem";
            this.EllipsToolStripMenuItem.Size = new System.Drawing.Size(214, 38);
            this.EllipsToolStripMenuItem.Text = "Ellips";
            this.EllipsToolStripMenuItem.Click += new System.EventHandler(this.EllipsToolStripMenuItem_Click);
            // 
            // BrokenLineToolStripMenuItem
            // 
            this.BrokenLineToolStripMenuItem.Name = "BrokenLineToolStripMenuItem";
            this.BrokenLineToolStripMenuItem.Size = new System.Drawing.Size(214, 38);
            this.BrokenLineToolStripMenuItem.Text = "Broken Line";
            this.BrokenLineToolStripMenuItem.Click += new System.EventHandler(this.BrokenLineToolStripMenuItem_Click);
            // 
            // ColorButton
            // 
            this.ColorButton.Location = new System.Drawing.Point(13, 605);
            this.ColorButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ColorButton.Name = "ColorButton";
            this.ColorButton.Size = new System.Drawing.Size(64, 59);
            this.ColorButton.TabIndex = 3;
            this.ColorButton.UseVisualStyleBackColor = true;
            this.ColorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1456, 858);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStripUP);
            this.MainMenuStrip = this.menuStripUP;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Paint";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.menuStripUP.ResumeLayout(false);
            this.menuStripUP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStripBaseFigure.ResumeLayout(false);
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripBaseFigure;
        private System.Windows.Forms.ToolStripMenuItem LineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PolygonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EllipsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BrokenLineToolStripMenuItem;
        private System.Windows.Forms.Button ShapeButton;
        private System.Windows.Forms.ColorDialog colorDialogPen;
        private System.Windows.Forms.Button ColorButton;
    }
}

