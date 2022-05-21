class Range                # Open an existing class for additions
  def by(step)             # Define an iterator named by
    x = self.begin         # Start at one endpoint of the range
    if exclude_end?        # For ... ranges that exclude the end
      while x < self.end   # Test with the < operator
        yield x
        x += step
      end
    else                   # Otherwise, for .. ranges that include the end
      while x <= self.end  # Test with <= operator
        yield x
        x += step
      end
    end
  end                      # End of method definition
end                        # End of class modification

=begin
为Range类添加一个新的迭代器
# Examples
(0..10).by(2) { |x| print x }   # Prints "0246810"
(0...10).by(2) { |x| print x }  # Prints "02468"
=end
