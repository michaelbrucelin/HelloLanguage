/*********************************************************************************
Exercise 3.4 The output from the code is 2. Here's the important statement again:

  unsigned int j = (k >> 4) & ~(~0 << 3);

This question is an exercise in bit manipulation on k. 
First, (k >> 4) shifts the bits in k 4 places to the right;
 the bitwise representation of 430 is 110101110, 
so a 4-bit shift leaves 11010. 
Next, ~0 is composed of all 1s; shifting that three places to the left
 and complementing the result will leave 111. 
Finally, doing a bitwise AND on 11010 and 111 leaves 10 (in binary)
 or 2 (in decimal) as the result.
*********************************************************************************/