
namespace Lesson13._1
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
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CallBackBtn = new System.Windows.Forms.Button();
            this.EndBtn = new System.Windows.Forms.Button();
            this.IsCompletedBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(278, 34);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(100, 20);
            this.textBoxResult.TabIndex = 9;
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(150, 34);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(100, 20);
            this.textBoxY.TabIndex = 8;
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(22, 34);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(100, 20);
            this.textBoxX.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(256, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "=";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(128, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "+";
            // 
            // CallBackBtn
            // 
            this.CallBackBtn.Location = new System.Drawing.Point(281, 83);
            this.CallBackBtn.Name = "CallBackBtn";
            this.CallBackBtn.Size = new System.Drawing.Size(75, 23);
            this.CallBackBtn.TabIndex = 12;
            this.CallBackBtn.Text = "Complete";
            this.CallBackBtn.UseVisualStyleBackColor = true;
            this.CallBackBtn.Click += new System.EventHandler(this.CallBackBtn_Click);
            // 
            // EndBtn
            // 
            this.EndBtn.Location = new System.Drawing.Point(150, 83);
            this.EndBtn.Name = "EndBtn";
            this.EndBtn.Size = new System.Drawing.Size(75, 23);
            this.EndBtn.TabIndex = 11;
            this.EndBtn.Text = "End";
            this.EndBtn.UseVisualStyleBackColor = true;
            this.EndBtn.Click += new System.EventHandler(this.EndBtn_Click);
            // 
            // IsCompletedBtn
            // 
            this.IsCompletedBtn.Location = new System.Drawing.Point(27, 83);
            this.IsCompletedBtn.Name = "IsCompletedBtn";
            this.IsCompletedBtn.Size = new System.Drawing.Size(75, 23);
            this.IsCompletedBtn.TabIndex = 10;
            this.IsCompletedBtn.Text = "IsCallBack";
            this.IsCompletedBtn.UseVisualStyleBackColor = true;
            this.IsCompletedBtn.Click += new System.EventHandler(this.IsCompletedBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 148);
            this.Controls.Add(this.CallBackBtn);
            this.Controls.Add(this.EndBtn);
            this.Controls.Add(this.IsCompletedBtn);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CallBackBtn;
        private System.Windows.Forms.Button EndBtn;
        private System.Windows.Forms.Button IsCompletedBtn;
    }
}

