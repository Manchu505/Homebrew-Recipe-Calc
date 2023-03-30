using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homebrew_Recipe_Calc
{
    public partial class splashScreen : Form
    {
        public splashScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmRecipe recipe = new frmRecipe();
            recipe.ShowDialog();
            this.Close();
        }
    }
}
