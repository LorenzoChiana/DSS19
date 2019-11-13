import pandas as pd, numpy as np
import matplotlib.pyplot as plt
import os
os.chdir('..\\..\\csv')
df = pd.read_csv('esempioSARIMA.csv') # dataframe (series)
df.plot(x='anno-trim',y='sales')
plt.title('Sales', color='black')
plt._show()

#Preprocessing: log transform
npa = df['sales'].to_numpy()
logdata = np.log(npa)
plt.plot(npa, color = 'blue', marker = "o")
plt.plot(logdata, color = 'red', marker = "o")
plt.title("numpy.log()")
plt.xlabel("x");plt.ylabel("logdata")
plt.show()

#Autocorrelazione
from statsmodels.tsa.stattools import acf
diffdata = df['sales'].diff()
diffdata[0] = df['sales'][0] # reset 1st elem
acfdata = acf(diffdata,unbiased=True,nlags=8)
plt.bar(np.arange(len(acfdata)),acfdata)
plt.show
# oppure
import statsmodels.api as sm
sm.graphics.tsa.plot_acf(diffdata, lags=8)
plt.show #significa che se ci sono dati che cadono all'esterno della zona azzurrina allora sono dati significativi: in questo caso solo quello sul 4 è appena significativo perché sulla riga di divisione