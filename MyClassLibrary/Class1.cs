using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyClassLibrary
{
    public class Print
    {
        private int publishing_year;
        private int edition;

        public string PublicationName { get; set; }
        public string PublishingHouseName { get; set; }
        public int PublishingYear
        {
            get
            {
                return publishing_year;
            }
            set
            {
                if (value < 1900) publishing_year = 1900;
                else if (value > 2018) publishing_year = 2018;
                else publishing_year = value;
            }
        }
        public int Edition
        {
            get
            {
                return edition;
            }
            set
            {
                if (value < 1) edition = 1;
                else edition = value;
            }
        }
    }

    public class Magazine : Print
    {
        private int magazine_number;
        private int magazine_number_of_pages;

        public string Month { get; set; }

        public int No
        {
            get
            {
                return magazine_number;
            }
            set
            {
                if (value < 1) magazine_number = 1;
                else magazine_number = value;
            }
        }
        public int NumberOfPages
        {
            get
            {
                return magazine_number_of_pages;
            }
            set
            {
                if (value < 50) magazine_number_of_pages = 50;
                else if (value > 2000) magazine_number_of_pages = 2000;
                else magazine_number_of_pages = value;
            }
        }

        public static Magazine GetSettings()
        {
            Magazine settings = null;
            string filename = Globals.XMLSettingsMagazine;

            if (File.Exists(filename))
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    XmlSerializer xser = new XmlSerializer(typeof(Magazine));
                    settings = (Magazine)xser.Deserialize(fs);
                    fs.Close();
                }
            }
            else settings = new Magazine();
            return settings;
        }
        public void Save()
        {
            string filename = Globals.XMLSettingsMagazine;
            if (File.Exists(filename)) File.Delete(filename);

            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                XmlSerializer xser = new XmlSerializer(typeof(Magazine));
                xser.Serialize(fs, this);
                fs.Close();
            }
            
        }
    }

    public class Book : Print
    {
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Seria { get; set; }
        public string Language { get; set; }
        public string Translator { get; set; }
        
        public static Book GetSettings()
        {
            Book settings = null;
            string filename = Globals.XMLSettingsBook;

            if (File.Exists(filename))
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    XmlSerializer xser = new XmlSerializer(typeof(Book));
                    settings = (Book)xser.Deserialize(fs);
                    fs.Close();
                }
            }
            else settings = new Book();
            return settings;
        }
        public void Save()
        {
            string filename = Globals.XMLSettingsBook;
            if (File.Exists(filename)) File.Delete(filename);

            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                XmlSerializer xser = new XmlSerializer(typeof(Book));
                xser.Serialize(fs, this);
                fs.Close();
            }
        }
        
    }

    public class ClassBook : Print
    {
        private int classook_grade;

        public string Subject { get; set; }
        public string Author { get; set; }
        public int Grade
        {
            get
            {
                return classook_grade;
            }
            set
            {
                if (value < 1) classook_grade = 1;
                else if (value > 11) classook_grade = 11;
                else classook_grade = value;
            }
        }

        public static ClassBook GetSettings()
        {
            ClassBook settings = null;
            string filename = Globals.XMLSettingsClassBook;

            if (File.Exists(filename))
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    XmlSerializer xser = new XmlSerializer(typeof(ClassBook));
                    settings = (ClassBook)xser.Deserialize(fs);
                    fs.Close();
                }
            }
            else settings = new ClassBook();
            return settings;
        }
        public void Save()
        {
            string filename = Globals.XMLSettingsClassBook;
            if (File.Exists(filename)) File.Delete(filename);

            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                XmlSerializer xser = new XmlSerializer(typeof(ClassBook));
                xser.Serialize(fs, this);
                fs.Close();
            }
        }
    }
}

