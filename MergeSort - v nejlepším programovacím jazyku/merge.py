import time
import math
# intlist = [995, 804, 181, 166, 661]
import csv
intlist = [] # V následujícím řádku si musíte změnit úmistění, z nějákýho důvodu to bez takhle tý cesty bugovalo
with open(r'C:\Users\borto\Documents\Programování\Moje-projekty\MergeSort - v nejlepším programovacím jazyku\cisla.csv', mode='r') as file: #Už bylo neúnosný psát seznam do tohoto kódu
    csv_reader = csv.reader(file)
    for row in csv_reader:
        intlist.append(int(row[0])) 
#intlist = [1, 5, 4, 5, 7]
# print(intlist)
#konečně solidní programovací jazyk
# print(intlist) haha ne už printovat 1 000 (kdysi 1000, teď 76m)

def mergesort(list):
    if len(list) <= 1:
        return list

    mid = len(list) // 2
    left_half = mergesort(list[:mid])
    right_half = mergesort(list[mid:])

    return merge(left_half, right_half)

def merge(left, right):
    sorted_list = []
    i = 0
    j = 0

    while i < len(left) and j < len(right):
        if left[i] <= right[j]:
            sorted_list.append(left[i])
            i += 1
        else:
            sorted_list.append(right[j])
            j += 1

    sorted_list.extend(left[i:])
    sorted_list.extend(right[j:])

    return sorted_list

def mergesort3(lst):
    if len(lst) <= 1:
        return lst
    
    n = len(lst)
    mid = n // 3
    second_third = 2 * (n // 3)
    
    remainder = n % 3 # 100 000 není dělitelné 3 :/
    if remainder == 1:
        mid += 1
    elif remainder == 2:
        mid += 1
        second_third += 1
    
    left_half = mergesort3(lst[:mid])
    middle = mergesort3(lst[mid:second_third])
    right_half = mergesort3(lst[second_third:])
    
    return merge3(left_half, middle, right_half)

def merge3(left, center, right):
    sorted_list3 = []
    i = 0
    j = 0
    k = 0
    while i < len(left) and j < len(center) and k < len(right): # TATO FUNKCE JE ŠPATNĚ, ZANECHÁVÁM JI ZDE JEN PRO ZAJÍMAVOST, ŽE JSEM SI NEUVĚDOMIL, ŽE TA FUNKCE MUSÍ BĚŽET DOKUD SE NEVYČERPÁ N-1 LISTŮ V DALŠÍ FUNKCI UŽ TO JE OPRAVENO
        if left[i] <= center[j] and left[i] <= right[k]: #kdybych si to usnadnil pomocí funkce min(), tak se časová složitost actually protáhne.
            sorted_list3.append(left[i]) # tohle, jak jste si mohla všimnout platí pouze, pokud bych porovnával 2 zároveň viz. výše.
            i += 1
        elif center[j] <= left[i] and center[j] <= right[k]:
            sorted_list3.append(center[j])
            j += 1
        else:
            sorted_list3.append(right[k])
            k += 1

    sorted_list3.extend(left[i:])
    sorted_list3.extend(center[j:])
    sorted_list3.extend(right[k:])
    
    return sorted_list3

def mergesort4(lst):
    if len(lst) <= 1:
        return lst  
    
    n = len(lst)
    
    first = max(1, n // 4)
    second = max(first + 1, first + (n // 4))
    third = max(second + 1, second + (n // 4))
    fourth = n  
    

    left_quarter = mergesort4(lst[:first]) 
    middle_left = mergesort4(lst[first:second]) 
    middle_right = mergesort4(lst[second:third]) 
    right_quarter = mergesort4(lst[third:fourth]) 
    return merge4(left_quarter, middle_left, middle_right, right_quarter)

def merge4(first, second, third, fourth):
    sorted_list4 = []
    i = j = k = l = 0
    
    while i < len(first) or j < len(second) or k < len(third) or l < len(fourth):
        candidates = [] # Přes dávání na kandidáty tím ulehčíme práci a vyřešíme bug s špatným řazením a především mizením prvků.
        if i < len(first): # Vždycky přes kandidáty z těch 4 seznamů.
            candidates.append((first[i], 'first'))
        if j < len(second):
            candidates.append((second[j], 'second'))
        if k < len(third):
            candidates.append((third[k], 'third'))
        if l < len(fourth):
            candidates.append((fourth[l], 'fourth'))
        
        m, source = min(candidates)  # m nepotřebuju
        
        if source == 'first':
            sorted_list4.append(first[i])
            i += 1
        elif source == 'second':
            sorted_list4.append(second[j])
            j += 1
        elif source == 'third':
            sorted_list4.append(third[k])
            k += 1
        else:
            sorted_list4.append(fourth[l])
            l += 1
    
    return sorted_list4


start_time = time.time() # Record start time
sorted_list = mergesort(intlist)
end_time = time.time() # Record end time
elapsed_time = end_time - start_time # Calculate elapsed time 
n = len(intlist)
print(f"Funkce MergeSort dělící prvky na množiny s 2 prvky s celkovým počtem {n} prvků proběhla za {elapsed_time:.6f} sekund.")
start_time2 = time.time() # Record start time
sorted_list2 = mergesort3(intlist)
end_time2 = time.time() # Record end time
elapsed_time2 = end_time2 - start_time2 # Calculate elapsed time 
print(f"Funkce MergeSort dělící prvky na množiny s 3 prvky s celkovým počtem {n} prvků proběhla za {elapsed_time2:.6f} sekund.")
start_time3 = time.time() # Record start time
sorted_list3 = mergesort4(intlist)
end_time3 = time.time() # Record end time
elapsed_time3 = end_time3 - start_time3 # Calculate elapsed time 
print(f"Funkce MergeSort dělící prvky na množiny s 4 prvky s celkovým počtem {n} prvků proběhla za {elapsed_time3:.6f} sekund.")
# uspora1 = 100 - math.log(n, 3) / math.log(n, 2) * 100
uspora1 = 63
# uspora2 = 100 - math.log(n, 4) / math.log(n, 2) * 100
uspora2 = 100
uspora1b = round(100 - elapsed_time2 / elapsed_time * 100)
uspora2b = round(100 - elapsed_time3 / elapsed_time * 100) * -1
print("Teoretické prodloužení času při třetění posploupnosti je:", uspora1, "%", "praktické je:", uspora1b, "%")
print("Teoretické prodloužení času při čtvrtění posploupnosti je:", uspora2, "%", "praktické je:", uspora2b, "%")
print("Jelikož s dělením seznamu na více prvů se bude počet rekurzí zvyšovat, tak i časová složitost se bude zvyšovat.")
with open(r'C:\Users\borto\Documents\Programování\Moje-projekty\MergeSort - v nejlepším programovacím jazyku\sorted2.csv', mode='w', newline='') as file:
    csv_writer = csv.writer(file)
    cisla = []
    expecptfirsttime = 0
    for i in range(len(sorted_list)):
        cislo = sorted_list[i]
        cisla.append(cislo) 
        expecptfirsttime += 1
        if i % 100 == 0 and expecptfirsttime != 1:
            csv_writer.writerow([cisla])
            cisla = [] 
    #print("Data byla zapsána do sorted2.csv") # abych to nevypisoval do konzole žeo
with open(r'C:\Users\borto\Documents\Programování\Moje-projekty\MergeSort - v nejlepším programovacím jazyku\sorted3.csv', mode='w', newline='') as file:
    csv_writer = csv.writer(file)
    cisla = []
    expecptfirsttime = 0
    for i in range(len(sorted_list2)):
        cislo = sorted_list2[i]
        cisla.append(cislo) 
        expecptfirsttime += 1
        if i % 100 == 0 and expecptfirsttime != 1:
            csv_writer.writerow([cisla])
            cisla = [] 
    #print("Data byla zapsána do sorted3.csv")
with open(r'C:\Users\borto\Documents\Programování\Moje-projekty\MergeSort - v nejlepším programovacím jazyku\sorted4.csv', mode='w', newline='') as file:
    csv_writer = csv.writer(file)
    cisla = []
    expecptfirsttime = 0
    for i in range(len(sorted_list3)):
        cislo = sorted_list3[i]
        cisla.append(cislo) 
        expecptfirsttime += 1
        if i % 100 == 0 and expecptfirsttime != 1:
            csv_writer.writerow([cisla])
            cisla = [] 
    print("Data byla zapsána do sorted2, sorted3 a sorted4.csv")
print("Jsou stejná data v sorted2 a sorted3?", sorted_list == sorted_list2)
print("Jsou stejná data v sorted2 a sorted4?", sorted_list3 == sorted_list)
# print(sorted_list)