using FileIOApp;
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

namespace FileIOAppGUI
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            String[] args = { };
            InitializeComponent();
            //FileIOApp.Program.Main(args);
            string firstName = Console.ReadLine();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            string URL = URLtextBox.Text;
            string fullName = $"{firstName} {lastName}";

            string[] item = { fullName, URL };

            listBox1.Items.Add(string.Join(", ", item));
        }

        private void SaveToFile(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (string item in listBox1.Items)
                {
                    sw.WriteLine(item);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveToFile("listbox_items.txt");
        }

        private void LoadFromFile(string fileName)
        {
            listBox1.Items.Clear();

            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    listBox1.Items.Add (line);
                }
            }
        }

        private void loadFileButton_Click(object sender, EventArgs e)
        {
            LoadFromFile("listbox_items.txt");
        }

        private void DeleteFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteFile("listbox_items.txt"); // delete the file 

            listBox1.Items.Clear (); // remove all items from the listbox
        }
    }
}
