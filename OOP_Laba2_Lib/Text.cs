using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Laba2_Lib
{
    public class Text
    {
        private int _numberOfStr; 
        private Line[] _text;
        public Text(Line line) // конструктор для створення тексту, який складається з першого, початкового рядка
        {
            _text = new Line[1];
            _text[0] = line;
            _numberOfStr++;
        }
        public int TheBigestLength() //знаходження довжини найдовшого рядка
        {
            int max = 0;
            for (int i = 0; i < _numberOfStr; i++) 
            {
                if (_text[i].GetSize() > max)
                {
                    max = _text[i].GetSize();
                }
            }
            return max;
        } 
        public void UpperCase() //приведення перших символів до верхнього регістру
        {
            for (int i = 0; i < _numberOfStr; i++)
            {
                _text[i].FirstLetterUpperCase();
            }
        }
        public void DeleteStringWhichContainsWord(char[] str, int len) //видалення рядків, які містять заданий підрядок
        {
            for (int i = 0; i < _numberOfStr; i++)
            {
                if (_text[i].FindSubstr(str, len))
                {
                    DeleteLine(i + 1);
                    i--;
                } 
            }
        } 
        public char[][] GetText() //отримуємо зубчатий масив розміром кількість рядків * довжину і-го рядка
        {
            char[][] text = new char[_numberOfStr][];
            for (int i = 0; i < _numberOfStr; i++)
            {
                char[] chars = _text[i].GetLine();
                text[i] = new char[_text[i].GetSize()];
                for (int j = 0; j < _text[i].GetSize(); j++)
                {
                    text[i][j] = chars[j];
                }
            }
            return text;
        }
        public int GetNumberOfStr()
        {
            return _numberOfStr;
        }
        public void AddToText(Line line) //додавання рядка 
        {
            Line[] temp = new Line[_numberOfStr];
            temp = CopyArr(_text, _numberOfStr, _numberOfStr);
            _numberOfStr++;
            _text = new Line[_numberOfStr];
            _text = CopyArr(temp, _numberOfStr - 1, _numberOfStr);
            _text[_numberOfStr - 1] = line;
        }
        public void DeleteLine(int delIndex) //видалення рядка за індексом 
        {
            for (int i = delIndex - 1; i < _numberOfStr - 1; i++)
            {
                _text[i] = _text[i + 1];
            }
            _numberOfStr--;
            Line[] temp = new Line[_numberOfStr]; // проміжний текст
            temp = CopyArr(_text, _numberOfStr, _numberOfStr); //копіювання в темп нашого тексту
            _text = new Line[_numberOfStr];
            _text = CopyArr(temp, _numberOfStr, _numberOfStr);
        } 
        private Line[] CopyArr(Line[] lineToCopy, int sizeNow, int sizeNew) 
        {
            Line[] temp = new Line[sizeNew];
            for (int i = 0; i < sizeNow; i++)
            {
                temp[i] = lineToCopy[i];
            }
            return temp;
        }
        public void Erase()
        {
            _text = new Line[0];
            _numberOfStr = 0;
        }
        public void OutputText(char[][] text, int maxI)
        {
            for (int i = 0; i < maxI; i++)
            {
                for (int j = 0; j < text[i].Length; j++)
                {
                    Console.Write(text[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
