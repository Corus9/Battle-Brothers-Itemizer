namespace BattleBrothersItemizer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.newButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tacticalMapMainSpriteId = new System.Windows.Forms.TextBox();
            this.inventorySpriteBrowse = new System.Windows.Forms.Button();
            this.inventoryImagePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.bbrusherProjectPath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.entityName = new System.Windows.Forms.TextBox();
            this.restorePanel = new System.Windows.Forms.Panel();
            this.tacticalMapDamagedSpriteId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.restoreCheckbox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.entityType = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.entityList = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.restorePanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(3, 505);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(75, 23);
            this.newButton.TabIndex = 0;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(3, 505);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 1;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tactical map main sprite ID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tacticalMapMainSpriteId
            // 
            this.tacticalMapMainSpriteId.Location = new System.Drawing.Point(4, 69);
            this.tacticalMapMainSpriteId.Name = "tacticalMapMainSpriteId";
            this.tacticalMapMainSpriteId.Size = new System.Drawing.Size(200, 23);
            this.tacticalMapMainSpriteId.TabIndex = 3;
            // 
            // inventorySpriteBrowse
            // 
            this.inventorySpriteBrowse.Location = new System.Drawing.Point(203, 24);
            this.inventorySpriteBrowse.Name = "inventorySpriteBrowse";
            this.inventorySpriteBrowse.Size = new System.Drawing.Size(25, 25);
            this.inventorySpriteBrowse.TabIndex = 6;
            this.inventorySpriteBrowse.Text = "...";
            this.inventorySpriteBrowse.UseVisualStyleBackColor = true;
            this.inventorySpriteBrowse.Click += new System.EventHandler(this.button4_Click);
            // 
            // inventoryImagePath
            // 
            this.inventoryImagePath.Location = new System.Drawing.Point(3, 25);
            this.inventoryImagePath.Name = "inventoryImagePath";
            this.inventoryImagePath.Size = new System.Drawing.Size(200, 23);
            this.inventoryImagePath.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Iinventory image path";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.bbrusherProjectPath);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.entityName);
            this.panel1.Controls.Add(this.restorePanel);
            this.panel1.Controls.Add(this.restoreCheckbox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.entityType);
            this.panel1.Controls.Add(this.newButton);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 533);
            this.panel1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "Bbrusher project path";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(207, 30);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 25);
            this.button3.TabIndex = 8;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // bbrusherProjectPath
            // 
            this.bbrusherProjectPath.Location = new System.Drawing.Point(7, 31);
            this.bbrusherProjectPath.Name = "bbrusherProjectPath";
            this.bbrusherProjectPath.Size = new System.Drawing.Size(200, 23);
            this.bbrusherProjectPath.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "Name";
            // 
            // entityName
            // 
            this.entityName.Location = new System.Drawing.Point(7, 119);
            this.entityName.Name = "entityName";
            this.entityName.Size = new System.Drawing.Size(100, 23);
            this.entityName.TabIndex = 17;
            this.entityName.Text = "new_entity";
            // 
            // restorePanel
            // 
            this.restorePanel.Controls.Add(this.inventoryImagePath);
            this.restorePanel.Controls.Add(this.tacticalMapDamagedSpriteId);
            this.restorePanel.Controls.Add(this.inventorySpriteBrowse);
            this.restorePanel.Controls.Add(this.label5);
            this.restorePanel.Controls.Add(this.label2);
            this.restorePanel.Controls.Add(this.tacticalMapMainSpriteId);
            this.restorePanel.Controls.Add(this.label1);
            this.restorePanel.Enabled = false;
            this.restorePanel.Location = new System.Drawing.Point(-1, 299);
            this.restorePanel.Name = "restorePanel";
            this.restorePanel.Size = new System.Drawing.Size(456, 200);
            this.restorePanel.TabIndex = 10;
            // 
            // tacticalMapDamagedSpriteId
            // 
            this.tacticalMapDamagedSpriteId.Location = new System.Drawing.Point(4, 113);
            this.tacticalMapDamagedSpriteId.Name = "tacticalMapDamagedSpriteId";
            this.tacticalMapDamagedSpriteId.Size = new System.Drawing.Size(200, 23);
            this.tacticalMapDamagedSpriteId.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tactical map damaged sprite ID";
            // 
            // restoreCheckbox
            // 
            this.restoreCheckbox.AutoSize = true;
            this.restoreCheckbox.Location = new System.Drawing.Point(3, 274);
            this.restoreCheckbox.Name = "restoreCheckbox";
            this.restoreCheckbox.Size = new System.Drawing.Size(85, 19);
            this.restoreCheckbox.TabIndex = 15;
            this.restoreCheckbox.Text = "Copy From";
            this.restoreCheckbox.UseVisualStyleBackColor = true;
            this.restoreCheckbox.CheckedChanged += new System.EventHandler(this.restoreCheckbox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Type";
            // 
            // entityType
            // 
            this.entityType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.entityType.FormattingEnabled = true;
            this.entityType.Location = new System.Drawing.Point(7, 75);
            this.entityType.Name = "entityType";
            this.entityType.Size = new System.Drawing.Size(200, 23);
            this.entityType.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.entityList);
            this.panel2.Controls.Add(this.exportButton);
            this.panel2.Location = new System.Drawing.Point(474, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(314, 533);
            this.panel2.TabIndex = 9;
            // 
            // entityList
            // 
            this.entityList.FormattingEnabled = true;
            this.entityList.Location = new System.Drawing.Point(3, 3);
            this.entityList.Name = "entityList";
            this.entityList.Size = new System.Drawing.Size(121, 23);
            this.entityList.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 557);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.restorePanel.ResumeLayout(false);
            this.restorePanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button newButton;
        private Button exportButton;
        private Label label1;
        private TextBox tacticalMapMainSpriteId;
        private Button inventorySpriteBrowse;
        private TextBox inventoryImagePath;
        private Label label2;
        private Panel panel1;
        private Panel panel2;
        private Label label3;
        private ComboBox entityType;
        private CheckBox restoreCheckbox;
        private Panel restorePanel;
        private Label label7;
        private TextBox entityName;
        private ComboBox entityList;
        private Button button3;
        private TextBox bbrusherProjectPath;
        private Label label4;
        private Label label5;
        private TextBox tacticalMapDamagedSpriteId;
    }
}