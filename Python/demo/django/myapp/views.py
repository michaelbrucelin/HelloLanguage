from django.shortcuts import render

# Create your views here.

from django.http import HttpResponse,HttpResponseRedirect
def index(request):
    return HttpResponse("Hello World, This is mlin.")

def index0(request):
    return HttpResponseRedirect("/")

from django.shortcuts import redirect
def index1(request):
    return redirect("/")

def detailnum(request, num):
    return HttpResponse("detail-%s"%num)

def detailtwonums(request, num1, num2):
    return HttpResponse("detail-%s-%s"%(num1, num2))

from .models import Grades
def grades(request):
    # 去模板里取数据
    gradesList = Grades.objects.all()
    # 将数据传递给模板，模板在渲染页面，再将渲染好的页面传递回给浏览器
    # 传参数时，传的是一个字典，键是形参，值是实参
    return render(request, 'myapp/grades.html', {"grades":gradesList})

from .models import Students
def students(request):
    studentsList = Students.stuObj1.all()
    return render(request, 'myapp/students.html', {"students":studentsList})

def stupage(request, page):
    # 每页显示5条数据
    page = int(page)
    studentsList = Students.stuObj1.all()[(page - 1) * 5:page * 5]
    return render(request, 'myapp/students.html', {"students":studentsList})

def gradeStudents(request,num):
    grade = Grades.objects.get(pk=num)
    studentsList = grade.students_set.all()
    return render(request, 'myapp/students.html', {"students":studentsList})

def addStudent1(request):
    grade = Grades.objects.get(pk=1)
    stu = Students.createStudent1("八神庵", 18, True, "我叫八神庵，我爱弹吉他。", grade,
            "2018-01-29", "2018-01-29")
    stu.save()
    return HttpResponse("创建了学生：八神庵。")

def addStudent2(request):
    grade = Grades.objects.get(pk=1)
    stu = Students.stuObj2.createStudent2("神乐千鹤", 18, False, "我是鹤", grade, "2018-01-30", "2018-01-30")
    stu.save()
    return HttpResponse("创建了学生：神乐千鹤。")

def showrequest(request):
    print(request.path)
    print(request.method)
    print(request.encoding)
    print(request.GET)
    print(request.POST)
    print(request.FILES)
    print(request.COOKIES)
    print(request.session)
    return HttpResponse("showrequest")

def showresponse(request):
    res = HttpResponse()
    res.content = b'good'
    print(res.content)
    print(res.charset)
    print(res.status_code)
    print(res.content-type)
    return res

def get1(request):
    a = request.GET.get('a')
    b = request.GET.get('b')
    c = request.GET['c']
    return HttpResponse(a + "===" + b + "===" + c)

def get2(request):
    a = request.GET.getlist('a')
    a1 = a[0]
    a2 = a[1]
    c = request.GET['c']
    return HttpResponse(a1 + "===" + a2 + "===" + c)

def showregister(request):
    return render(request, 'myapp/register.html')

def register(request):
    name = request.POST.get("name")
    gender = request.POST.get("gender")
    age = request.POST.get("age")
    hobby = request.POST.getlist("hobby")
    print(name)
    print(gender)
    print(age)
    print(hobby)
    return HttpResponse("register not open, infomation printed background.")

def cookieset(request):
    res = HttpResponse()
    cookie = res.set_cookie("mlin", "good man")
    return res

def cookieget(request):
    res = HttpResponse()
    cookie = request.COOKIES
    res.write("<h1>"+cookie["mlin"]+"</h1>")
    return res

from django.http import HttpResponseRedirect
def redirect1(request):
    return HttpResponseRedirect("/redirect2")

def redirect2(request):
    return HttpResponse("this is redirect2`s page.")

def main(request):
    # 取session
    username = request.session.get('uname', '游客')
    return render(request, "myapp/main.html", {'username':username})

def login(request):
    return render(request, "myapp/login.html")

def showmain(request):
    username = request.POST.get("username")
    # 存储session
    request.session['uname'] = username
    request.session.set_expiry(10)
    return redirect("/main")

from django.contrib.auth import logout
def quit(request):
    # 清除session
    logout(request)
    return redirect("/main")

def bad(request):
    return render(request, 'myapp/bad.html')

def good(request):
    return render(request, 'myapp/good.html')

def mymain_base01(request):
    return render(request, 'myapp/mymain_base01.html')

def test(request):
    return render(request, 'myapp/test.html', {"code":"<h1>this is code from view</h1>"})

def postfile(request):
    return render(request, 'myapp/postfile.html')

def showinfo(request):
    username = request.POST.get("username")
    password = request.POST.get("password")
    return render(request, 'myapp/showinfo.html', {"username":username,"password":password})

def upfile(request):
    return render(request, 'myapp/upfile.html')

import os
from django.conf import settings
def savefile(request):
    if request.method == "POST":
        file = request.FILES["file"]
        filePath = os.path.join(settings.MDEIA_ROOT, file.name)
        with open(filePath, 'wb') as fp:
            for info in file.chunks():
                fp.write(info)
        return HttpResponse("upload succesed!")
    else:
        return HttpResponse("upload failed!")

from .models import Students
from django.core.paginator import Paginator
def studentspage(request, pageid):
    allList = Students.stuObj1.all()
    paginator = Paginator(allList, 6)
    page = paginator.page(pageid)
    return render(request, 'myapp/studentspage.html', {"students":page})

def studentsajax(request):
    return render(request, 'myapp/studentsajax.html')

from django.http import JsonResponse
def studentsinfo(request):
    stus = Students.stuObj1.all()
    list = []
    for stu in stus:
        list.append([stu.sname, stu.sage, stu.sgender])
    return JsonResponse({"data":list})

def fuwenben(request):
    return render(request, 'myapp/fuwenben.html')

from .task import wait5s
def celery(request):
    wait5s.delay()
    return render(request, 'myapp/celery.html')