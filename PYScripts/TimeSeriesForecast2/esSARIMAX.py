import pandas as pd, numpy as np
import matplotlib.pyplot as plt
import os
os.chdir('..\\..\\csv')
df = pd.read_csv('esempioSARIMA.csv') # dataframe (series)
df.set_index('anno-trim')

from statsmodels.tsa.statespace.sarimax import SARIMAX
ds = df.sales
sarima_model = SARIMAX(ds, order=(0,2,2), seasonal_order=(0,1,0,4))
sfit = sarima_model.fit()
sfit.plot_diagnostics(figsize=(10, 6))
plt.show()

#Predizioni in-sample:
ypred = sfit.predict(start=0,end=len(ds))
plt.plot(ds.values)
plt.plot(ypred)
plt.xlabel('time')
plt.ylabel('sales')
plt.show()

#Previsioni, out-of-sample
forewrap = sfit.get_forecast(steps=4)
forecast_ci = forewrap.conf_int()
forecast_val = forewrap.predicted_mean
plt.plot(ds.values) #grafico serie (no previsione)
plt.fill_between(forecast_ci.index, forecast_ci.iloc[:, 0],
                 forecast_ci.iloc[:, 1],
                 color='k', alpha=.25) #area grigia
plt.plot(forecast_val) #grafico previsione
plt.xlabel('time')
plt.ylabel('sales')
plt.show()

#Come trovare i parameteri del modello?
import pmdarima as pm # pip install pmdarima
model = pm.auto_arima(ds.values, start_p=1, start_q=1,
                      test='adf', max_p=3, max_q=3, m=4,
                      start_P=0, seasonal=True,
                      d=None, D=1, trace=True,
                      error_action='ignore',
                      suppress_warnings=True,
                      stepwise=True) # False full grid
print(model.summary())
morder = model.order
mseasorder = model.seasonal_order
fitted = model.fit(ds)
yfore = fitted.predict(n_periods=4) # forecast
ypred = fitted.predict_in_sample()
plt.plot(ds.values)
plt.plot(ypred)
plt.plot([None for i in ypred] + [x for x in yfore])
plt.xlabel('time')
plt.ylabel('sales')
plt.show()

data = ds.values
n_periods = 4
fitted, confint = model.predict(n_periods=n_periods, return_conf_int=True)
tindex = np.arange(df.index[-1]+1,df.index[-1]+n_periods+1)
# series, per plot
fitted_series = pd.Series(fitted, index=tindex)
lower_series = pd.Series(confint[:, 0], index=tindex)
upper_series = pd.Series(confint[:, 1], index=tindex)
# Plot
plt.plot(data)
plt.plot(fitted_series, color='darkgreen')
plt.fill_between(lower_series.index, lower_series, upper_series,
color='k', alpha=.15)
plt.title("SARIMAX")
plt.show()