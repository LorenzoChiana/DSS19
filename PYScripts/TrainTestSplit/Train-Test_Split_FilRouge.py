import pandas as pd, os
from matplotlib import pyplot

os.chdir('..\\..\\csv')
series = pd.read_csv('FilRouge.csv', header=0, usecols=['sales'])
X = series.values                                       
train_size = int(len(X) * 0.66)                         
train, test = X[0:train_size], X[train_size:len(X)] 
print('Observations: %d' % (len(X)))
print('Training Observations: %d' % (len(train)))
print('Testing Observations: %d' % (len(test)))
pyplot.plot(train)                                      
pyplot.plot([None for i in train] + [x for x in test])  
pyplot.show()