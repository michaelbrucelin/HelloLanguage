# This hash will map the names of digits to the digits themselves
numbers = Hash.new                                  # Create a new, empty, hash object
numbers["one"] = 1                                  # Map the String "one" to the Fixnum 1
numbers["two"] = 2                                  # Note that we are using array notation here
numbers["three"] = 3
sum = numbers["one"] + numbers["two"]               # Retrieve values like this

numbers = { "one" => 1, "two" => 2, "three" => 3 }
numbers = { :one => 1, :two => 2, :three => 3 }
numbers = { :one, 1, :two, 2, :three, 3 }           # Same, but harder to read
numbers = { :one => 1, :two => 2, }                 # Extra comma ignored
numbers = { one: 1, two: 2, three: 3 }
