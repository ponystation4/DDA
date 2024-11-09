namespace Elipse
{
    partial class FormElipse
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
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.btn_Calcular = new System.Windows.Forms.Button();
            this.txt_RadioX = new System.Windows.Forms.TextBox();
            this.lbl_RadioX = new System.Windows.Forms.Label();
            this.lbl_Y = new System.Windows.Forms.Label();
            this.lbl_X = new System.Windows.Forms.Label();
            this.lbl_Coord = new System.Windows.Forms.Label();
            this.txt_Y = new System.Windows.Forms.TextBox();
            this.txt_X = new System.Windows.Forms.TextBox();
            this.dgv_4 = new System.Windows.Forms.DataGridView();
            this.dgv_3 = new System.Windows.Forms.DataGridView();
            this.dgv_2 = new System.Windows.Forms.DataGridView();
            this.dgv_1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_RadioY = new System.Windows.Forms.TextBox();
            this.lbl_RadioY = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Limpiar.Location = new System.Drawing.Point(242, 70);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(75, 39);
            this.btn_Limpiar.TabIndex = 48;
            this.btn_Limpiar.Text = "Limpiar";
            this.btn_Limpiar.UseVisualStyleBackColor = true;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // btn_Calcular
            // 
            this.btn_Calcular.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Calcular.Location = new System.Drawing.Point(63, 70);
            this.btn_Calcular.Name = "btn_Calcular";
            this.btn_Calcular.Size = new System.Drawing.Size(75, 39);
            this.btn_Calcular.TabIndex = 47;
            this.btn_Calcular.Text = "Calcular";
            this.btn_Calcular.UseVisualStyleBackColor = true;
            this.btn_Calcular.Click += new System.EventHandler(this.btn_Calcular_Click);
            // 
            // txt_RadioX
            // 
            this.txt_RadioX.Location = new System.Drawing.Point(209, 29);
            this.txt_RadioX.Name = "txt_RadioX";
            this.txt_RadioX.Size = new System.Drawing.Size(50, 20);
            this.txt_RadioX.TabIndex = 46;
            // 
            // lbl_RadioX
            // 
            this.lbl_RadioX.AutoSize = true;
            this.lbl_RadioX.Location = new System.Drawing.Point(206, 9);
            this.lbl_RadioX.Name = "lbl_RadioX";
            this.lbl_RadioX.Size = new System.Drawing.Size(48, 13);
            this.lbl_RadioX.TabIndex = 45;
            this.lbl_RadioX.Text = "Radio X:";
            // 
            // lbl_Y
            // 
            this.lbl_Y.AutoSize = true;
            this.lbl_Y.Location = new System.Drawing.Point(149, 52);
            this.lbl_Y.Name = "lbl_Y";
            this.lbl_Y.Size = new System.Drawing.Size(14, 13);
            this.lbl_Y.TabIndex = 44;
            this.lbl_Y.Text = "Y";
            // 
            // lbl_X
            // 
            this.lbl_X.AutoSize = true;
            this.lbl_X.Location = new System.Drawing.Point(83, 52);
            this.lbl_X.Name = "lbl_X";
            this.lbl_X.Size = new System.Drawing.Size(14, 13);
            this.lbl_X.TabIndex = 43;
            this.lbl_X.Text = "X";
            // 
            // lbl_Coord
            // 
            this.lbl_Coord.AutoSize = true;
            this.lbl_Coord.Location = new System.Drawing.Point(37, 9);
            this.lbl_Coord.Name = "lbl_Coord";
            this.lbl_Coord.Size = new System.Drawing.Size(115, 13);
            this.lbl_Coord.TabIndex = 42;
            this.lbl_Coord.Text = "Coordenadas de inicio:";
            // 
            // txt_Y
            // 
            this.txt_Y.Location = new System.Drawing.Point(103, 29);
            this.txt_Y.Name = "txt_Y";
            this.txt_Y.Size = new System.Drawing.Size(60, 20);
            this.txt_Y.TabIndex = 41;
            // 
            // txt_X
            // 
            this.txt_X.Location = new System.Drawing.Point(37, 29);
            this.txt_X.Name = "txt_X";
            this.txt_X.Size = new System.Drawing.Size(60, 20);
            this.txt_X.TabIndex = 40;
            // 
            // dgv_4
            // 
            this.dgv_4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_4.Location = new System.Drawing.Point(209, 306);
            this.dgv_4.Name = "dgv_4";
            this.dgv_4.Size = new System.Drawing.Size(132, 150);
            this.dgv_4.TabIndex = 52;
            // 
            // dgv_3
            // 
            this.dgv_3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_3.Location = new System.Drawing.Point(37, 306);
            this.dgv_3.Name = "dgv_3";
            this.dgv_3.Size = new System.Drawing.Size(130, 150);
            this.dgv_3.TabIndex = 51;
            // 
            // dgv_2
            // 
            this.dgv_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_2.Location = new System.Drawing.Point(209, 115);
            this.dgv_2.Name = "dgv_2";
            this.dgv_2.Size = new System.Drawing.Size(130, 150);
            this.dgv_2.TabIndex = 50;
            // 
            // dgv_1
            // 
            this.dgv_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_1.Location = new System.Drawing.Point(37, 115);
            this.dgv_1.Name = "dgv_1";
            this.dgv_1.Size = new System.Drawing.Size(130, 150);
            this.dgv_1.TabIndex = 49;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Location = new System.Drawing.Point(397, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 444);
            this.panel1.TabIndex = 53;
            // 
            // txt_RadioY
            // 
            this.txt_RadioY.Location = new System.Drawing.Point(289, 29);
            this.txt_RadioY.Name = "txt_RadioY";
            this.txt_RadioY.Size = new System.Drawing.Size(50, 20);
            this.txt_RadioY.TabIndex = 55;
            // 
            // lbl_RadioY
            // 
            this.lbl_RadioY.AutoSize = true;
            this.lbl_RadioY.Location = new System.Drawing.Point(286, 9);
            this.lbl_RadioY.Name = "lbl_RadioY";
            this.lbl_RadioY.Size = new System.Drawing.Size(48, 13);
            this.lbl_RadioY.TabIndex = 54;
            this.lbl_RadioY.Text = "Radio Y:";
            // 
            // FormElipse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 468);
            this.Controls.Add(this.txt_RadioY);
            this.Controls.Add(this.lbl_RadioY);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_4);
            this.Controls.Add(this.dgv_3);
            this.Controls.Add(this.dgv_2);
            this.Controls.Add(this.dgv_1);
            this.Controls.Add(this.btn_Limpiar);
            this.Controls.Add(this.btn_Calcular);
            this.Controls.Add(this.txt_RadioX);
            this.Controls.Add(this.lbl_RadioX);
            this.Controls.Add(this.lbl_Y);
            this.Controls.Add(this.lbl_X);
            this.Controls.Add(this.lbl_Coord);
            this.Controls.Add(this.txt_Y);
            this.Controls.Add(this.txt_X);
            this.Name = "FormElipse";
            this.Text = "Elipse";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Calcular;
        private System.Windows.Forms.TextBox txt_RadioX;
        private System.Windows.Forms.Label lbl_RadioX;
        private System.Windows.Forms.Label lbl_Y;
        private System.Windows.Forms.Label lbl_X;
        private System.Windows.Forms.Label lbl_Coord;
        private System.Windows.Forms.TextBox txt_Y;
        private System.Windows.Forms.TextBox txt_X;
        private System.Windows.Forms.DataGridView dgv_4;
        private System.Windows.Forms.DataGridView dgv_3;
        private System.Windows.Forms.DataGridView dgv_2;
        private System.Windows.Forms.DataGridView dgv_1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_RadioY;
        private System.Windows.Forms.Label lbl_RadioY;
    }
}

