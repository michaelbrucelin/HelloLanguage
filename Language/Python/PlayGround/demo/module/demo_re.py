import re

pat = re.compile("ABC")

print(pat.search("ABAB"))
print(pat.search("ABABC"))

print(re.search("AB", "CBAAB"))
print(re.findall("a", "abcdabcda"))
print(re.findall("\d", "a1b2c3d4"))

print(re.sub("a", "A", "a1b2c3d4"))