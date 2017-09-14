## Problem 1 – Array Manipulator

Trifon has finally become a junior developer and has received his first task. It&#39;s about manipulating an array of integers. He is not quite happy about it, since he hates manipulating arrays. They are going to pay him a lot of money, though, and he is willing to give somebody half of it if to help him do his job. You, on the other hand, love arrays (and money) so you decide to try your luck.

The array may be manipulated by one of the following commands

- **exchange {index}** – splits the array **after** the given index, and exchanges the places of the two resulting sub-arrays. E.g. [1, 2, 3, 4, 5] -&gt; exchange 2 -&gt; result: [4, 5, 1, 2, 3]
  - If the index is outside the boundaries of the array, print &quot; **Invalid index**&quot;
- **max**** even/odd **– returns the** INDEX**of the max even/odd element -&gt; [1, 4, 8, 2, 3] -&gt;**max odd **-&gt; print** 4**
- **min**** even/odd **– returns the** INDEX**of the min even/odd element -&gt; [1, 4, 8, 2, 3] -&gt;**min even **&gt; print** 3**
  - If there are two or more equal **min/max** elements, return the index of the **rightmost** one
  - If a **min/max even/odd** element **cannot** be found, print **&quot;No matches&quot;**
- **first {count}**** even/odd**– returns the first {count} elements -&gt; [1, 8, 2, 3] -&gt;**first 2 even**-&gt; print [**8, 2]**
- **last {count}**** even/odd**– returns the last {count} elements -&gt; [1, 8, 2, 3] -&gt;**last 2 odd**-&gt; print [**1, 3]**
  - If the count is greater than the array length, print &quot; **Invalid count**&quot;
  - If there are **not**** enough **elements to satisfy the count, print as many as you can. If there are** zero ****even/odd** elements, print an empty array &quot;[]&quot;
- **end** – stop taking input and print the final state of the array

### Input

- The input data should be read from the console.
- On the first line, the initial array is received as a line of integers, separated by a single space
- On the next lines, until the command &quot; **end**&quot; is received, you will receive the array manipulation commands
- The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

- The output should be printed on the console.
- On a separate line, print the output of the corresponding command
- On the last line, print the final array in **square brackets** with its elements separated by a comma and a space
- See the examples below to get a better understanding of your task

### Constraints

- The **number of input lines** will be in the range [2 … 50].
- The **array elements** will be integers in the range [0 … 1000].
- The **number of elements** will be in the range [1 .. 50]
- The **split index** will be an integer in the range [-2# 31… 2# 31– 1]
- **first/last count** will be an integer in the range [1#… 2# 31 – 1]
- There will **not** be redundant whitespace anywhere in the input
- Allowed working time for your program: 0.1 seconds. Allowed memory: 16 MB.

### Examples

| **Input** | **Output** |
| --- | --- |
| 1 3 5 7 9 <br/> exchange 1 <br/> max odd <br/> min even <br/> first 2 odd <br/> last 2 even <br/> exchange 3 <br/> end | 2 <br/> No matches[5, 7] <br/> [] <br/> [3, 5, 7, 9, 1] |





| **Input** | **Output** |
| --- | --- |
| 1 10 100 1000 <br/> max even <br/> first 5 even <br/> exchange 10 <br/> min odd <br/> exchange 0 <br/> max even <br/> min even <br/> end | 3 <br/> Invalid count <br/> Invalid index <br/> 0 <br/> 2 <br/> 0 <br/> [10, 100, 1000, 1] |

| **Input** | **Output** |
| --- | --- |
| 1 10 100 1000 <br/> exchange 3 <br/> first 2 odd <br/> last 4 odd <br/> end | [1] <br/> [1] <br/> [1, 10, 100, 1000] |




## Problem 2 – Radioactive Mutant Vampire Bunnies

Browsing through GitHub, you come across an old JS Basics teamwork game. It is about very nasty bunnies that multiply extremely fast. There&#39;s also a player that has to escape from their lair. You really like the game so you decide to port it to C# because that&#39;s your language of choice. The last thing that is left is the algorithm that decides if the player will escape the lair or not.

The **bunnies** are marked with **B,** the **player** is marked with P, and **everything** else is free space, marked with a dot (.) First, you will receive a line holding integers **N** and **M** , which represent the rows and columns in the lair. Then you receive **N** strings that can **only** consist of dots (.), bunnies (B), and the player (P). They represent the initial state of the lair. There will be **only** one player. Then you will receive a string with **commands** such as **LLRRUUDD** – where each letter represents the next **step** of the player (Left, Right, Up, Down).

**After** each step of the player, the bunnies spread to the up, down, left and right (neighboring cells marked as &quot;.&quot; **change** their value to B). If the player **moves** to a bunny cell or a bunny **reaches** the player, the player has died. If the player goes **out** of the lair **without** encountering a bunny, the player has won.

If the player **dies** or **wins** , the game ends. All the activities for **this** turn continue (e.g. all the bunnies spread normally), but there are no more turns. There will be **no** stalemates where the moves of the player end before he dies or escapes.

Print the final state of the lair with every row on a separate line. On the last line, print either **&quot;dead: {row} {col}&quot;** or **&quot;won: {row} {col}&quot;**. Row and col are the coordinates of the cell where the player has died or the last cell he has been in before escaping the lair.

### Input

- On the first line of input, the number N and M are received – the number of rows and columns in the lair
- On the next N lines, each row is received in the form of a string. The string will contain only &quot;.&quot;, &quot;B&quot;, &quot;P&quot;. All strings will be the same length. There will be only one &quot;P&quot; for all the input
- On the last line, the directions are received in the form of a string, containing &quot;R&quot;, &quot;L&quot;, &quot;U&quot;, &quot;D&quot;

### Output

- On the first N lines, print the final state of the bunny lair
- On the last line, print the outcome – &quot;won:&quot; or &quot;dead:&quot; + {row} {col}

### Constraints

- The dimensions of the lair are in range [3…20]
- The directions string length is in range [1..20]

### Examples

| **Input** | **Output** |
| --- | --- |
| 5 8 <br/> .......B <br/> ...B.... <br/> ....B..B <br/> ........ <br/> ..P..... <br/> ULLL | BBBBBBBB <br/> BBBBBBBB <br/> BBBBBBBB <br/> .BBBBBBB <br/> ..BBBBBB <br/> won: 3 0  |





| **Input** | **Output** |
| --- | --- |
| 4 5 <br/> ..... <br/> ..... <br/> .B... <br/> ...P. <br/> LLLLLLLL | .B... <br/> BBB.. <br/> BBBB. <br/> BBB.. <br/> dead: 3 1  |




## Problem 3 – Shmoogle Counter

You are the newest employee at Shmoogle – a startup that aims to overthrow the mighty Google. On the first day of work, your boss arrives and informs you that he has the brightest idea how to optimize the search algorithm to be ultra-giga-fast. Google will be finished once and for all.

You will be provided with the source code, each of its lines will be on a new line of input. Your only job is to find the unique **double** and **int** variables that are declared in the algorithm&#39;s code. Extract their names, and sort them **alphabetically**. Variables will **not** be declared with commas (int row, col, radius).If a variable with the **same name** is located in another scope, it counts as **unique.** There are **no comments** in the code until the last line. Variable types won&#39;t be placed in string literals and there are **no** runtime and compile time constants in the code.

The code follows **naming conventions** and compiles. The variable&#39;s keyword and name will **never** be on two lines.

### Input

- The input is read from the console.
- You will be given lines of C# code, until the comment **//END\_OF\_CODE** is reached

### Output

-     On the first line print **Doubles: {extracted doubles}** or **None**
-     On the second – **Ints: {extracted ints}** or **None**

### Constraints

- The length of each line is no more than 100 characters.
- Variable names will be no more than 25 characters long and will contain **only** Latin letters.
- The count of lines is in range [5…250]
- Allowed working time for your program: 0.25s
- Allowed memory: 16MB

###

Examples

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/14.JPG)


![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/15.JPG)




# Problem 4 – Сръбско Unleashed

Admit it – the СРЪБСКО is your favorite sort of music. You never miss a concert and you have become quite the geek concerning everything involved with СРЪБСКО. You can&#39;t decide between all the singers you know who your favorite one is. One way to find out is to keep a statistics of how much money their concerts make. Write a program that does all the boring calculations for you.

On each input line you&#39;ll be given data in format: **&quot;singer @venue ticketsPrice ticketsCount&quot;**. There will be **no redundant whitespaces anywhere** in the input. Aggregate the data **by venue and by singer**. For each venue, print the singer and the total amount of money his/her concerts have made on a separate line. **Venues** should be kept in the **same order** they were entered, the **singers** should be **sorted by how much money** they have made in **descending order**. If two singers have made the same amount of money, keep them **in the order** in which **they were entered.**

Keep in mind that if a line is in incorrect format, it should be skipped and its data should not be added to the output. Each of the four tokens must be separated by **a space** , everything else is invalid. The venue should be denoted with **@** in front of it, such as @Sunny Beach

**SKIP THOSE** : Ceca@Belgrade125 12378, Ceca @Belgrade12312 123

The singer and town name may consist of one to three words.

### Input

- The input data should be read from the console.
- It consists of a variable number of lines and ends when the command &quot; **End**&quot; is received.
- The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

- The output should be printed on the console.
- Print the aggregated data for each venue and singer in the format shown below.
- Format for singer lines is **#{2\*space}{singer}{space}-&gt;{space}{total money}**

### Constraints

- The **number of input lines** will be in the range [2 … 50].
- The **ticket price** will be an integer in the range [0 … 200].
- The **ticket count** will be an integer in the range [0 … 100 000]
- **Singers** and **venues** are case sensitive
- Allowed working time for your program: 0.1 seconds. Allowed memory: 16 MB.

### Examples

| **Input** | **Output** |
| --- | --- |
| Lepa Brena @Sunny Beach 25 3500 <br/> Dragana @Sunny Beach 23 3500 <br/> Ceca @Sunny Beach 28 3500 <br/> Mile Kitic @Sunny Beach 21 3500 <br/> Ceca @Sunny Beach 35 3500 <br/> Ceca @Sunny Beach 70 15000 <br/> Saban Saolic @Sunny Beach 120 35000 <br/> End | Sunny Beach <br/> #  Saban Saolic -&gt; 4200000 <br/> #  Ceca -&gt; 1270500 <br/> #  Lepa Brena -&gt; 87500 <br/> #  Dragana -&gt; 80500 <br/> #  Mile Kitic -&gt; 73500 |





| **Input** | **Output** |
| --- | --- |
| Lepa Brena @Sunny Beach 25 3500 <br/> Dragana@Belgrade23 3500 <br/> Ceca @Sunny Beach 28 3500 <br/> Mile Kitic @Sunny Beach 21 3500 <br/> Ceca @Belgrade 35 3500 <br/> Ceca @Sunny Beach 70 15000 <br/> Saban Saolic @Sunny Beach 120 35000 <br/> End | Sunny Beach <br/> #  Saban Saolic -&gt; 4200000 <br/> #  Ceca -&gt; 1148000 <br/> #  Lepa Brena -&gt; 87500 <br/> #  Mile Kitic -&gt; 73500 <br/> Belgrade <br/> #  Ceca -&gt; 122500 |
