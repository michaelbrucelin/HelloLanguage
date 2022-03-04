// Program 11.2 Using pointers to Box objects,  File:  box.h
// Defines the Box structure type
#ifndef BOX_H
#define BOX_H

struct Box {
  double length;
  double width;
  double height;

  double volume();       // Function to calculate the volume of a box
};
#endif
