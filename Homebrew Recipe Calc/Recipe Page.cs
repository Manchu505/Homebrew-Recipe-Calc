using System;
using System.Data.OleDb;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Homebrew_Recipe_Calc
{
    public partial class frmRecipe : Form
    {
        double waterVol1;
        double waterVol2;
        double yeastFact;
        double Efficiency;
        double Efficiency1 = 0.924432289701999;
        double Efficiency2 = -0.000123500565824217;
        double[] PPG = new double[9];
        double[] Lbs = new double[9];
        double[] Attn = new double[9];
        double[] points = new double[9];
        double[] grainWt = new double[9];
        double[] percent = new double[9];
        double[] ferment = new double[9];
        double[] Lov = new double[9];
        double[] contribution = new double[9];
        double[] waterAb = new double[9];
        string[] waterAbsor = new string[9];
        double[] OGCon = new double[9];
        double[] FGCon = new double[9];
        double[] hopAB = new double[9];
        double[] lblwaterAB = new double[9];


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
        }
        private void percentChange(object sender)
        {
            try
            {
                grainWt[0] = double.Parse(txtGrainWT1.Text);
                if (grainWt[0] >= .01)
                {
                    percent[0] = grainWt[0] / grainWt.Sum();
                    lblPercent1.Text = percent[0].ToString("P2");
                }
                if (grainWt[1] >= .01)
                {
                    percent[1] = grainWt[1] / grainWt.Sum();
                    lblPercent2.Text = percent[1].ToString("P2");
                }
                if (grainWt[2] >= .01)
                {
                    percent[2] = grainWt[2] / grainWt.Sum();
                    lblPercent3.Text = percent[2].ToString("P2");
                }
                if (grainWt[3] >= .01)
                {
                    percent[3] = grainWt[3] / grainWt.Sum();
                    lblPercent4.Text = percent[3].ToString("P2");
                }
                if (grainWt[4] >= .01)
                {
                    percent[4] = grainWt[4] / grainWt.Sum();
                    lblPercent5.Text = percent[4].ToString("P2");
                }
                if (grainWt[5] >= .01)
                {
                    percent[5] = grainWt[5] / grainWt.Sum();
                    lblPercent6.Text = percent[5].ToString("P2");
                }
                if (grainWt[6] >= .01)
                {
                    percent[6] = grainWt[6] / grainWt.Sum();
                    lblPercent7.Text = percent[6].ToString("P2");
                }
                if (grainWt[7] >= .01)
                {
                    percent[7] = grainWt[7] / grainWt.Sum();
                    lblPercent8.Text = percent[7].ToString("P2");
                }
                if (grainWt[8] >= .01)
                {
                    percent[8] = grainWt[8] / grainWt.Sum();
                    lblPercent9.Text = percent[8].ToString("P2");
                }
                Efficiency = Efficiency1 + Efficiency2 * grainWt.Sum();
                txtPreEff.Text = Efficiency.ToString("P0");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                txtGrainWT1.Text = grainWt[0].ToString("0");
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
                txtGrainWT2.Text = grainWt[1].ToString("0");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cboGrain3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn;
                string query = "select * from GRAINLOOKUP where Grain='" + cboGrain3.Text + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lblPPG3.Text = reader["PPG"].ToString();
                    lblAttn3.Text = reader["Basic Attenuation"].ToString();
                    lblAff3.Text = reader["Attenuation Affected by Mash Cond?"].ToString();
                    lblLov3.Text = reader["Lovibond"].ToString();
                    lblDP3.Text = reader["DP"].ToString();
                    lblWA3.Text = reader["Absorption (ml/g)"].ToString();
                    waterAbsor[2] = reader["Absorption (ml/g)"].ToString();
                }
                conn.Close();
                txtGrainWT3.Text = grainWt[2].ToString("0");
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

                {
                    grainWt[0] = double.Parse(txtGrainWT1.Text);
                    percentChange(percent[0]);

                    Lbs[0] = grainWt[0] / 1000 * 2.20462;
                    lblLbGrain1.Text = Lbs[0].ToString("N2");

                    if (Lbs[0] >= .01)
                    {
                        PPG[0] = double.Parse(lblPPG1.Text);
                        points[0] = PPG[0] * Lbs[0];
                        lblPoi1.Text = points[0].ToString("N1");
                    }
                    if (grainWt[0] >= .01)
                    {
                        Attn[0] = double.Parse(lblAttn1.Text);
                        ferment[0] = (Attn[0] / .83) * (points[0] / points.Sum());
                        lblFer1.Text = ferment[0].ToString("N1");
                    }
                    else
                    {
                        lblFer1.Text = "0.0";
                    }
                    if (grainWt[0] >= .01)
                    {
                        Lov[0] = double.Parse(lblLov1.Text);
                        contribution[0] = 1.49 * Math.Pow((Lov[0] * Lbs[0] / waterVol1), .69);
                        lblCon1.Text = contribution[0].ToString("N1");
                    }
                    else
                    {
                        lblCon1.Text = "0.0";
                    }
                    if (grainWt[0] >= .01)
                    {
                        waterAb[0] = double.Parse(waterAbsor[0]);
                        lblwaterAB[0] = waterAb[0] * grainWt[0];
                        lblWA1.Text = lblwaterAB[0].ToString();
                    }
                    if (lblAff1.Text == "y")
                    {
                        OGCon[0] = ((points[0] * Efficiency) / waterVol2) / 1000;
                        lblOGC1.Text = OGCon[0].ToString("N3");
                    }
                    else 
                    {
                        OGCon[0] = ((points[0] + Efficiency) / waterVol2) / 1000;
                        lblOGC1.Text = OGCon[0].ToString("N3");
                    }
                    if (Attn[0] <= .010)
                    {
                        lblFGC1.Text = OGCon[0].ToString("N3");
                    }
                    else
                    {
                        FGCon[0] = OGCon[0] - (1 + OGCon[0] - 1) * yeastFact / 100;
                        lblFGC1.Text = FGCon[0].ToString("N3");
                    }
                }
            }
            
            catch (Exception)
            {
                MessageBox.Show("First Change Box Catch");
            }
        }
        private void txtGrainWT2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                    grainWt[1] = double.Parse(txtGrainWT2.Text);
                    percentChange(percent[1]);

                    Lbs[1] = grainWt[1] / 1000 * 2.20462;
                    lblLbGrain2.Text = Lbs[1].ToString("N2");

                    if (Lbs[1] >= .01)
                    {
                        PPG[1] = double.Parse(lblPPG2.Text);
                        points[1] = PPG[1] * Lbs[1];
                        lblPoi2.Text = points[1].ToString("N1");
                    }
                    if (grainWt[1] >= .01)
                    {
                        Attn[1] = double.Parse(lblAttn2.Text);
                        ferment[1] = (Attn[1] / .83) * (points[1] / points.Sum());
                        lblFer2.Text = ferment[1].ToString("N1");
                    }
                    else
                    {
                        lblFer2.Text = "0.0";
                    }
                    if (grainWt[1] >= .01)
                    {
                        Lov[1] = double.Parse(lblLov2.Text);
                        contribution[1] = 1.49 * Math.Pow((Lov[1] * Lbs[1] / waterVol1), .69);
                        lblCon2.Text = contribution[1].ToString("N1");
                    }
                    else
                    {
                        lblCon2.Text = "0.0";
                    }
                    if (grainWt[1] >= .01)
                    {
                        waterAb[1] = double.Parse(waterAbsor[1]);
                        lblwaterAB[1] = waterAb[1] * grainWt[1];
                        lblWA2.Text = lblwaterAB[1].ToString();
                    }
                    if (lblAff2.Text == "y")
                    {
                        OGCon[1] = ((points[1] * Efficiency) / waterVol2) / 1000;
                        lblOGC2.Text = OGCon[1].ToString("N3");
                    }
                    else
                    {
                        OGCon[1] = ((points[1] + Efficiency) / waterVol2) / 1000;
                        lblOGC2.Text = OGCon[1].ToString("N3");
                    }
                    if (Attn[1] <= .010)
                    {
                        lblFGC2.Text = OGCon[1].ToString("N3");
                    }
                    else
                    {
                        FGCon[1] = OGCon[1] - (1 + OGCon[1] - 1) * yeastFact / 100;
                        lblFGC2.Text = FGCon[1].ToString("N3");
                    }

            }
            catch (Exception)
            {
                MessageBox.Show("Second Change Box Catch");
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
                
                // for (p = 0; p <= 0; p++)
            {
             // MessageBox.Show("Loop");
            }
            // catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Close Button
            this.Close();
        }

        private void txtYeastFactor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                yeastFact = double.Parse(txtYeastFactor.Text);
            }
            catch (Exception) { }

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Close Button
            this.Close();
        }

        private void aBVCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calcABV ABVC = new calcABV();
            ABVC.Show();

        }

        private void txtGrainWT3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                grainWt[2] = double.Parse(txtGrainWT3.Text);
                percentChange(percent[2]);

                Lbs[2] = grainWt[2] / 1000 * 2.20462;
                lblLbGrain3.Text = Lbs[2].ToString("N2");

                if (Lbs[2] >= .01)
                {
                    PPG[2] = double.Parse(lblPPG3.Text);
                    points[2] = PPG[2] * Lbs[2];
                    lblPoi3.Text = points[2].ToString("N1");
                }
                if (grainWt[2] >= .01)
                {
                    Attn[2] = double.Parse(lblAttn3.Text);
                    ferment[2] = (Attn[2] / .83) * (points[2] / points.Sum());
                    lblFer3.Text = ferment[2].ToString("N1");
                }
                else
                {
                    lblFer3.Text = "0.0";
                }
                if (grainWt[2] >= .01)
                {
                    Lov[2] = double.Parse(lblLov3.Text);
                    contribution[2] = 1.49 * Math.Pow((Lov[2] * Lbs[2] / waterVol1), .69);
                    lblCon3.Text = contribution[2].ToString("N1");
                }
                else
                {
                    lblCon3.Text = "0.0";
                }
                if (grainWt[2] >= .01)
                {
                    waterAb[2] = double.Parse(waterAbsor[2]);
                    lblwaterAB[2] = waterAb[2] * grainWt[2];
                    lblWA3.Text = lblwaterAB[2].ToString();
                }
                if (lblAff3.Text == "y")
                {
                    OGCon[2] = ((points[2] * Efficiency) / waterVol2) / 1000;
                    lblOGC3.Text = OGCon[2].ToString("N3");
                }
                else
                {
                    OGCon[2] = ((points[2] + Efficiency) / waterVol2) / 1000;
                    lblOGC3.Text = OGCon[2].ToString("N3");
                }
                if (Attn[2] <= .010)
                {
                    lblFGC3.Text = OGCon[2].ToString("N3");
                }
                else
                {
                    FGCon[2] = OGCon[2] - (1 + OGCon[2] - 1) * yeastFact / 100;
                    lblFGC3.Text = FGCon[2].ToString("N3");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Third Change Box Catch");
            }
        }

        private void txtGrainWT4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                grainWt[3] = double.Parse(txtGrainWT4.Text);
                percentChange(percent[3]);

                Lbs[3] = grainWt[3] / 1000 * 2.20462;
                lblLbGrain4.Text = Lbs[3].ToString("N2");

                if (Lbs[3] >= .01)
                {
                    PPG[3] = double.Parse(lblPPG4.Text);
                    points[3] = PPG[3] * Lbs[3];
                    lblPoi4.Text = points[3].ToString("N1");
                }
                if (grainWt[3] >= .01)
                {
                    Attn[3] = double.Parse(lblAttn4.Text);
                    ferment[3] = (Attn[3] / .83) * (points[3] / points.Sum());
                    lblFer4.Text = ferment[3].ToString("N1");
                }
                else
                {
                    lblFer4.Text = "0.0";
                }
                if (grainWt[3] >= .01)
                {
                    Lov[3] = double.Parse(lblLov4.Text);
                    contribution[3] = 1.49 * Math.Pow((Lov[3] * Lbs[3] / waterVol1), .69);
                    lblCon4.Text = contribution[3].ToString("N1");
                }
                else
                {
                    lblCon4.Text = "0.0";
                }
                if (grainWt[3] >= .01)
                {
                    waterAb[3] = double.Parse(waterAbsor[3]);
                    lblwaterAB[3] = waterAb[3] * grainWt[3];
                    lblWA4.Text = lblwaterAB[3].ToString();
                }
                if (lblAff4.Text == "y")
                {
                    OGCon[3] = ((points[3] * Efficiency) / waterVol2) / 1000;
                    lblOGC4.Text = OGCon[3].ToString("N3");
                }
                else
                {
                    OGCon[3] = ((points[3] + Efficiency) / waterVol2) / 1000;
                    lblOGC4.Text = OGCon[3].ToString("N3");
                } 
                if (Attn[3] <= .010)
                {
                    lblFGC4.Text = OGCon[3].ToString("N3");
                }
                else
                {
                    FGCon[3] = OGCon[3] - (1 + OGCon[3] - 1) * yeastFact / 100;
                    lblFGC4.Text = FGCon[3].ToString("N3");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Fourth Change Box Catch");
            }
        }

        private void cboGrain4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn;
                string query = "select * from GRAINLOOKUP where Grain='" + cboGrain4.Text + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lblPPG4.Text = reader["PPG"].ToString();
                    lblAttn4.Text = reader["Basic Attenuation"].ToString();
                    lblAff4.Text = reader["Attenuation Affected by Mash Cond?"].ToString();
                    lblLov4.Text = reader["Lovibond"].ToString();
                    lblDP4.Text = reader["DP"].ToString();
                    lblWA4.Text = reader["Absorption (ml/g)"].ToString();
                    waterAbsor[3] = reader["Absorption (ml/g)"].ToString();
                }
                conn.Close();
                txtGrainWT4.Text = grainWt[3].ToString("0");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtWaterVolume_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                double waVolume = double.Parse(txtWaterVolume.Text);
                waterVol2 = (waVolume + /*hopAb[].Sum() */ 90) / 1000 * .264172;
                txtWaterFinishGal.Text = waterVol2.ToString("N2");

                double waterToAddFinal = (lblwaterAB.Sum() + /*hopAB.Sum()*/ 90 + waVolume);
                txtWaterToAdd.Text = waterToAddFinal.ToString();

                waterVol1 = waterToAddFinal / 1000 * .264172;
                txtWaterToAddGal.Text = waterVol1.ToString("N2");

                
            }
            catch (Exception) { }
        }
    }
}

