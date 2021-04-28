/********************************************************************
*  класс описания структуры 
*  серий книг
* 
* *****************************************************************/
namespace Bibliotecar.TableBook.Series
{
    class DataSeries
    {
        private uint _id;                           //id серии
        private string _series;                     //название

        public DataSeries(uint id, string series)
        {
            _id = id;
            _series = series;
        }
        public uint Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Series
        {
            get { return _series; }
            set { _series = value; }
        }

    }
}
