// Exercise 7.3 Here's the amended program. 
// For the price of having to say at the start how many students' details
// you want to enter, you get rid of all the limitations of constants and
// fixed-length arrays. 
// Make sure you don't forget to delete the memory you allocated using new.

#include <iostream>
#include <string>
using  std::cout;
using  std::cin;
using  std::endl;
using  std::string;

int main() {
  int student_count = 0;
  double total_marks = 0;
  double class_average = 0;

  cout << "How many students' details do you wish to enter?: ";
  cin >> student_count;

  string* student_names = new string[student_count];
  float* student_marks = new float[student_count];

  // Data entry loop. This loop allows the teacher to enter the students' marks.
  for(int i = 0 ; i < student_count ; i++) {
    cout << "Enter student's name: ";
    cin >> student_names[i];

    cout << "Enter student's mark: ";
    cin  >> student_marks[i];

    total_marks += student_marks[i];
    cout << endl;
  }

  // Calculating the class average.
  class_average = total_marks / student_count;

  // Displaying the class average.
  cout << endl << "The class average for "
               << student_count
               << " students is "
               << class_average;
  cout << endl;

  // Displaying the students' names and marks.
  for(int j = 0; j < student_count ; j++)
    cout << endl << student_names[j] << "\t\t" << student_marks[j];
  cout << endl;

  delete [] student_names;
  delete [] student_marks;

  return 0;
}