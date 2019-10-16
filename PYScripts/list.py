#lista
print("--- lista 1 ---")
lst = [0,1,2,3,4,5,6,7,8]
print(lst[0])
print(lst[-1])
print(lst[-2])
print(lst[2:4])
print(lst[2:])
print("--- lista 2 ---")
#lista bidimensionale 3x2
lst2 = [[1,2,3],[4,5,6]]
print(lst2[1][1])
print(lst2[1][:])
#1D array
print("--- 1 D array ---")
n = 5;
arr1 = [0]*n
arr2 = [0 for i in range(n)]
print(arr1)
print(arr2)
#2D array
print("--- 2 D array ---")
rows, cols = (5, 5);
arr1 = [[0]*cols]*rows
arr2 = [[0 for i in range(cols)] for j in range(rows)]
print(arr1)
print(arr2)