/********************************************************************
*  класс описания структуры 
*  анонса книг
* 
* *****************************************************************/
namespace Bibliotecar.TableBook.BookAnons
{
    class DataBookAnons
    {
        private uint _id;                        //id книги
        private string _bookAnons;               //анонс книги

        public DataBookAnons(uint id, string bookAnons)
        {
            _id = id;
            _bookAnons = bookAnons;
        }
        public uint Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string BookAnons
        {
            get { return _bookAnons; }
            set { _bookAnons = value; }
        }
    }
}
