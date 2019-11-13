import pandas as pd, os
import numpy as np
from matplotlib import pyplot as plt

os.chdir('..\\..\\csv')
series = pd.read_csv('BoxJenkins.csv', header=0, usecols=['Passengers'])
X = series.values                                       
train_size = int(len(X) * 0.66)                         
train, test = X[0:train_size], X[train_size:len(X)]
plt.plot(train); 
plt.plot([None for i in train] + [x for x in test])
y = X.transpose()[0]                                    # prendo solo la prima riga del trasposto
x = np.arange(len(y))                                   # range fino a lunghezza di y
z = np.polyfit(x, y, 2)                                 # serve a fittare un polinomio sui dati che gli passo (in questo caso un polinomio di ordine 2   # qui quadratico (1 lineare)
p = np.poly1d(z)                                        # puntatore a funzione
plt.plot(x,p(x),"r--")                                  # plottami tutti i dati di x, fai p(x), r-- -> fammela rossa e a trattini
plt.show()