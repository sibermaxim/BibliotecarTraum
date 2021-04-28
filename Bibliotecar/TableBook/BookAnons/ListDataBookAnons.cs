/********************************************************************
 *  класс для работы со списком книг
 * 
 * *****************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Bibliotecar.FormatFiles;

namespace Bibliotecar.TableBook.BookAnons
{
    class ListDataBookAnons
    {
        public List<DataBookAnons> DataBookAnonsList = new List<DataBookAnons>();

        public ListDataBookAnons(string folderTable, string fileName)
        {
            string[] _lineFileds;
            string _bookAnons;
            uint id;
            FormatStr p_FormatStr;      //hработа со строкой файла

            _lineFileds = File.ReadAllLines(folderTable + fileName, Encoding.GetEncoding(1251));
            p_FormatStr = new FormatStr();
            foreach (string currLine in _lineFileds)
            {
                System.Windows.Forms.Application.DoEvents();
                p_FormatStr.FormatetStr(currLine);
                id = Convert.ToUInt32(p_FormatStr.StrFiledList[0]);
                _bookAnons = p_FormatStr.StrFiledList[1];
                DataBookAnonsList.Add(new DataBookAnons(id, _bookAnons));
                p_FormatStr.StrFiledList.Clear();
            }
        }
    }
}
