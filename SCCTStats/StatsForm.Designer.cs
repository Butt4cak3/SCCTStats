namespace SCCTStats
{
    partial class StatsForm
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
            Label label1;
            Label label2;
            Label label3;
            tableLayoutPanel1 = new TableLayoutPanel();
            timerText = new Label();
            movementSpeedText = new Label();
            alarmsText = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 0;
            label1.Text = "Timer";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 20);
            label2.Name = "label2";
            label2.Size = new Size(99, 15);
            label2.TabIndex = 2;
            label2.Text = "Movement speed";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 40);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 4;
            label3.Text = "Alarms";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(timerText, 1, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(movementSpeedText, 1, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(alarmsText, 1, 2);
            tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(480, 60);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // timerText
            // 
            timerText.AutoSize = true;
            timerText.Location = new Point(243, 0);
            timerText.Name = "timerText";
            timerText.Size = new Size(13, 15);
            timerText.TabIndex = 1;
            timerText.Text = "0";
            // 
            // movementSpeedText
            // 
            movementSpeedText.AutoSize = true;
            movementSpeedText.Location = new Point(243, 20);
            movementSpeedText.Name = "movementSpeedText";
            movementSpeedText.Size = new Size(36, 15);
            movementSpeedText.TabIndex = 3;
            movementSpeedText.Text = "None";
            // 
            // alarmsText
            // 
            alarmsText.AutoSize = true;
            alarmsText.Location = new Point(243, 40);
            alarmsText.Name = "alarmsText";
            alarmsText.Size = new Size(13, 15);
            alarmsText.TabIndex = 5;
            alarmsText.Text = "0";
            // 
            // StatsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 388);
            Controls.Add(tableLayoutPanel1);
            Name = "StatsForm";
            Text = "SCCTStats";
            TopMost = true;
            FormClosing += onFormClosing;
            Shown += onFormShown;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label timerText;
        private Label movementSpeedText;
        private Label label3;
        private Label alarmsText;
    }
}