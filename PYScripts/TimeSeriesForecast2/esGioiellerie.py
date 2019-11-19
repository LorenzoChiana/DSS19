import pandas as pd, numpy as np, os
import matplotlib.pyplot as plt
import pmdarima as pm
from statsmodels.tsa.stattools import acf
# data upload
os.chdir('..\\..\\csv')
df = pd.read_csv('gioiellerie.csv', header=0)
df["period"] = df["year"].map(str) +"-" + df["month"].map(str)
df['period'] = pd.to_datetime(df['period'], format="%Y-%m").dt.to_period('M')
df.set_index('period')
aSales = df['sales'].to_numpy() # array of sales data
logdata = np.log(aSales) # log transform
data = pd.Series(logdata) # convert to pandas series
plt.rcParams["figure.figsize"] = (10,8) # redefines figure size
plt.plot(data.values)
plt.show # data plot

# acf plot, industrial
import statsmodels.api as sm
sm.graphics.tsa.plot_acf(data.values, lags=25)
plt.show
# train and test set
train = data[:-12] #uso come training tutti i dati tranne gli ultimi 12 mesi
test = data[-12:] #uso come test set gli ultimi 12 mesi
# simple reconstruction, not necessary, unused
reconstruct = np.exp(np.r_[train,test])

# auto arima
model = pm.auto_arima(train.values, start_p=1, start_q=1,
                      test='adf', max_p=3, max_q=3, m=12,
                      start_P=0, seasonal=True,
                      d=None, D=1, trace=True,
                      error_action='ignore',
                      suppress_warnings=True,
                      stepwise=True) # False full grid
print(model.summary())
morder = model.order
print("Sarimax order {0}".format(morder))
mseasorder = model.seasonal_order
print("Sarimax seasonal order {0}".format(mseasorder))

# predictions and forecasts
fitted = model.fit(train)
ypred = fitted.predict_in_sample() # prediction (in-sample)
yfore = fitted.predict(n_periods=12) # forecast (out-of-sample)
plt.plot(train.values)
plt.plot(ypred)
plt.plot([None for x in ypred]+[x for x in yfore])
plt.xlabel('time');plt.ylabel('log sales')
plt.show()

# recostruction
yplog = pd.Series(ypred)
expdata = np.exp(yplog) # unlog
expfore = np.exp(yfore)
plt.plot(expdata)
plt.plot(df.sales)
plt.plot([None for x in expdata]+[x for x in expfore])
plt.show

# -------------------------------------- using ARIMA
from statsmodels.tsa.statespace.sarimax import SARIMAX
sarima_model = SARIMAX(train.values, order=morder, seasonal_order=mseasorder)
sfit = sarima_model.fit()
sfit.plot_diagnostics()
plt.show()
ypred = sfit.predict(start=0,end=len(train))
yfore = sfit.get_forecast(steps=12)
expdata = np.exp(ypred) # unlog
expfore = np.exp(yfore.predicted_mean)
plt.plot(expdata)
plt.plot(df.sales)
plt.plot([None for x in expdata]+[x for x in expfore])
plt.show

#previsione storica univariata con metodi regressivi