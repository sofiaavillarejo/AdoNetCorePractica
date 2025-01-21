namespace AdoNetCorePractica
{
    partial class FormPractica
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
            label1 = new Label();
            cmbHospitales = new ComboBox();
            label2 = new Label();
            lstEmpleados = new ListBox();
            label3 = new Label();
            txtSuma = new TextBox();
            txtMedia = new TextBox();
            label4 = new Label();
            txtPersonas = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(119, 53);
            label1.Name = "label1";
            label1.Size = new Size(156, 41);
            label1.TabIndex = 0;
            label1.Text = "Hospitales";
            // 
            // cmbHospitales
            // 
            cmbHospitales.FormattingEnabled = true;
            cmbHospitales.Location = new Point(119, 116);
            cmbHospitales.Name = "cmbHospitales";
            cmbHospitales.Size = new Size(302, 49);
            cmbHospitales.TabIndex = 1;
            cmbHospitales.SelectedIndexChanged += cmbHospitales_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(835, 53);
            label2.Name = "label2";
            label2.Size = new Size(277, 41);
            label2.TabIndex = 2;
            label2.Text = "Empleados hospital";
            // 
            // lstEmpleados
            // 
            lstEmpleados.FormattingEnabled = true;
            lstEmpleados.Location = new Point(846, 116);
            lstEmpleados.Name = "lstEmpleados";
            lstEmpleados.Size = new Size(422, 496);
            lstEmpleados.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(119, 247);
            label3.Name = "label3";
            label3.Size = new Size(189, 41);
            label3.TabIndex = 4;
            label3.Text = "Suma salarial";
            // 
            // txtSuma
            // 
            txtSuma.Location = new Point(119, 304);
            txtSuma.Name = "txtSuma";
            txtSuma.Size = new Size(250, 47);
            txtSuma.TabIndex = 5;
            // 
            // txtMedia
            // 
            txtMedia.Location = new Point(119, 488);
            txtMedia.Name = "txtMedia";
            txtMedia.Size = new Size(250, 47);
            txtMedia.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(119, 417);
            label4.Name = "label4";
            label4.Size = new Size(198, 41);
            label4.TabIndex = 6;
            label4.Text = "Media salarial";
            // 
            // txtPersonas
            // 
            txtPersonas.Location = new Point(119, 650);
            txtPersonas.Name = "txtPersonas";
            txtPersonas.Size = new Size(250, 47);
            txtPersonas.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(119, 593);
            label5.Name = "label5";
            label5.Size = new Size(136, 41);
            label5.TabIndex = 8;
            label5.Text = "Personas";
            // 
            // FormPractica
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 730);
            Controls.Add(txtPersonas);
            Controls.Add(label5);
            Controls.Add(txtMedia);
            Controls.Add(label4);
            Controls.Add(txtSuma);
            Controls.Add(label3);
            Controls.Add(lstEmpleados);
            Controls.Add(label2);
            Controls.Add(cmbHospitales);
            Controls.Add(label1);
            Name = "FormPractica";
            Text = "FormPractica";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbHospitales;
        private Label label2;
        private ListBox lstEmpleados;
        private Label label3;
        private TextBox txtSuma;
        private TextBox txtMedia;
        private Label label4;
        private TextBox txtPersonas;
        private Label label5;
    }
}