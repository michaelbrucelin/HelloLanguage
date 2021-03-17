from flask import Flask, render_template, request
import sqlite3
app = Flask(__name__)


@app.route('/')
def hello_world():
    return render_template("index.html")


@app.route('/index')
def index():
    return hello_world()


@app.route('/movie')
def movie():
    datalist = []
    conn = sqlite3.connect("DouBanMovieTop250.db")
    cursor = conn.cursor()
    sql = "select id, info_link, pic_link, cname, ename, score, rated, instroduction, info from movie250"
    data = cursor.execute(sql)
    for item in data:
        datalist.append(item)
    cursor.close()
    conn.close()
    return render_template("movie.html", movies=datalist)


@app.route('/score')
def score():
    score = []
    num = []
    conn = sqlite3.connect("DouBanMovieTop250.db")
    cursor = conn.cursor()
    sql = "select score, count(*) as cnt from movie250 group by score"
    data = cursor.execute(sql)
    for item in data:
        score.append(str(item[0]))
        num.append(item[1])
    cursor.close()
    conn.close()
    return render_template("score.html", score=score, num=num)


@app.route('/word')
def word():
    return render_template("word.html")


@app.route('/team')
def team():
    return render_template("team.html")


if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000, debug=True)
