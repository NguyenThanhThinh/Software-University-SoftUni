## Problem 1.Homework: Loops

This document defines homework assignments from the [&quot;C# Basics&quot; Course @ Software University](https://softuni.bg/trainings/1297/programming-basics-january-2016). Please submit as homework a single **zip** / **rar** / **7z** archive holding the solutions (source code only) of all below described problems.

### Problem 1. Numbers from 1 to N

Write a program that enters from the console a positive integer **n** and **prints all the numbers from 1 to n** , on a single line, separated by a space. Examples:

| **n** | **output** |
| --- | --- |
| 3 | 1 2 3 |
| 5 | 1 2 3 4 5 |

### Problem 2. Numbers Not Divisible by 3 and 7

Write a program that enters from the console a positive integer **n** and prints all the **numbers from 1 to n not divisible by 3 and 7** , on a single line, separated by a space. Examples:

| **n** | **output** |
| --- | --- |
| 3 | 1 2 |
| 10 | 1 2 4 5 8 10 |

### Problem 3. Min, Max, Sum and Average of N Numbers

Write a program that reads from the console a sequence of **n** integer numbers and returns the **minimal** , the **maximal** number, the sum and the average of all numbers (displayed with 2 digits after the decimal point). The **input** starts by the number **n** (alone in a line) followed by **n lines** , each holding an integer number. The **output** is like in the examples below. Examples:

| **input** | **output** |   | **input** | **output** |
| --- | --- | --- | --- | --- |
| 3 | min = 1 | | 2 | min = -1 |
| 2 | max = 5 | | -1 | max = 4 |
| 5 | sum = 8 | | 4 | sum = 3 |
| 1 | avg = 2.67 | | | avg = 1.50 |

### Problem 4. Print a Deck of 52 Cards

![](https://github.com/sevdalin/Software-University-SoftUni/blob/master/Programming-Basics/images/57.JPG)

![](https://github.com/sevdalin/Software-University-SoftUni/blob/master/Programming-Basics/images/58.JPG)

### Problem 6. Calculate N! / K!

Write a program that calculates **n! / k!** for given **n** and **k** (1 &lt; **k** &lt; **n** &lt; 100). Use only one loop. Examples:

| **n** | **k** | **n! / k!** |
| --- | --- | --- |
| 5 | 2 | 60 |
| 6 | 5 | 6 |
| 8 | 3 | 6720 |

### Problem 7. Calculate N! / (K! \* (N-K)!)

In combinatorics, the number of ways to choose **k** different members out of a group of **n** different elements (also known as the number of [**combinations**](http://en.wikipedia.org/wiki/Combination)) is calculated by the following formula:

![](https://github.com/sevdalin/Software-University-SoftUni/blob/master/Programming-Basics/images/59.JPG)

For example, there are 2598960 ways to withdraw 5 cards out of a standard deck of 52 cards. Your task is to write a program that calculates **n! / (k! \* (n-k)!)** for given **n** and **k** (1 &lt; **k** &lt; **n** &lt; 100). Try to use only two loops. Examples:

| **n** | **k** | **n! / (k! \* (n-k)!)** |
| --- | --- | --- |
| 3 | 2 | 3 |
| 4 | 2 | 6 |
| 10 | 6 | 210 |
| 52 | 5 | 2598960 |

### Problem 8. Catalan Numbers

In combinatorics, the [Catalan numbers](http://en.wikipedia.org/wiki/Catalan_number) are calculated by the following formula:

![](https://github.com/sevdalin/Software-University-SoftUni/blob/master/Programming-Basics/images/60.JPG)

Write a program to calculate the **n**-th **Catalan number** by given **n** (1 &lt; n &lt; 100). Examples:

| **n** | **Catalan(n)** |
| --- | --- |
| 0 | 1 |
| 5 | 42 |
| 10 | 16796 |
| 15 | 9694845 |

### Problem 9. Matrix of Numbers

Write a program that reads from the console a positive integer number **n** (1 ? **n** ? 20) and **prints a matrix** like in the examples below. Use two nested loops. Examples:

![](https://github.com/sevdalin/Software-University-SoftUni/blob/master/Programming-Basics/images/61.JPG)

### Problem 10. Odd and Even Product

You are given **n** integers (given in a single line, separated by a space). Write a program that checks whether the product of the odd elements is equal to the product of the even elements. Elements are counted from **1** to **n** , so the first element is odd, the second is even, etc. Examples:

| **numbers** | **result** |
| --- | --- |
| **2** 1 **1** 6 **3** | yes |
| | product = 6 |
| **3** 10 **4** 6 **5** 1 | yes |
| | product = 60 |
| **4** 3 **2** 5 **2** | no | 
| | odd\_product = 16 | 
| | even\_product = 15 |

### Problem 11. Random Numbers in Given Range

Write a program that enters 3 integers **n** , **min** and **max** ( **min** <= **max** ) and prints **n** random numbers in the range [**min**... **max**]. Examples:

| **n** | **min** | **max** | **random numbers** |
| --- | --- | --- | --- |
| 5 | 0 | 1 | 1 0 0 1 1 |
| 10 | 10 | 15 | 12 14 12 15 10 12 14 13 13 11 |

Note that the above output is just an example. Due to randomness, your program most probably will produce different results.

### Problem 12. \* Randomize the Numbers 1…N

Write a program that enters in integer **n** and prints the numbers 1, 2, …, **n** in random order. Examples:

| **n** | **randomized numbers 1…n** |
| --- | --- |
| 3 | 2 1 3 |
| 10 | 3 4 8 2 6 7 9 1 10 5 |

Note that the above output is just an example. Due to randomness, your program most probably will produce different results. You might need to use [arrays](http://msdn.microsoft.com/en-us/library/aa288453(v=vs.71).aspx).

### Problem 13. Binary to Decimal Number

Using loops write a program that converts a [binary integer](http://en.wikipedia.org/wiki/Binary_numeral_system) number to its decimal form. The input is entered as **string**. The output should be a variable of type **long**. Do not use the built-in .NET functionality. Examples:

| **binary** | **decimal** |
| --- | --- |
| 0 | 0 |
| 11 | 3 |
| 1010101010101011 | 43691 |
| 1110000110000101100101000000 | 236476736 |

### Problem 14. Decimal to Binary Number

Using loops write a program that converts an integer number to its [binary representation](http://en.wikipedia.org/wiki/Binary_numeral_system). The input is entered as **long**. The output should be a variable of type **string**. Do not use the built-in .NET functionality. Examples:

| **decimal** | **binary** |
| --- | --- |
| 0 | 0 |
| 3 | 11 |
| 43691 | 1010101010101011 |
| 236476736 | 1110000110000101100101000000 |

### Problem 15. Hexadecimal to Decimal Number

Using loops write a program that converts a [hexadecimal integer](http://en.wikipedia.org/wiki/Hexadecimal) number to its decimal form. The input is entered as **string**. The output should be a variable of type **long**. Do not use the built-in .NET functionality. Examples:

| **hexadecimal** | **decimal** |
| --- | --- |
| FE | 254 |
| 1AE3 | 6883 |
| 4ED528CBB4 | 338583669684 |

### Problem 16. Decimal to Hexadecimal Number

Using loops write a program that converts an integer number to its [hexadecimal representation](http://en.wikipedia.org/wiki/Hexadecimal). The input is entered as **long**. The output should be a variable of type **string**. Do not use the built-in .NET functionality. Examples:

| **decimal** | **hexadecimal** |
| --- | --- |
| 254 | FE |
| 6883 | 1AE3 |
| 338583669684 | 4ED528CBB4 |

### Problem 17. \* Calculate GCD

Write a program that calculates the [**greatest common divisor**](http://en.wikipedia.org/wiki/Greatest_common_divisor) ( **GCD** ) of given two integers **a** and **b**. Use the **Euclidean algorithm** (find it in Internet). Examples:

| **a** | **b** | **GCD(a, b)** |
| --- | --- | --- |
| 3 | 2 | 1 |
| 60 | 40 | 20 |
| 5 | -15 | 5 |

### Problem 18. \* Trailing Zeroes in N!

Write a program that calculates with how many zeroes the factorial of a given number **n** has at its end. Your program should work well for very big numbers, e.g. n=100000. Examples:

| **n** | **trailing zeroes of n!** | **explaination** |
| --- | --- | --- |
| 10 | 2 | 36288 **00** |
| 20 | 4 | 243290200817664 **0000** |
| 100000 | 24999 | think why |

### Problem 19. \*\* Spiral Matrix

Write a program that reads from the console a positive integer number **n** (1 <= **n** <= 20) and **prints a matrix** holding the numbers from **1** to **n** \ ***n** in the form of **square spiral** like in the examples below. Examples:

![](https://github.com/sevdalin/Software-University-SoftUni/blob/master/Programming-Basics/images/62.JPG)
