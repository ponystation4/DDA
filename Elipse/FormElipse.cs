using ScottPlot;
using ScottPlot.Colormaps;
using ScottPlot.Palettes;
using ScottPlot.Plottables;
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

namespace Elipse
{
    public partial class FormElipse : Form
    {
        //Lista de valores final
        List<double> listaColumnaX = new List<double>();
        List<double> listaColumnaY = new List<double>();
        // Se crea una instancia de FormsPlot porque no jala en Diseño
        readonly FormsPlot FormsPlot1 = new FormsPlot() { Dock = DockStyle.Fill };
        public FormElipse()
        {
            InitializeComponent();

            // Añade el FormsPlot de ScottPlot al panel
            panel1.Controls.Add(FormsPlot1);
            //Se indica que la gráfica está preparada
            FormsPlot1.Plot.Title("Preparado.");
            //Se crean las listas de valores de los octantes
            dgv_1.Columns.Add("Column1", "X");
            dgv_1.Columns.Add("Column2", "Y");
            dgv_2.Columns.Add("Column1", "X");
            dgv_2.Columns.Add("Column2", "Y");
            dgv_3.Columns.Add("Column1", "X");
            dgv_3.Columns.Add("Column2", "Y");
            dgv_4.Columns.Add("Column1", "X");
            dgv_4.Columns.Add("Column2", "Y");

        }

        private void UnirValoresColumnas(DataGridView dgv)
        {

            foreach (DataGridViewRow row in dgv.Rows)
            {
                // Verificar que la fila no esté vacía
                if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                {
                    // Agregar los valores de cada columna a sus respectivas listas
                    listaColumnaX.Add(Convert.ToDouble(row.Cells[0].Value));
                    listaColumnaY.Add(Convert.ToDouble(row.Cells[1].Value));
                }
            }
        }

        private void btn_Calcular_Click(object sender, EventArgs e)
        {
            //Valores ingresados por el usuario
            double radioX = Convert.ToDouble(txt_RadioX.Text);
            double radioY = Convert.ToDouble(txt_RadioY.Text);
            double x = Convert.ToDouble(txt_X.Text);
            double y = Convert.ToDouble(txt_Y.Text);

            //Valores PK
            int N = 0;
            int O = 0;
            double PK = 0;
            double nPK = 0; //Pk+1

            //Se crean las listas de valores
            List<double> listaX = new List<double>();
            List<double> listaY = new List<double>();

            //Por si acaso limpiar las listas y reducir el tamaño a 0
            listaX.Clear();
            listaX.TrimExcess();
            listaY.Clear();
            listaY.TrimExcess();
            listaColumnaX.Clear();
            listaColumnaX.TrimExcess();
            listaColumnaY.Clear();
            listaColumnaY.TrimExcess();

            //Limpiar tablas y FormsPlot
            FormsPlot1.Plot.Clear();
            dgv_1.Rows.Clear();
            dgv_2.Rows.Clear();
            dgv_3.Rows.Clear();
            dgv_4.Rows.Clear();

            //Se añade el primer valor
            double xsum = 0;
            double ysum = radioY;
            listaX.Add(xsum);
            listaY.Add(ysum);

            //Obtención de valores (Región 1)
            while ((2 * Math.Pow(radioY, 2) * xsum) < (2 * Math.Pow(radioX, 2) * ysum)){
                if (N == 0) //Si es la primera ejecución se usa el parámetro de decisión
                {
                    //Primer valor (Parámetro de decisión)
                    nPK = (radioY * radioY) - ((radioX * radioX) * radioY) + (0.25 * (radioX * radioX));
                }
                else //De otra forma se decide si PK es mayor, igual o menor que 0
                {
                    if (nPK < 0)
                    {
                        xsum++;
                        nPK = nPK + (2 * Math.Pow(radioY, 2) * xsum) + Math.Pow(radioY, 2);
                        listaX.Add(xsum);
                        listaY.Add(ysum);
                    }
                    else //if (nPK => 0)
                    {
                        xsum++;
                        ysum--;
                        nPK = nPK + (2 * Math.Pow(radioY, 2) * xsum) - (2 * Math.Pow(radioX, 2) * ysum) + (Math.Pow(radioY, 2));
                        listaX.Add(xsum);
                        listaY.Add(ysum);
                    }
                }
                N++;
            }
            MessageBox.Show("Último xsum = " + Convert.ToString(xsum) + ", último ysum = " + Convert.ToString(ysum));
            //Obtención de valores (Región 2)
            while (ysum != 0)
            {
                if (O == 0) //Si es la primera ejecución se usa el parámetro de decisión
                {
                    //Primer valor (Parámetro de decisión)
                    nPK = ((Math.Pow(radioY, 2) * Math.Pow(xsum + 0.5, 2)) + (Math.Pow(radioX, 2) * Math.Pow(ysum - 1, 2)) - (Math.Pow(radioX, 2) * Math.Pow(radioY, 2)));
                }
                else
                {
                    if (nPK > 0)
                    {
                        ysum--;
                        nPK = nPK - (2 * Math.Pow(radioX, 2) * ysum) + (Math.Pow(radioX, 2));
                        listaX.Add(xsum);
                        listaY.Add(ysum);
                    }
                    else
                    {
                        xsum++;
                        ysum--;
                        nPK = nPK + (2 * Math.Pow(radioY, 2) * xsum) - (2 * Math.Pow(radioX, 2) * ysum) + (Math.Pow(radioX, 2));
                        listaX.Add(xsum);
                        listaY.Add(ysum);
                    }
                }

                O++;
            }
            /* do
            {
                if (O == 0) //Parámetro de decisión P2
                {
                    /*nPK = ((Math.Pow(radioY, 2) * Math.Pow(xsum + 0.5, 2)) + (Math.Pow(radioX, 2) * Math.Pow(ysum - 1, 2)) - (Math.Pow(radioX, 2) * Math.Pow(radioY, 2))); //Mucho texto AAA
                    double seccion1 = Math.Pow(radioY, 2) + Math.Pow((xsum+0.5), 2);
                    double seccion2 = Math.Pow(radioX, 2) * Math.Pow((ysum - 1), 2);
                    double seccion3 = Math.Pow(radioX, 2) * Math.Pow(radioY, 2);
                    //Borrar esta parte después
                    MessageBox.Show("xsum = " + xsum + " ysum = " + ysum, "huh");
                    MessageBox.Show("R2Y = " + Convert.ToString(seccion1) + " + " + Convert.ToString(seccion2) + " - " + Convert.ToString(seccion3),Convert.ToString(nPK));
                }
                else
                {
                    if (nPK <= 0)
                    {
                        PK = nPK;
                        nPK = PK + (2 * Math.Pow(radioY, 2) * xsum) - (2 * Math.Pow(radioX, 2) * ysum) + (Math.Pow(radioX, 2));
                        listaX.Add(xsum);
                        xsum++;
                        listaY.Add(ysum);
                        ysum--;
                    }
                    else
                    {
                        PK = nPK;
                        nPK = PK - (2 * Math.Pow(radioX, 2) * ysum) + Math.Pow(radioX, 2);
                        listaX.Add(xsum);
                        listaY.Add(ysum);
                        xsum++;
                    }
                }

                O++;
            } 

            while (ysum!=0); //Un saludo a la raza de la FCFM que la sigue cotorreando*/

            //Lista de valores de los octantes
            double[] ValoresX = listaX.ToArray();
            double[] ValoresY = listaY.ToArray();

            //Creación de tablas con valores negativos
            double[] ValoresXNeg = new double[ValoresX.Length];
            for (int i = 0; i < ValoresX.Length; i++)
            {
                ValoresXNeg[i] = -ValoresX[i]; // Asigna el valor negativo de cada elemento
            }
            double[] ValoresYNeg = new double[ValoresY.Length];
            for (int i = 0; i < ValoresY.Length; i++)
            {
                ValoresYNeg[i] = -ValoresY[i]; // Asigna el valor negativo de cada elemento
            }

            //Añade valores a las tablas
            for (int i = 0; i < ValoresX.Length; i++) 
            {
                dgv_1.Rows.Add();
                dgv_1.Rows[i].Cells[0].Value = ValoresX[i] + x;
                dgv_1.Rows[i].Cells[1].Value = ValoresY[i] + y;
                dgv_1.AutoResizeColumns();
                dgv_1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                dgv_2.Rows.Add();
                dgv_2.Rows[i].Cells[0].Value = ValoresX[i] + x;
                dgv_2.Rows[i].Cells[1].Value = ValoresYNeg[i] + y;
                dgv_2.AutoResizeColumns();
                dgv_2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                dgv_3.Rows.Add();
                dgv_3.Rows[i].Cells[0].Value = ValoresXNeg[i] + x;
                dgv_3.Rows[i].Cells[1].Value = ValoresYNeg[i] + y;
                dgv_3.AutoResizeColumns();
                dgv_3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                dgv_4.Rows.Add();
                dgv_4.Rows[i].Cells[0].Value = ValoresXNeg[i] + x;
                dgv_4.Rows[i].Cells[1].Value = ValoresY[i] + y;
                dgv_4.AutoResizeColumns();
                dgv_4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            for (int i = 0; i < ValoresY.Length; i++) //Añade líneas que conectan el centro con los puntos del círculo
            {
                FormsPlot1.Plot.Add.Line(x, y, Convert.ToDouble(dgv_1.Rows[i].Cells[0].Value), Convert.ToDouble(dgv_1.Rows[i].Cells[1].Value));
                FormsPlot1.Plot.Add.Line(x, y, Convert.ToDouble(dgv_2.Rows[i].Cells[0].Value), Convert.ToDouble(dgv_2.Rows[i].Cells[1].Value));
                FormsPlot1.Plot.Add.Line(x, y, Convert.ToDouble(dgv_3.Rows[i].Cells[0].Value), Convert.ToDouble(dgv_3.Rows[i].Cells[1].Value));
                FormsPlot1.Plot.Add.Line(x, y, Convert.ToDouble(dgv_4.Rows[i].Cells[0].Value), Convert.ToDouble(dgv_4.Rows[i].Cells[1].Value));
            }

            //Añade un círculo de ejemplo
            var e1 = FormsPlot1.Plot.Add.Ellipse(
                xCenter: x,
                yCenter: y,
                radiusX: radioX,
                radiusY: radioY); 
            e1.LineWidth = 0.4F;
            e1.LineColor = Colors.Black;

            //Une los valores de las columnas para crear la circunferencia del círculo con los valores de los octantes
            UnirValoresColumnas(dgv_1);
            UnirValoresColumnas(dgv_2);
            UnirValoresColumnas(dgv_3);
            UnirValoresColumnas(dgv_4);

            //Colorea los puntos finales de la circunferencia de verde
            var puntos = FormsPlot1.Plot.Add.Scatter(listaColumnaX, listaColumnaY);
            puntos.Color = Colors.Green.WithOpacity(.2);
            puntos.LineWidth = 0;
            puntos.MarkerSize = 25;

            //Escala automáticamente el gráfico para ajustarse al FormsPlot sin afectar la precisión del círculo
            FormsPlot1.Plot.Axes.AutoScale();
            FormsPlot1.Plot.Title("Elipse");
            FormsPlot1.Refresh();
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
            {

            }

        
    }
}
