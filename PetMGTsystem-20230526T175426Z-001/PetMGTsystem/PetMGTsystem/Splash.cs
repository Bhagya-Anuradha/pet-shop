﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetMGTsystem
{
    public partial class Splash : Form
    {
        public Splash()
        {
            
            InitializeComponent();
            timer1.Start();
        }

        int startP = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startP += 1;
            MyProgress.Value = startP;
            PercentageLbl.Text = startP + "%";
            if (MyProgress.Value == 100)
            {
                MyProgress.Value = 0;
                Login Obj = new Login ();
                Obj.Show();
                this.Hide();
                timer1.Stop();
            }

        }

        
    }
}
