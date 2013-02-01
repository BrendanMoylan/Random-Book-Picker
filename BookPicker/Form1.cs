using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace BookPicker
{
    public partial class Form1 : Form
    {
        ArrayList bookList;
        int i = 0;
        Random rand;
        int randomNum;
        String line;
        StreamReader sr;
        StreamWriter sw;
        string bookToRemove;

        public Form1()
        {
            InitializeComponent();
            bookList = new ArrayList();
            rand = new Random();
            sr = new StreamReader("books.txt");

            while ((line = sr.ReadLine()) != null)
            {
                bookList.Add(line);
            }

            sr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            randomNum = rand.Next(0, bookList.Count);
            textBox2.Text = (string)bookList[randomNum];
            bookToRemove = (string)bookList[randomNum];
            bookList.Remove(bookToRemove);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bookList.Add(textBox1.Text);
            writeFile();
        }

        public void writeFile()
        {
            sw = new StreamWriter("books.txt");
            for (int i = 0; i < bookList.Count; i++)
            {
                sw.WriteLine(bookList[i]);
            }
            sw.Close();
        }
    }
}
