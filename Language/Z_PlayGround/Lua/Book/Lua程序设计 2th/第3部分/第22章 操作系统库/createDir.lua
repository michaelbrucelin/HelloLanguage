function createDir(dirname)
    os.execute("mkdir " .. dirname)  -- os.execute() 函数用于执行一个系统命令，相当于C语言中的system()函数
end
