[1, 2, 3]                                    # An array that holds three Fixnum objects
[-10...0, 0..10]                             # An array of two ranges; trailing commas are allowed
[[1, 2], [3, 4], [5]]                        # An array of nested arrays
[x + y, x - y, x * y]                        # Array elements can be arbitrary expressions
[]                                           # The empty array has size 0

words = %w[this is a test]                   # Same as: ['this', 'is', 'a', 'test']
open = %w| ( [ { < |                         # Same as: ['(', '[', '{', '<']
white = %W(\s \t \r \n)                      # Same as: ["\s", "\t", "\r", "\n"]

empty = Array.new                            # []: returns a new empty array
nils = Array.new(3)                          # [nil, nil, nil]: new array with 3 nil elements
zeros = Array.new(4, 0)                      # [0, 0, 0, 0]: new array with 4 0 elements
copy = Array.new(nils)                       # Make a new copy of an existing array
count = Array.new(3) { |i| i + 1 }           # [1,2,3]: 3 elements computed from index

a = [0, 1, 4, 9, 16]                         # Array holds the squares of the indexes
a[0]                                         # First element is 0
a[-1]                                        # Last element is 16
a[-2]                                        # Second to last element is 9
a[a.size - 1]                                # Another way to query the last element
a[-a.size]                                   # Another way to query the first element
a[8]                                         # Querying beyond the end returns nil
a[-8]                                        # Querying before the start returns nil, too

a[0] = "zero"                                # a is ["zero", 1, 4, 9, 16]
a[-1] = 1..16                                # a is ["zero", 1, 4, 9, 1..16]
a[8] = 64                                    # a is ["zero", 1, 4, 9, 1..16, nil, nil, nil, 64]
a[-10] = 100                                 # Error: can't assign before the start of an array

a = ("a".."e").to_a                          # Range converted to ['a', 'b', 'c', 'd', 'e']
a[0, 0]                                      # []: this subarray has zero elements
a[1, 1]                                      # ['b']: a one-element array
a[-2, 2]                                     # ['d','e']: the last two elements of the array
a[0..2]                                      # ['a', 'b', 'c']: the first three elements
a[-2..-1]                                    # ['d','e']: the last two elements of the array
a[0...-1]                                    # ['a', 'b', 'c', 'd']: all but the last element

a[0, 2] = ["A", "B"]                         # a becomes ['A', 'B', 'c', 'd', 'e']
a[2...5] = ["C", "D", "E"]                   # a becomes ['A', 'B', 'C', 'D', 'E']
a[0, 0] = [1, 2, 3]                          # Insert elements at the beginning of a
a[0..2] = []                                 # Delete those elements
a[-1, 1] = ["Z"]                             # Replace last element with another
a[-1, 1] = "Z"                               # For single elements, the array is optional
a[-2, 2] = nil                               # Delete last 2 elements in 1.8; replace with nil in 1.9

a = [1, 2, 3] + [4, 5]                       # [1, 2, 3, 4, 5]
a = a + [[6, 7, 8]]                          # [1, 2, 3, 4, 5, [6, 7, 8]]
a = a + 9                                    # Error: righthand side must be an array

a = []                                       # Start with an empty array
a << 1                                       # a is [1]
a << 2 << 3                                  # a is [1, 2, 3]
a << [4, 5, 6]                               # a is [1, 2, 3, [4, 5, 6]]
a.concat [7, 8]                              # a is [1, 2, 3, [4, 5, 6], 7, 8]

["a", "b", "c", "b", "a"] - ["b", "c", "d"]  # ['a', 'a']

a = [0] * 8                                  # [0, 0, 0, 0, 0, 0, 0, 0]

a = [1, 1, 2, 2, 3, 3, 4]
b = [5, 5, 4, 4, 3, 3, 2]
a | b                                        # [1, 2, 3, 4, 5]: duplicates are removed
b | a                                        # [5, 4, 3, 2, 1]: elements are the same, but order is different
a & b                                        # [2, 3, 4]
b & a                                        # [4, 3, 2]

a = ("A".."Z").to_a                          # Begin with an array of letters
a.each { |x| print x }                       # Print the alphabet, one letter at a time
