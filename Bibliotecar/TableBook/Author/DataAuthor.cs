/********************************************************************
 *  класс описания структуры 
 *  списка авторов
 * 
 * *****************************************************************/
namespace Bibliotecar.TableBook.Author
{
    class DataAuthor
    {
        private uint _id;                   //уникальный id
        private string _name;               // имя, фамилия (для соавторов - "имя, фамилия + имя, фамилия + ...")
        private string _midname;            //отчество
        public DataAuthor(uint id, string name, string midname)
        {
            _id = id;
            _name = name;
            _midname = midname;
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
        public string Midname
        {
            get { return _midname; }
            set { _midname = value; }
        }
    }
}
