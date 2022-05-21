a = "Ruby"                  # One reference to one String object
b = c = "Ruby"              # Two references to another String object
a.equal?(b)                 # false: a and b are different objects
b.equal?(c)                 # true: b and c refer to the same object

a.object_id == b.object_id  # Works like a.equal?(b)

a = "Ruby"                  # One String object
b = "Ruby"                  # A different String object with the same content
a.equal?(b)                 # false: a and b do not refer to the same object
a == b                      # true: but these two distinct objects have equal values

1 == 1.0                    # true: Fixnum and Float objects can be ==
1.eql?(1.0)                 # false: but they are never eql!

(1..10) === 5               # true: 5 is in the range 1..10
/\d+/ === "123"             # true: the string matches the regular expression
String === "s"              # true: "s" is an instance of the class String
:s === "s"                  # true in Ruby 1.9
