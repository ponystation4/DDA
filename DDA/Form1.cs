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

namespace DDA
{
    public partial class Form1 : Form
    {
        // Se crea una instancia de FormsPlot porque no jala en Diseño
        readonly FormsPlot FormsPlot1 = new FormsPlot() { Dock = DockStyle.Fill };
        public Form1()
        {
            InitializeComponent();
            // Añade el FormsPlot de ScottPlot al panel
            panel1.Controls.Add(FormsPlot1);
            FormsPlot1.Refresh();
            //Se crean las 2 columnas del DataGridView
            dgv_tabla.Columns.Add("Column1", "X");
            dgv_tabla.Columns.Add("Column2", "Y");
            FormsPlot1.Plot.Title("Preparado.");
        }

        void Limpiar()
        {
            txt_x1.Clear();
            txt_x2.Clear();
            txt_y1.Clear();
            txt_y2.Clear();
            txt_Elem.Clear();
            FormsPlot1.Plot.Clear();
            FormsPlot1.Refresh();
            dgv_tabla.Rows.Clear();
            FormsPlot1.Plot.Title("Preparado.");
        }

        private void btn_calc_Click(object sender, EventArgs e)
        {
            FormsPlot1.Plot.Clear();
            dgv_tabla.Rows.Clear();
            //Obtener los valores de los textboxes
            double x1 = Convert.ToDouble(txt_x1.Text);
            double x2 = Convert.ToDouble(txt_x2.Text);
            double y1 = Convert.ToDouble(txt_y1.Text);
            double y2 = Convert.ToDouble(txt_y2.Text);
            int elem = Convert.ToInt32(txt_Elem.Text);

            //Crear arrays con los valores de X y Y y los elementos intermedios
            double[] x_valores = new double[elem];
            double[] y_valores = new double[elem];

            //Creación de tamaño de intervalos para x2-x1 y y2-y1
            double x_intervalo = (x2 - x1) / (elem - 1);
            double y_intervalo = (y2 - y1) / (elem - 1);

            //Se crean los valores para los arrays y se agregan al DataGridView
            for (int i = 0; i < elem; i++)
            {
                x_valores[i] = x1 + i * x_intervalo;
                y_valores[i] = y1 + i * y_intervalo;
                dgv_tabla.Rows.Add();
                dgv_tabla.Rows[i].Cells[0].Value = x_valores[i];
                dgv_tabla.Rows[i].Cells[1].Value = x_valores[i];
            }

            //Se le mandan a FormsPlot1 los valores y los muestra en pantalla
            FormsPlot1.Plot.Add.Scatter(x_valores, y_valores);
            FormsPlot1.Plot.Axes.AutoScale();
            FormsPlot1.Plot.Title("(" + Convert.ToString(x_valores[0]) + ", " + Convert.ToString(y_valores[0]) + ") -> (" + Convert.ToString(x_valores[elem-1]) + ", " + Convert.ToString(y_valores[elem-1]) + "), " + Convert.ToString(elem) + " elementos.");
            FormsPlot1.Refresh();
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        //Dar formato a las celdas con decimales
        private void dgv_tabla_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value is double)
            {
                double valor = (double)e.Value;

                // Si el valor tiene decimales, lo mostramos con 2 decimales, de lo contrario sin decimales
                if (valor % 1 == 0)
                {
                    e.Value = valor.ToString("N0"); // Sin decimales
                }
                else
                {
                    e.Value = valor.ToString("N5"); // Con 2 decimales
                }

                e.FormattingApplied = true;
            }
        }
    }
}
