s = "Ruby"  # Create a String object. Store a reference to it in s.
t = s       # Copy the reference to t. s and t both refer to the same object.
t[-1] = ""  # Modify the object through the reference in t.
print s     # Access the modified object through s. Prints "Rub".
t = "Java"  # t now refers to a different object.
print s, t  # Prints "RubJava".
