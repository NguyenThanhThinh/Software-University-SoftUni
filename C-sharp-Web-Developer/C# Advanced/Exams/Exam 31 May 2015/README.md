## Problem 1 – Command Interpreter

Jagged arrays, regular expressions, asynchronous programming… Tough stuff. But simple structures like arrays are piece of cake, right? Let&#39;s see how well you can manipulate data in a collection.

You will be given a series of strings on a single line, separated by one or more whitespaces. These represent the collection you&#39;ll be working with.

On the next input lines, until you receive the command **&quot;end&quot;** , you&#39;ll receive a series of commands in one of the following formats:

- **&quot;reverse from [start] count [count]&quot;** – this instructs you to reverse a **portion** of the array – just [count] elements starting at index [start];
- **&quot;sort from [start] count [count]&quot;** – this instructs you to sort a **portion** of the array - [count] elements starting at index [start];
- **&quot;rollLeft [count] times&quot;** – this instructs you to move **all** elements in the array to the left [count] times. On each roll, the first element is placed at the end of the array;
- **&quot;rollRight [count] times&quot;** – this instructs you to move **all** elements in the array to the right [count] times. On each roll, the last element is placed at the beginning of the array;

If any of the provided indices or counts is **invalid** (non-existent or negative), you should print a message on the console – **&quot;Invalid input parameters.&quot;** and **keep the collection unchanged.**

After you&#39;re done, print the resulting array in the following format: **&quot;[arr0, arr1 … arrN]&quot;**. The examples should help you understand the task better.

### Input

- The input data should be read from the console.
- The first input line will hold **a series of strings** , separated by **one or more whitespaces**.
- The next lines will hold **commands** in the described formats (exactly).
- The input ends with the keyword **&quot;end&quot;.**
- The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

- The output should be printed on the console.
- Each time an invalid command is received (containing an invalid index or count parameter), print the following line: **&quot;Invalid input parameters.&quot;**
- After receiving the &quot; **end**&quot; command, print the **resulting array** on the console in the format specified above.

### Constraints

- The **count of strings** in the collection will be in the range [1 … 50].
- The **number of commands** will be in the range [1 … 20].
- All commands will be in the described format; an invalid command is a command containing invalid [start] or [count], **there won&#39;t be any missing or misspelled words**.
- [**start**] and [**count**] will be integers in the range [-2# 31 … 2# 31- 1].
- Allowed working time for your program: 0.1 seconds. Allowed memory: 16 MB.

### Examples

| **Input** | **Output** |
| --- | --- |
| 1 2 **5 8 7 3** 10 6 4 9 <br/> reverse from 2 count 4 <br/> end | [1, 2, **3, 7, 8, 5** , 10, 6, 4, 9] |




## Problem 2 – Target Practice

Cotton-eye Gosho has a problem. Snakes! An infestation of snakes! Gosho is a red-neck which means he doesn&#39;t really care about animal rights, so he bought some ammo, loaded his shotgun and started shooting at the poor creatures. He has a favorite spot – rectangular stairs which the snakes like to climb in order to reach Gosho&#39;s stash of whiskey in the attic. You&#39;re tasked with the horrible cleanup of the aftermath.

A **snake** is represented by **a string**. The **stairs** are a **rectangular matrix of size NxM**. A snake starts climbing the stairs from the **bottom-right corner** and slithers its way up in a **zigzag** – first it moves left until it reaches the left wall, it climbs on the next row and starts moving right, then on the third row, moving left again and so on. The first cell (bottom-right corner) is filled with the first symbol of the snake, the second cell (to the left of the first) is filled with the second symbol, etc. The snake is as long as it takes in order to **fill the stairs completely** – if you reach the end of the string representing the snake, start again at the beginning. Gosho is patient and a sadist, he&#39;ll wait until the stairs are completely covered with snake and will then fire a shot.

The shot has three parameters – **impact row, impact column and radius**. When the projectile lands on the specified coordinates of the matrix it **destroys all symbols in the given radius (turns them into a space)**. You can check whether a cell is inside the blast radius using the Pythagorean Theorem (very similar to the &quot;point inside a circle&quot; problem).

The symbols above the impact area start **falling down until they land on other symbols (meaning a symbol moves down a row as long as there is a space below)**. When the horror ends, print on the console the **resulting staircase, each row on a new line**. You should really check out the examples at this point.

### Input

- The input data should be read from the console. It consists of exactly three lines.
- On the first line, you&#39;ll receive the **dimensions** of the stairs in format: **&quot;N M&quot;** , where **N** is the number of **rows** , and **M** is the number of **columns**. They&#39;ll be separated by a single space.
- On the second line you&#39;ll receive the string representing the **snake**.
- On the third line, you&#39;ll receive the **shot parameters (impact row, impact column and radius)**, all separated by a **single space**.
- The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

- The output should be printed on the console. It should consist of **N lines**.
- Each line should contain a string representing the respective row of the final matrix.

### Constraints

- The **dimensions** N and M of the matrix will be integers in the range [1 … 12].
- The **snake** will be a string with length in the range [1 … 20] and **will not contain any whitespace characters**.
- The shot&#39;s **impact row and column** will always be **valid coordinates** in the matrix – they will be integers in the range [0 … N – 1] and [0 … M – 1] respectively.
- The shot&#39;s **radius** will be an integer in the range [0 … 4].
- Allowed working time for your program: 0.1 seconds. Allowed memory: 16 MB.

### Examples

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/19.JPG)

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/20.JPG)
  
  ## Problem 3 – Text Transformer

Nakov is a good lecturer, but sometimes he drinks beer during lectures and gets drunk. When he gets drunk, instead of writing normally, he produces an incomprehensible tsunami of words and symbols. When he gets sober, he has no idea what he has written just a few hours before, so he&#39;s giving away 100 exam points to those of our Advanced C# students who can write a program to decipher his gibberish. The good news – you know how Nakov thinks when he&#39;s drunk! There is a specific algorithm his brain follows when too much beer is introduced into his blood stream.

He&#39;s typing symbols and every once in a while he presses enter to go to a new line. Your first task is to **collect all the pieces of text** into a single string and **replace multiple whitespaces (e.g. &quot;       &quot;), with a single one (&quot; &quot;)**. The important pieces of data are stored between special symbols which are the following: a **dollar sign (&#39;$&#39;) with weight of 1**, a **percentage sign (&#39;%&#39;) with weight of 2**, **ampersand (&#39;&amp;&#39;) with weight of 3** and a **single quote (&#39;&#39;&#39;) with weight of 4**. You need to retrieve all **non-empty strings that are**** contained between two ****identical** special symbols. **Special symbols aren&#39;t allowed inside these strings!** A special symbol can be part of only one string, e.g. in &quot;$abc$def$&quot; only the left string should be captured (&quot;$abc$&quot;). Then, for each **even** symbol in the captured string (positions 0, 2, etc.), you need to **add** the **weight** of the surrounding special symbol to the **ASCII code** of the current symbol. For each **odd** symbol (positions 1, 3, etc.), you need to **subtract** the weight of the special symbol from the ASCII code of the current symbol. When you&#39;re done, just **print all resulting strings on the console (on a single line, separated by a space)**. That&#39;s it! Check out the example for a more thorough explanation of the process.

### Input

- The input data should be read from the console.
- It consists of an unknown number of lines, containing various symbols from the ASCII table.
- The input ends with the keyword &quot; **burp**&quot;.
- The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

- The output should be printed on the console. It should consist of **exactly one line**.
- Print the resulting string as described above on a single line. All decoded pieces should be separated from each other by a single space.

### Constraints

- The count of **input lines** will be in the range [1 … 125 000].
- Each input line will contain ASCII symbols and will have a length in the range [1 … 50].
- Allowed working time for your program: 0.1 seconds. Allowed memory: 20 MB.

### Examples

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/21.JPG)



## Problem 4 – Olympics Are Coming

It&#39;s still 2015, but all around the world athletes are in the heat of preparation for one of the biggest events in sports. You&#39;re a statistician and you&#39;ve been hired by a bookie to collect some data in order to determine the favorites and underdogs in the coming Olympic Games. To do that, you&#39;ll receive information about the winners of some sports events in format: **&quot;[athlete] | [country]&quot;**. Your employer needs the data fast, so at some point he&#39;ll tell you to stop and **&quot;report&quot;**.

Your task is to aggregate the data and print it on the console. The data for each country should be on a separate line and should be in format: **&quot;[country] ([numberOfParticipants] participants): [wins] wins&quot;**. The number of participants reflects the number of **unique athletes** as some of them may have won more than one contest (name comparison should be **case-sensitive** ). The **countries** should be **ordered by the number of wins in descending order** , meaning that you should print first the country with the most total wins. In case several countries have the same number of wins, print them in the order in which they have been added to the database.

Make sure to **remove all unnecessary whitespaces** from the names of the countries and the athletes; if a name consists of two words they should be separated by a single space and there shouldn&#39;t be any leading or trailing whitespaces.

### Input

- The input data should be read from the console.
- It consists of a variable number of lines and ends when the command &quot; **report**&quot; is received.
- The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

- The output should be printed on the console.
- Print the aggregated data for each country on a new line in the format specified above.

### Constraints

- The **name** of the **athlete** and the **country** will consist of **one or two words (separated by one or more whitespaces)**. There may be whitespaces before or after the names.
- The name of the athlete and the country name will be separated from each other by a pipe (&#39;|&#39;). There may be whitespaces around the pipe.
- The number of input lines will be in the range [2 … 50].
- Allowed working time for your program: 0.1 seconds. Allowed memory: 16 MB.

### Examples

| **Input** | **Output** |
| --- | --- |
| Ivan ivanov \| Bulgaria <br/> Ivan Ivanov \|Bulgaria <br/> Roger Federer\|Switzerland <br/> Ivan    Ivanov\|   Bulgaria <br/> report | Bulgaria (2 participants): 3 wins <br/> Switzerland (1 participants): 1 wins |

| **Input** | **Output** |
| --- | --- |
| Boko\|Bulgaria <br/> Gero\|Spain <br/> A\|Angola <br/> B\|Angola <br/> Mike\|England <br/> Steve\|England <br/> Pesho  \|    Bulgaria <br/> report | Bulgaria (2 participants): 2 wins <br/> Angola (2 participants): 2 wins <br/> England (2 participants): 2 wins <br/> Spain (1 participants): 1 wins |
