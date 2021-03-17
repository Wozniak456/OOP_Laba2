#include <iostream>
#include <string>
#include <iomanip> 
#pragma once

class Line
{
private:
	char* _str;
	int _size;
public:
	Line();
	Line(char* str, int len);
	char* GetLine();
	int GetSize();
	void FirstLetterUpperCase();
	bool FindSubstr(char* substr, int len);
	~Line();
};
class Text
{
private:
	int _numberOfStr;
	Line* _text;
	Line* CopyArr(Line* lineToCopy, int sizeNow, int sizeNew);
public:
	Text();
	Text(Line line);
	int TheBigestLength();
	void UpperCase();
	void DeleteStringsWhichContainWord(char* str, int len);
	char** GetText();
	int GetNumberOfStr();
	void AddToText(Line line);
	void DeleteLine(int delIndex);
	void Erase();
	void OutputText(char** text, int maxI);
	~Text();
};
