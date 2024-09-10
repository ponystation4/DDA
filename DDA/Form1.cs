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
        // Create an instance of a FormsPlot like this
        readonly FormsPlot FormsPlot1 = new FormsPlot() { Dock = DockStyle.Fill };
        public Form1()
        {
            InitializeComponent();
            // Add the FormsPlot to the panel
            panel1.Controls.Add(FormsPlot1);

            // Plot data using the control
            double[] dataX = { 1, 2, 3, 4, 5 };
            double[] dataY = { 1, 2, 3, 4, 5 };

            FormsPlot1.Plot.Add.Scatter(dataX, dataY);
            FormsPlot1.Refresh();
        }
    }
}
