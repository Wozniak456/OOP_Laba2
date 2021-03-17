#include <iostream>
#include "Header.h"
#include <string>
using namespace std;

char* ToCharArray(string stroka, int len)
{
    char* arr = new char[len];
    for (int i = 0; i < len; i++)
    {
        arr[i] = stroka[i];
    }
    return arr;
}
int main()
{
    int choice;
    string strochka1 = "strumming my pain with his fingers";
    string strochka2 = "singing my life with his words";
    string strochka3 = "killing me softly with his song";
    string strochka4 = "killing me softly with his song";

    Line line1 = Line(ToCharArray(strochka1, strochka1.length()), strochka1.length());
    Line line2 = Line(ToCharArray(strochka2, strochka2.length()), strochka2.length());
    Line line3 = Line(ToCharArray(strochka3, strochka3.length()), strochka3.length());
    Line line4 = Line(ToCharArray(strochka4, strochka4.length()), strochka4.length());

    Text text = Text(line1);
    text.AddToText(line2);
    text.AddToText(line3);
    text.AddToText(line4);

    char** chars = text.GetText();

    cout << "Current text: " << endl;

    text.OutputText(chars, text.GetNumberOfStr());

    cout << "'1' - to add a string, \n'2' - to delete a string, \n'3' - to delete strings that contains a word,"
        "\n'4' - to clear a text, \n'5' - to get a length of the longest string, "
        "\n'6' - to make first letters to uppercase, \n'7' - to see this message";
    for (int i = 0; i < 7; i++)
    {
        cout << "\nInput a num: ";
        cin >> choice;
        switch (choice)
        {
        case 1:
        {
            string strochka5 = "telling my whole life with his words";
            Line line5 = Line(ToCharArray(strochka5, strochka5.length()), strochka5.length());
            text.AddToText(line5);
            chars = text.GetText();
            cout << "Current text: " << endl;
            text.OutputText(chars, text.GetNumberOfStr());
            break;
        }
        case 2:
            int delIndex;
            cout << "please, enter an index: ";
            cin >> delIndex;
            text.DeleteLine(delIndex);
            chars = text.GetText();
            cout << "Current text: " << endl;
            text.OutputText(chars, text.GetNumberOfStr());
            break;
        case 3:
        {
            string substring;
            cout << "Input a substring: ";
            cin >> substring;
            text.DeleteStringsWhichContainWord(ToCharArray(substring, substring.length()), substring.length());
            chars = text.GetText();
            cout << "Current text: " << endl;
            text.OutputText(chars, text.GetNumberOfStr());
            break;
        }
        case 4:
            text.Erase();
            chars = text.GetText();
            cout << "Current text: " << endl;
            text.OutputText(chars, text.GetNumberOfStr());
            break;

        case 5:
        {
            int len;
            len = text.TheBigestLength();
            cout << "The bigest length is: " << len << endl;
            break;
        }
        case 6:
        {
            text.UpperCase();
            chars = text.GetText();
            cout << "\nCurrent text: " << endl;
            text.OutputText(chars, text.GetNumberOfStr());
            break;
        }
        case 7:
        {
            cout << "'1' - to add a string, \n'2' - to delete a string, \n'3' - to delete strings that contains a word,"
                "\n'4' - to clear a text, \n'5' - to get a length of the longest string, "
                "\n'6' - to make first letters to uppercase, \n'7' - to see this message";
            break;
        }
        default:
            cout << "error4ik :) try again";
            break;
        }
    }
    return 0;
}

