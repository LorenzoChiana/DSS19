# Sliding window MLP, Airline Passengers dataset (predicts t+1)
import os
import numpy as np, pandas as pd
import matplotlib.pyplot as plt
from keras.models import Sequential
from keras.layers import Dense
# from series of values to windows matrix
def compute_windows(nparray, npast=1):
    dataX, dataY = [], [] # window and value
    for i in range(len(nparray)-npast-1): #per ogni finestra he posso identificare, i identifica la pos di partenza e la pos finale i + npast
        a = nparray[i:(i+npast), 0]
        dataX.append(a)
        dataY.append(nparray[i + npast, 0])
    return np.array(dataX), np.array(dataY)

np.random.seed(550) # for reproducibility
os.chdir('..\\..\\csv')
df = pd.read_csv('cust12ordini2017.csv', usecols=[1], names=['quant'], header=0)

aQuant = df['quant'].to_numpy() # array of sales data
diffdata = np.diff(aQuant) # diff transform

diffdata = pd.DataFrame({'quant': diffdata[:]})
diffdata = diffdata.values
diffdata = diffdata.astype('float32') # needed for MLP input

dataset = df.values # time series values
dataset = dataset.astype('float32') # needed for MLP input

# train - test sets
cutpoint = int(len(dataset) * 0.7) # 70% train, 30% test
train, test = dataset[:cutpoint], dataset[cutpoint:]
print("Len train={0}, len test={1}".format(len(train), len(test)))

# sliding window matrices (npast = window width); dim = n - npast - 1
npast = 3
trainX, trainY = compute_windows(train, npast)
testX, testY = compute_windows(test, npast) # should get also the last npred of train

# Multilayer Perceptron model - parte che effettivamente costruisce la rete
model = Sequential()
n_hidden = 10
n_output = 1 # 3 neuroni di input, 8 hidden e 1 output
model.add(Dense(n_hidden, input_dim=npast, activation='relu')) # hidden neurons, 1 layer
model.add(Dense(n_output)) # output neurons
model.compile(loss='mean_squared_error', optimizer='adam')
model.fit(trainX, trainY, epochs=500, batch_size=5, verbose=2) # batch_size divisor of len(trainX)

# Model performance
trainScore = model.evaluate(trainX, trainY, verbose=0)
print('Score on train: MSE = {0:0.2f} '.format(trainScore))
testScore = model.evaluate(testX, testY, verbose=0)
print('Score on test: MSE = {0:0.2f} '.format(testScore))

trainPredict = model.predict(trainX) # predictions
testForecast = model.predict(testX) # forecast

plt.rcParams["figure.figsize"] = (10,8) # redefines figure size
plt.plot(dataset) #blue
plt.plot(np.concatenate((np.full(1,np.nan),trainPredict[:,0]))) #orange
plt.plot(np.concatenate((np.full(len(train)+1,np.nan), testForecast[:,0]))) #green
plt.show()

#------------------------------------------------------------------------------
# train - test sets
cutpoint = int(len(diffdata) * 0.7) # 70% train, 30% test
train, test = diffdata[:cutpoint], diffdata[cutpoint:]
print("Len train={0}, len test={1}".format(len(train), len(test)))

# sliding window matrices (npast = window width); dim = n - npast - 1
npast = 3
trainX, trainY = compute_windows(train, npast)
testX, testY = compute_windows(test, npast) # should get also the last npred of train

# Multilayer Perceptron model - parte che effettivamente costruisce la rete
model = Sequential()
n_hidden = 10
n_output = 1 # 3 neuroni di input, 8 hidden e 1 output
model.add(Dense(n_hidden, input_dim=npast, activation='relu')) # hidden neurons, 1 layer
model.add(Dense(n_output)) # output neurons
model.compile(loss='mean_squared_error', optimizer='adam')
model.fit(trainX, trainY, epochs=500, batch_size=5, verbose=2) # batch_size divisor of len(trainX)

# Model performance
trainScore = model.evaluate(trainX, trainY, verbose=0)
print('Score on train: MSE = {0:0.2f} '.format(trainScore))
testScore = model.evaluate(testX, testY, verbose=0)
print('Score on test: MSE = {0:0.2f} '.format(testScore))

trainPredict = model.predict(trainX) # predictions
testForecast = model.predict(testX) # forecast

#------------------------------------------------------------------------------

plt.rcParams["figure.figsize"] = (10,8) # redefines figure size
plt.plot(dataset) #blue
plt.plot(np.concatenate((np.full(1,np.nan),trainPredict[:,0]))) #orange
plt.plot(np.concatenate((np.full(len(train)+1,np.nan), testForecast[:,0]))) #green
plt.show()