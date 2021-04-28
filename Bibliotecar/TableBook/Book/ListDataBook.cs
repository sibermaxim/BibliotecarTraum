using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Bibliotecar.FormatFiles;

/********************************************************************
 *  класс для работы со списком книг
 * 
 * *****************************************************************/
namespace Bibliotecar.TableBook.Book
{
    class ListDataBook
    {
        public List<DataBook> DataBookList = new List<DataBook>();

        public ListDataBook(string folderTable, string fileName)
        {
            string[] _lineFileds;
            string lang, nameBook, added, transl, path, fname;
            uint id, idAuthor, series, year, size, crc32, number;
            FormatStr p_FormatStr;      //hработа со строкой файла

            _lineFileds = File.ReadAllLines(folderTable + fileName, Encoding.GetEncoding(1251));

            p_FormatStr = new FormatStr();
            foreach (string currLine in _lineFileds)
            {
                p_FormatStr.FormatetStr(currLine);
                id = Convert.ToUInt32(p_FormatStr.StrFiledList[0]);
                idAuthor = Convert.ToUInt32(p_FormatStr.StrFiledList[1]);
                nameBook = p_FormatStr.StrFiledList[2];
                lang = p_FormatStr.StrFiledList[3];
                series = Convert.ToUInt32(p_FormatStr.StrFiledList[4]);
                number = Convert.ToUInt32(p_FormatStr.StrFiledList[5]);
                year = Convert.ToUInt32(p_FormatStr.StrFiledList[6]);
                transl = p_FormatStr.StrFiledList[7];
                path = p_FormatStr.StrFiledList[8];
                fname = p_FormatStr.StrFiledList[9];
                size = Convert.ToUInt32(p_FormatStr.StrFiledList[10]);
                added = p_FormatStr.StrFiledList[12];
                crc32 = Convert.ToUInt32(p_FormatStr.StrFiledList[13]);
                DataBookList.Add(new DataBook(id, nameBook, idAuthor, lang, series, number, year,
                                              transl, path, fname, size, added, crc32));
                p_FormatStr.StrFiledList.Clear();
            }
        }
    }
}
