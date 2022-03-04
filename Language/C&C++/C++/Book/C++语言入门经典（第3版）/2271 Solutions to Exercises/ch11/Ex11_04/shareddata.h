// Exercise 11.4 Exercising SharedData - shareddata.h
// Definitions for Type enumeration and SharedData structure
enum Type { Double, Float, Long, Int, pDouble, pFloat, pLong, pInt};

struct SharedData {
    union {                   // An anonymous union
      double dData;
      float fData;
      long lData;
      int iData;
      double* pdData;       // Pointers to
      float* pfData;        // various types
      long* plData;
      int* piData;
    };
    Type type;              // Variable of the enumeration type Type
    void show();            // Display a SharedData value

};