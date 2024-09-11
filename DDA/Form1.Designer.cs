namespace DDA
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_calc = new System.Windows.Forms.Button();
            this.lbl_x1 = new System.Windows.Forms.Label();
            this.lbl_y1 = new System.Windows.Forms.Label();
            this.txt_x1 = new System.Windows.Forms.TextBox();
            this.txt_y1 = new System.Windows.Forms.TextBox();
            this.txt_x2 = new System.Windows.Forms.TextBox();
            this.txt_y2 = new System.Windows.Forms.TextBox();
            this.lbl_x2 = new System.Windows.Forms.Label();
            this.lbl_y2 = new System.Windows.Forms.Label();
            this.dgv_tabla = new System.Windows.Forms.DataGridView();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.lbl_Elem = new System.Windows.Forms.Label();
            this.txt_Elem = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tabla)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Location = new System.Drawing.Point(246, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 332);
            this.panel1.TabIndex = 0;
            // 
            // btn_calc
            // 
            this.btn_calc.Location = new System.Drawing.Point(12, 139);
            this.btn_calc.Name = "btn_calc";
            this.btn_calc.Size = new System.Drawing.Size(99, 56);
            this.btn_calc.TabIndex = 1;
            this.btn_calc.Text = "Calcular";
            this.btn_calc.UseVisualStyleBackColor = true;
            this.btn_calc.Click += new System.EventHandler(this.btn_calc_Click);
            // 
            // lbl_x1
            // 
            this.lbl_x1.AutoSize = true;
            this.lbl_x1.Location = new System.Drawing.Point(12, 13);
            this.lbl_x1.Name = "lbl_x1";
            this.lbl_x1.Size = new System.Drawing.Size(23, 13);
            this.lbl_x1.TabIndex = 2;
            this.lbl_x1.Text = "X1:";
            // 
            // lbl_y1
            // 
            this.lbl_y1.AutoSize = true;
            this.lbl_y1.Location = new System.Drawing.Point(65, 13);
            this.lbl_y1.Name = "lbl_y1";
            this.lbl_y1.Size = new System.Drawing.Size(23, 13);
            this.lbl_y1.TabIndex = 3;
            this.lbl_y1.Text = "Y1:";
            // 
            // txt_x1
            // 
            this.txt_x1.Location = new System.Drawing.Point(12, 29);
            this.txt_x1.Name = "txt_x1";
            this.txt_x1.Size = new System.Drawing.Size(50, 20);
            this.txt_x1.TabIndex = 4;
            // 
            // txt_y1
            // 
            this.txt_y1.Location = new System.Drawing.Point(68, 29);
            this.txt_y1.Name = "txt_y1";
            this.txt_y1.Size = new System.Drawing.Size(50, 20);
            this.txt_y1.TabIndex = 5;
            // 
            // txt_x2
            // 
            this.txt_x2.Location = new System.Drawing.Point(12, 80);
            this.txt_x2.Name = "txt_x2";
            this.txt_x2.Size = new System.Drawing.Size(50, 20);
            this.txt_x2.TabIndex = 9;
            // 
            // txt_y2
            // 
            this.txt_y2.Location = new System.Drawing.Point(68, 80);
            this.txt_y2.Name = "txt_y2";
            this.txt_y2.Size = new System.Drawing.Size(50, 20);
            this.txt_y2.TabIndex = 8;
            // 
            // lbl_x2
            // 
            this.lbl_x2.AutoSize = true;
            this.lbl_x2.Location = new System.Drawing.Point(12, 64);
            this.lbl_x2.Name = "lbl_x2";
            this.lbl_x2.Size = new System.Drawing.Size(23, 13);
            this.lbl_x2.TabIndex = 7;
            this.lbl_x2.Text = "X2:";
            // 
            // lbl_y2
            // 
            this.lbl_y2.AutoSize = true;
            this.lbl_y2.Location = new System.Drawing.Point(65, 64);
            this.lbl_y2.Name = "lbl_y2";
            this.lbl_y2.Size = new System.Drawing.Size(23, 13);
            this.lbl_y2.TabIndex = 6;
            this.lbl_y2.Text = "Y2:";
            // 
            // dgv_tabla
            // 
            this.dgv_tabla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_tabla.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_tabla.Location = new System.Drawing.Point(12, 201);
            this.dgv_tabla.Name = "dgv_tabla";
            this.dgv_tabla.Size = new System.Drawing.Size(228, 143);
            this.dgv_tabla.TabIndex = 10;
            this.dgv_tabla.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_tabla_CellFormatting);
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.Location = new System.Drawing.Point(141, 139);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(99, 56);
            this.btn_Limpiar.TabIndex = 11;
            this.btn_Limpiar.Text = "Limpiar";
            this.btn_Limpiar.UseVisualStyleBackColor = true;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // lbl_Elem
            // 
            this.lbl_Elem.AutoSize = true;
            this.lbl_Elem.Location = new System.Drawing.Point(127, 36);
            this.lbl_Elem.Name = "lbl_Elem";
            this.lbl_Elem.Size = new System.Drawing.Size(113, 13);
            this.lbl_Elem.TabIndex = 12;
            this.lbl_Elem.Text = "Número de elementos:";
            // 
            // txt_Elem
            // 
            this.txt_Elem.Location = new System.Drawing.Point(147, 57);
            this.txt_Elem.Name = "txt_Elem";
            this.txt_Elem.Size = new System.Drawing.Size(75, 20);
            this.txt_Elem.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 356);
            this.Controls.Add(this.txt_Elem);
            this.Controls.Add(this.lbl_Elem);
            this.Controls.Add(this.btn_Limpiar);
            this.Controls.Add(this.dgv_tabla);
            this.Controls.Add(this.txt_x2);
            this.Controls.Add(this.txt_y2);
            this.Controls.Add(this.lbl_x2);
            this.Controls.Add(this.lbl_y2);
            this.Controls.Add(this.txt_y1);
            this.Controls.Add(this.txt_x1);
            this.Controls.Add(this.lbl_y1);
            this.Controls.Add(this.lbl_x1);
            this.Controls.Add(this.btn_calc);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_calc;
        private System.Windows.Forms.Label lbl_x1;
        private System.Windows.Forms.Label lbl_y1;
        private System.Windows.Forms.TextBox txt_x1;
        private System.Windows.Forms.TextBox txt_y1;
        private System.Windows.Forms.TextBox txt_x2;
        private System.Windows.Forms.TextBox txt_y2;
        private System.Windows.Forms.Label lbl_x2;
        private System.Windows.Forms.Label lbl_y2;
        private System.Windows.Forms.DataGridView dgv_tabla;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Label lbl_Elem;
        private System.Windows.Forms.TextBox txt_Elem;
    }
}

