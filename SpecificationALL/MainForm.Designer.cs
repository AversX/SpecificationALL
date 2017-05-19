namespace SpecificationPack
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.addSpec1Btn = new System.Windows.Forms.Button();
            this.formBtn = new System.Windows.Forms.Button();
            this.addSpec2Btn = new System.Windows.Forms.Button();
            this.addSpec3Btn = new System.Windows.Forms.Button();
            this.addSpec4Btn = new System.Windows.Forms.Button();
            this.specVladTBox = new System.Windows.Forms.TextBox();
            this.specAlexAvrTBox = new System.Windows.Forms.TextBox();
            this.specAlexTBox = new System.Windows.Forms.TextBox();
            this.specAndrTBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.clrBtn = new System.Windows.Forms.Button();
            this.colNameTBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SpecAlexHelukabel = new System.Windows.Forms.CheckBox();
            this.SpecAlexAvrHelukabel = new System.Windows.Forms.CheckBox();
            this.SpecAndrHelukabel = new System.Windows.Forms.CheckBox();
            this.SpecVladHelukabel = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Спецификация Алексея";
            // 
            // addSpec1Btn
            // 
            this.addSpec1Btn.Location = new System.Drawing.Point(197, 69);
            this.addSpec1Btn.Name = "addSpec1Btn";
            this.addSpec1Btn.Size = new System.Drawing.Size(99, 36);
            this.addSpec1Btn.TabIndex = 2;
            this.addSpec1Btn.Text = "Добавить спецификацию";
            this.addSpec1Btn.UseVisualStyleBackColor = true;
            this.addSpec1Btn.Click += new System.EventHandler(this.addSpec1Btn_Click);
            // 
            // formBtn
            // 
            this.formBtn.Location = new System.Drawing.Point(181, 501);
            this.formBtn.Name = "formBtn";
            this.formBtn.Size = new System.Drawing.Size(118, 34);
            this.formBtn.TabIndex = 3;
            this.formBtn.Text = "Сформировать";
            this.formBtn.UseVisualStyleBackColor = true;
            this.formBtn.Click += new System.EventHandler(this.formBtn_Click);
            // 
            // addSpec2Btn
            // 
            this.addSpec2Btn.Location = new System.Drawing.Point(200, 187);
            this.addSpec2Btn.Name = "addSpec2Btn";
            this.addSpec2Btn.Size = new System.Drawing.Size(99, 36);
            this.addSpec2Btn.TabIndex = 7;
            this.addSpec2Btn.Text = "Добавить спецификацию";
            this.addSpec2Btn.UseVisualStyleBackColor = true;
            this.addSpec2Btn.Click += new System.EventHandler(this.addSpec2Btn_Click);
            // 
            // addSpec3Btn
            // 
            this.addSpec3Btn.Location = new System.Drawing.Point(199, 302);
            this.addSpec3Btn.Name = "addSpec3Btn";
            this.addSpec3Btn.Size = new System.Drawing.Size(99, 36);
            this.addSpec3Btn.TabIndex = 7;
            this.addSpec3Btn.Text = "Добавить спецификацию";
            this.addSpec3Btn.UseVisualStyleBackColor = true;
            this.addSpec3Btn.Click += new System.EventHandler(this.addSpec3Btn_Click);
            // 
            // addSpec4Btn
            // 
            this.addSpec4Btn.Location = new System.Drawing.Point(200, 456);
            this.addSpec4Btn.Name = "addSpec4Btn";
            this.addSpec4Btn.Size = new System.Drawing.Size(99, 36);
            this.addSpec4Btn.TabIndex = 7;
            this.addSpec4Btn.Text = "Добавить спецификацию";
            this.addSpec4Btn.UseVisualStyleBackColor = true;
            this.addSpec4Btn.Click += new System.EventHandler(this.addSpec4Btn_Click);
            // 
            // specVladTBox
            // 
            this.specVladTBox.AllowDrop = true;
            this.specVladTBox.Location = new System.Drawing.Point(16, 412);
            this.specVladTBox.Multiline = true;
            this.specVladTBox.Name = "specVladTBox";
            this.specVladTBox.Size = new System.Drawing.Size(281, 38);
            this.specVladTBox.TabIndex = 8;
            this.specVladTBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.specVladTBox_DragDrop);
            this.specVladTBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.specVladTBox_DragEnter);
            // 
            // specAlexAvrTBox
            // 
            this.specAlexAvrTBox.AllowDrop = true;
            this.specAlexAvrTBox.Location = new System.Drawing.Point(16, 143);
            this.specAlexAvrTBox.Multiline = true;
            this.specAlexAvrTBox.Name = "specAlexAvrTBox";
            this.specAlexAvrTBox.Size = new System.Drawing.Size(281, 38);
            this.specAlexAvrTBox.TabIndex = 8;
            this.specAlexAvrTBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.specAlexAvrTBox_DragDrop);
            this.specAlexAvrTBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.specAlexAvrTBox_DragEnter);
            // 
            // specAlexTBox
            // 
            this.specAlexTBox.AllowDrop = true;
            this.specAlexTBox.Location = new System.Drawing.Point(13, 25);
            this.specAlexTBox.Multiline = true;
            this.specAlexTBox.Name = "specAlexTBox";
            this.specAlexTBox.Size = new System.Drawing.Size(281, 38);
            this.specAlexTBox.TabIndex = 8;
            this.specAlexTBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.specAlexTBox_DragDrop);
            this.specAlexTBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.specAlexTBox_DragEnter);
            // 
            // specAndrTBox
            // 
            this.specAndrTBox.AllowDrop = true;
            this.specAndrTBox.Location = new System.Drawing.Point(15, 258);
            this.specAndrTBox.Multiline = true;
            this.specAndrTBox.Name = "specAndrTBox";
            this.specAndrTBox.Size = new System.Drawing.Size(281, 38);
            this.specAndrTBox.TabIndex = 8;
            this.specAndrTBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.specAndrTBox_DragDrop);
            this.specAndrTBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.specAndrTBox_DragEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Спецификация Алексея(АВР)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Спецификация Андеря";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 396);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Спецификация Владимира";
            // 
            // clrBtn
            // 
            this.clrBtn.Location = new System.Drawing.Point(12, 499);
            this.clrBtn.Name = "clrBtn";
            this.clrBtn.Size = new System.Drawing.Size(99, 36);
            this.clrBtn.TabIndex = 5;
            this.clrBtn.Text = "Очистить";
            this.clrBtn.UseVisualStyleBackColor = true;
            this.clrBtn.Click += new System.EventHandler(this.clrBtn_Click);
            // 
            // colNameTBox
            // 
            this.colNameTBox.Location = new System.Drawing.Point(14, 318);
            this.colNameTBox.Name = "colNameTBox";
            this.colNameTBox.Size = new System.Drawing.Size(36, 20);
            this.colNameTBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 302);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Буква столбца (лат.)";
            // 
            // SpecAlexHelukabel
            // 
            this.SpecAlexHelukabel.AutoSize = true;
            this.SpecAlexHelukabel.Checked = true;
            this.SpecAlexHelukabel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SpecAlexHelukabel.Location = new System.Drawing.Point(12, 70);
            this.SpecAlexHelukabel.Name = "SpecAlexHelukabel";
            this.SpecAlexHelukabel.Size = new System.Drawing.Size(167, 17);
            this.SpecAlexHelukabel.TabIndex = 11;
            this.SpecAlexHelukabel.Text = "Домножать Helukabel на 10";
            this.SpecAlexHelukabel.UseVisualStyleBackColor = true;
            // 
            // SpecAlexAvrHelukabel
            // 
            this.SpecAlexAvrHelukabel.AutoSize = true;
            this.SpecAlexAvrHelukabel.Checked = true;
            this.SpecAlexAvrHelukabel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SpecAlexAvrHelukabel.Location = new System.Drawing.Point(12, 187);
            this.SpecAlexAvrHelukabel.Name = "SpecAlexAvrHelukabel";
            this.SpecAlexAvrHelukabel.Size = new System.Drawing.Size(167, 17);
            this.SpecAlexAvrHelukabel.TabIndex = 12;
            this.SpecAlexAvrHelukabel.Text = "Домножать Helukabel на 10";
            this.SpecAlexAvrHelukabel.UseVisualStyleBackColor = true;
            // 
            // SpecAndrHelukabel
            // 
            this.SpecAndrHelukabel.AutoSize = true;
            this.SpecAndrHelukabel.Location = new System.Drawing.Point(12, 355);
            this.SpecAndrHelukabel.Name = "SpecAndrHelukabel";
            this.SpecAndrHelukabel.Size = new System.Drawing.Size(167, 17);
            this.SpecAndrHelukabel.TabIndex = 13;
            this.SpecAndrHelukabel.Text = "Домножать Helukabel на 10";
            this.SpecAndrHelukabel.UseVisualStyleBackColor = true;
            // 
            // SpecVladHelukabel
            // 
            this.SpecVladHelukabel.AutoSize = true;
            this.SpecVladHelukabel.Location = new System.Drawing.Point(12, 456);
            this.SpecVladHelukabel.Name = "SpecVladHelukabel";
            this.SpecVladHelukabel.Size = new System.Drawing.Size(167, 17);
            this.SpecVladHelukabel.TabIndex = 14;
            this.SpecVladHelukabel.Text = "Домножать Helukabel на 10";
            this.SpecVladHelukabel.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 547);
            this.Controls.Add(this.SpecVladHelukabel);
            this.Controls.Add(this.SpecAndrHelukabel);
            this.Controls.Add(this.SpecAlexAvrHelukabel);
            this.Controls.Add(this.SpecAlexHelukabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.colNameTBox);
            this.Controls.Add(this.specAndrTBox);
            this.Controls.Add(this.specVladTBox);
            this.Controls.Add(this.specAlexAvrTBox);
            this.Controls.Add(this.specAlexTBox);
            this.Controls.Add(this.clrBtn);
            this.Controls.Add(this.addSpec4Btn);
            this.Controls.Add(this.addSpec3Btn);
            this.Controls.Add(this.addSpec2Btn);
            this.Controls.Add(this.formBtn);
            this.Controls.Add(this.addSpec1Btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Формирование общей спецификации";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addSpec1Btn;
        private System.Windows.Forms.Button formBtn;
        private System.Windows.Forms.Button addSpec2Btn;
        private System.Windows.Forms.Button addSpec3Btn;
        private System.Windows.Forms.Button addSpec4Btn;
        private System.Windows.Forms.TextBox specVladTBox;
        private System.Windows.Forms.TextBox specAlexAvrTBox;
        private System.Windows.Forms.TextBox specAlexTBox;
        private System.Windows.Forms.TextBox specAndrTBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button clrBtn;
        private System.Windows.Forms.TextBox colNameTBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox SpecAlexHelukabel;
        private System.Windows.Forms.CheckBox SpecAlexAvrHelukabel;
        private System.Windows.Forms.CheckBox SpecAndrHelukabel;
        private System.Windows.Forms.CheckBox SpecVladHelukabel;
    }
}

