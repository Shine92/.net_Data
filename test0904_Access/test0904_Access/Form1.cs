using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test0904_Access {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            da.Fill(ds);
        }

        private void button2_Click(object sender, EventArgs e) {
            da.Update(ds);
        }

        private void button3_Click(object sender, EventArgs e) {
            ds.WriteXml(@"C:\temp\music.xml", XmlWriteMode.DiffGram);
        }

        private void button4_Click(object sender, EventArgs e) {
            ds.ReadXml(@"C:\temp\music.xml");
        }

        private void button5_Click(object sender, EventArgs e) {
            textBox2.Text = "OK";
        }
    }
}
