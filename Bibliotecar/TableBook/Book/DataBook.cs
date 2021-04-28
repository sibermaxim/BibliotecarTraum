/********************************************************************
*  класс описания структуры 
*  списка книг
* 
* *****************************************************************/

namespace Bibliotecar.TableBook.Book
{
    class DataBook
    {
        private uint _id;                       //id книги
        private string _nameBook;               //имя книги
        private uint _idAuthor;                 //id автора
        private string _lang;                   //язык
        private uint _series;                   //серия
        private uint _number;                   //№ в серии
        private uint _year;                     //год написания
        private string _transl;                 //переводчик
        private string _path;                   //путь
        private string _fname;                  //имя файла
        private uint _size;                     //размер
        private string _added;                  //дата добавления
        private uint _crc32;                    //контрольная сумма


        public DataBook(uint id, string nameBook, uint idAuthor, string lang,
                        uint series, uint number, uint year, string transl, string path,
                        string fname, uint size, string added, uint crc32)
        {
            _id = id;
            _nameBook = nameBook;
            _idAuthor = idAuthor;
            _lang = lang;
            _series = series;
            _number = number;
            _year = year;
            _transl = transl;
            _path = path;
            _fname = fname;
            _size = size;
            _added = added;
            _crc32 = crc32;
        }

        public uint Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string NameBook
        {
            get { return _nameBook; }
            set { _nameBook = value; }
        }
        public uint IdAuthor
        {
            get { return _idAuthor; }
            set { _idAuthor = value; }
        }
        public string Lang
        {
            get { return _lang; }
            set { _lang = value; }
        }
        public uint Series
        {
            get { return _series; }
            set { _series = value; }
        }
        public uint Number
        {
            get { return _number; }
            set { _number = value; }
        }        
        public uint Year
        {
            get { return _year; }
            set { _year = value; }
        }
        public string Transl
        {
            get { return _transl; }
            set { _transl = value; }
        }
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
        public string Fname
        {
            get { return _fname; }
            set { _fname = value; }
        }
        public uint Size
        {
            get { return _size; }
            set { _size = value; }
        }
        public string Added
        {
            get { return _added; }
            set { _added = value; }
        }
        public uint Crc32
        {
            get { return _crc32; }
            set { _crc32 = value; }
        }
    }
}
