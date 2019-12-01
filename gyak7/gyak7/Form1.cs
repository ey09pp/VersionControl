using gyak7.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gyak7
{
    public partial class Form1 : Form
    {

        BindingList<User> users = new BindingList<User>();

        public Form1()
        {
            InitializeComponent();

            label1.Text = Resource1.FullName; // label1
           
            button1.Text = Resource1.Add; // button1
            button2.Text = Resource1.write;
            button3.Text = Resource1.delete;


            // listbox1
            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBox1.Text,
                
            };
            users.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog () == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName);

                foreach (var u in users)
                {
                    sw.Write(u.ID);
                    sw.Write(";");
                    sw.Write(u.FullName);
                    sw.WriteLine();

                }

                sw.Close();

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var törlendő = (from x in users
                            where x.ID == (Guid)listUsers.SelectedValue
                            select x).FirstOrDefault();
            users.Remove(törlendő);
            
            listUsers.DataSource = users;


        }
    }
}
