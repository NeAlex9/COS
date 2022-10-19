
namespace Lab1
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
            this.constValues = new System.Windows.Forms.ComboBox();
            this.Garmonical_btn = new System.Windows.Forms.Button();
            this.Polynomical_btn = new System.Windows.Forms.Button();
            this.PolynomicalWithLinear = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // constValues
            // 
            this.constValues.Items.AddRange(new object[] {
            "512",
            "1024",
            "2048",
            "4096"});
            this.constValues.Location = new System.Drawing.Point(251, 568);
            this.constValues.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.constValues.Name = "constValues";
            this.constValues.Size = new System.Drawing.Size(121, 24);
            this.constValues.TabIndex = 1;
            this.constValues.SelectedIndexChanged += new System.EventHandler(this.numberInput_SelectedIndexChanged);
            // 
            // Garmonical_btn
            // 
            this.Garmonical_btn.Location = new System.Drawing.Point(575, 562);
            this.Garmonical_btn.Name = "Garmonical_btn";
            this.Garmonical_btn.Size = new System.Drawing.Size(127, 37);
            this.Garmonical_btn.TabIndex = 4;
            this.Garmonical_btn.Text = "Garmonical";
            this.Garmonical_btn.UseVisualStyleBackColor = true;
            this.Garmonical_btn.Click += new System.EventHandler(this.button2_Click);
            // 
            // Polynomical_btn
            // 
            this.Polynomical_btn.Location = new System.Drawing.Point(746, 562);
            this.Polynomical_btn.Name = "Polynomical_btn";
            this.Polynomical_btn.Size = new System.Drawing.Size(123, 36);
            this.Polynomical_btn.TabIndex = 5;
            this.Polynomical_btn.Text = "Polynomical";
            this.Polynomical_btn.UseVisualStyleBackColor = true;
            this.Polynomical_btn.Click += new System.EventHandler(this.Polynomical_btn_Click);
            // 
            // PolynomicalWithLinear
            // 
            this.PolynomicalWithLinear.Location = new System.Drawing.Point(913, 564);
            this.PolynomicalWithLinear.Name = "PolynomicalWithLinear";
            this.PolynomicalWithLinear.Size = new System.Drawing.Size(181, 35);
            this.PolynomicalWithLinear.TabIndex = 6;
            this.PolynomicalWithLinear.Text = "PolynomicalWithLinear";
            this.PolynomicalWithLinear.UseVisualStyleBackColor = true;
            this.PolynomicalWithLinear.Click += new System.EventHandler(this.PolynomicalWithLinear_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Items.AddRange(new object[] {
            "ConstAandF",
            "ConstAnadFi",
            "ConstFandFi"});
            this.comboBox1.Location = new System.Drawing.Point(418, 569);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1493, 628);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.PolynomicalWithLinear);
            this.Controls.Add(this.Polynomical_btn);
            this.Controls.Add(this.Garmonical_btn);
            this.Controls.Add(this.constValues);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox constValues;
        private System.Windows.Forms.Button Garmonical_btn;
        private System.Windows.Forms.Button Polynomical_btn;
        private System.Windows.Forms.Button PolynomicalWithLinear;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

