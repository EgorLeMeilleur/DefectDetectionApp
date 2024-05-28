namespace DefectDetectionApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.fileDownload = new System.Windows.Forms.Button();
            this.btnRunInference = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.showDatabase = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeleteDatabase = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // fileDownload
            // 
            this.fileDownload.Location = new System.Drawing.Point(737, 188);
            this.fileDownload.Name = "fileDownload";
            this.fileDownload.Size = new System.Drawing.Size(152, 38);
            this.fileDownload.TabIndex = 0;
            this.fileDownload.Text = "Загрузить новый файл";
            this.fileDownload.UseVisualStyleBackColor = true;
            this.fileDownload.Click += new System.EventHandler(this.fileDownload_Click);
            // 
            // btnRunInference
            // 
            this.btnRunInference.Location = new System.Drawing.Point(737, 232);
            this.btnRunInference.Name = "btnRunInference";
            this.btnRunInference.Size = new System.Drawing.Size(152, 38);
            this.btnRunInference.TabIndex = 1;
            this.btnRunInference.Text = "Найти дефекты на изображении";
            this.btnRunInference.UseVisualStyleBackColor = true;
            this.btnRunInference.Click += new System.EventHandler(this.btnRunInference_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.ErrorImage = null;
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Location = new System.Drawing.Point(18, 43);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(700, 500);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // showDatabase
            // 
            this.showDatabase.Location = new System.Drawing.Point(737, 276);
            this.showDatabase.Name = "showDatabase";
            this.showDatabase.Size = new System.Drawing.Size(152, 41);
            this.showDatabase.TabIndex = 3;
            this.showDatabase.Text = "Посмотреть сохранённые детекции";
            this.showDatabase.UseVisualStyleBackColor = true;
            this.showDatabase.Click += new System.EventHandler(this.showDatabase_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(740, 387);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(152, 23);
            this.progressBar.Step = 20;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 4;
            this.progressBar.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ваше изображение";
            // 
            // btnDeleteDatabase
            // 
            this.btnDeleteDatabase.Location = new System.Drawing.Point(737, 323);
            this.btnDeleteDatabase.Name = "btnDeleteDatabase";
            this.btnDeleteDatabase.Size = new System.Drawing.Size(152, 41);
            this.btnDeleteDatabase.TabIndex = 6;
            this.btnDeleteDatabase.Text = "Удалить все данные о детекциях";
            this.btnDeleteDatabase.UseVisualStyleBackColor = true;
            this.btnDeleteDatabase.Click += new System.EventHandler(this.btnDeleteDatabase_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(737, 371);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Выполняется детекция:";
            this.label2.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(904, 561);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDeleteDatabase);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.showDatabase);
            this.Controls.Add(this.btnRunInference);
            this.Controls.Add(this.fileDownload);
            this.Controls.Add(this.pictureBox);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Обнаружение дефектов";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button fileDownload;
        private System.Windows.Forms.Button btnRunInference;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button showDatabase;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeleteDatabase;
        private System.Windows.Forms.Label label2;
    }
}

