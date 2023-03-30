using System;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

namespace Homebrew_Recipe_Calc
{
    public partial class frmRecipe : Form
    {
        int p = 0;
        double[] PPG = new double[9];
        double[] Lbs = new double[9];
        double[] Attn = new double[9];
        double[] points = new double[9];
        double[] grainWt = new double[9];
        double[] percent = new double[9];
        double[] ferment = new double[9];
        double[] waterVol = new double[9];
        double[] Lov = new double[9];
        double[] contribution = new double[9];
        double[] waterAb = new double[9];
        string[] waterAbsor = new string[9];
        double Efficiency1 = 0.924432289701999;
        double Efficiency2 = -0.000123500565824217;
        double Efficiency;
        double[] OGCon = new double[9];
        double[] FGCon = new double[9];
        double[] yeastFact = new double[9];




        double grainWt1;
        double grainWt2;
        double grainWt3;
        double grainWt4;
        double grainWt5;
        double grainWt6;
        double grainWt7;
        double grainWt8;
        double grainWt9;
        double points1 = 16.3;
        double points2;
        double points3;
        double points4;
        double points5;
        double points6;
        double points7;
        double points8;
        double points9;




        public frmRecipe()
        {
            InitializeComponent();
        }

        OleDbConnection conn;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                var DBPath = Application.StartupPath + "\\Access_ingredients.accdb";
                conn = new OleDbConnection("provider = Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + DBPath);

                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn;
                string query = "select * from GRAINLOOKUP";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cboGrain1.Items.Add(reader["Grain"].ToString());
                    cboGrain2.Items.Add(reader["Grain"].ToString());
                    cboGrain3.Items.Add(reader["Grain"].ToString());
                    cboGrain4.Items.Add(reader["Grain"].ToString());
                    cboGrain5.Items.Add(reader["Grain"].ToString());
                    cboGrain6.Items.Add(reader["Grain"].ToString()); 
                    cboGrain7.Items.Add(reader["Grain"].ToString());
                    cboGrain8.Items.Add(reader["Grain"].ToString());
                    cboGrain9.Items.Add(reader["Grain"].ToString());

                }
                label34.Text = "Connection Successful";
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtGrainWT1.Text = "0";
            txtGrainWT2.Text = "0";
            txtGrainWT3.Text = "0";
            txtGrainWT4.Text = "0";
            txtGrainWT5.Text = "0";
            txtGrainWT6.Text = "0";
            txtGrainWT7.Text = "0";
            txtGrainWT8.Text = "0";
            txtGrainWT9.Text = "0";
            lblLbGrain1.Text = "0.00";
            lblLbGrain2.Text = "0.00";
            lblLbGrain3.Text = "0.00";
            lblLbGrain4.Text = "0.00";
            lblLbGrain5.Text = "0.00";
            lblLbGrain6.Text = "0.00";
            lblLbGrain7.Text = "0.00";
            lblLbGrain8.Text = "0.00";
            lblLbGrain9.Text = "0.00";
            lblPercent1.Text = "0.00";
            lblPercent2.Text = "0.00";
            lblPercent3.Text = "0.00";
            lblPercent4.Text = "0.00";
            lblPercent5.Text = "0.00";
            lblPercent6.Text = "0.00"; 
            lblPercent7.Text = "0.00";
            lblPercent8.Text = "0.00";
            lblPercent9.Text = "0.00";


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn;
                string query = "select * from GRAINLOOKUP where Grain='" + cboGrain1.Text + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lblPPG1.Text = reader["PPG"].ToString();
                    lblAttn1.Text = reader["Basic Attenuation"].ToString();
                    lblAff1.Text = reader["Attenuation Affected by Mash Cond?"].ToString();
                    lblLov1.Text = reader["Lovibond"].ToString();
                    lblDP1.Text = reader["DP"].ToString();
                    lblWA1.Text = reader["Absorption (ml/g)"].ToString();
                    waterAbsor[0] = reader["Absorption (ml/g)"].ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn;
                string query = "select * from GRAINLOOKUP where Grain='" + cboGrain2.Text + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lblPPG2.Text = reader["PPG"].ToString();
                    lblAttn2.Text = reader["Basic Attenuation"].ToString();
                    lblAff2.Text = reader["Attenuation Affected by Mash Cond?"].ToString();
                    lblLov2.Text = reader["Lovibond"].ToString();
                    lblDP2.Text = reader["DP"].ToString();
                    lblWA2.Text = reader["Absorption (ml/g)"].ToString();
                    waterAbsor[1] = reader["Absorption (ml/g)"].ToString();
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtGrainWT1_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                grainWt[0] = double.Parse(txtGrainWT1.Text);
                Lbs[0] = grainWt[0] / 1000 * 2.20462;
                lblLbGrain1.Text = Lbs[0].ToString("N2");
                PPG[0] = double.Parse(lblPPG1.Text);
                points[0] = PPG[0] * Lbs[0];
                lblPoi1.Text = points[0].ToString("N1");
                Attn[0] = double.Parse(lblAttn1.Text);
                ferment[0] = (Attn[0] / .83) * (points[0] / points.Sum());
                lblFer1.Text = ferment[0].ToString("N1");

                percent[0] = grainWt[0] / grainWt.Sum();
                lblPercent1.Text = percent[0].ToString("P2");

                percent[1] = grainWt[1] / grainWt.Sum();
                lblPercent2.Text = percent[1].ToString("P2");

                percent[2] = grainWt[2] / grainWt.Sum();
                lblPercent3.Text = percent[2].ToString("P2");

                Lov[0] = double.Parse(lblLov1.Text);
                contribution[0] = 1.49 * Math.Pow((Lov[0] * Lbs[0] / waterVol[0]), .69);
                lblCon1.Text = contribution[0].ToString("N1");

                waterAb[0] = double.Parse(waterAbsor[0]);
                double waterAb1 = waterAb[0] * grainWt[0];
                lblWA1.Text = waterAb1.ToString();

                if (lblAff1.Text == "y")
                {
                    OGCon[0] = ((points[0] * Efficiency) / waterVol[0]) / 1000;
                    lblOGC1.Text = OGCon[0].ToString("N3");
                }
                else //if (lblAff1.Text == "n")
                {
                    OGCon[0] = ((points[0] + Efficiency) / waterVol[0]) / 1000;
                    lblOGC1.Text = OGCon[0].ToString("N3");
                }
                if (Attn[0] <= 0)
                {
                    lblFGC1.Text = OGCon[0].ToString("N3");
                }
                else
                {
                    FGCon[0] = OGCon[0] - (1 + OGCon[0] - 1) * yeastFact[0] / 100;
                    lblFGC1.Text = FGCon[0].ToString("N3");
                }

                Efficiency = Efficiency1 + Efficiency2 * grainWt.Sum();
                txtPreEff.Text = Efficiency.ToString("P0");
            }
            catch (Exception)
            {
                //MessageBox.Show("Enter a Valid Weight");
            }
        }
        private void txtGrainWT2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                grainWt[1] = double.Parse(txtGrainWT2.Text);
                Lbs[1] = grainWt[1] / 1000 * 2.20462;
                lblLbGrain2.Text = Lbs[1].ToString("N2");
                PPG[1] = double.Parse(lblPPG2.Text);
                points[1] = PPG[1] * Lbs[1];
                lblPoi2.Text = points[1].ToString("N1");
                Attn[1] = double.Parse(lblAttn2.Text);
                ferment[1] = (Attn[1] / .83) * (points[1] / points.Sum());
                lblFer2.Text = ferment[1].ToString("N1");

                percent[0] = grainWt[0] / grainWt.Sum();
                lblPercent1.Text = percent[0].ToString("P2");

                percent[1] = grainWt[1] / grainWt.Sum();
                lblPercent2.Text = percent[1].ToString("P2");

                percent[2] = grainWt[2] / grainWt.Sum();
                lblPercent3.Text = percent[2].ToString("P2");
                Lov[1] = double.Parse(lblLov2.Text);
                contribution[1] = 1.49 * Math.Pow((Lov[1] * Lbs[1] / waterVol[0]), .69);
                lblCon2.Text = contribution[1].ToString("N1");

                waterAb[1] = double.Parse(waterAbsor[1]);
                double waterAb1 = waterAb[1] * grainWt[1];
                lblWA2.Text = waterAb1.ToString();

                double Efficiency = Efficiency1 + Efficiency2 * grainWt.Sum();
                txtPreEff.Text = Efficiency.ToString("P0");
            }
            catch (Exception)
            {
                //MessageBox.Show("something is wrong");

            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            //double Efficiency = Efficiency1 + Efficiency2 * grainWt.Sum();
            //label10.Text = Efficiency.ToString();


            //double sum1 = points[0] / (points[0]+ points[1]);
            //double tpoints = points[1]/points.Sum();
            //waterAbsor[0] = double.Parse(lblWA1.Text);
            //double waterAb = waterAbsor[0] * grainWt[0];
            //label10.Text = waterAb.ToString();
            //label3.Text = waterAbsor[0].ToString();
            //Attn[1].ToString(); //tpoints.ToString();


            //for (p = 0; p <= 0; p++)
            {
                // MessageBox.Show("Loop");
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Close Button
            this.Close();
        }

        private void txtWaterVolume_TextChanged(object sender, EventArgs e)
        {

            try
            {
                // Update Formula
                txtWaterToAdd.Text = txtWaterVolume.Text;
                double GalVolume = double.Parse(txtWaterToAdd.Text);
                waterVol[0] = (GalVolume / 1000 * .264172d);
                txtWaterToAddGal.Text = waterVol[0].ToString("N2");
            }
            catch (Exception)
            { }


        }

        private void txtYeastFactor_TextChanged(object sender, EventArgs e)
        {
           yeastFact[0] = double.Parse(txtYeastFactor.Text);

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Close Button
            this.Close();
        }

        private void aBVCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //ABV_Calc ABVForm = new ABV_Calc;
                //designRecipe designRecipe = new designRecipe(beerName.Text);
            //designRecipe.Show();
           
        }
    }
}
