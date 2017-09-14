## Problem 1. C# Advanced Lab - Algorithms

This document defines **algorithmic problems** from the [&quot;Advanced C#&quot; Course @ Software University](http://softuni.bg/courses/advanced-csharp/). You are presented with some problems and certain steps you need to take in order to accomplish the tasks.

1. Problem 1. Prime Factorization

_Fun fact: did you know int.MaxValue (2_# 31_– 1) is a prime?_

Prime factorization of a number N is the process of finding a set of prime numbers that multiply together to produce N. E.g. 12 can be represented as 2 \* 2 \* 3; 534543 = 3 \* 23 \* 61 \* 127.

There are useful online calculators you can use to check the prime factorization of a number, like [this one](http://www.calculatorsoup.com/calculators/math/prime-factors.php).

**The task** : Write a program that takes as input an **integer number N (N &gt;= 2)** and represents it as a multiple of prime numbers in format: **&quot;[number] = [prime factor 1] \* [prime factor 2] \* … \* [prime factor n]&quot;**.

Examples:

| **Input** | **Output** |
| --- | --- |
| 2 | 2 = 2 |
| 12 | 12 = 2 \* 2 \* 3 |
| 220 | 220 = 2 \* 2 \* 5 \* 11 |
| 534543 | 534543 = 3 \* 23 \* 61 \* 127 |   

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/7.jpg)

One **possible** approach:

1. Create a **list** to hold each prime multiple.
2. Set a variable **divisor** to 2 (the first prime number).
3. Check if N can be divided by divisor:
  1. If you can divide N by divisor without remainder, add divisor to the list and divide N by divisor. Repeat this step.
  2. If you cannot divide N by divisor without remainder, increment divisor and repeat step 3.
4. End the process when N equals 1.
5. Print the result in the specified format.

### Restrictions

- The number N will always be a positive integer in the range [2 … 2 000 000 000]. There is no need to check it explicitly.
- The prime factors of the number should be sorted in ascending order.
- Allowed working time for your program: 0.9 seconds.
- Allowed memory: 16 MB.



# Problem 2. C# Advanced Lab - Algorithms

This document defines **algorithmic problems** from the [&quot;Advanced C#&quot; Course @ Software University](http://softuni.bg/courses/advanced-csharp/). You are presented with some problems and certain steps you need to take in order to accomplish the tasks.

1. Problem 2.The Sieve of Eratosthenes

There are various methods for finding prime numbers. The [sieve of Eratosthenes](https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes) is one of the oldest and most popular algorithms for finding the primes in a given range. A picture is worth a thousand words, so this [animation](https://upload.wikimedia.org/wikipedia/commons/b/b9/Sieve_of_Eratosthenes_animation.gif) will probably be helpful.

This is the general description of the process:

1. Create a list/array of consecutive integers from 2 through N: (2, 3, 4, ..., N). For convenience, you may look into the [Range()](https://msdn.microsoft.com/en-us/library/system.linq.enumerable.range%28v=vs.100%29.aspx) method in C#. _Hint: You may also start the sequence from 0 to keep a correlation between any given number and its index in the array._
2. Initially, let **p** equal 2, the first prime number.
3. Starting from p, enumerate (iterate) its multiples by counting to N in increments of p, and mark them in the list (these will be 2 \* p, 3 \* p, 4\* p, etc.). The number p itself should not be marked. You may use any suitable value to mark the number that are not prime (e.g. -1, 0, 1 make sense, but a positive number greater than 1 does not).
4. Find the first number greater than p in the list that is not marked. If there was no such number, stop. Otherwise, let p now equal this new number (which is the next prime), and repeat from step 3.

### Input

On the only input line you will receive a natural number N. N will be in the range [2 … 50 000].

### Output

On a single line on the console, print all prime numbers in the range [2 … N], separated by a comma and space like in the examples below. You may check online if your program works correctly, e.g. [here](https://primes.utm.edu/lists/small/10000.txt).

### Examples

| **Input** | **Output** |
| --- | --- |
| 2 | 2 |
| 3 | 2, 3 |
| 77 | 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73 |
| 200 | 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199 |



# Problem 3. C# Advanced Lab - Algorithms

This document defines **algorithmic problems** from the [&quot;Advanced C#&quot; Course @ Software University](http://softuni.bg/courses/advanced-csharp/). You are presented with some problems and certain steps you need to take in order to accomplish the tasks.

1. Problem 3.Insertion Sort

You can see an **animated** version of the algorithm in detail here: [_http://upload.wikimedia.org/wikipedia/commons/0/0f/Insertion-sort-example-300px.gif_](http://upload.wikimedia.org/wikipedia/commons/0/0f/Insertion-sort-example-300px.gif) |

Your task is to implement the [Insertion Sort](http://en.wikipedia.org/wiki/Insertion_sort) algorithm using C#. The solution of the algorithm is as follows:

- Start from **i =**** 1 **and iterate to the** last element**
  - If  **A[i-1]** is **larger** than **A[i]**:
    - Start shifting all previous elements ( **i-1** , **i-2** , **i-3** , etc.) **larger** than the **A[i]** to the right
    - Do the above until **A[i-n]**is smaller or equal to **A[i]**

### Constraints

- The input list will hold integers in the range [−2147483648 … 2147483647].
- You are **NOT allowed** to use **Array.Sort()**, **.OrderBy()** or similar methods. Write **your own** Insertion Sort algorithm.

### Example

| **Input** | **Output** |
| --- | --- |
| 5 1 19 12 3 6 10 2 | 1 2 3 5 6 10 12 19 |
| 0 1 2 3 4 5 6 6 7 8 | 0 1 2 3 4 5 6 6 7 8 |
| 0 -1 0 -1 -1 0 -2 3 -1 -3 5 -1 | -3 -2 -1 -1 -1 -1 -1 0 0 0 3 5 |



# Problem 4. C# Advanced Lab - Algorithms

This document defines **algorithmic problems** from the [&quot;Advanced C#&quot; Course @ Software University](http://softuni.bg/courses/advanced-csharp/). You are presented with some problems and certain steps you need to take in order to accomplish the tasks.

1. Problem 4.Linear and Binary Search

There are two standard array searching algorithms - **Linear** and **Binary** Search.

- Linear search traverses the entire collection until the searched element is found.
- Binary search works only on **sorted collections**. It picks the **mid element** of the collection and checks if it&#39;s equal to the searched element.
  - ** If it&#39;s **equal** , returns the mid index.
  - ** If it&#39;s **smaller** , cuts the right half of the collection and repeats the same step.
  - ** If it&#39;s **larger** , cuts the left half of the collection and repeats the same step.

If **no such element is found** , both algorithms should return **-1** as result.

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/8.JPG)

**Animated gif** _:_ [_https://blog.penjee.com/wp-content/uploads/2015/04/binary-and-linear-search-animations.gif_](https://blog.penjee.com/wp-content/uploads/2015/04/binary-and-linear-search-animations.gif) |

Your task is to implement both Linear Search and Binary Search algorithms using C#. Create respective methods for them - **LinearSearch(array, element)** and **BinarySearch(array, element)**.

The solution for **Linear search** is as follows:

- Iterate through each element of the collection
  - **oo** Check if its equal to the searched element. Return index if it is.
  - **oo** Continue iterating if not.
  - **oo** Return **-1** if no such element is found.

One solution for **Binary search** is as follows:

- Define **min=0** and **max=A.length-1**
- Until there is at least 1 element in range:
  - **oo** Get **mid** index in range **[min…max]** and check if **A[mid]** is equal to **search element**
    - If it&#39;s **equal** , return **mid** index
    - If it&#39;s **larger** , repeat iteration by **ignoring all elements** to the **left** f **mid**
    - If it&#39;s **smaller** , repeat iteration by **ignoring all elements** to the **right** f **mid**

In case of **duplicate elements** , both algorithms should return the **leftmost index** (see example 3 below).

### Constraints

- The input list will hold integers in the range [−2147483648 … 2147483647].
- You are **NOT allowed** to use **.IndexOf()**, **Array.BinarySearch()** or similar methods. Write **your own** Linear and Binary search algorithms.

### Example

| **Input** | **Output** |
| --- | --- |
| -2 0 3 5 213 8582 239191 985128 <br/> 239191 | **6** |
| 0 1 2 3 4 5 6 6 7 8 <br/> -2 | **-1** |
| 3 9 10 12 13 13 13 13 <br/> 13 | **4** |


# Problem 5. C# Advanced Lab - Algorithms

This document defines **algorithmic problems** from the [&quot;Advanced C#&quot; Course @ Software University](http://softuni.bg/courses/advanced-csharp/). You are presented with some problems and certain steps you need to take in order to accomplish the tasks.

1. Problem 5. Largest Rectangle

Write a program to **find the largest rectangular area**** in a rectangular matrix **of strings. The area should hold equal cells at its** borders **. The area size is calculated by the classical formula** width \* height**.

### Input

The input comes as from the console. Each row of the matrix is on a **separate line** ; **each cell is surrounded by commas (&#39;,&#39;) on both sides**. The input ends with the keyword &quot; **END**&quot;.

### Output

The output should be printed on the console. **Border cells of the largest rectangle** should be enclosed in square brackets (**[]**) and colored in green. Each cell should be **padded 5 spaces to right**. Ensure all your cell data is correctly encoded as HTML (use the **SecurityElement.Escape** method).

### Constraints

- The input will always contain data for a matrix with a rectangular form.
- The minimal size of the matrix will be 1 x 1. The maximum matrix size will be 20 x 20.
- Allowed working time: 0.2 seconds. Allowed memory: 16 MB.

### Examples

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/9.JPG)
