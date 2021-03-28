using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buran
{
    public partial class buranForm : Form
    {
        private SLOBSLocal mySlobs;
        private string apiSecret;
        public buranForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mySlobs = new SLOBSLocal();
            apiSecret = "syke you thought";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mySlobs.authRequest(apiSecret);
            
            foreach(String s in mySlobs.getScenes())
            {
                MessageBox.Show(s);
                mySlobs.switchToScene(s);
            }

        }
    }
}
