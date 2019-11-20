import pandas as pd, numpy as np, os
import matplotlib.pyplot as plt
import pmdarima as pm
from statsmodels.tsa.stattools import acf
# data upload
os.chdir('..\\..\\csv')
#os.chdir('D:\loren\Documents\workspace\SSD\DSS19\csv')
df = pd.read_csv('ordini2017.csv', header=0)

df["period"] = df["time"].map(str)

df.set_index('period')
aSales = df['quant'].to_numpy() # array of sales data
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
plt.xlabel('time');plt.ylabel('log quant')
plt.show()

# recostruction
yplog = pd.Series(ypred)
expdata = np.exp(yplog) # unlog
expfore = np.exp(yfore)
plt.plot(expdata)
plt.plot(aSales)
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
plt.plot(aSales)
plt.plot([None for x in expdata]+[x for x in expfore])
plt.show

#previsione storica univariata con metodi regressivi

#def forecast_accuracy(forecast, actual):
#    mape = np.mean(np.abs(forecast - actual)/np.abs(actual)) # MAPE
#    me = np.mean(forecast - actual) # ME
#    mae = np.mean(np.abs(forecast - actual)) # MAE
#    mpe = np.mean((forecast - actual)/actual) # MPE
#    rmse = np.mean((forecast - actual)**2)**.5 # RMSE
#    corr = np.corrcoef(forecast, actual)[0,1] # corr
#    mins = np.amin(np.hstack([forecast[:,None], actual[:,None]]), axis=1)
#    maxs = np.amax(np.hstack([forecast[:,None], actual[:,None]]), axis=1)
#    minmax = 1 - np.mean(mins/maxs) # minmax
#    acf1 = acf(forecast-test)[1] # ACF1
#    return({'mape':mape, 'me':me, 'mae': mae,
#            'mpe': mpe, 'rmse':rmse, 'acf1':acf1,
#            'corr':corr, 'minmax':minmax})
    
#print( forecast_accuracy(yfore, test.values) )