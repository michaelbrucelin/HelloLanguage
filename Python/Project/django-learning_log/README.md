# 这是一个测试项目

这是一个django的测试项目，使用python的虚拟环境搭建。

```bash
cd /.../django-learning_log
python -m venv ll_env       # 创建一个名为ll_env的虚拟环境
source ll_env/bin/activate  # 激活虚拟环境

pip install django
django-admin startproject learning_log .     # 创建django项目
python manage.py migrate                     # 创建一个供django使用的数据库
python manage.py runserver                   # 启动django服务
python manage.py runserver 192.168.1.1:8000  # 需要将设置的ip添加到settings.py的ALLOWED_HOSTS中

# 再打开另一个终端，前一个终端拖着服务
cd /.../django-learning_log
source ll_env/bin/activate
python manage.py startapp learning_logs  # 创建一个应用程序

python manage.py makemigrations learning_logs  # 创建将实体（类）生成数据库表的映射信息
python manage.py migrate                       # 执行上面生成的映射信息
# 只要更改了Model，就需要迁移？

python manage.py createsuperuser         # 创建超级用户，这里创建的是ll_admin:123456
python manage.py shell                   # 打开django shell，查看数据
    from learning_logs.models import Topic
    topics = Topic.objects.all()
        for topic in topics:
            print(topic.id, topic)

python manage.py startapp users  # 创建一个名为user的应用程序


deactivate  # 停止虚拟环境
```
