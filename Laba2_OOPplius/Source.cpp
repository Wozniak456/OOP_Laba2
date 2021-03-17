#include "Header.h"
Line::Line()
{
	_str = nullptr;
	_size = 0;
}
Line::Line(char* str, int len)
{
	_str = new char[len + 1];
	for (int i = 0; i < len; i++)
	{
		_str[i] = str[i];
	}
	_str[len] = '\0';
	_size = len + 1;
}
char* Line::GetLine()
{
	return _str;
}
int Line::GetSize()
{
	return _size;
}
void Line::FirstLetterUpperCase()
{
	_str[0] = putchar(toupper(_str[0]));
}
bool Line::FindSubstr(char* substr, int len)
{
	bool isInLine = false;
	char* temp = new char[len];
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
	delete[] temp;
	return isInLine;
}
Line::~Line()
{
	delete[] _str;
}
Text::Text()
{
	_text = nullptr;
	_numberOfStr = 0;
}
Text::Text(Line line)
{
	_text = new Line[1];
	_text[0] = line;
	_numberOfStr++;
}
int Text::TheBigestLength()
{
	int max = 0;
	for (int i = 0; i < _numberOfStr; i++)
	{
		if (_text[i].GetSize() > max)
		{
			max = _text[i].GetSize();
		}
	}
	return max - 1;
}
char** Text::GetText()
{
	char** text = new char* [_numberOfStr];
	for (int i = 0; i < _numberOfStr; i++)
	{
		char* array = _text[i].GetLine();
		text[i] = new char[_text[i].GetSize()];
		for (int j = 0; j < _text[i].GetSize(); j++)
		{
			text[i][j] = array[j];
		}
	}
	return text;
}
void Text::OutputText(char** text, int maxI)
{
	for (int i = 0; i < maxI; i++)
	{
		int j = 0;
		while (text[i][j] != '\0')
		{
			std::cout << text[i][j];
			j++;
		}
		std::cout << '\n';
	}
}
int Text::GetNumberOfStr()
{
	return _numberOfStr;
}
void Text::AddToText(Line line)
{
	Line* temp = new Line[_numberOfStr];
	temp = CopyArr(_text, _numberOfStr, _numberOfStr);
	_numberOfStr++;
	_text = new Line[_numberOfStr];
	_text = CopyArr(temp, _numberOfStr - 1, _numberOfStr);
	delete[] temp;
	_text[_numberOfStr - 1] = line;
}
Line* Text::CopyArr(Line* lineToCopy, int sizeNow, int sizeNew)
{
	Line* temp = new Line[sizeNew];
	for (int i = 0; i < sizeNow; i++)
	{
		temp[i] = lineToCopy[i];
	}
	return temp;
}
void Text::DeleteLine(int delIndex)
{
	for (int i = delIndex - 1; i < _numberOfStr - 1; i++)
	{
		_text[i] = _text[i + 1];
	}
	_numberOfStr--;
	Line* temp = new Line[_numberOfStr];
	temp = CopyArr(_text, _numberOfStr, _numberOfStr);
	_text = new Line[_numberOfStr];
	_text = CopyArr(temp, _numberOfStr, _numberOfStr);
	delete[] temp;
}
void Text::DeleteStringsWhichContainWord(char* str, int len)
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
void Text::Erase()
{
	_text = new Line[0];
	_numberOfStr = 0;
}
void Text::UpperCase()
{
	for (int i = 0; i < _numberOfStr; i++)
	{
		_text[i].FirstLetterUpperCase();
	}
}
Text::~Text()
{
	delete[] _text;
}
