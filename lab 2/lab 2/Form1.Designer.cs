
namespace lab_2
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
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listBoxPC = new System.Windows.Forms.ListBox();
            this.buttonRemovePC = new System.Windows.Forms.Button();
            this.buttonAddPC = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.listBoxNPC = new System.Windows.Forms.ListBox();
            this.buttonRemoveNPC = new System.Windows.Forms.Button();
            this.buttonAddNPC = new System.Windows.Forms.Button();
            this.textBoxHealth = new System.Windows.Forms.MaskedTextBox();
            this.textBoxAttribute2 = new System.Windows.Forms.MaskedTextBox();
            this.textBoxAttribute1 = new System.Windows.Forms.MaskedTextBox();
            this.textBoxName = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridParams = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxFunctions = new System.Windows.Forms.ComboBox();
            this.buttonCall = new System.Windows.Forms.Button();
            this.labelAttribute2 = new System.Windows.Forms.Label();
            this.labelAttribute1 = new System.Windows.Forms.Label();
            this.textBoxMessage = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridParams)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.splitContainerMain.IsSplitterFixed = true;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.textBoxHealth);
            this.splitContainerMain.Panel2.Controls.Add(this.textBoxAttribute2);
            this.splitContainerMain.Panel2.Controls.Add(this.textBoxAttribute1);
            this.splitContainerMain.Panel2.Controls.Add(this.textBoxName);
            this.splitContainerMain.Panel2.Controls.Add(this.groupBox1);
            this.splitContainerMain.Panel2.Controls.Add(this.labelAttribute2);
            this.splitContainerMain.Panel2.Controls.Add(this.labelAttribute1);
            this.splitContainerMain.Panel2.Controls.Add(this.textBoxMessage);
            this.splitContainerMain.Panel2.Controls.Add(this.label2);
            this.splitContainerMain.Panel2.Controls.Add(this.label1);
            this.splitContainerMain.Size = new System.Drawing.Size(927, 546);
            this.splitContainerMain.SplitterDistance = 278;
            this.splitContainerMain.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(278, 546);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(270, 520);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Игровой персонаж";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listBoxPC);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.buttonRemovePC);
            this.splitContainer2.Panel2.Controls.Add(this.buttonAddPC);
            this.splitContainer2.Size = new System.Drawing.Size(264, 514);
            this.splitContainer2.SplitterDistance = 478;
            this.splitContainer2.TabIndex = 1;
            // 
            // listBoxPC
            // 
            this.listBoxPC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxPC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxPC.FormattingEnabled = true;
            this.listBoxPC.ItemHeight = 16;
            this.listBoxPC.Location = new System.Drawing.Point(0, 0);
            this.listBoxPC.Name = "listBoxPC";
            this.listBoxPC.Size = new System.Drawing.Size(264, 478);
            this.listBoxPC.TabIndex = 1;
            this.listBoxPC.SelectedIndexChanged += new System.EventHandler(this.listBoxPC_SelectedIndexChanged);
            this.listBoxPC.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxPC_MouseDown);
            // 
            // buttonRemovePC
            // 
            this.buttonRemovePC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemovePC.Location = new System.Drawing.Point(84, 4);
            this.buttonRemovePC.Name = "buttonRemovePC";
            this.buttonRemovePC.Size = new System.Drawing.Size(75, 23);
            this.buttonRemovePC.TabIndex = 1;
            this.buttonRemovePC.Text = "Удалить";
            this.buttonRemovePC.UseVisualStyleBackColor = true;
            this.buttonRemovePC.Click += new System.EventHandler(this.buttonRemovePC_Click);
            // 
            // buttonAddPC
            // 
            this.buttonAddPC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddPC.Location = new System.Drawing.Point(3, 4);
            this.buttonAddPC.Name = "buttonAddPC";
            this.buttonAddPC.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonAddPC.Size = new System.Drawing.Size(75, 23);
            this.buttonAddPC.TabIndex = 0;
            this.buttonAddPC.Text = "Добавить";
            this.buttonAddPC.UseVisualStyleBackColor = true;
            this.buttonAddPC.Click += new System.EventHandler(this.buttonAddPC_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(270, 520);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Неигровой персонаж";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.listBoxNPC);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.buttonRemoveNPC);
            this.splitContainer3.Panel2.Controls.Add(this.buttonAddNPC);
            this.splitContainer3.Size = new System.Drawing.Size(264, 514);
            this.splitContainer3.SplitterDistance = 478;
            this.splitContainer3.TabIndex = 2;
            // 
            // listBoxNPC
            // 
            this.listBoxNPC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxNPC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxNPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxNPC.FormattingEnabled = true;
            this.listBoxNPC.ItemHeight = 16;
            this.listBoxNPC.Location = new System.Drawing.Point(0, 0);
            this.listBoxNPC.Name = "listBoxNPC";
            this.listBoxNPC.Size = new System.Drawing.Size(264, 478);
            this.listBoxNPC.TabIndex = 1;
            this.listBoxNPC.SelectedIndexChanged += new System.EventHandler(this.listBoxNPC_SelectedIndexChanged);
            this.listBoxNPC.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxNPC_MouseDown);
            // 
            // buttonRemoveNPC
            // 
            this.buttonRemoveNPC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemoveNPC.Location = new System.Drawing.Point(84, 4);
            this.buttonRemoveNPC.Name = "buttonRemoveNPC";
            this.buttonRemoveNPC.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveNPC.TabIndex = 1;
            this.buttonRemoveNPC.Text = "Удалить";
            this.buttonRemoveNPC.UseVisualStyleBackColor = true;
            this.buttonRemoveNPC.Click += new System.EventHandler(this.buttonRemoveNPC_Click);
            // 
            // buttonAddNPC
            // 
            this.buttonAddNPC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddNPC.Location = new System.Drawing.Point(3, 4);
            this.buttonAddNPC.Name = "buttonAddNPC";
            this.buttonAddNPC.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonAddNPC.Size = new System.Drawing.Size(75, 23);
            this.buttonAddNPC.TabIndex = 0;
            this.buttonAddNPC.Text = "Добавить";
            this.buttonAddNPC.UseVisualStyleBackColor = true;
            this.buttonAddNPC.Click += new System.EventHandler(this.buttonAddNPC_Click);
            // 
            // textBoxHealth
            // 
            this.textBoxHealth.Location = new System.Drawing.Point(385, 12);
            this.textBoxHealth.Name = "textBoxHealth";
            this.textBoxHealth.Size = new System.Drawing.Size(88, 20);
            this.textBoxHealth.TabIndex = 7;
            this.textBoxHealth.TextChanged += new System.EventHandler(this.textBoxHealth_TextChanged);
            // 
            // textBoxAttribute2
            // 
            this.textBoxAttribute2.Location = new System.Drawing.Point(73, 68);
            this.textBoxAttribute2.Name = "textBoxAttribute2";
            this.textBoxAttribute2.Size = new System.Drawing.Size(123, 20);
            this.textBoxAttribute2.TabIndex = 7;
            this.textBoxAttribute2.TextChanged += new System.EventHandler(this.textBoxAttribute2_TextChanged);
            // 
            // textBoxAttribute1
            // 
            this.textBoxAttribute1.Location = new System.Drawing.Point(73, 42);
            this.textBoxAttribute1.Name = "textBoxAttribute1";
            this.textBoxAttribute1.Size = new System.Drawing.Size(123, 20);
            this.textBoxAttribute1.TabIndex = 7;
            this.textBoxAttribute1.TextChanged += new System.EventHandler(this.textBoxAttribute1_TextChanged);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(73, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(232, 20);
            this.textBoxName.TabIndex = 7;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            this.textBoxName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxName_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridParams);
            this.groupBox1.Controls.Add(this.comboBoxFunctions);
            this.groupBox1.Controls.Add(this.buttonCall);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(645, 291);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Функции";
            // 
            // dataGridParams
            // 
            this.dataGridParams.AllowUserToAddRows = false;
            this.dataGridParams.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridParams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridParams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnValue});
            this.dataGridParams.GridColor = System.Drawing.SystemColors.MenuHighlight;
            this.dataGridParams.Location = new System.Drawing.Point(6, 46);
            this.dataGridParams.Name = "dataGridParams";
            this.dataGridParams.RowHeadersVisible = false;
            this.dataGridParams.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridParams.Size = new System.Drawing.Size(300, 150);
            this.dataGridParams.TabIndex = 8;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Параметр";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.Width = 150;
            // 
            // ColumnValue
            // 
            this.ColumnValue.HeaderText = "Значение";
            this.ColumnValue.Name = "ColumnValue";
            this.ColumnValue.Width = 150;
            // 
            // comboBoxFunctions
            // 
            this.comboBoxFunctions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFunctions.FormattingEnabled = true;
            this.comboBoxFunctions.Location = new System.Drawing.Point(6, 19);
            this.comboBoxFunctions.Name = "comboBoxFunctions";
            this.comboBoxFunctions.Size = new System.Drawing.Size(300, 21);
            this.comboBoxFunctions.TabIndex = 4;
            this.comboBoxFunctions.SelectedIndexChanged += new System.EventHandler(this.comboBoxFunctions_SelectedIndexChanged);
            // 
            // buttonCall
            // 
            this.buttonCall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCall.Location = new System.Drawing.Point(6, 262);
            this.buttonCall.Name = "buttonCall";
            this.buttonCall.Size = new System.Drawing.Size(75, 23);
            this.buttonCall.TabIndex = 3;
            this.buttonCall.Text = "Call";
            this.buttonCall.UseVisualStyleBackColor = true;
            this.buttonCall.Click += new System.EventHandler(this.buttonCall_Click);
            // 
            // labelAttribute2
            // 
            this.labelAttribute2.AutoSize = true;
            this.labelAttribute2.Location = new System.Drawing.Point(5, 71);
            this.labelAttribute2.Name = "labelAttribute2";
            this.labelAttribute2.Size = new System.Drawing.Size(52, 13);
            this.labelAttribute2.TabIndex = 2;
            this.labelAttribute2.Text = "Attribute2";
            // 
            // labelAttribute1
            // 
            this.labelAttribute1.AutoSize = true;
            this.labelAttribute1.Location = new System.Drawing.Point(5, 45);
            this.labelAttribute1.Name = "labelAttribute1";
            this.labelAttribute1.Size = new System.Drawing.Size(52, 13);
            this.labelAttribute1.TabIndex = 2;
            this.labelAttribute1.Text = "Attribute1";
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxMessage.Location = new System.Drawing.Point(0, 418);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.ReadOnly = true;
            this.textBoxMessage.Size = new System.Drawing.Size(645, 128);
            this.textBoxMessage.TabIndex = 1;
            this.textBoxMessage.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(311, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Health";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 546);
            this.Controls.Add(this.splitContainerMain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridParams)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox textBoxMessage;
        private System.Windows.Forms.Label labelAttribute2;
        private System.Windows.Forms.Label labelAttribute1;
        private System.Windows.Forms.Button buttonCall;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxFunctions;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox listBoxPC;
        private System.Windows.Forms.Button buttonRemovePC;
        private System.Windows.Forms.Button buttonAddPC;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListBox listBoxNPC;
        private System.Windows.Forms.Button buttonRemoveNPC;
        private System.Windows.Forms.Button buttonAddNPC;
        private System.Windows.Forms.MaskedTextBox textBoxHealth;
        private System.Windows.Forms.MaskedTextBox textBoxAttribute2;
        private System.Windows.Forms.MaskedTextBox textBoxAttribute1;
        private System.Windows.Forms.MaskedTextBox textBoxName;
        private System.Windows.Forms.DataGridView dataGridParams;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
    }
}

