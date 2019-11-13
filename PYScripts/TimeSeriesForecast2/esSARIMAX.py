import pandas as pd, numpy as np
import matplotlib.pyplot as plt
import os
os.chdir('..\\..\\csv')
df = pd.read_csv('esempioSARIMA.csv') # dataframe (series)
df.set_index('anno-trim')

from statsmodels.tsa.statespace.sarimax import SARIMAX
sarima_model = SARIMAX(df.sales, order=(0,2,2), seasonal_order=(0,1,0,4))
sfit = sarima_model.fit()
sfit.plot_diagnostics(figsize=(10, 6))
plt.show()

#Predizioni in-sample:
ypred = sfit.predict(start=0,end=len(df.sales))
plt.plot(df.sales.values)
plt.plot(ypred)
plt.xlabel('time')
plt.ylabel('sales')
plt.show()