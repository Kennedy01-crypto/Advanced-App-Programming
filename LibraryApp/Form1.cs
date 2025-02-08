using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace LibraryApp
{
    partial class Form1 : Form
    {
        private List<Book> books = new List<Book>();
        private TextBox txtTitle, txtAuthor, txtPrice, txtBookNum, txtCopies;
        private ListView lstBooks;

        public Form1()
        {
            this.Text = "Library Inventory";
            this.Width = 500;
            this.Height = 500;
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeUI();
        }

        private void InitializeUI()
        {
            this.BackColor = Color.White;

            Label lblTitle = new Label() { Text = "Title:", Left = 10, Top = 20, Width = 100 };
            txtTitle = new TextBox() { Left = 120, Top = 20, Width = 300 };

            Label lblAuthor = new Label() { Text = "Author:", Left = 10, Top = 50, Width = 100 };
            txtAuthor = new TextBox() { Left = 120, Top = 50, Width = 300 };

            Label lblPrice = new Label() { Text = "Price:", Left = 10, Top = 80, Width = 100 };
            txtPrice = new TextBox() { Left = 120, Top = 80, Width = 300 };

            Label lblBookNum = new Label() { Text = "Book Number:", Left = 10, Top = 110, Width = 100 };
            txtBookNum = new TextBox() { Left = 120, Top = 110, Width = 300 };

            Label lblCopies = new Label() { Text = "Copies:", Left = 10, Top = 140, Width = 100 };
            txtCopies = new TextBox() { Left = 120, Top = 140, Width = 300 };

            Button btnAdd = new Button() { Text = "Add Book", Left = 10, Top = 180, Width = 100 };
            btnAdd.Click += BtnAdd_Click;

            Button btnShow = new Button() { Text = "Show Books", Left = 120, Top = 180, Width = 100 };
            btnShow.Click += BtnShow_Click;

            // ListView for a neat display
            lstBooks = new ListView()
            {
                Left = 10,
                Top = 220,
                Width = 450,
                Height = 200,
                View = View.Details,  
                FullRowSelect = true,  
                GridLines = true       
            };

            // Adding columns to ListView
            lstBooks.Columns.Add("Title", 120);
            lstBooks.Columns.Add("Author", 100);
            lstBooks.Columns.Add("Price ($)", 80);
            lstBooks.Columns.Add("Book #", 80);
            lstBooks.Columns.Add("Copies", 60);

            // Adding UI components to the form
            this.Controls.Add(lblTitle);
            this.Controls.Add(txtTitle);
            this.Controls.Add(lblAuthor);
            this.Controls.Add(txtAuthor);
            this.Controls.Add(lblPrice);
            this.Controls.Add(txtPrice);
            this.Controls.Add(lblBookNum);
            this.Controls.Add(txtBookNum);
            this.Controls.Add(lblCopies);
            this.Controls.Add(txtCopies);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnShow);
            this.Controls.Add(lstBooks);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                books.Add(new Book(txtTitle.Text, txtAuthor.Text, double.Parse(txtPrice.Text),
                                   txtBookNum.Text, int.Parse(txtCopies.Text)));

                MessageBox.Show("Book added successfully!");
                txtTitle.Clear(); txtAuthor.Clear(); txtPrice.Clear();
                txtBookNum.Clear(); txtCopies.Clear();
            }
            catch
            {
                MessageBox.Show("Invalid input! Please enter correct data.");
            }
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            lstBooks.Items.Clear();
            foreach (var book in books)
            {
                ListViewItem item = new ListViewItem(new[]
                {
                    book.Title,
                    book.Author,
                    book.Price.ToString("F2"),
                    book.BookNumber,
                    book.Copies.ToString()
                });

                lstBooks.Items.Add(item);
            }
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string BookNumber { get; set; }
        public int Copies { get; set; }

        public Book(string title, string author, double price, string bookNumber, int copies)
        {
            Title = title;
            Author = author;
            Price = price;
            BookNumber = bookNumber;
            Copies = copies;
        }
    }
}
