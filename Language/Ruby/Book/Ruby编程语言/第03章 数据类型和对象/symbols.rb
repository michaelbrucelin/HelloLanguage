:symbol                 # A Symbol literal
:"symbol"               # The same literal
:'another long symbol'  # Quotes are useful for symbols with spaces
s = "string"
sym = :"#{s}"           # The Symbol :string

%s["]                   # Same as :'"'

o.respond_to? :each

name = :size
if o.respond_to? name
  o.send(name)
end

str = "string"          # Begin with a string
sym = str.intern        # Convert to a symbol
sym = str.to_sym        # Another way to do the same thing
str = sym.to_s          # Convert back to a string
str = sym.id2name       # Another way to do it
