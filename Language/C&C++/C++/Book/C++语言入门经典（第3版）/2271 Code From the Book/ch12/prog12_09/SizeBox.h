// SizeBox.h
#ifndef SIZEBOX_H
#define SIZEBOX_H

class SizeBox {
  public:
    SizeBox();
    int totalSize();                   // Sum of sizes of members

  private:
    char* pMaterial;
    double length;
    double width;
    double height;
};

#endif
