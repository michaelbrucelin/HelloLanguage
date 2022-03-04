/*
***************************************************************
*
*	Project.cpp
*	
****************************************************************
*/

// standard library includes

#include <iostream>
#include <iomanip>
#include <cstdlib>
#include <fstream>
#include <cctype>

// private includes

#include "project.h"
using std::cout;
using std::cin;
using std::endl;
using std::string;
using std::setw;

/*
***************************************************************
*
*	In this file we define and implement the member functions
*	of the "Person" class, as well as it's derived classes. 
*
*	The derived classes are the "Teacher" class and the "Student"
*	class.  Only the virtual functions inherited from the
*	"Person" class, along with their constructors are defined
*	and implemented in this file.
*
****************************************************************
*/

/*
****************************************************************
*
*	The "Person" Class Member Functions
*
****************************************************************
*/

// Set member functions for the base Person Class.  

void Person::setup() {
	// Validate the object, and prompt user to enter values
	// for all the attributes.

	set_first_name();
	set_surname();
	set_address();
	set_city();
	set_state();
	set_zip();
	set_phone();
}

// This function determines whether the user input should consist of digits,
// alphabetic characters, or a mixture

bool Person::validate_input(const string& input, bool is_string) {
	// If is_string is true, we test for characters.  If not we test for digits.

	if (is_string) 	{
		for (unsigned int i = 0; i < input.length(); i++) {
      if (!std::isalpha(input[i])) {
				cout << endl << "The input contained invalid characters.  Try Again." << endl;
				return false;
			}
		}
	}
	else {
		for (size_t i = 0; i < input.length(); i++) {
      if (!std::isdigit(input[i])) {
				cout << endl << "The input contained invalid characters.  Try Again." << endl;
				return false;
			}
		}
	}

	return true;
}

// Set member functions of the Person Abstract Class

void Person::set_first_name() {
	string temp;

	// initialize boolean variables to test the user inputs.
	bool result = false;

	while (!result) {
		cout << endl << "Please enter the First Name. " << endl;
		cin >> temp;

		if (temp.length() >= FIRST_NAME_SIZE) {
			cout << endl << "The input must be less than "
				 << FIRST_NAME_SIZE << " characters. " << endl;
			continue;
		}
		
		if (validate_input(temp, true))
			result = true;
	}

	// Now we can assign the input variable to the member variable
	first_name = temp;
}

void Person::set_surname() {
	string temp;

	// initialize boolean variables to test the user inputs.
	bool result = false;

	while (!result) 	{
		cout << endl << "Please enter the Surname. " << endl;
		cin >> temp;

		if (temp.length() >= SURNAME_SIZE) {
			cout << endl << "The input must be less than "
				 << SURNAME_SIZE << " characters. " << endl;
			continue;
		}

		if (validate_input(temp, true))
			result = true;
	}

	// Now we can assign the input variable to the member variable
	surname = temp;
}

void Person::set_address() {
	string temp;

	// initialize boolean variables to test the user inputs.
	bool result = false;

  while (!result) {
		cout << endl << "Enter line 1 of the street address (or '.' to exit) " << endl;
    std::ws(cin);     // Skip any whitespace left on cin
		std::getline(cin, temp, '\n');

		if (temp == ".")
			return;

		address1 = temp;
		result = true;
	}

	// Re-initialize result to validate user input
	result = false;

	while (result == false) {
		cout << endl << "Enter line 2 of the street address (or '.' to exit) " << endl;
    std::ws(cin);   // Skip any whitespace left on input
    std::getline(cin, temp, '\n');

		if (temp == ".")
			return;

		address2 = temp;
		result = true;
	}

	// Re-initialize result to validate user input
	result = false;

	while (result == false) {
		cout << endl << "Enter line 3 of the street address (or '.' to exit) " << endl;
    std::ws(cin);    // Skip whitepsace on input
    std::getline(cin, temp, '\n');

		if (temp == ".")
			return;

		address3 = temp;
		result = true;
	}
}

void Person::set_city() {
	string temp;

	// initialize boolean variables to test the user inputs.
	bool result = false;

	while (result == false) {
		cout << endl << "Please enter the City. " << endl;
		cin >> temp;

		if (temp.length() >= CITY_SIZE ) {
			cout << endl << "The input must be less than "
				 << CITY_SIZE << " characters. " << endl;
			continue;
		}

		if (validate_input(temp, true))
			result = true;
	}

	// Now we can assign the input variable to the member variable
	city = temp;
}

void Person::set_state() {
	string temp;

	// initialize boolean variables to test the user inputs.
	bool result = false;

	while (result == false) {
		cout << endl << "Please enter the State. " << endl;
		cin >> temp;

		if (temp.length() >= STATE_SIZE ) {
			cout << endl << "The input must be less than "
				 << STATE_SIZE << " characters. " << endl;
			continue;
		}

		if(validate_input(temp, true))
			result = true;
	}

	// Now we can assign the input variable to the member variable
	state = temp;
}

void Person::set_zip() {
	string temp;

	// initialize boolean variables to test the user inputs.
	bool result = false;

	while (result == false) {
		cout << endl << "Please enter the 6 digit Zip Code. " << endl;
		cin >> temp;

		if (temp.length() != ZIP_CODE_SIZE - 1) {
			cout << endl << "The Zip Code must be 6 digits long. Try Again." << endl;
			continue;
		}
		
		if (validate_input(temp, false))
			result = true;
	}

	// Now we can assign the input variable to the member variable
  zip = std::atoi(temp.c_str());
}

void Person::set_phone() {
	string phone_number; // temp storage for the phone number

	int i = 0; // generic looping variable

	// initialize boolean variable to test the user inputs.
	bool result = false;

	// Seeing as the phone number has a "-", we must manually validate
	// the user input

	do {
		
		// initialize boolean variable to test the user inputs.
		bool bValid = true;
		
		cout << endl << "Enter the Phone Number Using the format " << endl;
		cout << "###-#### (where # is any digit between 0 and 9)." << endl;

		cin >> phone_number;

		if ((phone_number.length() != 8) || (phone_number[3] != '-')) {
			cout << "Invalid Phone Number.  Try Again." << endl;
			continue;
		}

		for (i = 0; i < PHONE_NUMBER_SIZE - 1; i++) {
			// We don't need to test for the '-' character
			if (i != 3)
        continue;
			if (!isdigit(phone_number[i])) {
				cout << "Invalid Phone Number.  Try Again." << endl;
				bValid = false;
				break;
			}
		}

		if (!bValid)
			continue;
		else
			result = true;

	} while (result == false);

	// Now we can assign the input variable to the member variable
	phone = phone_number;
}

// This function will display the attributes of the object, and
// align them properly.
void Person::display_info()	const {
	cout << endl;
  cout << std::setiosflags(std::ios::left) << endl;

	cout <<	setw(HEADER_SIZE)  << "First Name :" << setw(MAX_FIELD_SIZE) << first_name << endl;
	cout << setw(HEADER_SIZE)  << "Surname : "  << setw(MAX_FIELD_SIZE) << surname << endl;
	cout << setw(HEADER_SIZE)  << "Address1 : " << setw(MAX_FIELD_SIZE) << address1 << endl;
	cout << setw(HEADER_SIZE)  << "Address2 : " << setw(MAX_FIELD_SIZE) << address2 << endl;
	cout << setw(HEADER_SIZE)  << "Address3 : " << setw(MAX_FIELD_SIZE) << address3 << endl;
	cout << setw(HEADER_SIZE)  << "City : " << setw(MAX_FIELD_SIZE) << city << endl;
	cout << setw(HEADER_SIZE)  << "State : " << setw(MAX_FIELD_SIZE) << state << endl;
	cout << setw(HEADER_SIZE)  << "Zip Code : " << setw(MAX_FIELD_SIZE) << zip << endl;
	cout << setw(HEADER_SIZE)  << "Telephone : " << setw(MAX_FIELD_SIZE) << phone << endl;
}

// This function will dump the attributes of the object to an output stream
void Person::dump_info(std::ostream& os) const {
	os << first_name << endl;
	os << surname << endl;
	os << address1 << endl;
	os << address2 << endl;
	os << address3 << endl;
	os << city << endl;
	os << state << endl;
	os << zip << endl;
	os << phone << endl;
}

void Person::load_info(std::ifstream& is) {
  std::getline(is, first_name, '\n');
	cout << "  first_name: '" << first_name << "'" << endl;
  std::getline(is, surname, '\n');
	cout << "  surname: '" << surname << "'" << endl;
	std::getline(is, address1, '\n');
	cout << "  address1: '" << address1 << "'" << endl;
	std::getline(is, address2, '\n');
	cout << "  address2: '" << address2 << "'" << endl;
	std::getline(is, address3, '\n');
	cout << "  address3: '" << address3 << "'" << endl;
	std::getline(is, city, '\n');
	cout << "  city: '" << city << "'" << endl;
	std::getline(is, state, '\n');
	cout << "  state: '" << state << "'" << endl;
	is >> zip;
	is.get(); // retrieve the final '\n' and discard
	cout << "  zip: '" << zip << "'" << endl;
	std::getline(is, phone, '\n');
	cout << "  phone: '" << phone << "'" << endl;
}

/*
****************************************************************
*
*	The "Student" Class Member Functions.
*	This class is inerited from the "Person" Abstract Class.
*
****************************************************************
*/

void Student::setup() {
	// Initialise base class part of object
	Person::setup();

	//set_other_info();
	string temp_ID;
	int temp_grade;

	// initialize a boolean variable to test the user inputs.
	bool result = false;
	
	// The student ID can be an alphanumeric combination, so we cannot use
	// the Validate_Input() function.
	while (!result) {
		cout << endl << "Please enter 6 character Student ID." << endl;
		cin >> temp_ID;

		if (temp_ID.length() != 6)
			cout << endl << "The Student ID was not 6 characters.  Try Again." << endl;
		else
			result = true;
	}

	// It passed, now assign it to the member variable
	student_ID = temp_ID;

	// Initialize result again to test for the nGrade member variable
	result = false;

	while (result == false) {
		cout << endl << "Enter the Student GPA (0 to 100). " << endl;
		cin >> temp_grade;

		if( (temp_grade < 0) || (temp_grade > 100) ) {
			cout << endl << "Please enter a value between 0 and 100.  Try Again." << endl;
			continue;
		}
		else
			result = true;
	}

	// It passed, now assign it to the member variable
	grade = temp_grade;
}

// Virtual function to print Student specific variables 
void Student::display_other_info() const {
	cout << std::setiosflags(std::ios::left) << endl;
	cout << setw(HEADER_SIZE) << "Student ID : " << setw(MAX_FIELD_SIZE) << student_ID << endl;
	cout << setw(HEADER_SIZE) << "GPA : " << setw(MAX_FIELD_SIZE) << grade << endl;
}
 

// This function will dump the attributes of the object to an output stream
void Student::dump_info(std::ostream& os) const
{
	Person:: dump_info(os);

	os << student_ID << endl;
	os << grade << endl;
}


void Student::load_info(std::ifstream& is) {
	Person::load_info(is);

	std::getline(is, student_ID, '\n');
	cout << "  ID: '" << student_ID << "'" << endl;
	is >> grade;
	cout << "  grade: '" << grade << "'" << endl;
}
  
/*
****************************************************************
*
*	The "Teacher" Class Member Functions.
*	This class is inerited from the "Person" Abstract Class.
*
****************************************************************
*/

void Teacher::setup() {
	// Initialise base class part of object
	Person::setup();

	// set_other_info();
	bool result = false;

	int years;
	while (result == false) {
		cout << endl << "Enter the Number of Years of Experience. " << endl;
		cin >> years;

		if (years < 0) 	{
			cout << "This value must be positive." << endl;
		}
		else
			result = true;
	}
	years_experience = years;

	result = false;

	int cash;
	while (result == false) {
		cout << endl << "Enter the annual salary: " << endl;
		cin >> cash;

		if (cash < 0) {
			cout << "This value must be positive." << endl;
		}
		else
			result = true;
	}
	salary = cash;
}
 
// Virtual function to print Teacher specific variables 
void Teacher::display_other_info() const {
	cout << std::setiosflags(std::ios::left) << endl;
	cout << setw(HEADER_SIZE) << "Experience : " << setw(MAX_FIELD_SIZE) << years_experience << endl;
	cout << setw(HEADER_SIZE) << "Salary :$ " << setw(MAX_FIELD_SIZE) << salary << endl;
}

void Teacher::dump_info(std::ostream& os) const {
	Person:: dump_info(os);

	os << years_experience << endl;
	os << salary << endl;
}

void Teacher::load_info(std::ifstream& is) {
	Person::load_info(is);

	is >> years_experience;
//	is.get(); // retrieve the final newline and discard
	cout << "  experience: '" << years_experience << "'" << endl;
	is >> salary;
	cout << "  salary: '" << salary << "'" << endl;
}