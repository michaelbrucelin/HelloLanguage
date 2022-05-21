o = "test"                     # This is a value
o.class                        # Returns an object representing the String class

o.class                        # String: o is a String object
o.class.superclass             # Object: superclass of String is Object
o.class.superclass.superclass  # nil: Object has no superclass

# Ruby 1.9 only
Object.superclass              # BasicObject: Object has a superclass in 1.9
BasicObject.superclass         # nil: BasicObject has no superclass

o.class == String              # true if o is a String
o.instance_of? String          # true if o is a String

x = 1                          # This is the value we're working with
x.instance_of? Fixnum          # true: is an instance of Fixnum
x.instance_of? Numeric         # false: instance_of? doesn't check inheritance
x.is_a? Fixnum                 # true: x is a Fixnum
x.is_a? Integer                # true: x is an Integer
x.is_a? Numeric                # true: x is a Numeric
x.is_a? Comparable             # true: works with mixin modules, too
x.is_a? Object                 # true for any value of x

Numeric === x                  # true: x is_a Numeric

o.respond_to? :"<<"            # true if o has an << operator

o.respond_to? :"<<" and not o.is_a? Numeric
