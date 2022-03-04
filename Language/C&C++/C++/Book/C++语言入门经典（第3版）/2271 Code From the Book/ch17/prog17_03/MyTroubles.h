// MyTroubles.h Exception class definition
#ifndef MYTROUBLES_H
#define MYTROUBLES_H

class Trouble {
  public:
    Trouble(const char* pStr = "There's a problem") : pMessage(pStr) {}
    const char* what() const {return pMessage;}

  private:
    const char* pMessage;
};

#endif
