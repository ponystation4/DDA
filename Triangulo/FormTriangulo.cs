using ScottPlot.TickGenerators.TimeUnits;
using ScottPlot.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triangulo
{
    public partial class FormTriangulo : Form
    {
        // Se crea una instancia de FormsPlot porque no jala en Diseño
        readonly FormsPlot FormsPlot1 = new FormsPlot() { Dock = DockStyle.Fill };
        public FormTriangulo()
        {
            InitializeComponent();
            // Añade el FormsPlot de ScottPlot al panel
            panel1.Controls.Add(FormsPlot1);
            FormsPlot1.Refresh();
            //Se crean las 2 columnas por DataGridView (3)
            dgv_tabla1.Columns.Add("Column1", "X");
            dgv_tabla1.Columns.Add("Column2", "Y");
            dgv_tabla2.Columns.Add("Column1", "X");
            dgv_tabla2.Columns.Add("Column2", "Y");
            dgv_tabla3.Columns.Add("Column1", "X");
            dgv_tabla3.Columns.Add("Column2", "Y");
            //Se indica que la gráfica está preparada
            FormsPlot1.Plot.Title("Preparado.");
        }

        void Limpiar()
        {
            txt_x11.Clear();
            txt_x21.Clear();
            txt_y11.Clear();
            txt_y21.Clear();
            txt_x12.Clear();
            txt_x22.Clear();
            txt_y12.Clear();
            txt_y22.Clear();
            txt_x13.Clear();
            txt_x23.Clear();
            txt_y13.Clear();
            txt_y23.Clear();
            dgv_tabla1.Rows.Clear();
            dgv_tabla2.Rows.Clear();
            dgv_tabla3.Rows.Clear();
            FormsPlot1.Plot.Clear();
            FormsPlot1.Plot.Title("Preparado.");
            FormsPlot1.Refresh();
            txt_x11.Focus();
        }

        private void btn_calc_Click(object sender, EventArgs e)
        {
            //Limpieza del DataGridView y del FormsPlot
            FormsPlot1.Plot.Clear();
            dgv_tabla1.Rows.Clear();
            dgv_tabla2.Rows.Clear();
            dgv_tabla3.Rows.Clear();

            //Obtener los valores de la linea 1
            double x11 = Convert.ToDouble(txt_x11.Text);
            double x21 = Convert.ToDouble(txt_x21.Text);
            double y11 = Convert.ToDouble(txt_y11.Text);
            double y21 = Convert.ToDouble(txt_y21.Text);
            double m1 = (y21 - y11) / (x21 - x11);

            //Obtener los valores de la linea 2
            double x12 = Convert.ToDouble(txt_x12.Text);
            double x22 = Convert.ToDouble(txt_x22.Text);
            double y12 = Convert.ToDouble(txt_y12.Text);
            double y22 = Convert.ToDouble(txt_y22.Text);
            double m2 = (y22 - y12) / (x22 - x12);

            //Obtener los valores de la linea 3
            double x13 = Convert.ToDouble(txt_x13.Text);
            double x23 = Convert.ToDouble(txt_x23.Text);
            double y13 = Convert.ToDouble(txt_y13.Text);
            double y23 = Convert.ToDouble(txt_y23.Text);
            double m3 = (y23 - y13) / (x23 - x13);

            //Compatibilidad con la estructura anterior
            int elem = 101;

            //Crear arrays con los valores de X y Y y los elementos intermedios para cada datagridview
            double[] x_valores1 = new double[elem];
            double[] y_valores1 = new double[elem];
            double[] x_valores2 = new double[elem];
            double[] y_valores2 = new double[elem];
            double[] x_valores3 = new double[elem];
            double[] y_valores3 = new double[elem];

            //Creación de tamaño de intervalos para x2-x1 y y2-y1 de cada datagridview
            double x_intervalo1 = (x21 - x11) / (elem - 1);
            double y_intervalo1 = (y21 - y11) / (elem - 1);
            double x_intervalo2 = (x22 - x12) / (elem - 1);
            double y_intervalo2 = (y22 - y12) / (elem - 1);
            double x_intervalo3 = (x23 - x13) / (elem - 1);
            double y_intervalo3 = (y23 - y13) / (elem - 1);

            //Se crean los valores para los arrays y se agregan al DataGridView
            for (int i = 0; i < elem; i++)
            {
                x_valores1[i] = x11 + i * x_intervalo1;
                y_valores1[i] = y11 + i * y_intervalo1;
                dgv_tabla1.Rows.Add();
                dgv_tabla1.Rows[i].Cells[0].Value = x_valores1[i];
                dgv_tabla1.Rows[i].Cells[1].Value = y_valores1[i];

                x_valores2[i] = x12 + i * x_intervalo2;
                y_valores2[i] = y12 + i * y_intervalo2;
                dgv_tabla2.Rows.Add();
                dgv_tabla2.Rows[i].Cells[0].Value = x_valores2[i];
                dgv_tabla2.Rows[i].Cells[1].Value = y_valores2[i];

                x_valores3[i] = x13 + i * x_intervalo3;
                y_valores3[i] = y13 + i * y_intervalo3;
                dgv_tabla3.Rows.Add();
                dgv_tabla3.Rows[i].Cells[0].Value = x_valores3[i];
                dgv_tabla3.Rows[i].Cells[1].Value = y_valores3[i];
            }

            FormsPlot1.Plot.Add.Line(x11, y11, x21, y21);
            FormsPlot1.Plot.Add.Line(x12, y12, x22, y22);
            FormsPlot1.Plot.Add.Line(x13, y13, x23, y23);

            //Esto genera las líneas del triángulo basado en la cantidad de elementos que hay
            for (int i = 1; i<elem-1; i++)
            {
                FormsPlot1.Plot.Add.Line(x11, y11, x_valores2[i], y_valores2[i]);
            }

            FormsPlot1.Plot.Axes.AutoScale();
            FormsPlot1.Plot.Title("Triángulo");
            FormsPlot1.Refresh();
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void dgv_tabla1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.Value != null && e.Value is double)
            {
                double valor = (double)e.Value;

                // Si el valor tiene decimales, lo mostramos con 2 decimales, de lo contrario sin decimales
                if (valor % 1 == 0)
                {
                    e.Value = valor.ToString("N0"); // Sin decimales
                }
                else
                {
                    e.Value = valor.ToString("N2"); // Con 2 decimales
                }

                e.FormattingApplied = true;
            }
        }

        private void dgv_tabla2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.Value != null && e.Value is double)
            {
                double valor = (double)e.Value;

                // Si el valor tiene decimales, lo mostramos con 2 decimales, de lo contrario sin decimales
                if (valor % 1 == 0)
                {
                    e.Value = valor.ToString("N0"); // Sin decimales
                }
                else
                {
                    e.Value = valor.ToString("N2"); // Con 2 decimales
                }

                e.FormattingApplied = true;
            }
        }

        private void dgv_tabla3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.Value != null && e.Value is double)
            {
                double valor = (double)e.Value;

                // Si el valor tiene decimales, lo mostramos con 2 decimales, de lo contrario sin decimales
                if (valor % 1 == 0)
                {
                    e.Value = valor.ToString("N0"); // Sin decimales
                }
                else
                {
                    e.Value = valor.ToString("N2"); // Con 2 decimales
                }

                e.FormattingApplied = true;
            }
        }
    }
}
