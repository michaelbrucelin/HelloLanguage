/*
***************************************************************
*
*	Project.h
*	
****************************************************************
*/

// Include files
#include <string>

using std::string;

// Global Const variables.  These variables determine
// the maximum lengths of fields and member variables.

const int MAX_FIELD_SIZE	= 35;
const int HEADER_SIZE		= 15;

const int SURNAME_SIZE		= 21;
const int FIRST_NAME_SIZE	= 21;
const int ADDRESS_SIZE		= 31;
const int CITY_SIZE			= 21;
const int STATE_SIZE		= 4;
const int ZIP_CODE_SIZE		= 7;
const int PHONE_NUMBER_SIZE	= 9;

/*
***************************************************************
*
*	In this file we declare the member functions and member
*	variables of the "Person" base class, as well as it's 
*	derived classes.
*
****************************************************************
*/

/*
****************************************************************
*
*	The "Person" Class.  This is the base class for 
*	both the Student and Teacher class.
*
****************************************************************
*/

class Person {
private:

	// Private member variables
	string first_name;
	string surname;
	string address1;
	string address2;
	string address3;
	string city;
	string state;
	int zip;
	string phone;

	// Private virtual member functions
	// virtual void set_other_info() = 0;

public:
	// Function to get the data for the object
	virtual void setup();
	
	// Public Get member functions
  string get_first_name() const{ return first_name; }
  string get_surname() const { return surname; }
  string get_address1() const {return address1; }
  string get_address2() const { return address2; }
	string get_address3() const { return address3; }
  string get_city() const { return city; }
  string get_state() const { return state; }
  int    get_zip() const { return zip; }
  string get_phone() const { return phone; }

	void display_info() const;
  virtual void dump_info(std::ostream& os) const;
  virtual void load_info(std::ifstream& is);
	bool validate_input(const string& input, bool is_string = true);

	// Public Set member functions
	void set_first_name();
	void set_surname();
	void set_address();
	void set_city();
	void set_state();
	void set_zip();
	void set_phone();

	// Public virtual member functions
	virtual void display_other_info() const = 0;
};

/*
****************************************************************
*
*	The "Student" Class inherited from the 
*	"Person" base Class.
*
****************************************************************
*/

class Student : public Person {
private:
	
	// Private member variables
	string student_ID;
	int grade;

public:
	// Function to get the data for the object
	virtual void setup();
	
	// Public virtual member functions
	virtual void display_other_info() const;
  virtual void dump_info(std::ostream& os) const;
  virtual void load_info(std::ifstream& is);
};

/*
****************************************************************
*
*	The "Teacher" Class inherited from the 
*	"Person" base Class.
*
****************************************************************
*/

class Teacher: public Person {
private:
	
	// Private member variables
	int years_experience;
	long salary;

public:
	// Function to get the data for the object
	virtual void setup();
	
	// Public virtual member functions
	virtual void display_other_info() const;
  virtual void dump_info(std::ostream& os) const;
	virtual void load_info(std::ifstream& is);
};


// Exception class
class create_ex: public std::exception {
private:
	string msg;

public:
	create_ex(const string& m) { msg = m; }
	const char* what() const throw() { return msg.c_str(); }
};
