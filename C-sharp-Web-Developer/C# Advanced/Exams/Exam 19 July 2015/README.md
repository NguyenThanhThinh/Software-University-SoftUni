## Problem 1 – Bunker Buster

Achieving peace through superior firepower! That&#39;s the motto of your company. Its main business – selling bombs to anyone who can afford them.

In order to attract clients, your boss decided to make a demonstration, so he needs you to keep track of what&#39;s going on. He has selected a spot ( **rectangular** in shape) to bombard and will drop several bombs on it. The target area is **separated into cells** and each of them holds a **non-negative integer number representing its strength**. Each time a bomb falls, it **reduces the strength of the cells in its vicinity**. After each bomb has dropped you have to do the math and **reduce the strength of the affected cells**. In the end you have to print out some statistics, like the **total number of cells destroyed** and **the overall destruction as a percentage of the total number of cells**.

On the first line you&#39;ll receive the **dimensions** of the field – number of **rows N and columns M**. On the next **N lines** you&#39;ll receive strings, each containing **M non-negative 32-bit integer numbers representing the strength of each cell on the specified row**. The cells&#39; strengths will be separated from each other by a single space.

On the next lines, you&#39;ll receive the bombs in format **&quot;[row] [column] [power]&quot;**. The [row] and [column] are integers representing the impact coordinates of the bomb. **Power** will be an **ASCII symbol** ; the destructive power of the bomb is the symbol&#39;s **position** in the ASCII table. **A bomb hits the impact cell will full force** (it reduces its strength with the strength of the bomb); all other **adjacent cells receive half the damage (rounded up)**. E.g. the bomb is &quot;1 1 =&quot;; the symbol is &#39;=&#39; (61), so the value of cell [1, 1] is reduced by 61. 61 / 2 = 30.5; **round that up** to 31 to get the damage inflicted on adjacent cells. So, the cells [0, 0], [0, 1], [0, 2], [1, 0], [1, 2], [2, 0], [2, 1], [2, 2] receive 31 damage each. Check out the example below to see the effect more clearly.

The bombardment ends with the command **&quot;cease fire!&quot;** After receiving it, print the following info on separate lines: 1) **&quot;Destroyed bunkers: {0}&quot;** , where {0} is the number of cells **with value 0 or less** ; 2) **&quot;Damage done: {0} %&quot;** , where {0} is the **percentage of cells with value 0 or less** in the field, **rounded to one digit after the decimal separator**** (use the F1 flag for rounding the output percentage).**

### Input

- The input data should be read from the console.
- On the first, you&#39;ll receive the line **dimensions** of the field in format: **&quot;N M&quot;** , where **N** is the number of **rows** , and **M** is the number of **columns**. They&#39;ll be separated by a single space.
- On the next **N lines** you&#39;ll receive **the strength of each cell** in the field, each line represents a row.
- On the next lines, until you receive the command **&quot;cease fire!&quot;** you&#39;ll receive the bombs in format **&quot;[row] [column] [power]&quot;**.
- The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

- The output should be printed on the console. It should consist of **2 lines**.
- On the first line, print the **total number of cells destroyed** in format **&quot;Destroyed bunkers: {0}&quot;**.
- On the second line, print the **total destruction (in percent)** in the following format: **&quot;Damage done: {0} %&quot;**.

### Constraints

- The **dimensions** N and M of the matrix will be integers in the range [1 … 10].
- The **strength** of each cell will be a non-negative integer number in the range [0 … 2 000 000 000].
- The **[row] and [col]** coordinates of each bomb will be **valid coordinates** inside the field.
- The bomb&#39;s **[power]** will be represented by an ASCII symbol.
- The number of shots taken will be in the range [0 … 1000].
- Allowed working time for your program: 0.1 seconds. Allowed memory: 16 MB.





### Examples

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/16.JPG)
 
 
 
 ## Problem 2 – Array Slider

Fil is not a nice guy. You think that the array problem on your exam will be the easiest, but he goes out of his way to make it harder. Also, Fil likes people who follow orders blindly, so he&#39;ll give you an array of integer numbers and a series of operations to perform on it.

On the first input line you&#39;ll be given some **non-negative integer numbers separated by whitespaces (one or more)**.

On the following lines, until the &quot; **stop**&quot; command is received, you&#39;ll receive commands which will describe what you need to do. The commands will be in **format &quot;[offset] [operation] [operand]&quot;**. Offset will be a number which shows which element you need to manipulate. **You start with the element at position 0 and add the offset at each step**. If you receive the command &quot;2 \* 2&quot;, this means you need to work with element at position 2 = that is 0 (initial index) + 2 (offset). As the next command, you receive &quot;-2 \* 2&quot;, this means you need to operate on the element at index 0 = 2 (current index) + -2 (offset). If you receive a **positive offset and end up**** out of range **,** start at the beginning **. The same applies for** negative offsets; if you end up with target index less than 0, start at the end of the array**.

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/17.JPG)

Keep track of the current index, you start at 0, but **every offset is applied to the index you were manipulating previously**.

The **operation** will be one of the following symbols: **&#39;&amp;&#39; (bitwise AND), &#39;|&#39; (bitwise OR), &#39;^&#39; (bitwise XOR), &#39;+&#39; (add), &#39;-&#39; (subtract), &#39;\*&#39; (multiply), &#39;/&#39; (divide)**. The **operand** will be a **non-negative integer number**. What you need to do is: **1) find the target index** following the rules described above; **2) perform the operation** on the selected element. Do all the math, follow your orders, and **print the array on the console** when you&#39;re done in format: **&quot;[arr0, arr1, …, arrN]&quot;**.

**The resulting array should contain only non-negative numbers**! This means that when **subtracting** , if you end up with a negative number, the resulting number should be 0. All other operations should result in **non-negative** numbers.

### Input

- The input data should be read from the console.
- The first input line will hold **a series of integers** , separated by **one or more whitespaces**.
- The next lines will contain **commands** in format **&quot;[offset] [operation] [operand]&quot;**.
- On the final input line you&#39;ll receive the **command &quot;stop&quot;**.
- The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

- The output should be printed on the console.
- After all commands have been processed, print **the final array in format &quot;[arr1, arr2, …]&quot;**. No negative numbers are allowed in the output!

### Constraints

- The **count of integers** in the collection will be in the range [1 … 50].
- The **number of commands** will be in the range [1 … 20].
- **All numbers in the input**** array **and the** operands** will be integers in the range [0 … 2# 31- 1].
- The **offset** will be in the range [-2# 31 … 2# 31 - 1].
- Allowed working time for your program: 0.1 seconds. Allowed memory: 16 MB.



### Examples

| **Input** | **Output** | **Comments** |
| --- | --- | --- |
| 1 2 3 4 5 <br/> 2 \* 2 <br/> 2 / 2 <br/> 1 – 2 <br/>-2 &amp; 1<br/> stop | [0, 2, 6, 0, 2]  | Start at index 0. First command has offset 2, we end up at index 2 (which is the number 3). Multiply it by 2 to get 6. Next command has offset 2; current index is 2, so target index is 2 + 2 = 4 (which is the number 5). Divide by 2 (integer division) to get 2. Next command has offset 1, current index is 4, target index is 5 (1 + 4) which ends up out of bounds, so we start at 0 again, thus target index is 0 which is the number 1. Subtract 2 to get -1, which is not valid, so it becomes 0 instead. Final command has offset -2, target index is -2, which is out of bounds, so start at the end of the array to arrive at index 3 which is the number 4. Apply bitwise AND with 1 which results with 0 at this position. Final array is [0, 2, 6, 0, 2]. |




# Problem 3 – Rage Quit

Every gamer knows what rage-quitting means. It&#39;s basically when you&#39;re just not good enough and you blame everybody else for losing a game. You press the CAPS LOCK key on the keyboard and flood the chat with gibberish to show your frustration.

Chochko is a gamer, and a bad one at that. He asks for your help; he wants to be the most annoying kid in his team, so when he rage-quits he wants something truly spectacular. He&#39;ll give you **a series of strings followed by non-negative numbers** , e.g. &quot;a3&quot;; you need to print on the console **each string repeated N times** ; **convert the letters to uppercase beforehand**. In the example, you need to write back &quot;AAA&quot;.

On the output, print first a statistic of the **number of unique symbols** used (the casing of letters is irrelevant, meaning that &#39;a&#39; and &#39;A&#39; are the same); the format shoud be **&quot;Unique symbols used {0}&quot;**. Then, **print the rage message** itself.

The **strings and numbers will not be separated by anything**. The input will always start with a string and for each string there will be a corresponding number. The entire input will be given on a **single line** ; Chochko is too lazy to make your job easier.

### Input

- The input data should be read from the console.
- It consists of a single line holding a series of **string-number sequences**.
- The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

- The output should be printed on the console. It should consist of **exactly two lines**.
- On the first line, print the **number of unique symbols used** in the message.
- On the second line, print the **resulting rage message** itself.

### Constraints

- The count of **string-number pairs** will be in the range [1 … 20 000].
- Each string will contain any character **except digits**. The **length** of each string will be in the range [1 … 20].
- The **repeat count** for each string will be an integer in the range [0 … 20].
- Allowed working time for your program: 0.3 seconds. Allowed memory: 64 MB.

### Examples

| **Input** | **Output** | **Comments** |
| --- | --- | --- |
| a3 | Unique symbols used: 1 <br/> AAA | We have just one string-number pair. The symbol is &#39;a&#39;, convert it to uppercase and repeat 3 times: AAA.Only one symbol is used (&#39;A&#39;). |
| aSd2&amp;5s@1 | Unique symbols used: 5 <br/> ASDASD&amp;&amp;&amp;&amp;&amp;S@ | &quot;aSd&quot; is converted to &quot;ASD&quot; and repeated twice; &quot;&amp;&quot; is repeated 5 times; &quot;s@&quot; is converted to &quot;S@&quot; and repeated once.5 symbols are used: &#39;A&#39;, &#39;S&#39;, &#39;D&#39;, &#39;&amp;&#39; and &#39;@&#39;. |

&#39;



# Problem 4 – Population Counter

So many people! It&#39;s hard to count them all. But that&#39;s your job as a statistician. You get raw data for a given city and you need to aggregate it.

On each input line you&#39;ll be given data in format: **&quot;city|country|population&quot;**. There will be **no redundant whitespaces anywhere** in the input. Aggregate the data **by country and by city** and print it on the console. For each country, print its **total population** and on separate lines the data for each of its cities. **Countries should be ordered by their total population in descending order** and within each country, the **cities should be ordered by the same criterion**. If two countries/cities have the same population, keep them **in the order in which they were entered.** Check out the examples; follow the output format strictly!

### Input

- The input data should be read from the console.
- It consists of a variable number of lines and ends when the command &quot; **report**&quot; is received.
- The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

- The output should be printed on the console.
- Print the aggregated data for each country and city in the format shown below.

### Constraints

- The name of the city, country and the population count will be separated from each other by **a pipe (&#39;|&#39;)**.
- The **number of input lines** will be in the range [2 … 50].
- A city-country pair will not be repeated.
- The **population count** of each city will be an integer in the range [0 … 2 000 000 000].
- Allowed working time for your program: 0.1 seconds. Allowed memory: 16 MB.

### Examples

| **Input** | **Output** |
| --- | --- |
| Sofia\|Bulgaria\|1000000 <br/> report | Bulgaria (total population: 1000000) <br/> =&gt;Sofia: 1000000 |

| **Input** | **Output** |
| --- | --- |
| Sofia\|Bulgaria\|1 <br/> Veliko Tarnovo\|Bulgaria\|2 <br/> London\|UK\|4 <br/> Rome\|Italy\|3 <br/> report | UK (total population: 4) <br/> =&gt;London: 4 <br/> Bulgaria (total population: 3) <br/> =&gt;Veliko Tarnovo: 2 <br/> =&gt;Sofia: 1 <br/> Italy (total population: 3) <br/> =&gt;Rome: 3 |
