#prova while 
cont = 0
while (cont < 10):
    print("in while loop")
    cont = cont + 1
else:
    print("while loop has ended")

# prova for 
#Example: a for loop that iterates through a sequence
animals = ['dog','cats','mouse','deer','bear']
for theAnimal in animals:
    print("the animal is a " + theAnimal)
#Example: an iteration using the index in the list
for index in range(len(animals)):
    print("the animal is a " + animals[index])
#Example with index printed  
animals = ['dog','cats','mouse','deer','bear']
for index in range(len(animals)):
    print(str(index) + " the animal is a " + animals[index])
#Example with index printed     
cont = 0
while(cont < 100):
    print("{0} in while loop".format(cont))
    cont += 1
    
#Crivello di Aristotele
n = 100
lst = [i for i in range(2, n)]
for i in lst:
    for j in lst:
        if(i != j and j % i == 0):
            lst.remove(j)        
print(lst)

#funzioni
def somma(a, b):
    c = a + b
    return [c]

def crivelloAristotele(n):
    lst = [i for i in range(2, n)]
    for i in lst:
        for j in lst:
            if(i != j and j % i == 0):
                lst.remove(j)
    return[lst]
    
def crivelloAristoteleComprehension(n):
    lst = [i for i in range(2, n)]
    [lst.remove(j) for i in lst for j in lst if(i != j and j % i == 0)]
    return[lst]

print(somma(14, 15))
print(crivelloAristotele(200))
print(crivelloAristoteleComprehension(200))