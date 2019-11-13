import pandas as pd, numpy as np
import matplotlib.pyplot as plt
import os
os.chdir('..\\..\\csv')
df = pd.read_csv('esempioSARIMA.csv') # dataframe (series)

#Preprocessing, log - diff transform
df.set_index('anno-trim')
aSales = df['sales'].to_numpy() # array of sales data
logdata = np.log(aSales) # log transform
logdiff = pd.Series(logdata).diff() # logdiff transform

#Preprocessing, train and test set
cutpoint = int(0.7*len(logdiff))
train = logdiff[:cutpoint]
test = logdiff[cutpoint:]

#Postprocessing, reconstruction
train[0] = 0 # set first entry
reconstruct = np.exp(np.r_[train,test].cumsum()+logdata[0])
#si fa la cumulazione (che è l'inverso della differenzazione)

plt.plot(df.sales)
plt.plot(reconstruct)
plt.show()