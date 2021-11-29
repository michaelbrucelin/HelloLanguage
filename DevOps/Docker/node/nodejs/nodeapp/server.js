// server.js文件引入了所有的依赖，并启动了Express应用。
// Express应用把会话（session）信息保存到Redis里，并创建了一个以JSON格式返回状态信息的节点。
// 这个应用默认使用redis_primary作为主机名去连接Redis，如果有必要，可以通过环境变量覆盖这个默认的主机名。
// 这个应用会把日志记录到/var/log/nodeapp/nodeapp.log文件里，并监听3000端口。

var fs = require('fs');
var express = require('express'),
    session = require('express-session')
cookieParser = require('cookie-parser')
morgan = require('morgan')
app = express(),
    redis = require('redis'),
    RedisStore = require('connect-redis')(session),
    server = require('http').createServer(app);

var logFile = fs.createWriteStream('/var/log/nodeapp/nodeapp.log', { flags: 'a' });

app.use(morgan('combined', { stream: logFile }));
app.use(cookieParser('keyboard-cat'));
app.use(session({
    resave: false,
    saveUninitialized: false,
    store: new RedisStore({
        host: process.env.REDIS_HOST || 'redis_primary',
        port: process.env.REDIS_PORT || 6379,
        db: process.env.REDIS_DB || 0
    }),
    secret: 'keyboard cat',
    cookie: {
        expires: false,
        maxAge: 30 * 24 * 60 * 60 * 1000
    }
}));

app.get('/', function (req, res) {
    res.json({
        status: "ok"
    });
});

app.get('/hello/:name', function (req, res) {
    res.json({
        hello: req.params.name
    });
});

var port = process.env.HTTP_PORT || 3000;
server.listen(port);
console.log('Listening on port ' + port);
