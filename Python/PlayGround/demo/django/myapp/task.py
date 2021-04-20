from celery import task
import time

@task
def wait5s():
    print("==========begin to countdown!==========")
    time.sleep(5)
    print("==========end to countdown!==========")
