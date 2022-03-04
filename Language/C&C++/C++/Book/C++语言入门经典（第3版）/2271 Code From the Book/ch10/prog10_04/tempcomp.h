// tempcomp.h
namespace compare {
// Function template to find the maximum element in an array
template<class T> T max(const T* data, int size) {
    T result = data[0];
    for(int i = 1 ; i < size ; i++)
      if(result < data[i])
        result = data[i];
    return result;
  }

// Function template to find the minimum element in an array
template<class T> T min(const T* data, int size) {
    T result = data[0];
    for(int i = 1 ; i < size ; i++)
      if(result > data[i])
        result = data[i];
    return result;
  }
}
