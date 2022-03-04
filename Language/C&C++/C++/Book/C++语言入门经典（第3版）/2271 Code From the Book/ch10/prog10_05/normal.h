// normal.h
// Normalize an array of values to the range 0 to 1
#include "tempcomp.h"

namespace compare {
  template<class Toriginal, class Tnormalized>
      void normalize(Toriginal* data, Tnormalized* newData, int size) {
    Toriginal minValue = min(data, size);        // Get minimum element

    // Shift all elements so minimum is zero
    for(int i = 0 ; i < size ; i++)
      newData[i] = static_cast<Tnormalized>(data[i]-minValue);

    Tnormalized maxValue = max(newData, size);    // Get max of new set 

    // Scale elements so maximum is 1
    for(int i = 0 ; i < size ; i++)
      newData[i] /= maxValue;
  }
}
