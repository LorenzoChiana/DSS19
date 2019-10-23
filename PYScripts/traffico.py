import numpy as np
import pandas as pd
from scipy import stats # to be used later
import matplotlib.pyplot as plt
import os
os.chdir('../csv')

#STATISCTICHE DESCRITTIVE

df = pd.read_csv('traffico16.csv') # dataframe (series)
npa = df['ago-02'].to_numpy() # numpy array
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

print("Agosto 01\n", df['ago-01'].describe())
print("\nAgosto 02\n", df['ago-02'].describe())

'''
#boxplot
df.boxplot(column=['ago-01', 'ago-02'])
plt.boxplot(npa)
'''
'''
df.boxplot(column=['ago-01', 'ago-02','set-01', 'set-02','ott-01', 'ott-02'])
plt.boxplot(npa)
'''
#scatter plot
plt.scatter(df['ago-01'].sort_values(), df['set-01'].sort_values())
plt.show()

#STATISTICHE INFERENZIALI