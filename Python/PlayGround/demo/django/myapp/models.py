from django.db import models

# Create your models here.

class Grades(models.Model):
    gname    = models.CharField(max_length=20)
    gdate    = models.DateTimeField()
    ggirlnum = models.IntegerField()
    gboynum  = models.IntegerField()
    isDelete = models.BooleanField(default=False)

    def __str__(self):
        # 结果不方便查看，只是为了演示
        # return "%s-%s-%d"%(self.gname, self.ggirlnum, self.gboynum)
        return self.gname

    class Meta:
        db_table="grades"

class StudentsManager(models.Manager):
    def get_queryset(self):
        return super(StudentsManager,self).get_queryset().filter(isDelete=False)

    def createStudent2(self, name, age, gender, content, grade, lastT, createT, isD=False):
        stu = self.model()
        stu.sname = name
        stu.sage = age
        stu.sgender = gender
        stu.scontent = content
        stu.sgrade = grade
        stu.lastTime = lastT
        stu.createTime = createT
        return stu

class Students(models.Model):
    # 自定义管理器
    stuObj1 = models.Manager()
    stuObj2 = StudentsManager()

    sname    = models.CharField(max_length=20)
    sgender  = models.BooleanField(default=True)
    sage     = models.IntegerField()
    scontent = models.CharField(max_length=100)
    isDelete = models.BooleanField(default=False)
    # 关联外键
    sgrade   = models.ForeignKey("Grades")

    def __str__(self):
        return self.sname

    lastTime = models.DateTimeField(auto_now=True)
    createTime = models.DateTimeField(auto_now_add=True)
    class Meta:
        db_table="students"
        ordering=['id']

    # 定义一个类方法来创建对象
    @classmethod
    def createStudent1(cls, name, age, gender, content, grade, lastT, createT, isD=False):
        stu = cls(sname=name, sage=age, sgender=gender, scontent=content, sgrade=grade, lastTime=lastT,
                createTime=createT, isDelete=isD)
        return stu

from tinymce.models import HTMLField
class Text(models.Model):
    str = HTMLField()
