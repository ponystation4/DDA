using ScottPlot;
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

namespace Circulo
{
    public partial class FormCirculo : Form
    {
        //Lista de valores final
        List<double> listaColumnaX = new List<double>();
        List<double> listaColumnaY = new List<double>();

        // Se crea una instancia de FormsPlot porque no jala en Diseño
        readonly FormsPlot FormsPlot1 = new FormsPlot() { Dock = DockStyle.Fill };
        public FormCirculo()
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
            dgv_5.Columns.Add("Column1", "X");
            dgv_5.Columns.Add("Column2", "Y");
            dgv_6.Columns.Add("Column1", "X");
            dgv_6.Columns.Add("Column2", "Y");
            dgv_7.Columns.Add("Column1", "X");
            dgv_7.Columns.Add("Column2", "Y");
            dgv_8.Columns.Add("Column1", "X");
            dgv_8.Columns.Add("Column2", "Y");
        }
        void LimpiarDGV()
        {
            dgv_1.Rows.Clear();
            dgv_2.Rows.Clear();
            dgv_3.Rows.Clear();
            dgv_4.Rows.Clear();
            dgv_5.Rows.Clear();
            dgv_6.Rows.Clear();
            dgv_7.Rows.Clear();
            dgv_8.Rows.Clear();
        }
        void LimpiarPlot()
        {
            FormsPlot1.Plot.Clear();
            FormsPlot1.Plot.Title("Preparado.");
            FormsPlot1.Refresh();
        }
        void LimpiarTexto()
        {
            txt_Radio.Clear();
            txt_X.Clear();
            txt_Y.Clear();
        }
        void Limpiar()
        {
            LimpiarDGV();
            LimpiarPlot();
            LimpiarTexto();
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
        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void btn_Calcular_Click(object sender, EventArgs e)
        {
            //Se obtienen los valores ingresados por el usuario
            double radio = Convert.ToDouble(txt_Radio.Text);
            double x = Convert.ToDouble(txt_X.Text);
            double y = Convert.ToDouble(txt_Y.Text);

            int N = 0;
            double PK = 0;
            double nPK = 0; //Pk+1

            //Parámetro de decisión
            PK = 1 - radio;

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
            dgv_5.Rows.Clear();
            dgv_6.Rows.Clear();
            dgv_7.Rows.Clear();
            dgv_8.Rows.Clear();

            //Se añade el primer valor
            double xsum = 0;
            double ysum = radio;

            //Obtención de valores
            do
            {
                if (N == 0) //Si es la primera ejecución se usa el parámetro de decisión
                {
                    listaX.Add(xsum);
                    listaY.Add(radio);
                    xsum++;
                    nPK = PK;
                }
                else //De otra forma se decide si PK es mayor, igual o menor que 0
                {
                    if (nPK < 0)
                    {
                        PK = nPK;
                        nPK = PK + (2 * xsum) + 1;
                        listaX.Add(xsum);
                        listaY.Add(ysum);
                        xsum++;
                    }
                    else //if (nPK => 0)
                    {
                        PK = nPK;
                        nPK = PK + (2 * xsum) + 1 - (2 * ysum);
                        listaX.Add(xsum);
                        xsum++;
                        listaY.Add(ysum);
                        ysum--;
                    }
                }
                N++;
            }
            while (!(xsum >= ysum));

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

            for (int i = 0; i < ValoresX.Length; i++) //Añade los valores a las tablas
            {
                dgv_1.Rows.Add();
                dgv_1.Rows[i].Cells[0].Value = ValoresX[i] + x;
                dgv_1.Rows[i].Cells[1].Value = ValoresY[i] + y;
                dgv_1.AutoResizeColumns();
                dgv_1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                dgv_2.Rows.Add();
                dgv_2.Rows[i].Cells[0].Value = ValoresY[i] + x;
                dgv_2.Rows[i].Cells[1].Value = ValoresX[i] + y;
                dgv_2.AutoResizeColumns();
                dgv_2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                dgv_3.Rows.Add();
                dgv_3.Rows[i].Cells[0].Value = ValoresYNeg[i] + x;
                dgv_3.Rows[i].Cells[1].Value = ValoresX[i] + y;
                dgv_3.AutoResizeColumns();
                dgv_3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                dgv_4.Rows.Add();
                dgv_4.Rows[i].Cells[0].Value = ValoresX[i] + x;
                dgv_4.Rows[i].Cells[1].Value = ValoresYNeg[i] + y;
                dgv_4.AutoResizeColumns();
                dgv_4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                dgv_5.Rows.Add();
                dgv_5.Rows[i].Cells[0].Value = ValoresYNeg[i] + x;
                dgv_5.Rows[i].Cells[1].Value = ValoresXNeg[i] + y;
                dgv_5.AutoResizeColumns();
                dgv_5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                dgv_6.Rows.Add();
                dgv_6.Rows[i].Cells[0].Value = ValoresXNeg[i] + x;
                dgv_6.Rows[i].Cells[1].Value = ValoresYNeg[i] + y;
                dgv_6.AutoResizeColumns();
                dgv_6.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                dgv_7.Rows.Add();
                dgv_7.Rows[i].Cells[0].Value = ValoresXNeg[i] + x;
                dgv_7.Rows[i].Cells[1].Value = ValoresY[i] + y;
                dgv_7.AutoResizeColumns();
                dgv_7.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                dgv_8.Rows.Add();
                dgv_8.Rows[i].Cells[0].Value = ValoresY[i] + x;
                dgv_8.Rows[i].Cells[1].Value = ValoresXNeg[i] + y;
                dgv_8.AutoResizeColumns();
                dgv_8.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }

            for (int i = 0; i < ValoresY.Length; i++) //Añade líneas que conectan el centro con los puntos del círculo
            {
                FormsPlot1.Plot.Add.Line(x, y, Convert.ToDouble(dgv_1.Rows[i].Cells[0].Value), Convert.ToDouble(dgv_1.Rows[i].Cells[1].Value));
                FormsPlot1.Plot.Add.Line(x, y, Convert.ToDouble(dgv_2.Rows[i].Cells[0].Value), Convert.ToDouble(dgv_2.Rows[i].Cells[1].Value));
                FormsPlot1.Plot.Add.Line(x, y, Convert.ToDouble(dgv_3.Rows[i].Cells[0].Value), Convert.ToDouble(dgv_3.Rows[i].Cells[1].Value));
                FormsPlot1.Plot.Add.Line(x, y, Convert.ToDouble(dgv_4.Rows[i].Cells[0].Value), Convert.ToDouble(dgv_4.Rows[i].Cells[1].Value));
                FormsPlot1.Plot.Add.Line(x, y, Convert.ToDouble(dgv_5.Rows[i].Cells[0].Value), Convert.ToDouble(dgv_5.Rows[i].Cells[1].Value));
                FormsPlot1.Plot.Add.Line(x, y, Convert.ToDouble(dgv_6.Rows[i].Cells[0].Value), Convert.ToDouble(dgv_6.Rows[i].Cells[1].Value));
                FormsPlot1.Plot.Add.Line(x, y, Convert.ToDouble(dgv_7.Rows[i].Cells[0].Value), Convert.ToDouble(dgv_7.Rows[i].Cells[1].Value));
                FormsPlot1.Plot.Add.Line(x, y, Convert.ToDouble(dgv_8.Rows[i].Cells[0].Value), Convert.ToDouble(dgv_8.Rows[i].Cells[1].Value));
            }

            var c1 = FormsPlot1.Plot.Add.Circle(x, y, radio); //Añade un círculo de ejemplo
            c1.LineWidth = 0.4F;
            c1.LineColor = Colors.Black;

            //Une los valores de las columnas para crear la circunferencia del círculo con los valores de los octantes
            UnirValoresColumnas(dgv_1);
            UnirValoresColumnas(dgv_2);
            UnirValoresColumnas(dgv_3);
            UnirValoresColumnas(dgv_4);
            UnirValoresColumnas(dgv_5);
            UnirValoresColumnas(dgv_6);
            UnirValoresColumnas(dgv_7);
            UnirValoresColumnas(dgv_8);

            //Colorea los puntos finales de la circunferencia de verde
            var puntos = FormsPlot1.Plot.Add.Scatter(listaColumnaX, listaColumnaY);
            puntos.Color = Colors.Green.WithOpacity(.2);
            puntos.LineWidth = 0;
            puntos.MarkerSize = 25;

            //Escala automáticamente el gráfico para ajustarse al FormsPlot sin afectar la precisión del círculo
            FormsPlot1.Plot.Axes.AutoScale();
            FormsPlot1.Plot.Title("Círculo");
            FormsPlot1.Refresh();
        }
    }
}
