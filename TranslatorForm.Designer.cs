namespace Traductor_de_Subtitulos
{
    partial class TranslatorForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TranslatorForm));
            this.openFileButton = new System.Windows.Forms.Button();
            this.saveFileGroupBox = new System.Windows.Forms.GroupBox();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.savePathTextbox = new System.Windows.Forms.TextBox();
            this.optionGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label_check = new System.Windows.Forms.CheckBox();
            this.textCommentGroupBox = new System.Windows.Forms.GroupBox();
            this.comment_original = new System.Windows.Forms.RadioButton();
            this.comment_Translate = new System.Windows.Forms.RadioButton();
            this.comment_check = new System.Windows.Forms.CheckBox();
            this.translateViewText = new System.Windows.Forms.TextBox();
            this.fileData = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lineas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Directorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.translateButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.translateCounterLabel = new System.Windows.Forms.Label();
            this.infoLabelCounter = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.translateCounterLabelPercent = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.infoLabelProgress = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.saveFileGroupBox.SuspendLayout();
            this.optionGroupBox.SuspendLayout();
            this.textCommentGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileData)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(134, 12);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(129, 58);
            this.openFileButton.TabIndex = 3;
            this.openFileButton.Text = "Abrir Archivo";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_click);
            // 
            // saveFileGroupBox
            // 
            this.saveFileGroupBox.Controls.Add(this.saveFileButton);
            this.saveFileGroupBox.Controls.Add(this.savePathTextbox);
            this.saveFileGroupBox.Location = new System.Drawing.Point(12, 78);
            this.saveFileGroupBox.Name = "saveFileGroupBox";
            this.saveFileGroupBox.Size = new System.Drawing.Size(622, 45);
            this.saveFileGroupBox.TabIndex = 4;
            this.saveFileGroupBox.TabStop = false;
            this.saveFileGroupBox.Text = "Destino:";
            // 
            // saveFileButton
            // 
            this.saveFileButton.Location = new System.Drawing.Point(569, 17);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(40, 22);
            this.saveFileButton.TabIndex = 1;
            this.saveFileButton.Text = "...";
            this.saveFileButton.UseVisualStyleBackColor = true;
            this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_event);
            // 
            // savePathTextbox
            // 
            this.savePathTextbox.Location = new System.Drawing.Point(6, 17);
            this.savePathTextbox.Name = "savePathTextbox";
            this.savePathTextbox.Size = new System.Drawing.Size(555, 20);
            this.savePathTextbox.TabIndex = 0;
            // 
            // optionGroupBox
            // 
            this.optionGroupBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.optionGroupBox.Controls.Add(this.label2);
            this.optionGroupBox.Controls.Add(this.label1);
            this.optionGroupBox.Controls.Add(this.comboBox2);
            this.optionGroupBox.Controls.Add(this.comboBox1);
            this.optionGroupBox.Controls.Add(this.label_check);
            this.optionGroupBox.Controls.Add(this.textCommentGroupBox);
            this.optionGroupBox.Controls.Add(this.comment_check);
            this.optionGroupBox.Location = new System.Drawing.Point(12, 129);
            this.optionGroupBox.Name = "optionGroupBox";
            this.optionGroupBox.Size = new System.Drawing.Size(243, 221);
            this.optionGroupBox.TabIndex = 7;
            this.optionGroupBox.TabStop = false;
            this.optionGroupBox.Text = "Opciones";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "A:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "De:";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Ingles",
            "Español",
            "Francés",
            "Italiano",
            "Japonés",
            "Chino"});
            this.comboBox2.Location = new System.Drawing.Point(136, 173);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(95, 21);
            this.comboBox2.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Ingles",
            "Español",
            "Francés",
            "Italiano",
            "Japonés",
            "Chino"});
            this.comboBox1.Location = new System.Drawing.Point(16, 173);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(95, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // label_check
            // 
            this.label_check.AutoSize = true;
            this.label_check.Location = new System.Drawing.Point(15, 19);
            this.label_check.Name = "label_check";
            this.label_check.Size = new System.Drawing.Size(109, 17);
            this.label_check.TabIndex = 2;
            this.label_check.Text = "Eliminar Etiquetas";
            this.label_check.UseVisualStyleBackColor = true;
            // 
            // textCommentGroupBox
            // 
            this.textCommentGroupBox.Controls.Add(this.comment_original);
            this.textCommentGroupBox.Controls.Add(this.comment_Translate);
            this.textCommentGroupBox.Location = new System.Drawing.Point(16, 67);
            this.textCommentGroupBox.Name = "textCommentGroupBox";
            this.textCommentGroupBox.Size = new System.Drawing.Size(215, 77);
            this.textCommentGroupBox.TabIndex = 1;
            this.textCommentGroupBox.TabStop = false;
            // 
            // comment_original
            // 
            this.comment_original.AutoSize = true;
            this.comment_original.Checked = true;
            this.comment_original.Location = new System.Drawing.Point(6, 42);
            this.comment_original.Name = "comment_original";
            this.comment_original.Size = new System.Drawing.Size(144, 17);
            this.comment_original.TabIndex = 1;
            this.comment_original.TabStop = true;
            this.comment_original.Text = "Texto original comentado";
            this.comment_original.UseVisualStyleBackColor = true;
            // 
            // comment_Translate
            // 
            this.comment_Translate.AutoSize = true;
            this.comment_Translate.Location = new System.Drawing.Point(6, 19);
            this.comment_Translate.Name = "comment_Translate";
            this.comment_Translate.Size = new System.Drawing.Size(135, 17);
            this.comment_Translate.TabIndex = 0;
            this.comment_Translate.Text = "Traduccion comentada";
            this.comment_Translate.UseVisualStyleBackColor = true;
            // 
            // comment_check
            // 
            this.comment_check.AutoSize = true;
            this.comment_check.Checked = true;
            this.comment_check.CheckState = System.Windows.Forms.CheckState.Checked;
            this.comment_check.Location = new System.Drawing.Point(15, 53);
            this.comment_check.Name = "comment_check";
            this.comment_check.Size = new System.Drawing.Size(128, 17);
            this.comment_check.TabIndex = 0;
            this.comment_check.Text = "Comentar Traduccion";
            this.comment_check.UseVisualStyleBackColor = true;
            this.comment_check.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // translateViewText
            // 
            this.translateViewText.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.translateViewText.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.translateViewText.Location = new System.Drawing.Point(261, 129);
            this.translateViewText.Multiline = true;
            this.translateViewText.Name = "translateViewText";
            this.translateViewText.ReadOnly = true;
            this.translateViewText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.translateViewText.Size = new System.Drawing.Size(373, 221);
            this.translateViewText.TabIndex = 8;
            // 
            // fileData
            // 
            this.fileData.AllowUserToDeleteRows = false;
            this.fileData.AllowUserToResizeRows = false;
            this.fileData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.fileData.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.fileData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fileData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.fileData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fileData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.fileData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fileData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Lineas,
            this.Directorio});
            this.fileData.Cursor = System.Windows.Forms.Cursors.Default;
            this.fileData.EnableHeadersVisualStyles = false;
            this.fileData.GridColor = System.Drawing.SystemColors.ControlLight;
            this.fileData.Location = new System.Drawing.Point(269, 12);
            this.fileData.MultiSelect = false;
            this.fileData.Name = "fileData";
            this.fileData.ReadOnly = true;
            this.fileData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.fileData.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.fileData.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.fileData.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.fileData.ShowCellErrors = false;
            this.fileData.ShowCellToolTips = false;
            this.fileData.ShowEditingIcon = false;
            this.fileData.ShowRowErrors = false;
            this.fileData.Size = new System.Drawing.Size(366, 58);
            this.fileData.TabIndex = 9;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Lineas
            // 
            this.Lineas.HeaderText = "Lineas";
            this.Lineas.Name = "Lineas";
            this.Lineas.ReadOnly = true;
            // 
            // Directorio
            // 
            this.Directorio.HeaderText = "Directorio";
            this.Directorio.Name = "Directorio";
            this.Directorio.ReadOnly = true;
            // 
            // translateButton
            // 
            this.translateButton.Location = new System.Drawing.Point(60, 3);
            this.translateButton.Name = "translateButton";
            this.translateButton.Size = new System.Drawing.Size(128, 26);
            this.translateButton.TabIndex = 10;
            this.translateButton.Text = "Traducir";
            this.translateButton.UseVisualStyleBackColor = true;
            this.translateButton.Click += new System.EventHandler(this.translateButton_event);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.translateCounterLabel);
            this.panel1.Controls.Add(this.infoLabelCounter);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.translateCounterLabelPercent);
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Controls.Add(this.infoLabelProgress);
            this.panel1.Controls.Add(this.translateButton);
            this.panel1.Location = new System.Drawing.Point(-2, 356);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 32);
            this.panel1.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Traductor_de_Subtitulos.Properties.Resources.tenor;
            this.pictureBox1.Location = new System.Drawing.Point(608, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(254, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(3, 32);
            this.panel2.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Location = new System.Drawing.Point(595, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(3, 32);
            this.panel4.TabIndex = 15;
            // 
            // translateCounterLabel
            // 
            this.translateCounterLabel.AutoSize = true;
            this.translateCounterLabel.Location = new System.Drawing.Point(561, 10);
            this.translateCounterLabel.Name = "translateCounterLabel";
            this.translateCounterLabel.Size = new System.Drawing.Size(13, 13);
            this.translateCounterLabel.TabIndex = 16;
            this.translateCounterLabel.Text = "0";
            // 
            // infoLabelCounter
            // 
            this.infoLabelCounter.AutoSize = true;
            this.infoLabelCounter.Location = new System.Drawing.Point(458, 10);
            this.infoLabelCounter.Name = "infoLabelCounter";
            this.infoLabelCounter.Size = new System.Drawing.Size(97, 13);
            this.infoLabelCounter.TabIndex = 15;
            this.infoLabelCounter.Text = "Lineas Traducidas:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Location = new System.Drawing.Point(453, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(3, 32);
            this.panel3.TabIndex = 14;
            // 
            // translateCounterLabelPercent
            // 
            this.translateCounterLabelPercent.AutoSize = true;
            this.translateCounterLabelPercent.Location = new System.Drawing.Point(422, 10);
            this.translateCounterLabelPercent.Name = "translateCounterLabelPercent";
            this.translateCounterLabelPercent.Size = new System.Drawing.Size(21, 13);
            this.translateCounterLabelPercent.TabIndex = 13;
            this.translateCounterLabelPercent.Text = "0%";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(316, 6);
            this.progressBar.Minimum = 1;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 23);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 12;
            this.progressBar.Value = 1;
            // 
            // infoLabelProgress
            // 
            this.infoLabelProgress.AutoSize = true;
            this.infoLabelProgress.Location = new System.Drawing.Point(258, 10);
            this.infoLabelProgress.Name = "infoLabelProgress";
            this.infoLabelProgress.Size = new System.Drawing.Size(52, 13);
            this.infoLabelProgress.TabIndex = 11;
            this.infoLabelProgress.Text = "Progreso:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Traductor_de_Subtitulos.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(22, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(86, 73);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // TranslatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 387);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.fileData);
            this.Controls.Add(this.translateViewText);
            this.Controls.Add(this.optionGroupBox);
            this.Controls.Add(this.saveFileGroupBox);
            this.Controls.Add(this.openFileButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(663, 426);
            this.MinimumSize = new System.Drawing.Size(663, 426);
            this.Name = "TranslatorForm";
            this.Text = "SubTranslate (Alpha V 0.1.0)";
            this.Load += new System.EventHandler(this.TranslatorForm_Load);
            this.saveFileGroupBox.ResumeLayout(false);
            this.saveFileGroupBox.PerformLayout();
            this.optionGroupBox.ResumeLayout(false);
            this.optionGroupBox.PerformLayout();
            this.textCommentGroupBox.ResumeLayout(false);
            this.textCommentGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.GroupBox saveFileGroupBox;
        private System.Windows.Forms.Button saveFileButton;
        private System.Windows.Forms.TextBox savePathTextbox;
        private System.Windows.Forms.GroupBox optionGroupBox;
        private System.Windows.Forms.CheckBox label_check;
        private System.Windows.Forms.GroupBox textCommentGroupBox;
        private System.Windows.Forms.RadioButton comment_original;
        private System.Windows.Forms.RadioButton comment_Translate;
        private System.Windows.Forms.CheckBox comment_check;
        private System.Windows.Forms.DataGridView fileData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lineas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Directorio;
        private System.Windows.Forms.Button translateButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label translateCounterLabelPercent;
        private System.Windows.Forms.Label infoLabelProgress;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label infoLabelCounter;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.TextBox translateViewText;
        public System.Windows.Forms.ProgressBar progressBar;
        public System.Windows.Forms.Label translateCounterLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

