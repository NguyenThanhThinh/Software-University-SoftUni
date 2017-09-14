# Problem 1 – Jedi Meditation

A longtimeago, in a galaxyfar, faraway...

AllJedimustmeditate. Yet, whenthe Jediare at their temple, they cannot mediateat the same time, becausethe temple will overload itself with too much forceandan implosion will occur. Thereis a **strict**** order **for meditations: JediMastersmediate** first **,** then **Jedi Knights, and** lastly –** the Padawans.

Given thesequenceofJedi:

{Jedi Type}{Jedi Level}

p1 k1 m2 m1 k2 p2

they will meditate in the following order:

m2 m1 k1 k2 p1 p2

**m**  means a Jedi Master,  **k**  is a Jedi Knight, and  **p**  is a Padawan.

Toshkoand Slavare padawans. Theywant to haveas much timewith the Force as they can. So theyalways try to mediate **before** Jedi Masters, **until** Jedi Master Yoda shows up and moves them **after** Jedi Knightsand **before** Jedi Padawans. Given that  they do not want to waitmeaninglesslyfor meditation, you need to help themsolve in which orderall Jedi will mediate. There can be multiple yodas, but the number identifiers (such as m **2** are unique**).**

### Input

- On the first line, you will find the number N – the count of the input lines.
- On the next N lines you will receive sequences with Jedis, separated by a **single space** , waiting for meditation
  - **m**  meansJedi master
  - **k**  means Jedi knight
  - **p**  means Jedi padawan
  - **t** means Toshko the padawan
  - **s** means Slav the padawan
  - **y** means Master Yoda

### Output

- The output consists of a single line.
- You must print the sequence of jedis, ready for meditation in the correct order, and in the following format:
  - Print each jedis type and level
  - Differentjedis are separated by a **single**** space**
  - Master Yoda must **NOT** be printed.

### Constraints

- 0 &lt; N &lt; 100 000
- All inputs will be **lowercase** characters

| **Input** | **Output** |
| --- | --- |
| 2m1 k1 p1 t1 s1m2 p2 | t1 s1 m1 m2 k1 p1 p2 |



| **Input** | **Output** |
| --- | --- |
| 1p4 p2 p3 m1 k2 p1 k1 s1 t1 y1 | m1 k2 k1 s1 t1 p4 p2 p3 p1  |




## Problem 2 – Jedi Galaxy

Ivo is the illegal son of Darth Vader. But he doesn&#39;t know much about being a powerful Jedi warrior. Meanwhile, Princess Lea just broke up with Han Solo, because he cheated on her. Ivo decided to grab her heart, but he needs your help. He must be powerful enough to impress her and so he starts gathering stars to grow stronger.

His galaxy is represented as atwo dimensional array. Every cell in the matrix is a star that has a value. Ivo starts at the given **col** and **row**. He can move only on the diagonal **from the lowest left to the upper right** , and **adds** to his score all the stars (values) from the cells he **passes through**. Unfortunately, there is always an Evil power that tries to prevent his success.

Evil power starts at the given **row** and **col** and instantly destroys all stars on the opposite diagonal – **From lowest right to the upper left.**

Ivo **adds** the values only of the stars that are **not**** destroyed** by the evil power.

You will receive **two** integers, separated by space, which represent the two dimensional array - the first being the rows and the second being the columns. Then, you must fill the two dimensional array with increasing integers starting from 0, and continuing on every row, like this:
first row: 0, 1, 2… m
second row: n+1, n+2, n+3… n + n.
**Example:**

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/1.JPG)
Ivo starts with coordinates row = 5, col = -1. He must collect all stars with value [20, 16, 12, 8, 4]. Evil starts with coordinates row = 5, col = 5. The Evil destroys all stars in range [24, 18, 12, 6, 0]. The star with value **12** is the cross point for Ivo and The Evil, so Ivo skips the stars and collects only these who are not in the evil range.

You will also receive multiple pairs of commands in the form of 2 integers separated by a single space. The first two integers will represent Ivo&#39;s start coordinates. The second one will represent the Evil Power&#39;s start coordinates.

The input ends when you receive the command &quot; **Let the Force be with you**&quot;. When that happens, you must print the value of all stars that Ivo has collected successfully.

### Input

- On the first line, you will receive the number N, M -&gt; the dimensions of the matrix. You must then fill the matrix according to these dimensions.
- On the next several lines you will begin receiving 2 integers separated by a single **space** , which represent Ivo&#39;s row and col. On the next line you will receive the Evil Power&#39;s coordinates.
- There will always be **at least 2 lines** of input to represent at least 1 path of Ivo and the Evil force.
- When you receive the command, &quot; **Let the Force be with you**&quot; the input ends.

### Output

- The output is simple. Print the sum of the values from all stars that Ivo has collected.

### Constraints

- The dimensions of the matrix will be integers in the range [5, 2000].

- The given rows will be valid integers in the range [0, 2000].
- The given columns will be valid integers in the range [-2# 31+ 1, 2# 31- 1].

| **Input** | **Output** |
| --- | --- |
| 5 5 
| 5 -1 
| 5 5 
| Let the Force be with you | 48 |



| **Input** | **Output** |
| --- | --- |
| 5 5
 4 -1
 4 5
 Let the Force be with you | 29 |




# Problem 3 – Jedi Code-X

The Jedi and the Sith warfare is ruthless, and every leak of information could be lethal to the Light side&#39;s revolution, that is why encoded messages were created. You need to write a program that decodes the incoming messages and the names of those that sent them.

On the first line of input you will receive **n** , an integer. On the next **n** lines you will be receiving strings of **random ASCII characters** with **random length** , which will represent the encoded text.

After that you will receive **2** lines. They will contain **patterns**. You must **extract all names** that consist **of English alphabet letters** , with **length equal to the length of the pattern** given on the **first line** , and **prefix** the given pattern itself. Then you must extract all messages which consist of **English alphabet letters and digits** , with **length equal to the length of the pattern** given on the second line, and **prefix** the given pattern itself. A **character** which **does not** follow the **content conditions** specified above **denotes the end** of a particular Jedi name / message.

On the **last line** of input you will get **integers** separated by a space. **Every integer is an index of a message**. The **first Jedi found** in the encoded text corresponds to **the first index** and **the message at that index** , the second Jedi to the second index and so on… If a **particular message&#39;s index** is **non-existent** you **ignore** it and assign the next message with a **valid**** index **to the** current**Jedi, if such a message does not exist the Jedi is left with no message. In the situation that a Jedi&#39;s message has an invalid index and he skips through the messages to find a valid one, the Jedi after him (if one exists) will take the message after the one the first Jedi took. If there are**more indexes **than needed,** ignore** the extra indexes.

### Input

- On the first line you will get the integer **n**.
- On the next n lines you will get random amounts of random ASCII characters.
- After that you will get the two patterns each on a new line.
- On the last line you will get integers separated by a single space.

### Output

- The output is simple. You must print the Jedi, if the messages are less than the Jedi, print only those Jedi that have messages.
- Jedi must be printed in the following format:

- --{Jedi name} – {Jedi message}

### Constraints

- N will be a valid integer in the range [0, 1000].
- The encoded text will consist of ASCII characters.
- The prefix patterns can consist of any ASCII character.
- The integers (indexes of messages) will be valid integers in range [0, 1000].
- Allowed time / memory: 100ms /



![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/2.JPG)




# Problem 4 – Jedi Dreams

Now, here is Ivan. He is a young padawan. He thinks that, he can learn how to use the Force, but that is not true.  He dreams about how one day, he will hack The Dark Side Judge Systemand become a Master Jedi.

Your task is simple. Help Ivan to understand how the Force works and hack the Judge together.

Actually, you need to solve one hard programming problem.

You are given a source code with valid syntax. Your task is to find where all method invokes happen. For each declared method, you need to find all invoked methods in it. See the example below for better clarification.

For your convenience the code, has some limitations to make the task easier.

- The code will be fully understandable by your current level at Java Jedi Part 2. There will be no strange structures, object oriented programming, unknown keywords, whatsoever…
- **All method declarations will be static** without any access modifiers such as &quot;public&quot;, &quot;private&quot; and &quot;protected&quot;.
- The code will not be **necessary compiling** but will be with valid syntax.
- **All method names** will be on the same line with the **static** keyword.
- There will **not** be any other static declarations **except for the methods**.
- There will **not** be any **commented code or code in strings**.
- Brackets are your best friends.

You will be given **N** lines with source code. Find **all** method invokes in a particular method declaration.

Each declared method must be **ordered** by the **count** of the methods invoked in it – **descending order**. If two declared methods are with the same count of inner calls, print them in **alphabetical order**. All invoked methods must be sorted **alphabetically**.  Print them in the following format:

**&quot;{method name} -&gt; {number of calls} -&gt; {invoked method 1, invoked method2, …}&quot;**

If there are no invoked methods in certain declaration, print:

**&quot;{method name} -&gt; None&quot;**

See the examples below for more information.

### Input

- On the first input line you will be given the number **N**.
- On the next **N** lines you will be given lines of code.

### Output

- The output data should be printed on the console.
- Each method declaration must be printed on a separate line, in which you show all invoked methods in it in the format described above.

### Constraints

- **N** will be between 10 and 200, inclusive.
- The input data will **always be valid** and in the format described. There is no need to check it explicitly.
- All method names will contains at least one **uppercase** character.

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/3.JPG)
![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/4.JPG)
