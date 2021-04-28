/********************************************************************
*  класс описания структуры 
*  жанры книг
* 
* *****************************************************************/
namespace Bibliotecar.TableBook.BookTags
{
    class DataBookTags
    {
        private uint _id;                           //id книги
        private string _name;                       //анонс книги

        public DataBookTags(uint id, string name)
        {
            _id = id;
            _name = name;
        }
        public uint Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
