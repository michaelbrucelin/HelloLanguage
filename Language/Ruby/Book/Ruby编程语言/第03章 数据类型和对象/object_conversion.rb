# Ruby 1.8 only
e = Exception.new("not really an exception")
msg = "Error: " + e  # String concatenation with an Exception

1.1.coerce(1)        # [1.0, 1.1]: coerce Fixnum to Float
require "rational"   # Use Rational numbers
r = Rational(1, 3)   # One third as a Rational number
r.coerce(2)          # [Rational(2,1), Rational(1,3)]: Fixnum to Rational

if x != nil          # Expression "x != nil" returns true or false to the if
  puts x             # Print x if it is defined
end

if x                 # If x is non-nil
  puts x             # Then print it
end
