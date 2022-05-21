s = "ice"    # Strings are mutable objects
s.freeze     # Make this string immutable
s.frozen?    # true: it has been frozen
s.upcase!    # TypeError: can't modify frozen string
s[0] = "ni"  # TypeError: can't modify frozen string
