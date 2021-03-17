from flask import Flask, render_template, request
import datetime
app = Flask(__name__)

#默认路由
#@app.route('/')
#def hello_world():
#    return 'Hello World'

#创建一个index路由
@app.route('/index')
def hello_index():
    return 'Hello Index'

#获取字符串参数
@app.route('/user/<name>')
def welcome_name(name):
    return 'Hello, %s'%name

#获取整型参数
@app.route('/user/<int:id>')
def welcome_id(id):
    return 'Hello, 第 %s 号会员'%id

#获取浮点型参数
@app.route('/user/<float:balance>')
def welcome_balance(balance):
    return 'Hello, Your Balance: %s'%balance

#默认路由2，返回给用户渲染后的文件
@app.route('/')
def getIndex():
    return render_template("index.html")

#向页面传入变量
@app.route('/vars')
def getIndex_vars():
    date = datetime.date.today()               #普通变量
    name = ["张三", "李四", "王五", "赵六"]     #列表变量
    task = {"任务":"打扫卫生", "时间":"3小时"}  #字典变量
    return render_template("test/vars.html", date = date, name = name, task = task)

#表单提交
@app.route('/test/register')
def register():
    return render_template("test/register.html")

#接收表单提交的路由，需要指定允许POST方法
@app.route('/result', methods=['POST', 'GET'])
def result():
    if request.method == 'POST':
        result = request.form
        return render_template("test/result_post.html", result = result)
    else:
        return render_template("test/result_get.html")

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000, debug=True)