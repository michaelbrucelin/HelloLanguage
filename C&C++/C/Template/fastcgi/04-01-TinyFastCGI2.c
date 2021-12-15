#include <stdio.h>
#include <stdlib.h>

// 取消04-01-TinyFastCGI.c中的结构，比较二者的差异。

int count;

void initialize(void)
{
    count = 0;
}

void main(void)
{
    /* Initialization. */
    initialize();

    printf("Content-type: text/html\r\n"
           "\r\n"
           "<title>FastCGI Hello! (C, fcgi_stdio library)</title>"
           "<h1>FastCGI Hello! (C, fcgi_stdio library)</h1>"
           "Request number %d running on host <i>%s</i>\n",
           ++count, getenv("SERVER_HOSTNAME"));
}

/*
# gcc 04-01-TinyFastCGI2.c -o tinyf2.cgi -lfcgi

性能比较：比没有使用while (FCGI_Accept() >= 0)，性能略差；
结果比较：比较输出结果没有差异，原以为套用模板输出的count会是1, 2, 3...，但是实际测试每次都是1。
            注释掉main()中的initialize();，依然如此。

[root@linux]# ab -n 10000 -c 100 -t 10 -p abtest.txt -T 'application/x-www-form-urlencoded' 'http://8.8.8.8:8888/tinyf2.cgi'
This is ApacheBench, Version 2.0.40-dev <$Revision: 1.146 $> apache-2.0
Copyright 1996 Adam Twiss, Zeus Technology Ltd, http://www.zeustech.net/
Copyright 2006 The Apache Software Foundation, http://www.apache.org/

Benchmarking 8.8.8.8 (be patient)
Finished 3225 requests


Server Software:        nginx/1.20.1
Server Hostname:        8.8.8.8
Server Port:            4981

Document Path:          /test-c.ly
Document Length:        94 bytes

Concurrency Level:      100
Time taken for tests:   10.203 seconds
Complete requests:      3225
Failed requests:        0
Write errors:           0
Total transferred:      696600 bytes
Total POSTed:           658350
HTML transferred:       303150 bytes
Requests per second:    322.49 [#/sec] (mean)
Time per request:       310.084 [ms] (mean)
Time per request:       3.101 [ms] (mean, across all concurrent requests)
Transfer rate:          68.00 [Kbytes/sec] received
                        64.29 kb/s sent
                        132.32 kb/s total

Connection Times (ms)
              min  mean[+/-sd] median   max
Connect:        0    0   0.5      0       4
Processing:    10  305  44.5    305     391
Waiting:       10  304  44.5    305     391
Total:         11  305  44.2    305     391

Percentage of the requests served within a certain time (ms)
  50%    305
  66%    323
  75%    334
  80%    342
  90%    354
  95%    367
  98%    376
  99%    381
 100%    391 (longest request)

[root@antako Q0089]# ab -n 10000 -c 100 -t 10 -p abtest.txt -T 'application/x-www-form-urlencoded' 'http://8.8.8.8:8888/tinyf.cgi'
This is ApacheBench, Version 2.0.40-dev <$Revision: 1.146 $> apache-2.0
Copyright 1996 Adam Twiss, Zeus Technology Ltd, http://www.zeustech.net/
Copyright 2006 The Apache Software Foundation, http://www.apache.org/

Benchmarking 8.8.8.8 (be patient)
Finished 4321 requests


Server Software:        nginx/1.20.1
Server Hostname:        8.8.8.8
Server Port:            4981

Document Path:          /test-c2.ly
Document Length:        94 bytes

Concurrency Level:      100
Time taken for tests:   10.1002 seconds
Complete requests:      4321
Failed requests:        0
Write errors:           0
Total transferred:      933336 bytes
Total POSTed:           879779
HTML transferred:       406174 bytes
Requests per second:    432.06 [#/sec] (mean)
Time per request:       231.451 [ms] (mean)
Time per request:       2.315 [ms] (mean, across all concurrent requests)
Transfer rate:          91.09 [Kbytes/sec] received
                        85.91 kb/s sent
                        177.04 kb/s total

Connection Times (ms)
              min  mean[+/-sd] median   max
Connect:        0    0   2.2      0      17
Processing:    22  227  32.7    223     333
Waiting:       22  227  32.7    222     332
Total:         23  228  31.9    223     333

Percentage of the requests served within a certain time (ms)
  50%    223
  66%    233
  75%    241
  80%    248
  90%    269
  95%    290
  98%    311
  99%    317
 100%    333 (longest request)
*/
