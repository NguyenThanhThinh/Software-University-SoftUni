# <p align="center"> Homework: Arrays, Lists, Stacks, Queues <p>


### Problem 1. Sort Array of Numbers

Write a program to read an array of numbers from the console, **sort them** and print them back on the console. The numbers should be entered from the console on a single line, separated by a space. Examples:

| **Input** | **Output** |
| --- | --- |
| 6 5 4 10 -3 120 4 | -3 4 4 5 6 10 120 |
| 10 9 8 | 8 9 10 |

### Problem 2. Sort Array of Numbers Using Selection Sort

Write a program to sort an array of numbers and then print them back on the console. The numbers should be entered from the console on a single line, separated by a space. Refer to the examples for problem 1.

**Note:** Do not use the built-in sorting method, you should **write your own**. Use the [**selection sort algorithm**](https://en.wikipedia.org/wiki/Selection_sort).

**Hint** _: To understand the sorting process better you may use a visual aid, e.g._ [_Visualgo_](http://visualgo.net/sorting.html)_._

### Problem 3. Categorize Numbers and Find Min / Max / Average

Write a program that reads N **floating-point numbers** from the console. Your task is to separate them in two sets, one containing only the **round numbers** (e.g. 1, 1.00, etc.) and the other containing the **floating-point numbers with non-zero fraction**. Print both arrays along with their minimum, maximum, sum and average (rounded to two decimal places). Examples:

![](https://github.com/sevdalin/Software-University-SoftUni/blob/master/Programming-Fundamentals/07.%20Arrays-Lists-Stacks-Queues/Images/3.JPG)

### Problem 4. Sequences of Equal Strings

Write a program that reads an array of strings and finds in it all sequences of equal elements (comparison should be **case-sensitive** ). The input strings are given as a single line, separated by a space. Examples:

![](https://github.com/sevdalin/Software-University-SoftUni/blob/master/Programming-Fundamentals/07.%20Arrays-Lists-Stacks-Queues/Images/4.JPG)

### Problem 5. Longest Increasing Sequence

Write a program to find all **increasing** sequences inside an array of integers. The integers are given on a single line, separated by a space. Print the sequences in the order of their appearance in the input array, each at a single line. Separate the sequence elements by a space. Find also the longest increasing sequence and print it at the last line. If several sequences have the same longest length, print the **left-most** of them. Examples:

![](https://github.com/sevdalin/Software-University-SoftUni/blob/master/Programming-Fundamentals/07.%20Arrays-Lists-Stacks-Queues/Images/5.JPG)

### Problem 6. Subset Sums

Write a program that reads from the console a number N and an array of integers given on a single line. Your task is to find all **subsets** within the array which have a **sum equal to N** and print them on the console (the order of printing is not important). Find only the **unique subsets** by **filtering out repeating numbers first**. In case there aren&#39;t any subsets with the desired sum, print **&quot;No matching subsets.&quot;** Examples:

![](https://github.com/sevdalin/Software-University-SoftUni/blob/master/Programming-Fundamentals/07.%20Arrays-Lists-Stacks-Queues/Images/6.JPG)

### Problem 7. \* Sorted Subset Sums

Modify the program you wrote for the previous problem to print the results in the following way: each line should contain the **operands** (numbers that form the desired sum) in **ascending order** ; the lines **containing fewer operands** should be printed **before** those with more operands; when two lines have the same number of operands, the one containing the **smallest operand** should be printed first. If two or more lines contain the same number of operands and have the same smallest operand, the order of printing is not important. Example:

![](https://github.com/sevdalin/Software-University-SoftUni/blob/master/Programming-Fundamentals/07.%20Arrays-Lists-Stacks-Queues/Images/7.JPG)

### Problem 8. \* Lego Blocks

**This problem is from the Java Basics Exam (8 February 2015). You may check your solution** [**here**](https://judge.softuni.bg/Contests/Practice/Index/69#2) **.**

You are given two **jagged arrays**. Each array represents a **Lego block** containing integers. Your task is first to **reverse** the second jagged array and then check if it would **fit perfectly** in the first jagged array.

 ![](https://github.com/sevdalin/Software-University-SoftUni/blob/master/Programming-Fundamentals/07.%20Arrays-Lists-Stacks-Queues/Images/8.JPG)

The picture above shows exactly what fitting arrays mean. If the arrays fit perfectly you should **print out** the newly made rectangular matrix. If the arrays do not match (they do not form a rectangular matrix) you should print out the **number of cells** in the first array and in the second array combined. The examples below should help you understand the assignment better.

### Input

The first line of the input comes as an **integer**** number n **saying how many rows are there in both arrays. Then you have** 2 \* n**lines of numbers separated by whitespace(s). The first**n **lines are the rows of the first jagged array; the next** n** lines are the rows of the second jagged array. There might be leading and/or trailing whitespace(s).

### Output

You should print out the combined matrix in the format:
**[****elem, elem, …, elem ****]
[**** elem, elem, …, elem ****]
[**** elem, elem, …, elem****]**
If the two arrays do not fit you should print out : **The total number of cells is:**  **count**

### Constraints

- The number n will be in the range [2 … 10].
- Time limit: 0.3 sec. Memory limit: 16 MB.

### Examples

![](https://github.com/sevdalin/Software-University-SoftUni/blob/master/Programming-Fundamentals/07.%20Arrays-Lists-Stacks-Queues/Images/8.1.JPG)

