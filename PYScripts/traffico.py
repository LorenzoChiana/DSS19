import numpy as np
import pandas as pd
from scipy import stats # to be used later
import matplotlib.pyplot as plt
import os
os.chdir('D:/loren/Documents/workspace/SSD/DSS19/csv')

df = pd.read_csv('traffico16.csv') # dataframe (series)
npa = df['ago-01'].to_numpy() # numpy array
#dataframe monodimensionale si chiama series
#dataframe bidimensionale si chiama frame
#dataframe tridimensionale si chiama panel
plt.hist(npa, bins=10, color='#00AA00', edgecolor='black') #plt = pyplot; hist = histogram
plt.title(df.columns[0])
plt.xlabel('num')
plt.ylabel('days')
plt.show()
