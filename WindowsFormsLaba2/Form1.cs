using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyClassLibrary;
using System.Threading;
using System.IO;

namespace WindowsFormsLaba2
{
    public partial class Form1 : Form
    {
        Magazine _newMagazine = null;
        Book _newBook = null;
        ClassBook _newClassBook = null;

        public Form1()
        {
            InitializeComponent();
            _newMagazine = Magazine.GetSettings();
            _newBook = Book.GetSettings();
            _newClassBook = ClassBook.GetSettings();
        }
        private int waitOperation()
        {
            int count = 0;
            Thread.Sleep(2000);
            return count;
        }
        private async void waitXML(string alertProcess, string alertSuccess)
        {
            Task<int> task1 = new Task<int>(waitOperation);
            task1.Start();
            lblAlert.Text = alertProcess;
            await task1;
            lblAlert.Text = alertSuccess;

            Task<int> task2 = new Task<int>(waitOperation);
            task2.Start();
            await task2;
            lblAlert.Hide();
        }

        private void saveMagazXML_Click(object sender, EventArgs e)
        {          
            _newMagazine.PublicationName = fldMagazName.Text;
            _newMagazine.Month = fldMagazMonth.Text;
            _newMagazine.No = int.Parse(fldMagazNo.Text);
            _newMagazine.NumberOfPages = int.Parse(fldMagazPages.Text);
            _newMagazine.PublishingHouseName = fldMagazHouse.Text;
            _newMagazine.PublishingYear = int.Parse(fldMagazYear.Text);
            _newMagazine.Edition = int.Parse(fldMagazEdit.Text);        
            _newMagazine.Save();

            waitXML("Сохранение в XML. Пожалуйста, подождите...", "Успешно. XML сохранен");
        }

        private void uploadMagazXML_Click(object sender, EventArgs e)
        {

            waitXML("Загрузка XML. Пожалуйста, подождите...", "XML успешно загружен");           
            fldMagazName.Text = _newMagazine.PublicationName;
            fldMagazMonth.Text = _newMagazine.Month;
            fldMagazNo.Text = _newMagazine.No.ToString();
            fldMagazPages.Text = _newMagazine.NumberOfPages.ToString();
            fldMagazHouse.Text = _newMagazine.PublishingHouseName;
            fldMagazYear.Text = _newMagazine.PublishingYear.ToString();
            fldMagazEdit.Text = _newMagazine.Edition.ToString();          
        }

        private void saveBookXML_Click(object sender, EventArgs e)
        {
            _newBook.PublicationName = fldBookName.Text;
            _newBook.Author = fldBookAuthor.Text;
            _newBook.Genre = fldBookGenre.Text;
            _newBook.Seria = fldBookSeria.Text;
            _newBook.Language = fldBookLanguage.Text;
            _newBook.Translator = fldBookTranslator.Text;
            _newBook.PublishingHouseName = fldBookHouse.Text;
            _newBook.PublishingYear = int.Parse(fldBookYear.Text);
            _newBook.Edition = int.Parse(fldBookEdit.Text);
            _newBook.Save();

            waitXML("Сохранение в XML. Пожалуйста, подождите...", "Успешно. XML сохранен"); ;

        }

        private void uploadBookXML_Click(object sender, EventArgs e)
        {
            waitXML("Загрузка XML. Пожалуйста, подождите...", "XML успешно загружен");
            fldBookName.Text = _newBook.PublicationName;
            fldBookAuthor.Text = _newBook.Author;
            fldBookGenre.Text = _newBook.Genre;
            fldBookSeria.Text = _newBook.Seria;
            fldBookLanguage.Text = _newBook.Language;
            fldBookTranslator.Text = _newBook.Translator;
            fldBookHouse.Text = _newBook.PublishingHouseName;
            fldBookYear.Text = _newBook.PublishingYear.ToString();
            fldBookEdit.Text = _newBook.Edition.ToString();
        }

        private void saveClassBookXML_Click(object sender, EventArgs e)
        {
            _newClassBook.PublicationName = fldClassBookName.Text;
            _newClassBook.Subject = fldClassBookSubject.Text;
            _newClassBook.Grade = int.Parse(fldClassBookGrade.Text);
            _newClassBook.PublishingYear = int.Parse(fldClassBookYear.Text);
            _newClassBook.PublishingHouseName = fldClassBookHouse.Text;
            _newClassBook.Edition = int.Parse(fldClassBookEdit.Text);
            _newClassBook.Save();

            waitXML("Сохранение в XML. Пожалуйста, подождите...", "Успешно. XML сохранен");
        }

        private void uploadClassBookXML_Click(object sender, EventArgs e)
        {
            waitXML("Загрузка XML. Пожалуйста, подождите...", "XML успешно загружен");
            fldClassBookName.Text = _newClassBook.PublicationName;
            fldClassBookSubject.Text = _newClassBook.Subject;
            fldClassBookGrade.Text = _newClassBook.Grade.ToString();
            fldClassBookYear.Text = _newClassBook.PublishingYear.ToString();
            fldClassBookHouse.Text = _newClassBook.PublishingHouseName;
            fldClassBookEdit.Text = _newClassBook.Edition.ToString();
        }

        private void btnMagazAdd_Click(object sender, EventArgs e)
        {
            lblMagazName.Text = fldMagazName.Text;
            lblMagazMonth.Text = fldMagazMonth.Text;
            lblMagazNo.Text = fldMagazNo.Text;
            lblMagazPages.Text = fldMagazPages.Text;
            lblMagazHouse.Text = fldMagazHouse.Text;
            lblMagazYear.Text = fldMagazYear.Text;
            lblMagazEdit.Text = fldMagazEdit.Text;
        }

        private void btnBookAdd_Click(object sender, EventArgs e)
        {
            lblBookName.Text = fldBookName.Text;
            lblBookAuthor.Text = fldBookAuthor.Text;
            lblBookGenre.Text = fldBookGenre.Text;
            lblBookSeria.Text = fldBookSeria.Text;
            lblBookLanguage.Text = fldBookLanguage.Text;
            lblBookTranslator.Text = fldBookTranslator.Text;
            lblBookHouse.Text = fldBookHouse.Text;
            lblBookYear.Text = fldBookYear.Text;
            lblBookEdit.Text = fldBookEdit.Text;

        }
        private void btnClassBookAdd_Click(object sender, EventArgs e)
        {
            lblClassBookName.Text = fldClassBookName.Text;
            lblClassBookSubject.Text = fldClassBookSubject.Text;
            lblClassBookGrade.Text = fldClassBookGrade.Text;
            lblClassBookYear.Text = fldClassBookYear.Text;
            lblClassBookHouse.Text = fldClassBookHouse.Text;
            lblClassBookEdit.Text = fldClassBookEdit.Text;
        }

        private void clearMagaz_Click(object sender, EventArgs e)
        {
            fldMagazName.Text = "";
            fldMagazMonth.Text = "";
            fldMagazNo.Text = "";
            fldMagazPages.Text = "";
            fldMagazHouse.Text = "";
            fldMagazYear.Text = "";
            fldMagazEdit.Text = "";
        }

        private void clearBook_Click(object sender, EventArgs e)
        {
            fldBookName.Text = "";
            fldBookAuthor.Text = "";
            fldBookGenre.Text = "";
            fldBookSeria.Text = "";
            fldBookLanguage.Text = "";
            fldBookTranslator.Text = "";
            fldBookHouse.Text = "";
            fldBookYear.Text = "";
            fldBookEdit.Text = "";
        }

        private void clearClassBook_Click(object sender, EventArgs e)
        {
            fldClassBookName.Text = "";
            fldClassBookSubject.Text = "";
            fldClassBookGrade.Text = "";
            fldClassBookYear.Text = "";
            fldClassBookHouse.Text = "";
            fldClassBookEdit.Text = "";
        }



    }
}
