from flask import Flask, render_template
import pandas as pd

app = Flask(__name__)

@app.route("/")
def getDataHTML():
    data = pd.read_csv("..\\job-applications.csv")
    table = data.to_html(classes='data', index=False)
    return render_template('index.html', table=table)

if __name__ == "__main__":
   app.run()
