/********************************************************************
 *  класс для работы со списком авторов
 * 
 * *****************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Bibliotecar.FormatFiles;

namespace Bibliotecar.TableBook.Author
{
    class ListDataAuthor
    {
        public List<DataAuthor> DataAuthorList = new List<DataAuthor>();

        /**********************************************************
         *  имя процедуры:  ListDataAuthor
         *  назначение:     конструктор класса
         *  входные данные: folderTable - имя папки хранения таблиц
         *                  fileName - таблица списка авторов
         *  выходные данные:
         * ********************************************************/

        public ListDataAuthor(string folderTable, string fileName)
        {
            string[] _lineFileds;
            string name, midname;
            uint id;
            FormatStr p_FormatStr;      //работа со строкой файла

            _lineFileds = File.ReadAllLines(folderTable + fileName, Encoding.GetEncoding(1251));

            p_FormatStr = new FormatStr();
            foreach (string currLine in _lineFileds)
            {
                p_FormatStr.FormatetStr(currLine);
                id = Convert.ToUInt32(p_FormatStr.StrFiledList[0]);
                name = p_FormatStr.StrFiledList[1];
                midname = p_FormatStr.StrFiledList[2];
                DataAuthorList.Add(new DataAuthor(id, name, midname));
                p_FormatStr.StrFiledList.Clear();
            }
        }
    }
}
