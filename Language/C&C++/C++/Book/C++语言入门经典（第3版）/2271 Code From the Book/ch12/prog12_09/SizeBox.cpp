// SizeBox.cpp
#include "SizeBox.h"

SizeBox::SizeBox() :
     length(1.0), width(1.0), height(1.0), pMaterial("Cardboard") {}

// Sum of sizes of members
int SizeBox::totalSize() {
  return sizeof(length) + sizeof(width) + sizeof(height) + sizeof(pMaterial);
}
