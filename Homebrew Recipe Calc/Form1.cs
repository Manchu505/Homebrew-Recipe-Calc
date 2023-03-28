using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

namespace Homebrew_Recipe_Calc
{
    public partial class Form1 : Form
    {
        int p = 0;
        double[] PPG = new double [9];
        double[] Lbs = new double[9];
        double[] Attn = new double[9];
        double[] points = new double[9];
        
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




        public Form1()
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


                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void txtGrainWT1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn;
                string query = "select * from GRAINLOOKUP where Grain='" + cboGrain2.Text + "'";
                // double query1 = "select * from GRAINLOOKUP where Grain='" + comboBox2.Text + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    label33.Text = reader["PPG"].ToString();
                    label35.Text = reader["Basic Attenuation"].ToString();
                    label36.Text = reader["Lovibond"].ToString();
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtGrainWT2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Close Button
            this.Close();
        }

        private void txtGrainWT1_TextChanged_1(object sender, EventArgs e)
        {
            double num1;
            double num2;
            double num3;
            double num4;
            double tpoints = points.Sum();                //points[0 + 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8];

            try
            {
                {

                    if (cboGrain1.Text != "")
                    {
                        grainWt1 = double.Parse(txtGrainWT1.Text);
                        double lbs1 = grainWt1 / 1000 * 2.20462;
                        lblLbGrain1.Text = lbs1.ToString("N2");
                        PPG = new double[] { double.Parse(lblPPG1.Text) };
                        Lbs = new double[] { double.Parse(lblLbGrain1.Text) };
                        points = new double[] { PPG[0] * Lbs[0] };
                        lblPoi1.Text = points[0].ToString("N1");
                        Attn = new double[] { double.Parse(lblAttn1.Text) };
                        double ferm1 = (Attn[0] / .83) * (points[0] / points.Sum());
                        lblFer1.Text = ferm1.ToString();

                    }
                    else
                    {

                    }
                    if (cboGrain2.Text != "")
                    {
                        grainWt2 = double.Parse(txtGrainWT2.Text);
                        double lbs2 = grainWt2 / 1000 * 2.20462;
                        lblGrain2.Text = lbs2.ToString("N2");
                    }

                    else
                    {

                    }
                    if (grainWt9 <= 0 && grainWt1 > 0)
                    {
                        double percent1 = grainWt1 / (grainWt1 + grainWt2 + grainWt3 + grainWt4 + grainWt5);
                        lblPercent1.Text = percent1.ToString("P2");
                        // if (grainWt2 > 0)
                    }
                        if (grainWt9 <= 0 && grainWt2 >0)
                    {
                        double percent2 = grainWt2 / (grainWt1 + grainWt2 + grainWt3 + grainWt4 + grainWt5);
                        lblPercent2.Text = percent2.ToString("P2");
                    }
                            


                    } 
            }
            catch (Exception)
            {
                //MessageBox.Show("Enter a Valid Weight");
            }
            /*try
            {
                if (comboBox2.Text != "")
                {
                    grainWt2 = double.Parse(txtGrainWT2.Text);
                    double lbs2 = grainWt2 / 1000 * 2.20462;
                    lblGrain2.Text = lbs2.ToString("N2");
                    double percent2 = grainWt2 / (grainWt1 + grainWt2 + grainWt3 + grainWt4 + grainWt5);
                    lblPercent2.Text = percent2.ToString("P2");
                }
                else
                {
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Enter a Valid Weight");

            }*/
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //double sum1 = points[0] / (points[0]+ points[1]);
            double tpoints = points[0]/points.Sum();
            label10.Text = tpoints.ToString();
            

            //for (p = 0; p <= 0; p++)
            {
               // MessageBox.Show("Loop");
            }

        }
    }
}
