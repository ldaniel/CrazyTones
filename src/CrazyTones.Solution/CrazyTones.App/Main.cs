using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrazyTones.Core.Wave;

namespace CrazyTones.App
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            var waveGenerator = new WaveGenerator();
            waveGenerator.Save(@"C:\Users\Leandro Daniel\Projetos\CrazyTones\teste.wav");
        }
    }
}
