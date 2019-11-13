import os
import pandas as pd, matplotlib.pyplot as plt
from statsmodels.tsa.arima_model import ARIMA
# Import data
os.chdir('..\\..\\csv')
df = pd.read_csv('rawAirlinesPassengers.csv', usecols=[0], names=['value'], header=0)
# 1,1,2 ARIMA Model (p,d,q)
model = ARIMA(df.value, order=(1,1,2))
model_fit = model.fit(disp=0)
print(model_fit.summary())
# Plot residual errors
residuals = pd.DataFrame(model_fit.resid)
fig, ax = plt.subplots(1,2)
residuals.plot(title="Residuals", ax=ax[0])
residuals.plot(kind='kde', title='Density', ax=ax[1])
plt.show()