/*
***************************************************************
*
*	MainProg.cpp
*	
***************************************************************
*/


// standard library includes
#include <deque>
#include <fstream>
#include <iostream>
#include <cstdlib>
#include <string>
#include <cctype>

// private includes
#include "project.h"

using std::cout;
using std::cin;
using std::endl;
using std::string;


// Function Prototypes
void display_record_menu();
void display_all(bool do_teachers, bool do_students);

void add_record();
void add_person(bool is_student);

void delete_record();
void delete_all_records();
void delete_surname(const string &surname);

void search_record();
void search_surname(const string &surname);

void save_records();
void load_records();

void record_report();

// Global variables
std::deque<Person*> persons;	// Person Base Class Container

Person *pPerson;	// Base class pointer


// Program code

/* 
******************************************************
*	Function:	main
*	return:		int
*	parameters:	none
*
*	Description:
*	Start of the program.  This function will display 
*	the Main Menu.
*
******************************************************
*/

int main() {
	char option;	// User input

	do{
		// Display the Main Menu
		cout << endl << endl;
		cout << endl << "MAIN MENU";
		cout << endl << "---------";
		cout << endl << "(A)dd a record";
		cout << endl << "(D)elete a record";
		cout << endl << "(C)lear all records";
		cout << endl << "(S)earch a record";
		cout << endl << "Displa(Y) records";
		cout << endl << "Sa(V)e records to disk";
		cout << endl << "(L)oad records from disk";
		cout << endl << "(R)eport list contents" << endl;

		cout << endl << "(Q)uit the Program" << endl << endl;
		cout << endl << "Enter Selection" << endl;
		
    cin >> option;
    option = static_cast<char>(std::toupper(option));

    switch (option) {
		case 'A': 
			// The user wants to add records
			add_record();
			break;
		case 'D': 
			// The user wants to delete record
			delete_record();
			break;
		case 'C': 
			// The user wants to delete all the records.
			delete_all_records();
			break;
		case 'S': 
			// The user wants to search a record
			search_record(); 
			break;
		case 'Y': 
			// The user wants to display records on the screen
			display_record_menu();
			break;
		case 'V': 
			// The user wants to save the records to disk
			save_records();
			break;
		case 'L': 
			// The user wants to load a record file
			load_records();
			break;
		case 'R': 
			// Report on what we have saved
			record_report();
			break;
		case 'Q':
			// Delete all records in Container 'persons' before exiting.
			persons.clear();
			break;
		default: 
			cout << endl << "Invalid choice.";
			break;
		}

	}while (option != 'Q'); // loop until user enters 'q' or 'Q'

	return 0;
}

/* 
******************************************************
*	Function:	display_record_menu
*	return:		void
*	parameters:	none
*
*	Description:
*	This function will display the menu which is used
*   to control record display
*
******************************************************
*/


void display_record_menu() {
	char option;

	do{
		// Display the display Record System menu
		cout << endl << endl;
		cout << endl << "display RECORD SYSTEM MENU";
		cout << endl << "------------------------";
		cout << endl << "display all (T)eachers";
		cout << endl << "display all (S)tudents";
		cout << endl << "display (A)ll Students and Teachers" << endl;

		cout << endl << "Press (Q)uit to return to the Main Menu" << endl;

		cout << endl << "Enter Selection" << endl;
		
    cin >> option;
    option = static_cast<char>(std::toupper(option));

		switch (option) {
		case 'T': 
			// display all teacher records
			display_all(true, false);
			break;
		case 'S': 
			// display all student records
			display_all(false, true);
			break;
		case 'A': 
			// display all teacher and student records
			display_all(true, true); 
			break;
		default: 
			cout << endl << "Invalid choice.";
			break;
		}

	}while (option != 'Q'); // loop until user enters 'q' or 'Q'

	cout << endl << "Returning to the Main Menu." << endl;
}


/* 
******************************************************
*	Function:	delete_Record
*	return:		void
*	parameters:	none
*
*	Description:
*	This function will prompt the user to enter the surname
*	of the record to delete.
*
******************************************************
*/


void delete_record() {
	string search_surname;
	char option;

	do	{
		cout << endl << "DELETE SURNAME. " << endl;
		cout << endl << "---------------" << endl;
		
		cout << endl <<"Enter the Surname of the record you want to delete, or '.' to exit" << endl;
		cin >> search_surname;
//		cin.get(); // retrieve the final "ENTER" and discard

		if (search_surname == ".")
			return;

		// Call the function vDelete_Surname to delete the record
		delete_surname(search_surname);

		// flush the standard input buffer
		//std::fflush(stdin);

		cout << endl << "Do you want to delete another record [Y/N]? " << endl;

    cin >> option;
    option = static_cast<char>(std::toupper(option));

	}while (option != 'N'); // Continue deleting until user enters 'N' or 'n'
}


/* 
******************************************************
*	Function:	delete_all_records
*	return:		void
*	parameters:	none
*
*	Description:
*	This function will clear the entire list of records, after
* first confirming the user's choice
*
******************************************************
*/


void delete_all_records() {
	char option;
	
	cout << endl << "Are you sure you want to delete all the records [Y/N]? " << endl;

	cin >> option;
  option = static_cast<char>(std::toupper(option));

	if (option == 'Y') {
		persons.clear();
		cout << "All records deleted" << endl;
	}
	else
		cout << "Deletion aborted" << endl;
}

/* 
******************************************************
*	Function:	delete_surname
*	return:		void
*	parameters:	const string &surname
*
*	Description:
*	This function will search the existing records 
*	to find which record matches the user-entered
*	surname, then delete the record.
*
******************************************************
*/

void delete_surname(const string &surname) {
	unsigned int i = 0;

	// Loop around all student and teacher records 
	// for a match on the surname.
	for (i = 0; i < persons.size(); i++) {
		pPerson = persons[i];
	
		// Compare the surname field of the record at 
		// index i with the user input record.  
		if ((surname.compare(pPerson->get_surname()) == 0)) {
			cout << endl << "Deleting the following Record." << endl;

			pPerson->display_info();
			pPerson->display_other_info();

			// Set the pointer to 0, then delete the record.
			pPerson = 0;
			persons.erase(persons.begin() + i);

			return;
		}
	}
	// If we get here then the record was not found.
	// Let the user know.
	cout << endl << "The Surname " << surname << " was not found." << endl;
}


/* 
******************************************************
*	Function:	add_record
*	return:		void
*	parameters:	none
*
*	Description:
*	This function will add a single record.  The
*	function will prompt the user to add either a
*	Student record or a Teacher record.
*
******************************************************
*/

void add_record() {
	char option = 0;

	cout << endl << "ADD RECORD MENU";
	cout << endl << "---------------";
	cout << endl << "Enter (T) to add a Teacher record.";
	cout << endl << "Enter (S) to add a Student record." << endl;

  cin >> option;
  option = static_cast<char>(std::toupper(option));

	try {
		switch(option) 	{
		case 'T': 
			// Add a single teacher record
			cout << endl << "Adding Teacher record." << endl;
			add_person(false);
			break;
		case 'S': 
			// Add a single student record
			cout << endl << "Adding Student record." << endl;
			add_person(true); 
			break;
		default: 
			cout << endl << "Not a valid option.  Try again." << endl;
			break;
		}
	}
	catch(create_ex* pEx) {
		cout << "Error encountered during record creation. Error message was:" << endl;
		cout << pEx->what() << endl;
	}
}

/* 
******************************************************
*	Function:	add_person
*	return:		void
*	parameters:	none
*
*	Description:
*	This function will determine what type of record will be 
*	added to the Container 'persons' (i.e. either a Student record
*	or a Teacher record).
*
******************************************************
*/

void add_person(bool is_student) {
	// Add the record to the appropriate container.  
	// The type of record (i.e. either "Student" or "Teacher") 
	// is determined by the variable is_student.
		
	if (!is_student) {
		// Create a Teacher object on the heap (i.e. allocate the memory)
		// then add it to the Container 'persons'

		Teacher* tempTeacher = new Teacher();
		
		// Uncomment the next line to test the exception-handling
		// tempTeacher = 0;

		if (!tempTeacher)
			throw new create_ex("Failed to create teacher");

		// Get the data for the teacher object
		tempTeacher->setup();

		persons.push_back(tempTeacher);
	}
	else {
		// Create a Student object on the heap (i.e. allocate the memory)
		// then add it to the Container 'persons'

		Student *tempStudent = new Student();
		
		if (!tempStudent)
			throw new create_ex("Failed to create student");

		// Get the data for the teacher object
		tempStudent->setup();

		persons.push_back(tempStudent);
	}
}

/* 
******************************************************
*	Function:	search_record
*	return:		void
*	parameters:	none
*
*	Description:
*	This function will prompt the user to enter a 
*	surname, then call the function to search the 
*	existing records.	
*
******************************************************
*/

void search_record() {
	string surname;
	char option;

	do	{
		// Display the Search Surname Menu
		cout << endl << "SEARCH SURNAME. " << endl;
		cout << endl << "---------------" << endl;

		cout << endl <<"Enter the Surname to Search for." << endl;
		cin >> surname;

		// Search the records for the user input surname.
		search_surname(surname);

		cout << endl << "Do you want to continue searching [Y/N]? " << endl;

    cin >> option;
    option = static_cast<char>(std::toupper(option));
	
	}while (option != 'N'); // Continue searching until user enters 'N' or 'n'
}

/* 
******************************************************
*	Function:	search_surname
*	return:		void
*	parameters:	const string &surname
*
*	Description:
*	This function will search the existing records 
*	to find which record matches the user entered
*	Surname.	
*
******************************************************
*/

void search_surname(const string &surname) {
	unsigned int i = 0;

	// Loop around all student and teacher records for a match on 
	// the surname.
	for (i = 0; i < persons.size(); i++) {
		pPerson = persons[i];
	
		// Compare the surname field of the record at index i 
		// with the user input record.
		// *** implement match_surname() in Person, which returns bool ***
		if ((surname.compare(pPerson->get_surname()) == 0)) {
			cout << endl << "Record # " << i + 1 << endl;

			pPerson->display_info();
			pPerson->display_other_info();

			return;
		}
	}

	// Let the user know if the record is not found.
	cout << endl << "The Surname " << surname << " was not found." << endl;
}


/* 
******************************************************
*	Function:	display_all
*	return:		void
*	parameters:	bool do_teachers, bool do_students
*
*	Description:
*	This function will display the current records.  If
*	the parameter do_teachers is true, then all 
*	teachers will be displayed.  If the parameter 
*	do_students is true, then all students will be 
*	displayed.		
*
******************************************************
*/

void display_all(bool do_teachers, bool do_students) {
	int i = 0;

	// Display a header outlining which records will be output
	// to the screen.

	if (do_teachers && do_students)
		cout << endl << "displaying All Records." << endl;
	else if (do_teachers)
		cout << endl << "displaying All Teacher Records." << endl;
	else if (do_students)
		cout << endl << "displaying All Student Records." << endl;
	
	// Loop around all records in Container 'persons'.
	for (i = 0; i < persons.size(); i++) {
		pPerson = persons[i];

		// Determine whether or not the current record is to be displayed.

		if ( (do_teachers && (typeid(*pPerson) == typeid(Teacher))) ||
			 (do_students && (typeid(*pPerson) == typeid(Student))) ) {
			pPerson->display_info();
			pPerson->display_other_info();

			cout << endl << " Press ENTER to continue..." << endl;
			cin.get();
			cout << endl;
		}
	}

	cout << endl << "Returning to the display Record System Menu." << endl;
}


/* 
******************************************************
*	Function:	save_records 
*	return:		void
*	parameters:	none
*
*	Description:
*	This function will save the current list of records to
* a disk file
*
******************************************************
*/

void save_records() {
	string fn;

	// Basic sanity check
	if (persons.size() == 0) {
		cout << "There are no records to save!" << endl;
		return;
	}

	// get filename and open file
	cout << endl <<"Enter the filename (no extension):" << endl;
	cin >> fn;

	// verify it doesn't contain a '.', then add extension
	if (fn.find('.') != string::npos) {
		cout << "Can't have a '.' in a filename!";
		return;
	}
	fn += ".ih";

	// open file
	std::ofstream of(fn.c_str());
	if (!of.good()) {
		cout << "Error opening file" << endl;
		return;
	}

	// write header lines
	of << "Ivor Horton\'s ANSI C++ Database File" << endl;
	of << persons.size() << endl;

	// loop over records, writing each one out.
	// We need to say what sort of record each one is first, and then write the data
	// one line at a time
	for (int i = 0; i < persons.size(); i++) {
		pPerson = persons[i];
		if (typeid(*pPerson) == typeid(Teacher))
			of << "**Teacher" << endl;
		else
			of << "**Student" << endl;

		pPerson->dump_info(of);
	}

	// close file
	of.close();
}


/* 
******************************************************
*	Function:	load_records
*	return:		void
*	parameters:	none
*
*	Description:
*	This function will load a set of records from a file
*
******************************************************
*/

void load_records() {
	string fn;    // filename
	string temp;  // working string

	// get filename and open file
	cout << endl <<"Enter the filename (no extension):" << endl;
	cin >> fn;

	// verify it doesn't contain a '.', then add extension
	if (fn.find('.') != string::npos) {
		cout << "Can't have a '.' in a filename!";
		return;
	}
	fn += ".ih";

  std::ifstream is(fn.c_str());
	if (!is.good()) {
		cout << "Error opening file" << endl;
		return;
	}

	// verify header line
  std::getline(is, temp, '\n');

	if (temp != "Ivor Horton\'s ANSI C++ Database File") {
		cout << "This doesn't seem to be a database file..." << endl;
		return;
	}

	// next line tells us how many records there are
	int nVals;
	is >> nVals;
	cout << "The file contains " << nVals << " records" << endl;

	// loop over records
	for (int i=0; i<nVals; i++) {
		// See what type of object we're reading, and create the appropriate type
    std::ws(is);     // Ignore initial whitespace
		getline(is, temp, '\n');
		if (temp == "**Teacher") {
			cout << "> teacher" << endl;
			pPerson = new Teacher();
		}
		else if (temp == "**Student") {
			cout << "> student" << endl;
			pPerson = new Student();
		}
		else {
			cout << "error! unknown record type" << endl;
			return;
		}

		// Get the object to read in its data
		pPerson->load_info(is);

		// Add it to the deque
		persons.push_back(pPerson);
	}
}

void record_report() {
	cout << endl << "There are " << persons.size() << " records in the list" << endl;

	int nTeachers = 0;
	int nStudents = 0;
	for (unsigned int i = 0; i < persons.size(); i++) {
		pPerson = persons[i];
		if (typeid(*pPerson) == typeid(Teacher))
			nTeachers++;
		else
			nStudents++;
	}
	cout << "Of these, " << nTeachers << " are teachers and " << nStudents << " are students" << endl;
}