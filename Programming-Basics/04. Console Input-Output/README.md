
## Problem 1.Homework: Console Input / Output

This document defines homework assignments from the [&quot;C# Basics&quot; Course @ Software University](https://softuni.bg/trainings/1297/programming-basics-january-2016). Please submit as homework a single **zip** / **rar** / **7z** archive holding the solutions (source code only) of all below described problems.

### Problem 1. Sum of 3 Numbers

Write a program that reads **3 real numbers** from the console and prints their **sum**. Examples:

| **a** | **b** | **c** | **sum** |
| --- | --- | --- | --- |
| 3 | 4 | 11 | 18 |
| -2 | 0 | 3 | 1 |
| 5.5 | 4.5 | 20.1 | 30.1 |

### Problem 2. Print Company Information

A company has **name, address, phone number, fax number, web site and manager**. The manager has **first name, last name, age and a phone number**. Write a program that reads the information about a company and its manager and prints it back on the console.

| **program** | **user** |
| --- | --- |
| Company name: | Software University |
| Company address: | 15-18Tintyava, Sofia |
| Phone number: | +359 899 55 55 92 |
| Fax number: |   |
| Web site: | [http://softuni.bg](http://softuni.bg) |
| Manager first name: | Svetlin |
| Manager last name: | Nakov |
| Manager age: | 25 |
| Manager phone: | +359 2 981 981 |
| Software UniversityAddress: 26 V. Kanchev, SofiaTel. +359 899 55 55 92Fax: (no fax)Web site: [http://softuni.bg](http://softuni.bg)Manager: Svetlin Nakov (age: 25, tel. +359 2 981 981) |   |

### Problem 3. Circle Perimeter and Area

Write a program that reads the radius **r** of a circle and prints its perimeter and area formatted with 2 digits after the decimal point. Examples:

| **r** | **perimeter** | **area** |
| --- | --- | --- |
| 2 | 12.57 | 12.57 |
| 3.5 | 21.99 | 38.48 |

### Problem 4. Number Comparer

Write a program that gets **two numbers** from the console and prints the greater of them. Try to implement this without **if** statements. Examples:

| **a** | **b** | **greater** |
| --- | --- | --- |
| 5 | 6 | 6 |
| 10 | 5 | 10 |
| 0 | 0 | 0 |
| -5 | -2 | -2 |
| 1.5 | 1.6 | 1.6 |

### Problem 5. Formatting Numbers

Write a program that reads 3 numbers: an integer **a** (0 ? **a** ? 500), a floating-point **b** and a floating-point **c** and **prints them in**  **4**  **virtual columns**  on the console. Each column should have a width of 10 characters. The number **a** should be printed in  **hexadecimal, left aligned** ; then the number **a** should be printed in binary form, padded with zeroes, then the number **b** should be  **printed with 2 digits after the decimal point, right aligned** ; the number **c** should be **printed with 3 digits after the decimal point, left aligned**. Examples:

![ ](https://github.com/sevdalin/Programming-Basics/blob/master/images/44.JPG)

### Problem 6. \* Quadratic Equation

Write a program that reads the coefficients **a** , **b** and **c** of a quadratic equation (**ax**)*(**ax**) **+** bx **+** c **=** 0 and solves it (prints its real roots). Examples:

![ ](https://github.com/sevdalin/Programming-Basics/blob/master/images/45.JPG)

### Problem 7. \* Sum of 5 Numbers

Write a program that **enters 5 numbers** (given in a single line, separated by a space), **calculates and prints their sum**. Examples:

![ ](https://github.com/sevdalin/Programming-Basics/blob/master/images/46.JPG)

### Problem 8. \* Numbers from 1 to n

Write a program that reads an integer number **n** from the console and prints all the numbers in the interval [**1**.. **n**], each on a single line. Note that you may need to use a **for** -loop. Examples:

![ ](https://github.com/sevdalin/Programming-Basics/blob/master/images/47.JPG)

### Problem 9. \* Sum of n Numbers

Write a program that enters a number **n** and after that enters more **n** numbers and calculates and prints their sum. Note that you may need to use a **for** -loop. Examples:

![ ](https://github.com/sevdalin/Programming-Basics/blob/master/images/48.JPG)

### Problem 10. \* Fibonacci Numbers

Write a program that reads a number **n** and prints on the console the first **n** membersof the  [**Fibonacci sequence**](http://en.wikipedia.org/wiki/Fibonacci_number) (at a single line, separated by spaces) : 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, …. Note that you may need to learn how to use loops. Examples:

| **n** | **comments** |
| --- | --- |
| 1 | 0 |
| 3 | 0 1 1 |
| 10 | 0 1 1 2 3 5 8 13 21 34 |

### Problem 11. \* Numbers in Interval Dividable by Given Number

Write a program that reads two positive integer numbers and prints how many numbers **p** exist between them such that the reminder of the division by **5** is **0**. Examples:

| **start** | **end** | **p** | **comments** |
| --- | --- | --- | --- |
| 17 | 25 | 2 | 20, 25 |
| 5 | 30 | 6 | 5, 10, 15, 20, 25, 30 |
| 3 | 33 | 6 | 5, 10, 15, 20, 25, 30 |
| 3 | 4 | 0 | - |
| 99 | 120 | 5 | 100, 105, 110, 115, 120 |
| 107 | 196 | 18 | 110, 115, 120, 125, 130, 135, 140, 145, 150, 155, 160, 165, 170, 175, 180, 185, 190, 195 |



### Problem 12. \*\* Currency Check

Te4o is a big Battlefield fan. He&#39;s been saving money for months to buy the new Battlefield Hardline game. However, he has **five options** to buy the game from. **The first one** is a shady Russian site selling games in **rubles** (Russian currency). **Another option** is an American site selling games in **dollars** (American currency). Te4o&#39;s **third option** is the official site of the game - selling games in **euros** (European Union currency). **The final 2 options** are Bulgarian sites **B** and **M.** Both of them sell in **leva** (Bulgarian currency). **B** offersa very **special deal - 2 copies** of the gamefor **the price of one. M** sellsgamesfor **normal prices.** Te4o is very bad with math and can&#39;t calculate the game prices in leva. But he wants to impress his girlfriend by showing her he bought the cheapest game.

Assume that Te4o has a girlfriend, **all games are identical, 100 rubles** are **3.5 leva, 1 dollar** is **1.5 leva, 1 euro** is **1.95 leva** and if Te4o **buys 2 special games** fromB he can **sell one** of them for exactly **half of the money** he paid for both **.** Your task is to write a program that calculates **the cheapest game**.

### Input

The input data should be read from the console. It consists of five input values, each at a separate line:

- The number **r** – amount of **rubles** Te4o has to pay for the game at the Russian site.
- The number **d** – amount of **dollars** Te4o has to pay for the game at the American site.
- The number **e** – amount of **euro** Te4o has to pay for the game at the official site.
- The number **b** – amount of **leva** Te4o has to pay for the special offer at B.
- The number **m** – amount of **leva** Te4o has to pay for the game at M&#39;s site.

The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

The output data must be printed on the console. On the only output line you must print **the cheapest game price rounded up (removed &quot;up&quot;) to the second digit after the decimal mark.**

### Constraints

- The numbers **r, d, e, b, m** are integer numbers in range [0...4,294,967,295].
- Allowed working time for your program: 0.1 seconds.
- Allowed memory: 16 MB.

### Examples

![ ](https://github.com/sevdalin/Programming-Basics/blob/master/images/49.JPG)

### Problem 13. \*\* Dream Item

Trifon has a dream item. He is a good programmer and started working last month, but he needs help with his salary **.** You are given **the month** when Trifon is working, themoneyhe is **making**** per hour, number of hours per day **he is workingand the** price **of his dream item. Assume** February **has** 28 days **and every month has** exactly 10 holidays**when Trifon is not working. All other months have either 31 or 30 (check a calendar if you&#39;re unsure about the number of days in a given month). Also ifTrifon makes**more **than** 700 **leva this month, he is promised a** bonus of 10%** of the total money (e.g. if he makes 800 lv, his bonus will be 80 and the total money he would earn is 880 lv).

Your task is to write a program that calculates whetherTrifon **can buy his dream item**.

### Input

The input data consists of one line coming from the console. Check the examples below.

The format is: **Month\Money per hour\Hours per day\Price of the item**.

The input data will **always**** be valid** and in the format described. There is no need to check it explicitly.

### Output

- The output data must be printed on the console.
- On the only output line you must print whether the item can be bought -
**&quot;Money left = {0} leva.&quot;** r **&quot;Not enough money. {0} leva needed.&quot;**
-  The money must be **rounded to the second digit** after the decimal point.

![ ](https://github.com/sevdalin/Programming-Basics/blob/master/images/50.JPG)



### Problem 14. \*\* Magic Wand

As we all know programmers often make mistakes in their code. They spend hours and hours trying to figure out where the problem is. Some are praying for the code to fix itself, others are searching for magical rainbow unicorns to help them with their problem. One day, the programmers Gesho and Posho discovered a way to build magic wands that solve their coding problems. Your task is to help Gesho and Posho to build a **magic wand**.

### Input

The input data should be read from the console.

On the only input line you have an integer number **N**. The **width** of the wand is **3\*N+2**.

The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

The output data should be printed on the console. You must print the magic wand on the console.

Each row contains characters &quot; **.**&quot; (dot) and &quot; **\***&quot; (asterisk).

### Constraints

- The number **N** will always be an **odd** integer number in the range [5…39].
- Allowed working time for your program: 0.25 seconds.
- Allowed memory: 16 MB.

### Examples

![ ](https://github.com/sevdalin/Programming-Basics/blob/master/images/51.JPG)



### Problem 15. \*\* Array Matcher

You are given a **string** that consists of **two character arrays** and **a command**. Your task is to create a **new array** from the given two by executing the command.

If the command says **&quot;join&quot;** it means that you should create an array with elements that are contained in both arrays. If the command says &quot; **right exclude**&quot; it means that the newly created array should contain only elements from the first array that are not contained in the second array. If the command says &quot; **left exclude**&quot; it means that you should create an array with elements from the second array that are not contained in the first array.

The newly created array should have its elements sorted by their ASCII code. Examples:

1. You are given the array &quot;ABCD&quot;, the array &quot;CAFG&quot; and the command &quot;join&quot;. The new array should be &quot;AC&quot;.
2. You are given the array &quot;ABCD&quot;, the array &quot;CAFG&quot; and the command &quot;right exclude&quot;. The new array should be &quot;BD&quot;.
3. You are given the array &quot;ABCD&quot;, the array &quot;CAFG&quot; and the command &quot;left exclude&quot;. The new array should be &quot;FG&quot;.

### Input

The input data should be read from the console.

- A **single line** containing the **two arrays** and the **command** , separated by a &#39;\&#39; sign.

The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

The output should be printed on the console. It should consist of **exactly 1 line** :

- The output should be the elements of the newly formed array, sorted by their ASCII code.

### Constraints

- The characters of the arrays will be **characters** from the **ASCII** table.
- Each element in an array will have only **one occurrence**.
- Allowed working time for your program: 0.1 seconds.
- Allowed memory: 16 MB.

### Examples

| **Input** | **Output** |
| --- | --- |
| ABCD\CAFG\join | AC |

| **Input** | **Output** |
| --- | --- |
| EDCBA\ZHGLCA\left exclude | GHLZ |
