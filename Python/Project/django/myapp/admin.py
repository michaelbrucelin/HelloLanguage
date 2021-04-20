from django.contrib import admin

# Register your models here.

from .models import Grades, Students

# 在创建班级时，直接创建5个学生
# class StudentsAdminWithGrades(admin.StackedInline):  这种方式数据显示不友好
class StudentsAdminWithGrades(admin.TabularInline):
    model = Students
    extra = 5

class GradesAdmin(admin.ModelAdmin):
    # 在创建班级时，直接创建5个学生
    inlines = [StudentsAdminWithGrades]
    # 列表页属性
    # 显示字段
    list_display = ['pk', 'gname', 'gdate', 'ggirlnum', 'gboynum', 'isDelete']
    # 过滤字段
    list_filter = ['gname', 'gdate', 'ggirlnum', 'gboynum', 'isDelete']
    # 搜索字段
    search_fields = ['gname', 'gdate', 'ggirlnum', 'gboynum', 'isDelete']
    # 分页
    list_per_page = 5

    # 添加、修改页属性, fields和fieldsets不能同时使用
    # 属性的先后顺序
    # fields = ['gname', 'gdate', 'ggirlnum', 'gboynum', 'isDelete']
    # 给属性分组
    fieldsets = [
        ('basic', {'fields':['gname', 'gdate', 'isDelete']}),
        ('num', {'fields':['ggirlnum', 'gboynum']}),
        ('delete', {'fields':['isDelete']})
    ]

@admin.register(Students)
class StudentsAdmin(admin.ModelAdmin):
    # boolean值显示
    def gender(self):
        if self.sgender:
            return 'boy'
        else:
            return 'girl'
    # 表头
    gender.short_description = '性别'

    list_display = ['pk', 'sname', 'sage', gender, 'scontent', 'sgrade', 'isDelete']
    list_per_page = 10

#执行动作的位置
actions_on_top = True
actions_on_bottom = False

# 注册
admin.site.register(Grades, GradesAdmin)
# admin.site.register(Students, StudentsAdmin)
from .models import Text
admin.site.register(Text)
