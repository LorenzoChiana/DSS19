import pandas as pd, os
from matplotlib import pyplot

os.chdir('..\\csv')
series = pd.read_csv('BoxJenkins.csv', header=0, usecols=['Passengers'])
X = series.values                                       #array bidimensionale: 144 righe e 1 colonna
train_size = int(len(X) * 0.66)                         #faccio 2/3 e 1/3 e metto l'indice alla fine dei 2/3
train, test = X[0:train_size], X[train_size:len(X)] 
print('Observations: %d' % (len(X)))
print('Training Observations: %d' % (len(train)))
print('Testing Observations: %d' % (len(test)))
pyplot.plot(train)                                      #prima plotto il train (quello in blu)
pyplot.plot([None for i in train] + [x for x in test])  #poi incomincio a plottare i valori in test (quelli in arancio)
pyplot.show()