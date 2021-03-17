using System;

namespace OOP_Laba2_Lib
{
    public class Line
    {
        private char[] _str;  
        private int _size;
        public Line(char[] str, int len) //конструктор для початкового формування рядка (масиву чарів) і запису в _str
        {
            _str = new char[len];
            for (int i = 0; i < len; i++)
            {
                _str[i] = str[i]; 
            }
            _size = len;
        }
        public char[] GetLine()
        {
            return _str;
        }
        public int GetSize() 
        {
            return _size;
        }
        public void FirstLetterUpperCase()
        {
            char[] newLine = new char[_size];
            newLine[0] = char.ToUpper(_str[0]);
            for (int i = 1; i < _size; i++)
            {
                newLine[i] = _str[i];
            }
            _str = newLine;
        }
        public bool FindSubstr(char[] substr, int len) //повертає true, якщо в рядку є заданий підрядок
        {
            bool isInLine = false; 
            char[] temp = new char[len];
            for (int i = 0; i < _size; i++)
            {
                if (_str[i] == substr[0] && _size - i >= len + 1)
                {
                    int temp_i = i;
                    for (int j = 0; j < len; j++)
                    {
                        temp[j] = _str[i];
                        i++;
                    }
                    for (int j = 0; j < len; j++)
                    {
                        if (substr[j] != temp[j])
                        {
                            isInLine = false;
                            i = temp_i;
                            j = len - 1;
                        }
                        else
                        {
                            isInLine = true;
                            i = _size - 1;
                        }
                    }
                }
            }
            return isInLine;
        }
    }
}
