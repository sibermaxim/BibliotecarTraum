using System.Collections.Generic;

namespace Bibliotecar.FormatFiles
{
    class FormatStr
    {
        public List<string> StrFiledList = new List<string>();

        /**********************************************************
        *  имя процедуры:  FormatetStr
        *  назначение:     конструктор класса
        *  входные данные: strFiled - строка файла
        *  выходные данные:
        * ********************************************************/
        public bool FormatetStr(string strFiled)
        {
            string[] tmpFiled = strFiled.Split('\t');  //само разделение строки файла
            foreach (string tmp in tmpFiled)
                StrFiledList.Add(tmp);

            return true;
        }
    }
}
