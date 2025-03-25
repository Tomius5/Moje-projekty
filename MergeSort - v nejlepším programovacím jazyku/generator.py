import random
import csv
import time
start_time3 = time.time() # Record start time
with open(r'C:\Users\borto\Documents\Programování\Moje-projekty\MergeSort - v nejlepším programovacím jazyku\cisla.csv', mode='w', newline='') as file:
    csv_writer = csv.writer(file)
    for i in range(1000000):
        cislo = random.randint(1, 1000000)
        csv_writer.writerow([cislo]) 
    print("Data byla zapsána do cisla.csv")
end_time3 = time.time() # Record end time
elapsed_time3 = end_time3 - start_time3 # Calculate elapsed time 
print(f"Došel jsem sem za {elapsed_time3}s")

