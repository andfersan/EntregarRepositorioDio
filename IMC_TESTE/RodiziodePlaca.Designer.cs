
namespace Rodizio
{
    partial class RodiziodePlaca
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
            this.cbo_semana = new System.Windows.Forms.ComboBox();
            this.lb_dia = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbo_semana
            // 
            this.cbo_semana.FormattingEnabled = true;
            this.cbo_semana.Items.AddRange(new object[] {
            "Segunda ",
            "Terça",
            "Quarta",
            "Quinta",
            "Sexta"});
            this.cbo_semana.Location = new System.Drawing.Point(191, 28);
            this.cbo_semana.Name = "cbo_semana";
            this.cbo_semana.Size = new System.Drawing.Size(151, 28);
            this.cbo_semana.TabIndex = 0;
            // 
            // lb_dia
            // 
            this.lb_dia.AutoSize = true;
            this.lb_dia.Location = new System.Drawing.Point(23, 31);
            this.lb_dia.Name = "lb_dia";
            this.lb_dia.Size = new System.Drawing.Size(110, 20);
            this.lb_dia.TabIndex = 1;
            this.lb_dia.Text = "Dia da Semana";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(248, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 63);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RodiziodePlaca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lb_dia);
            this.Controls.Add(this.cbo_semana);
            this.Name = "RodiziodePlaca";
            this.Text = "RodiziodePlaca";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbo_semana;
        private System.Windows.Forms.Label lb_dia;
        private System.Windows.Forms.Button button1;
    }
}