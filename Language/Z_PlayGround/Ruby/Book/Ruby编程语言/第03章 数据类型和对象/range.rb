1..10                             # The integers 1 through 10, including 10
1.0...10.0                        # The numbers between 1.0 and 10.0, excluding 10.0 itself

cold_war = 1945..1989
cold_war.include? birthdate.year

r = "a".."c"
r.each { |l| print "[#{l}]" }     # Prints "[a][b][c]"
r.step(2) { |l| print "[#{l}]" }  # Prints "[a][c]"
r.to_a                            # => ['a','b','c']: Enumerable defines to_a

1..3.to_a                         # Tries to call to_a on the number 3
(1..3).to_a                       # => [1,2,3]

r = 0...100                       # The range of integers 0 through 99
r.member? 50                      # => true: 50 is a member of the range
r.include? 100                    # => false: 100 is excluded from the range
r.include? 99.9                   # => true: 99.9 is less than 100

triples = "AAA".."ZZZ"
triples.include? "ABC"            # true; fast in 1.8 and slow in 1.9
triples.include? "ABCD"           # true in 1.8, false in 1.9
triples.cover? "ABCD"             # true and fast in 1.9
triples.to_a.include? "ABCD"      # false and slow in 1.8 and 1.9
