=begin
if windows
  listcmd = "dir"
else
  listcmd = "ls"
end
listing = `#{listcmd}`
=end

listcmd = "ls /etc/fonts/"
listing = `#{listcmd}`               # 在shell中执行命令
puts listing
print "\n"

listing = Kernel.`("ls /dev/disk/")  # 这样也可以
puts listing

=begin
ruby execbash.rb
> conf.avail
> conf.d
> fonts.conf
> 
> by-id
> by-partuuid
> by-path
> by-uuid
=end