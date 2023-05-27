using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace PetMGTsystem
{
    public partial class Login : Form
    {
        internal static readonly String Employee;

        public Login()
        {
            InitializeComponent();
        }


        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\PetShopDb.mdf;Integrated Security = True; Connect Timeout = 30");
       
        
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void Login_Click(object sender, EventArgs e)
        {
           if(RoleCb.SelectedIndex == -1)
            {
                MessageBox.Show("Select The Role");

            }
           else if (RoleCb.SelectedIndex == 0)
            {
                if (UnameTb.Text == "" || PassTb.Text == "")
                {
                    MessageBox.Show("Enter Both Employee Name and Password");

                }
                else
                {
                    Con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select count(*) from EmployeeTbl where EmpName='" + UnameTb.Text + "' and EmpPass='" + PassTb.Text + "'", Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() =="1" )
                    {
                        Homes Obj = new Homes();
                        Obj.Show();
                        this.Hide();
                        Con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Wrong UserName or Password");
                        UnameTb.Text = "";
                        PassTb.Text = "";

                    }
                    Con.Close();
                }
            }
           else
            {
                if (UnameTb.Text == "" || PassTb.Text == "")
                {
                    MessageBox.Show("Enter Both Employee Name and Password");

                }
               
                    else
                    {
                        Con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("select count(*) from EmployeeTbl where EmpName='" + UnameTb.Text + "' and EmpPass='" + PassTb.Text + "'", Con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            Homes Obj = new Homes();
                            Obj.Show();
                            this.Hide();
                            Con.Close();
                        }
                        else
                        {
                            MessageBox.Show("Wrong Employee Name or Password");
                            UnameTb.Text = "";
                            PassTb.Text = "";

                        }
                        Con.Close();
                    }
                
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            UnameTb.Text = "";
            PassTb.Text  = "";
            RoleCb.SelectedIndex =  -1;
            RoleCb.Text = "Role";

        }

        
    }
}
