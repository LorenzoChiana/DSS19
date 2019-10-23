import numpy as np
import pandas as pd
from scipy import stats # to be used later
import matplotlib.pyplot as plt
import os
os.chdir('../csv')

df = pd.read_csv('traffico16.csv') # dataframe (series)
npa = df['ago-01'].to_numpy() # numpy array
#dataframe monodimensionale si chiama series
#dataframe bidimensionale si chiama frame
#dataframe tridimensionale si chiama panel

res = stats.relfreq(npa, numbins=10)
print(res[0])

print('Media: ', np.mean(npa))
print('Mediana: ', np.median(npa))
print('Moda: ', stats.mode(npa)[0])

plt.hist(npa, bins=10, color='#00AA00', edgecolor='black') #plt = pyplot; hist = histogram
plt.title(df.columns[0])
plt.xlabel('num')
plt.ylabel('days')
plt.show()