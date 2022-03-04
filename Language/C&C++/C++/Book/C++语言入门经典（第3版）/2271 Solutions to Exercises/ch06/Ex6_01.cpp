// Exercise 6.1 Using a pair of arrays to store a 'grade book' for up to ten students. 
#include <iostream>
#include <string>
using std::cout;
using std::cin;
using std::endl;
using std::string;

int main() {
  const int MAX_STUDENTS = 100;

  string student_names[MAX_STUDENTS];
  double student_marks[MAX_STUDENTS] = {0};
  int student_count = 0;
  double total_marks = 0;
  double class_average = 0;
  char answer = 'n';

  // Data entry loop. This loop allows the teacher to enter the students' marks.
  do {
    cout << "Enter a student's name: ";
    cin  >> student_names[student_count];

    cout << "Enter " << student_names[student_count] << "\'s mark: ";
    cin  >> student_marks[student_count];

    total_marks += student_marks[student_count++];

    cout << "Do you wish to enter another student's details (y/n): ";
    cin  >> answer;
  } while (tolower(answer) == 'y' && student_count < MAX_STUDENTS);

  if(student_count == MAX_STUDENTS)
    cout << endl << "Maximum number of students reached." << endl;
  // Calculating the class average.
  class_average = total_marks / student_count;

  // Displaying the class average.
  cout << endl << "The class average for "
               << student_count
               << " students is "
               << class_average;
  cout << endl;

  // Displaying the students' names and marks.
  for(int i = 0; i < student_count ; i++)
    cout << endl << student_names[i] << "\t\t" << student_marks[i];

  cout << endl;
  return 0;
}