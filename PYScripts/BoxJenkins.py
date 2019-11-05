import os
import pandas as pd
from matplotlib import pyplot as plot
from statsmodels.tsa.seasonal import seasonal_decompose

#os.chdir('D:\\loren\\Documents\\workspace\\SSD\\DSS19\\csv')
os.chdir('..\\csv')
plot.rcParams['figure.figsize'] = (10.0, 6.0)
series = pd.read_csv('BoxJenkins.csv', usecols=['Passengers'], header=0)
result = seasonal_decompose(series, model='multiplicative', freq=12)
result.plot()
plot.show()