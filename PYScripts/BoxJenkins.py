import os
from pandas import Series
from matplotlib import pyplot as plot
from statsmodels.tsa.seasonal import seasonal_decompose

os.chdir('D:\\loren\\Documents\\workspace\\SSD\\DSS19\\csv')
plot.rcParams['figure.figsize'] = (10.0, 6.0)
series = Series.from_csv('BoxJenkins.csv', header=0)
result = seasonal_decompose(series['Passengers'], model='multiplicative')
result.plot()
plot.show()