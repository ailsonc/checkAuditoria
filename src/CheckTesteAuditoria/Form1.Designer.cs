namespace CheckTesteAuditoria
{
    partial class Form1
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
            this.lbTitleChargeRemaining = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Descrição = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lbTitleNS = new System.Windows.Forms.Label();
            this.lbSerialNumber = new System.Windows.Forms.Label();
            this.lbtLinha = new System.Windows.Forms.Label();
            this.lbLine = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbChargeRemaining = new System.Windows.Forms.Label();
            this.lbModel = new System.Windows.Forms.Label();
            this.lbtmodel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lb_version = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_title = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.bt_close = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_close)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitleChargeRemaining
            // 
            this.lbTitleChargeRemaining.AutoSize = true;
            this.lbTitleChargeRemaining.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitleChargeRemaining.Location = new System.Drawing.Point(21, 137);
            this.lbTitleChargeRemaining.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTitleChargeRemaining.Name = "lbTitleChargeRemaining";
            this.lbTitleChargeRemaining.Size = new System.Drawing.Size(177, 36);
            this.lbTitleChargeRemaining.TabIndex = 1;
            this.lbTitleChargeRemaining.Text = "Carga total:";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Descrição,
            this.Status});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.LabelWrap = false;
            this.listView1.Location = new System.Drawing.Point(27, 194);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(553, 561);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Descrição
            // 
            this.Descrição.Text = "Descrição";
            this.Descrição.Width = 251;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Status.Width = 115;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(602, 301);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(262, 97);
            this.button1.TabIndex = 2;
            this.button1.Text = "Enviar Log";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.AutoEllipsis = true;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(220)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Window;
            this.button2.Location = new System.Drawing.Point(602, 194);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(262, 97);
            this.button2.TabIndex = 3;
            this.button2.Text = "Executar Testes";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(602, 658);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(262, 97);
            this.button3.TabIndex = 4;
            this.button3.Text = "Desligar Produto";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lbTitleNS
            // 
            this.lbTitleNS.AutoSize = true;
            this.lbTitleNS.Font = new System.Drawing.Font("Arial", 16F);
            this.lbTitleNS.Location = new System.Drawing.Point(21, 5);
            this.lbTitleNS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTitleNS.Name = "lbTitleNS";
            this.lbTitleNS.Size = new System.Drawing.Size(262, 36);
            this.lbTitleNS.TabIndex = 5;
            this.lbTitleNS.Text = "Número de Série:";
            // 
            // lbSerialNumber
            // 
            this.lbSerialNumber.AutoSize = true;
            this.lbSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lbSerialNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(220)))));
            this.lbSerialNumber.Location = new System.Drawing.Point(291, 4);
            this.lbSerialNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSerialNumber.Name = "lbSerialNumber";
            this.lbSerialNumber.Size = new System.Drawing.Size(283, 37);
            this.lbSerialNumber.TabIndex = 6;
            this.lbSerialNumber.Text = "00000000000000";
            // 
            // lbtLinha
            // 
            this.lbtLinha.AutoSize = true;
            this.lbtLinha.Font = new System.Drawing.Font("Arial", 16F);
            this.lbtLinha.Location = new System.Drawing.Point(20, 49);
            this.lbtLinha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbtLinha.Name = "lbtLinha";
            this.lbtLinha.Size = new System.Drawing.Size(102, 36);
            this.lbtLinha.TabIndex = 9;
            this.lbtLinha.Text = "Linha:";
            // 
            // lbLine
            // 
            this.lbLine.AutoSize = true;
            this.lbLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lbLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(220)))));
            this.lbLine.Location = new System.Drawing.Point(130, 48);
            this.lbLine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLine.Name = "lbLine";
            this.lbLine.Size = new System.Drawing.Size(36, 37);
            this.lbLine.TabIndex = 10;
            this.lbLine.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lbChargeRemaining);
            this.panel1.Controls.Add(this.lbModel);
            this.panel1.Controls.Add(this.lbtmodel);
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.lbLine);
            this.panel1.Controls.Add(this.lbtLinha);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lbSerialNumber);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.lbTitleNS);
            this.panel1.Controls.Add(this.lbTitleChargeRemaining);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Location = new System.Drawing.Point(0, 80);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(891, 783);
            this.panel1.TabIndex = 11;
            // 
            // lbChargeRemaining
            // 
            this.lbChargeRemaining.AutoSize = true;
            this.lbChargeRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lbChargeRemaining.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(220)))));
            this.lbChargeRemaining.Location = new System.Drawing.Point(206, 137);
            this.lbChargeRemaining.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbChargeRemaining.Name = "lbChargeRemaining";
            this.lbChargeRemaining.Size = new System.Drawing.Size(36, 37);
            this.lbChargeRemaining.TabIndex = 13;
            this.lbChargeRemaining.Text = "0";
            // 
            // lbModel
            // 
            this.lbModel.AutoSize = true;
            this.lbModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lbModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(220)))));
            this.lbModel.Location = new System.Drawing.Point(154, 92);
            this.lbModel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbModel.Name = "lbModel";
            this.lbModel.Size = new System.Drawing.Size(36, 37);
            this.lbModel.TabIndex = 12;
            this.lbModel.Text = "0";
            // 
            // lbtmodel
            // 
            this.lbtmodel.AutoSize = true;
            this.lbtmodel.Font = new System.Drawing.Font("Arial", 16F);
            this.lbtmodel.Location = new System.Drawing.Point(20, 93);
            this.lbtmodel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbtmodel.Name = "lbtmodel";
            this.lbtmodel.Size = new System.Drawing.Size(126, 36);
            this.lbtmodel.TabIndex = 11;
            this.lbtmodel.Text = "Modelo:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(220)))));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lb_version});
            this.statusStrip1.Location = new System.Drawing.Point(0, 860);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(891, 32);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lb_version
            // 
            this.lb_version.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(220)))));
            this.lb_version.ForeColor = System.Drawing.SystemColors.Window;
            this.lb_version.Name = "lb_version";
            this.lb_version.Size = new System.Drawing.Size(868, 25);
            this.lb_version.Spring = true;
            this.lb_version.Text = "Versão: 0";
            this.lb_version.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_title
            // 
            this.lb_title.AutoSize = true;
            this.lb_title.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_title.ForeColor = System.Drawing.Color.White;
            this.lb_title.Location = new System.Drawing.Point(74, 34);
            this.lb_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_title.Name = "lb_title";
            this.lb_title.Size = new System.Drawing.Size(231, 23);
            this.lb_title.TabIndex = 12;
            this.lb_title.Text = "Vallidação Auditoria 2024";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CheckTesteAuditoria.Properties.Resources.mb;
            this.pictureBox3.Location = new System.Drawing.Point(18, 18);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(51, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // bt_close
            // 
            this.bt_close.Image = global::CheckTesteAuditoria.Properties.Resources.close;
            this.bt_close.Location = new System.Drawing.Point(848, 18);
            this.bt_close.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(26, 40);
            this.bt_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bt_close.TabIndex = 14;
            this.bt_close.TabStop = false;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(891, 892);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.bt_close);
            this.Controls.Add(this.lb_title);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Vallidação Auditoria";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.button1_Click_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_close)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbTitleChargeRemaining;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Descrição;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lbTitleNS;
        private System.Windows.Forms.Label lbSerialNumber;
        private System.Windows.Forms.Label lbtLinha;
        private System.Windows.Forms.Label lbLine;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lb_version;
        private System.Windows.Forms.Label lb_title;
        private System.Windows.Forms.PictureBox bt_close;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lbModel;
        private System.Windows.Forms.Label lbtmodel;
        private System.Windows.Forms.Label lbChargeRemaining;
    }
}

