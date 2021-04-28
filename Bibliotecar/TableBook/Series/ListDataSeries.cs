using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Bibliotecar.FormatFiles;

namespace Bibliotecar.TableBook.Series
{
    class ListDataSeries
    {
        public List<DataSeries> DataSeriesList = new List<DataSeries>();

        public ListDataSeries(string folderTable, string fileName)
        {
            string[] _lineFileds;
            string _bookAnons;
            uint id;
            FormatStr p_FormatStr;      //hработа со строкой файла

            _lineFileds = File.ReadAllLines(folderTable + fileName, Encoding.GetEncoding(1251));
            p_FormatStr = new FormatStr();
            foreach (string currLine in _lineFileds)
            {
                p_FormatStr.FormatetStr(currLine);
                id = Convert.ToUInt32(p_FormatStr.StrFiledList[0]);
                _bookAnons = p_FormatStr.StrFiledList[1];
                DataSeriesList.Add(new DataSeries(id, _bookAnons));
                p_FormatStr.StrFiledList.Clear();
            }
        }
    }
}
