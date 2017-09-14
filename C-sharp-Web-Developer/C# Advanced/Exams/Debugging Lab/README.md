# Advanced C# – Debugging

The goal of this lab is to practice **debugging techniques** in scenarios where a piece of code does not work correctly. Your task is to pinpoint the bug and fix it (without rewriting the entire code).

## Problem 2. Instruction Set

Write an instruction compiler that receives an arbitrary number of instructions. The program should parse the instructions, execute them and print the result. The following instruction set should be supported:

- INC &lt;operand1&gt; - increments the operand by 1
- DEC &lt;operand1&gt; - decrements the operand by 1
- ADD &lt;operand1&gt; &lt;operand2&gt; - performs addition on the two operands
- MLA &lt;operand1&gt; &lt;operand2&gt; - performs multiplication on the two operands
- END – end of input

### Output

### The result of each instruction should be printed on a separate line on the console.

### Constraints

- The operands will be valid integers in the range [−2 147 483 648 … 2 147 483 647].

### Tests

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/10.JPG)




## Problem 3. Be Positive

You will receive some sequences of numbers on the console; your task is to **remove all negative numbers** and print back each sequence.

On the first line of input you are given a **count N – the number of sequences**.

On each of **the next N lines** you will receive some **numbers surrounded by whitespaces**.

You need to check each number, if it&#39;s positive – print it on the console; if it&#39;s negative, add to its value the value of the next number and only **print the result if it&#39;s not negative**. You only perform the addition once, e.g. if you have the sequence: -3, 1, 3, the algorithm is as follows:

- -3 is negative =&gt; add to it the next number (1) =&gt; -3 + 1 = -2 still negative =&gt; do not print anything (and don&#39;t keep adding numbers, you stop here).
- The next number we consider is 3 which is positive =&gt; print it.

If no numbers can be obtained in this manner for the given sequence, print **&quot;(empty)&quot;.**

Example:

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/11.JPG)

### Output

Print on the console **each modified sequence on a separate line.**

### Constraints

- The **number N** will be an integer in the range [1 … 15].
- The **numbers in the sequences** will be integers in the range [-1000 … 1000].
- The **count of numbers in each sequence** will be in the range [1 … 20].
- There may be **whitespa**** ces anywhere around the numbers** in a given sequence

### Tests

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/12.JPG)



## 1. Problem 5. Array Test

You are given a number **n** representingthe size of an array of integers and on the next line the elements of the array separated by whitespace. Then, you are given an arbitrary number of commands in the format: **&quot;[action] [i-th element] [value]&quot;**. The commands end when you receive the string **&quot;stop&quot;.**

The action can be **&quot;multiply&quot;, &quot;add&quot;, &quot;subtract&quot;, &quot;rshift&quot; or &quot;lshift&quot;**. The actions **&quot;multiply&quot;, &quot;add&quot;** and **&quot;subtract&quot;** have parameters. The first parameter is the number of the element that needs to be changed. The second parameter is the value with which we manipulate the element. The command **&quot;lshift&quot;** iterates through the array changing each element&#39;s position with 1 to the left. The first element which should go outside the array will eventually become last. E.g. {1, 2, 3} &quot;lshift&quot; will become {2, 3, 1}. The command **&quot;rshift&quot;** does the same thing but changes the positions with 1 to the right. The last element which should go outside the array, becomes first. E.g. {1, 2, 3} &quot;rshift&quot; will become {3, 1, 2}.

Example:

| 53 0 9 333 11 <br/> add 2 2 <br/> subtract 1 1 <br/> multiply 3 3 <br/> stop |
| --- |

We shift every 2nd element to the right twice. After the shifting we obtain the array
**{2**  **2 27 333 11** }.

### Output

For each action print the array&#39;s elements on a new line on the console.

### Constraints

- The **number n** will be an integer in the range [1 … 15].
- Each **element of the array** will be an integer in the range [0 … 2# 63-1].
- The **number i** and the **number of commands** will be integers in the range [1 … 10].
- The **number value** will be an integer in the range [-100 … 100]. If the command is &quot;rshift&quot; or &quot;lshift&quot; there are no parameters.

### Tests

| **Input** | **Program Output** | **Expected Output** |
| --- | --- | --- |
| 5 <br/> 3 0 9 333 11 <br/> add 2 2 <br/> subtract 1 1 <br/> multiply 3 3 <br/> stop | 3 0 9 333 11 <br/> 3 0 9 333 11 | 3 2 9 333 11  <br/> 2 2 9 333 11  <br/> 2 2 27 333 11 |




## Problem 5. Substring

You are given a **text** and number **j**. Your task is to search through the text for the letter &#39;p&#39; (ASCII code **112** ) and print &#39;p&#39; and **j** letters to its right.

For example, we are given the text &quot; **phahah put**&quot; and the number **3**. We find a match of &#39;p&#39; in the first letter so we print it and the 3 letters to its right. The result is &quot; **phah**&quot;. We continue and find another match of &#39;p&#39;, but there aren&#39;t 3 letters to its right, so we only print &quot; **put**&quot;.

Each match should be printed on a separate line. If there are no matches of &#39;p&#39; in the text, we print &quot; **no**&quot;.

### Output

For each match, print on a new line the matched substring. Print &quot;no&quot; if there no matches.

### Constraints

- The number j will be in the range [0 ... 100].

### Tests

| **Input** | **Program Output** | **Expected Output** |
| --- | --- | --- |
| phahah put <br/> 3 | no | phah <br/> put |
| No match <br/> 5 | no  | no |
| preparation <br/> 4 | no | prepra |
| preposition <br/> 0 | no | P <br/> p |




## Problem 6. Bit Carousel

You are given a number **n** , a **number of shifts** and **directions**. The program should shift the bits in a table with **6 cells**. The shifting should move all bits **1 position** to the given direction (either &quot; **left**&quot; or &quot; **right**&quot;).

For example we are given the number **17** and two times shift to &quot;right&quot;.

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/13.JPG)

Note: If a bit goes exits the table, it should start over from the other end.

The result is **20**.

### Output

The resulting number (after all shifting is done) should be printed on the console.

### Constraints

- The number **n** will be in the range [0 ... 63].

### Tests

| **Input** | **Program Output** | **Expected Output** |
| --- | --- | --- |
| 32 <br/> 2 <br/> right <br/> right | 8 | 8 |
| 63 <br/> 1 <br/> left | 126  | 63 |
| 59 <br/> 4 <br/> left <br/> left <br/> left <br/> left | 183 | 62 |
| 45 <br/> 3 <br/> left <br/> right <br/> left | 90 | 27 |
