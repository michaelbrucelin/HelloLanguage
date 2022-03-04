// Exercise 14.4 MyString.h
// Definition of the MyString class representing strings

#ifndef MYSTRING_H
#define MYSTRING_H
namespace mySpace {

class MyString {
  public:
    MyString();                                 // Default constructor
    MyString(const char* pString);              // Construct from a C-style string
    MyString(char ch, int n);                   // Construct from repeated character
    MyString(int number);                       // Construct string representation of integer
    MyString(const MyString& rString);          // Copy constructor
    ~MyString();                                // Destructor

    int length() const{ return strLength; }     // Return length excluding terminating null
    int find(char ch) const;                    // Find the occurrence of a character
    int find(const char* pString) const;        // Find the occurrence of a C-style string 
    int find(const MyString& rString) const;    // Find the occurrence of a MyString  as a sub-string
    void show() const;                          // Output the string
    MyString& operator=(const MyString& rhs);   // Assignment operator

    MyString operator+(const MyString& rOperand) const; // String concatenation
    MyString& operator+=(const MyString& rhs);          // Append MyString 
    MyString& operator+=(const char* rhs);              // Append C-style

    const char& operator[](int index) const;     // Subscript operator for const objects
    char& operator[](int index);                 // Subscript operator for non-const objects

    // Comparison operators all return type bool
    bool operator ==(const MyString& rOperand) const; 
    bool operator !=(const MyString& rOperand) const; 
    bool operator >(const MyString& rOperand) const; 
    bool operator <(const MyString& rOperand) const; 

  private:
    char* pStr;                                // Pointer to the string
    size_t strLength;                          // number of characters excluding terminating null
};

}  // End of namespace mySpace
#endif