// MyTroubles.h Exception class definition
#ifndef MYTROUBLES_H
#define MYTROUBLES_H

// Base exception class
class Trouble {
  public:
    Trouble(const char* pStr = "There's a problem");
    virtual ~Trouble();
    virtual const char* what() const;

  private:
    const char* pMessage;
};

// Derived exception class
class MoreTrouble : public Trouble {
  public:
    MoreTrouble(const char* pStr = "There's more trouble");
};

// Derived exception class 
class BigTrouble : public MoreTrouble {
  public:
    BigTrouble(const char* pStr = "Really big trouble");
};

#endif
