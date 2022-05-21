#!/usr/bin/ruby

# 神奇（诡异）的迭代器
3.times { print "Ruby!" }; print "\n"
1.upto(9) { |x| print x }; print "\n"

a = [3, 2, 1]
a[3] = a[2] - 1
a.each do |elt|
  print elt + 1
end
print "\n"

a = [1, 2, 3, 4]
b = a.map { |x| x * x }
c = a.select { |x| x % 2 == 0 }
a.inject do |sum, x|
  sum + x
end

h = {
  :one => 1,
  :two => 2,
}
h[:one]
h[:three] = 3
h.each do |key, value|
  print "#{value}:#{key}; "  # 类似于C#中的$"{value}:{key}; "
end
print "\n"

File.open("data.txt") do |f| # Open named file and pass stream to block
  line = f.readline # Use the stream to read from the file
end # Stream automatically closed at block end

t = Thread.new do # Run this block in a new thread
  File.read("data.txt") # Read a file in the background
end # File contents available as thread value

=begin
ruby iterator.rb
> Ruby!Ruby!Ruby!
> 123456789
> 4321
> 1:one; 2:two; 3:three; 
=end
