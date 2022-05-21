1 <=> 5            # -1
5 <=> 5            # 0
9 <=> 5            # 1
"1" <=> 5          # nil: integers and strings are not comparable

1.between?(0, 10)  # true: 0 <= 1 <= 10

nan = 0.0 / 0.0;   # zero divided by zero is not-a-number
nan < 0            # false: it is not less than zero
nan > 0            # false: it is not greater than zero
nan == 0           # false: it is not equal to zero
nan == nan         # false: it is not even equal to itself!
nan.equal?(nan)    # this is true, of course
