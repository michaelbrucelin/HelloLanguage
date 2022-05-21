10.times { puts "test".object_id }  # ruby中的字符串是可变的，所以每次解释器遇到一个字符串字面量的时候，都会新建一个新对象

s = "hello";               # Ruby 1.8
s[0]                       # 104: the ASCII character code for the first character 'h'
s[s.length - 1]            # 111: the character code of the last character 'o'
s[-1]                      # 111: another way of accessing the last character
s[-2]                      # 108: the second-to-last character
s[-s.length]               # 104: another way of accessing the first character
s[s.length]                # nil: there is no character at that index

s = "hello";               # Ruby 1.9
s[0]                       # 'h': the first character of the string, as a string
s[s.length - 1]            # 'o': the last character 'o'
s[-1]                      # 'o': another way of accessing the last character
s[-2]                      # 'l': the second-to-last character
s[-s.length]               # 'h': another way of accessing the first character
s[s.length]                # nil: there is no character at that index

s[0] = ?H                  # Replace first character with a capital H
s[-1] = ?O                 # Replace last character with a capital O
s[s.length] = ?!           # ERROR! Can't assign beyond the end of the string

s = "hello"                # Begin with a greeting
s[-1] = ""                 # Delete the last character; s is now "hell"
s[-1] = "p!"               # Change new last character and add one; s is now "help!"

s = "hello"
s[0, 2]                    # "he"
s[-1, 1]                   # "o": returns a string, not the character code ?o
s[0, 0]                    # "": a zero-length substring is always empty
s[0, 10]                   # "hello": returns all the characters that are available
s[s.length, 1]             # "": there is an empty string immediately beyond the end
s[s.length + 1, 1]         # nil: it is an error to read past that
s[0, -1]                   # nil: negative lengths don't make any sense

s = "hello"
s[0, 1] = "H"              # Replace first letter with a capital letter
s[s.length, 0] = " world"  # Append by assigning beyond the end of the string
s[5, 0] = ","              # Insert a comma, without deleting anything
s[5, 6] = ""               # Delete with no insertion; s == "Hellod"

s = "hello"
s[2..3]                    # "ll": characters 2 and 3
s[-3..-1]                  # "llo": negative indexes work, too
s[0..0]                    # "h": this Range includes one character index
s[0...0]                   # "": this Range is empty
s[2..1]                    # "": this Range is also empty
s[7..10]                   # nil: this Range is outside the string bounds
s[-2..-1] = "p!"           # Replacement: s becomes "help!"
s[0...0] = "Please "       # Insertion: s becomes "Please help!"
s[6..10] = ""              # Deletion: s becomes "Please!"

s = "hello"                # Start with the word "hello"
while (s["l"])             # While the string contains the substring "l"
  s["l"] = "L"             # Replace first occurrence of "l" with "L"
end                        # Now we have "heLLo"

s[/[aeiou]/] = "*"         # Replace first vowel with an asterisk

s = "¥1000"
s.each_char { |x| print "#{x} " }            # Prints "¥ 1 0 0 0". Ruby 1.9
0.upto(s.size - 1) { |i| print "#{s[i]} " }  # Inefficient with multibyte chars
