#!/usr/bin/ruby

# puts adds a new line to the end of each argument if there is not one already.
# print does not add a new line.

puts [[1,2,3], [4,5,nil]]

print "\n----------------------------------------------------------------\n"

print [[1,2,3], [4,5,nil]]
print("no new line.")

=begin
ruby print_puts.rb
> 1
> 2
> 3
> 4
> 5
> 
> 
> ----------------------------------------------------------------
> [[1, 2, 3], [4, 5, nil]]no new line.
=end