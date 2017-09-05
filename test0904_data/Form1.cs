using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test0904_data {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            da.Fill(ds);
        }

        private void button2_Click(object sender, EventArgs e) {
            da.Update(ds);
            //如果dr.RowState是unchanged=>不會Update
        }

        private void button3_Click(object sender, EventArgs e) {
            ds.WriteXml(@"D:\lab\test0904_data\music.xml", XmlWriteMode.DiffGram);
        }

        private void button4_Click(object sender, EventArgs e) {
            ds.ReadXml(@"D:\lab\test0904_data\music.xml");
        }

        private void button5_Click(object sender, EventArgs e) {

            int iRow = bindingSource1.Position;
            
            //DataTable dt = ds.Tables["Title"];
            //DataRow dr = dt.Rows[0];
            //textBox2.Text = dr["Song"].ToString();
            //textBox2.Text = ds.Tables["Title"].Rows[0]["Song"].ToString();

            MusicDataSet.TitleDataTable dt = ds.Title;
            MusicDataSet.TitleRow dr = dt[iRow];
            textBox2.Text = dr.Song;
            // textBox2.Text = ds.Title[0].Song;
        }

        private void bindingSource1_PositionChanged(object sender, EventArgs e) {
            int iRow = bindingSource1.Position;
            MusicDataSet.TitleDataTable dt = ds.Title;
            MusicDataSet.TitleRow dr = dt[iRow];
            textBox2.Text = dr.Song;
        }

        private void button6_Click(object sender, EventArgs e) {
            //DataTable dt = ds.Tables["Title"];
            //DataRow dr = dt.NewRow();
            //dr["SongID"] = "S000";
            //dr["Song"] = "S000 name";
            //dt.Rows.Add(dr);

            MusicDataSet.TitleRow dr = ds.Title.NewTitleRow();
            dr.SongID = "S999";
            ds.Title.AddTitleRow(dr);
        }

        private void button7_Click(object sender, EventArgs e) {
            int iRow = bindingSource1.Position;
            ds.Title[iRow].Delete();
            MessageBox.Show(ds.Title[iRow].RowState.ToString());
            // ds.Title.Rows.RemoveAt(iRow);
        }

        private void button8_Click(object sender, EventArgs e) {
            //復原.不改變
            // ds.RejectChanges();
            // ds.Title.RejectChanges();
            ds.Title[0].RejectChanges();
        }

        private void button9_Click(object sender, EventArgs e) {
            DataRow dr = ds.Title[0];
            label1.Text = string.Format("{0}\n{1}\n{2}",
                dr["Song"],
                dr["Song", DataRowVersion.Original],
                dr.RowState);
        }

        private void button10_Click(object sender, EventArgs e) {
            //改變原值Original
            ds.Title[0].AcceptChanges();
        }

    }
}
