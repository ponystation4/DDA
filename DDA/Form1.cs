using ScottPlot.TickGenerators.TimeUnits;
using ScottPlot.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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
            dgv_tabla.Rows.Clear();
            FormsPlot1.Plot.Clear();            
            FormsPlot1.Plot.Title("Preparado.");
            FormsPlot1.Refresh();
            lbl_P2.Text = "...";
            lbl_P3.Text  = "...";
            lbl_DH2.Text = "...";
            lbl_DV2.Text = "...";
            txt_x1.Focus();
        }

        private void btn_calc_Click(object sender, EventArgs e)
        {
            //Limpieza del DataGridView y del FormsPlot
            FormsPlot1.Plot.Clear();
            dgv_tabla.Rows.Clear();

            //Obtener los valores de los textboxes
            double x1 = Convert.ToDouble(txt_x1.Text);
            double x2 = Convert.ToDouble(txt_x2.Text);
            double y1 = Convert.ToDouble(txt_y1.Text);
            double y2 = Convert.ToDouble(txt_y2.Text);
            int elem;

            //Si txt_Elem está vacío 
            if (string.IsNullOrEmpty(txt_Elem.Text))
            {
                elem = 11;
            }
            else if ((Convert.ToInt32(txt_Elem.Text))<1)
            {
                elem = 2;
            }
            else
            {
                elem = Convert.ToInt32(txt_Elem.Text);
            }
            

            //Pendiente
            double m = (y2 - y1) / (x2 - x1);
            lbl_P2.Text = Convert.ToString(m);

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
                dgv_tabla.Rows[i].Cells[1].Value = y_valores[i];
            }

            //Se le mandan a FormsPlot1 los valores y los muestra en pantalla
            FormsPlot1.Plot.Add.Scatter(x_valores, y_valores);
            FormsPlot1.Plot.Axes.AutoScale();
            FormsPlot1.Plot.Title("(" + Convert.ToString(x_valores[0]) + ", " + Convert.ToString(y_valores[0]) + ") -> (" + Convert.ToString(x_valores[elem - 1]) + ", " + Convert.ToString(y_valores[elem - 1]) + "), " + Convert.ToString(elem) + " elementos.");
            FormsPlot1.Refresh();

            //Determinación del caso
            //Parte tricky del código jajsj

            //Primero, se verifica si es un caso especial en el que la pendiente es infinita (ERR)
            if (Double.IsPositiveInfinity(m)) //Caso 7.1 (Abajo-arriba, m = ERR)
            {
                lbl_P2.Text = "+∞";
                lbl_P3.Text = "Error";
                lbl_DH2.Text = "No disponible";
                lbl_DV2.Text = "⬆";
            }
            else if (Double.IsNegativeInfinity(m)) //Caso 7.2 (Arriba-abajo, m = ERR)
            {
                lbl_P2.Text = "-∞";
                lbl_P3.Text = "Error";
                lbl_DH2.Text = "No disponible";
                lbl_DV2.Text = "⬇";
            }

            //Después, se verifican los parámetros de x e y
            else if (Math.Abs(m) == 0)
            {
                if (x1 < x2) // Caso 6.1 (Izquierda - derecha, m = 0)
                {
                    lbl_P2.Text = Convert.ToString(m);
                    lbl_P3.Text = "M=0";
                    lbl_DH2.Text = "➡";
                    lbl_DV2.Text = "No disponible";
                }
                else if (x1 > x2) // Caso 6.2 (Derecha - izquierda, m = 0)
                {
                    lbl_P2.Text = Convert.ToString(m);
                    lbl_P3.Text = "M=0";
                    lbl_DH2.Text = "⬅";
                    lbl_DV2.Text = "No disponible";
                }
            }
            else if (Math.Abs(m) == 1) // m = 1
            {
                if (x1 < x2)
                {
                    if (y1 < y2) // Caso 5.1 (Izquierda - derecha, abajo - arriba, m = 1)
                    {
                        lbl_P2.Text = Convert.ToString(m);
                        lbl_P3.Text = "M=1";
                        lbl_DH2.Text = "➡";
                        lbl_DV2.Text = "⬆";
                    }
                    else if (y1 > y2) // Caso 5.2 (Izquierda - derecha, arriba - abajo, -m = 1)
                    {
                        lbl_P2.Text = Convert.ToString(m);
                        lbl_P3.Text = "-M=1";
                        lbl_DH2.Text = "➡";
                        lbl_DV2.Text = "⬇";
                    }
                }
                else if (x1 > x2)
                {
                    if (y1 < y2) // Caso 5.3 (Derecha - izquierda, abajo - arriba, m = -1)
                    {
                        lbl_P2.Text = Convert.ToString(m);
                        lbl_P3.Text = "-M=1";
                        lbl_DH2.Text = "⬅";
                        lbl_DV2.Text = "⬆";
                    }
                    else if (y1 > y2) // Caso 5.4 (Derecha - izquierda, arriba - abajo, m = 1)
                    {
                        lbl_P2.Text = Convert.ToString(m);
                        lbl_P3.Text = "M=1";
                        lbl_DH2.Text = "⬅";
                        lbl_DV2.Text = "⬇";
                    }
                }
            }
            else if (Math.Abs(m) > 0 && Math.Abs(m) < 1) // m < 1 y -m < 1
            {
                if (m > 0) //Positivo (m < 1)
                {
                    if (x1 < x2 && y1 < y2) //Caso 1
                    {
                        lbl_P2.Text = Convert.ToString(m);
                        lbl_P3.Text = "M<1";
                        lbl_DH2.Text = "➡";
                        lbl_DV2.Text = "⬆";
                    }
                    else if (x1 > x2 && y1 > y2) //Caso 2
                    {
                        lbl_P2.Text = Convert.ToString(m);
                        lbl_P3.Text = "M<1";
                        lbl_DH2.Text = "⬅";
                        lbl_DV2.Text = "⬇";
                    }
                }
                else //Negativo (-m < 1)
                {
                    if (x1 > x2 && y1 < y2) //Caso 8
                    {
                        lbl_P2.Text = Convert.ToString(m);
                        lbl_P3.Text = "-M<1";
                        lbl_DH2.Text = "⬅";
                        lbl_DV2.Text = "⬆";
                    }
                    else if (x1 < x2 && y1 > y2) //Caso 9
                    {
                        lbl_P2.Text = Convert.ToString(m);
                        lbl_P3.Text = "-M<1";
                        lbl_DH2.Text = "➡";
                        lbl_DV2.Text = "⬇";
                    }
                }
            }
            else if (Math.Abs(m) > 1) // m > 1 y -m > 1
            {
                if (m > 1) //Positivo
                {
                    if (x1 < x2 && y1 < y2) //Caso 3
                    {
                        lbl_P2.Text = Convert.ToString(m);
                        lbl_P3.Text = "M>1";
                        lbl_DH2.Text = "➡";
                        lbl_DV2.Text = "⬆";
                    }
                    else if (x1 > x2 && y1 > y2) //Caso 4
                    {
                        lbl_P2.Text = Convert.ToString(m);
                        lbl_P3.Text = "M>1";
                        lbl_DH2.Text = "⬅";
                        lbl_DV2.Text = "⬇";
                    }
                }
                else //Negativo
                {
                    if (x1 > x2 && y1 < y2) //Caso 10
                    {
                        lbl_P2.Text = Convert.ToString(m);
                        lbl_P3.Text = "-M>1";
                        lbl_DH2.Text = "⬅";
                        lbl_DV2.Text = "⬆";
                    }
                    else if (x1 < x2 && y1 > y2) //Caso 11
                    {
                        lbl_P2.Text = Convert.ToString(m);
                        lbl_P3.Text = "-M>1";
                        lbl_DH2.Text = "➡";
                        lbl_DV2.Text = "⬇";
                    }
                }
            }
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
