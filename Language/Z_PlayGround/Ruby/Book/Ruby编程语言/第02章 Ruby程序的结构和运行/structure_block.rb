if x < 10     # If this expression is true
  x = x + 1   # Then execute this statement
end           # Marks the end of the conditional

while x < 10  # While this expression is true...
  print x     # Execute this statement
  x = x + 1   # Then execute this statement
end           # Marks the end of the loop

3.times { print "Ruby! " }

1.upto(10) do |x|
  print x
end

module Stats                          # A module
  class Dataset                       # A class in the module
    def initialize(filename)          # A method in the class
      IO.foreach(filename) do |line|  # A block in the method
        if line[0, 1] == "#"          # An if statement in the block
          next                        # A simple statement in the if
        end                           # End the if body
      end                             # End the block
    end                               # End the method body
  end                                 # End the class body
end                                   # End the module body
