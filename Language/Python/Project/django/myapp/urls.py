from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^index/$', views.index1),
    url(r'^index.html/$', views.index0),
    url(r'^(\d+)/$', views.detailnum),
    url(r'^(\d+)/(\d+)/$', views.detailtwonums),
    url(r'^grades/$', views.grades),
    url(r'^students/$', views.students),
    url(r'^grades/(\d+)/$', views.gradeStudents),
    url(r'^addstudent1/$', views.addStudent1),
    url(r'^addstudent2/$', views.addStudent2),
    url(r'^students/(\d+)/$', views.stupage),
    url(r'^showrequest/$', views.showrequest),
    url(r'^showresponse/$', views.showresponse),
    url(r'^get1/$', views.get1),
    url(r'^get2/$', views.get2),
    url(r'^showregister/$', views.showregister),
    url(r'^showregister/register/$', views.register),
    url(r'^cookieset/$', views.cookieset),
    url(r'^cookieget/$', views.cookieget),
    url(r'^redirect1/$', views.redirect1),
    url(r'^redirect2/$', views.redirect2),
    url(r'^main/$', views.main),
    url(r'^login/$', views.login),
    url(r'^login/showmain/$', views.showmain),
    url(r'^quit/$', views.quit),
    url(r'^bad/$', views.bad, name="bad"),
    url(r'^good/$', views.good, name="good"),
    url(r'^mymain_base01/$', views.mymain_base01),
    url(r'^test/$', views.test),
    url(r'^postfile/$', views.postfile),
    url(r'^showinfo/$', views.showinfo),
    url(r'^upfile/$', views.upfile),
    url(r'^savefile/$', views.savefile),
    url(r'^studentspage/(\d+)/$', views.studentspage),
    url(r'^studentsajax/$', views.studentsajax),
    url(r'^studentsinfo/$', views.studentsinfo),
    url(r'^fuwenben/$', views.fuwenben),
    url(r'^celery/$', views.celery),
]