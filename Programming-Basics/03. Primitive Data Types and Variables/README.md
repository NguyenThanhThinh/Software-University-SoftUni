# Problem 1.Homework: Primitive Data Types and Variables

This document defines homework assignments from the [&quot;C# Basics&quot; Course @ Software University](https://softuni.bg/trainings/1297/programming-basics-january-2016). Please submit as homework a single **zip** / **rar** / **7z** archive holding the solutions (source code only) of all below described problems.

### Problem 1. Declare Variables

Declare five variables choosing for each of them the most appropriate of the types **byte** , **sbyte** , **short** , **ushort** , **int** , **uint** , **long** , **ulong** to represent the following values: **52130** , **-115** , **4825932** , **97** , **-10000**. Choose a large enough type for each number to ensure it will fit in it. Try to compile the code. Submit the source code of your Visual Studio project as part of your homework submission.

### Problem 2. Float or Double? 

Which of the following values can be assigned to a variable of type **float** and which to a variable of type **double** : **34.567839023** , **12.345** , **8923.1234857** , **3456.091**? Write a program to assign the numbers in variables and **print** them to ensure no precision is lost.

### Problem 3. Variable in Hexadecimal Format 

Declare an integer variable and assign it with the value **254** in hexadecimal format ( **0x##** ). Use Windows Calculator to find its hexadecimal representation. Print the variable and ensure that the result is &quot; **254**&quot;.

### Problem 4. Unicode Character 

Declare a character variable and assign it with the symbol that has Unicode code **42**** (decimal) **using the**&#39;\u00XX&#39; **syntax, and then print it. Hint: first, use the Windows Calculator to find the hexadecimal representation of** 42**.

| **Expected Output** |
| --- |
| \* |

### Problem 5. Boolean Variable 

Declare a Boolean variable called **isFemale** and assign an appropriate value corresponding to **your gender**. Print it on the console.

| **Expected Output** |
| --- |
| true |

### Problem 6. Strings and Objects 

Declare two **string variables** and assign them with &quot; **Hello**&quot; and &quot; **World**&quot;. Declare an **object variable** and assign it with the **concatenation** of the first two variables (mind adding an interval between). Declare a third **string** variable and initialize it with the value of the object variable (you should perform type **casting** ).



### Problem 7. Quotes in Strings 

Declare two string variables and assign them with following value:

| The &quot;use&quot; of quotations causes difficulties. |
| --- |

Do the above in two different ways: with and without using **quoted strings**. Print the variables to ensure that their value was correctly defined.

| **Expected Output** |
| --- |
| The &quot;use&quot; of quotations causes difficulties.The &quot;use&quot; of quotations causes difficulties. |

### Problem 8. Isosceles Triangle 

Write a program that prints an isosceles triangle of 9 copyright symbols ©, something like this:

|    ©  © © ©   ©© © © © |
| --- |

Note that the © symbol may be displayed incorrectly at the console so you may need to change the console character encoding to UTF-8 and assign a Unicode-friendly font in the console. Note also, that under old versions of Windows the © symbol may still be displayed incorrectly, regardless of how much effort you put to fix it.

### Problem 9. Exchange Variable Values 

Declare two integer variables **a** and **b** and assign them with 5 and 10 and after that exchange their values by using some programming logic. Print the variable values before and after the exchange.

| **Expected Output** |
| --- |
| Before:a = 5b = 10After:a = 10b = 5 |

### Problem 10. Employee Data 

A marketing company wants to keep record of its employees. Each record would have the following characteristics:

- First name
- Last name
- Age (0...100)
- Gender ( **m** or **f** )
- Personal ID number (e.g. 8306112507)
- Unique employee number (27560000…27569999)

Declare the variables needed to keep the information for a single employee using appropriate primitive data types. Use descriptive names. **Print** the data at the console.

| **Expected Output** |
| --- |
| First name: Amanda
  Last name: Jonson
  Age: 27
  Gender: f
  Personal ID: 8306112507
  Unique Employee number: 27563571 |

### Problem 11. Bank Account Data 

A bank account has a holder name (first name, middle name and last name), available amount of money (balance), bank name, IBAN, 3 credit card numbers associated with the account. Declare the variables needed to keep the information for a single bank account using the appropriate data types and descriptive names.

### Problem 12. Null Values Arithmetic 

Create a program that assigns null values to an integer and to a double variable. Try to print these variables at the console. Try to add some number or the **null** literal to these variables and print the result.

### Problem 13.\* Comparing Floats 

Write a program that **safely compares floating-point numbers** ( **double** ) with precision **eps** = **0.000001**. Note that we cannot directly compare two floating-point numbers **a** and **b** by **a==b** because of the nature of the floating-point arithmetic. Therefore, we assume two numbers are equal if they are more closely to each other than a fixed constant **eps**. Examples:

| **Number a** | **Number b** | **Equal (with precision eps=0.000001)** | **Explanation** |
| --- | --- | --- | --- |
| 5.3 | 6.01 | false | The difference of 0.71 is too big (&gt; eps) |
| 5.00000001 | 5.00000003 | true | The difference 0.00000002 &lt; eps |
| 5.00000005 | 5.00000001 | true | The difference 0.00000004 &lt; eps |
| -0.0000007 | 0.00000007 | true | The difference 0.00000077 &lt; eps |
| -4.999999 | -4.999998 | false | Border case. The difference 0.000001 == eps. We consider the numbers are different. |
| 4.999999 | 4.999998 | false | Border case. The difference 0.000001 == eps. We consider the numbers are different. |

### Problem 14.\* Print the ASCII Table 

Find online more information about [**ASCII**](http://www.ascii-code.com/) (American Standard Code for Information Interchange) and write a program to prints the entire ASCII table of characters at the console (characters from 0 to 255). Note that some characters have a special purpose and will not be displayed as expected. You may skip them or display them differently. You may need to use **for** -loops (learn in Internet how).

# Problem 3.Exam Problems

All of the problems below are given from the previous C# Basics exam (29-March-2015-Morning). **You are not obligated** to submit any of them in your homework, but it is highly recommend that you solve some or all of them so you can be well prepared for the upcoming exam. You may need to learn how to use conditional statements, loops, arrays and other things (learn in internet how or read those chapters in the book &quot; [Fundamentals of computer programming with C#](http://www.introprogramming.info/intro-csharp-book/read-online/)&quot;). If you still find those problems too hard for solving it&#39;s very useful to **check** and **understand** the solutions.  You can download all solutions and tests for this variant [here](http://svn.softuni.org/admin/svn/csharp-basics/Jan-2015/CSharp-Exam-29-Feb-2015-Morning.zip) or check all [previous exams](https://softuni.bg/courses/programming-basics). You can also test your solutions in our automated [judge system](https://judge.softuni.bg/Contests/78/Programming-Basics-Exam-29-March-2015-Morning) to see if you pass all tests.

### Problem 15.\*\* Torrent Pirate 

Captain Jack Sparrow is a famous pirate. He loves to steal different stuff just for fun and he loves watching movies. He recently discovered a brand new technology called peer-to-peer or torrent. After he browsed a famous site, he made a **collection of movies** he would like to download. Assume 1 movie has a size of **1500MB**. Jack doesn&#39;t want to pay for the internet, so he decided to go to the mall and use the free Wi-Fi there. The Wi-Fi has a fixed speed of **2MB/s**. Unfortunately for Jack, his wife will be going with him to the mall and this means that the download would not be free at all. She likes to buy sandals and other useless stuff. You are given the **money** his wife spends **per hour** at the mall.

Your task is to help Jack **calculate** whether it is **cheaper** to go to the mall and download the movies or go to the cinema to watch them. If the amount is the same, Jack still wants to make his wife happy, so he goes to the mall.

### Input

The input data should be read from the console. It consists of three input values, each at a separate line:

- Download data **d** : how much **megabytes** in total Jack should download.
- Price of cinema **p** : how much **money would cost** Jack to go to the cinema to watch one movie.
- Wife spending        **w** : how much **money per hour** does Jack&#39;s wife spend.

The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

- The output data must be printed on the console.
- On the only output line you must print **&quot;{place to go} -&gt; {price to pay}lv&quot;**.
- The **price to pay** should be formatted with 2 digits after the decimal sign.

### Constraints

- **d** is an integer number in range [0...2,147,483,647]. **p** is an integer number in range [0…30]. **w** is an integer number in range [0…200].
- Allowed working time for your program: 0.25 seconds.
- Allowed memory: 16 MB.

### Examples

| **Input** | **Output** | **Comments** |
| --- | --- | --- |
| 30000550 | cinema -&gt; 100.00lv | **Download time** = = _(download data)/(fixed speed)/(seconds)/(minutes)_ == 30000 / 2 / 60 / 60 = **4.1667** hours in the mall **Price for download** = _(download time)\*(wife spending)_ == 4.1667\*50 = **208.34** lv **Number of movies downloaded** = = _(download data)/(movie size)_ = 30000/1500 = **20** movies **Cinema price** = = _(number of movies)\*(cinema price)_ = 20\*5lv = **100** lvResult on the console: **cinema -&gt; 100lv** |
| **Input** | **Output** | **Input** | **Output** |
| 300001550 | mall -&gt; 208.33lv | 300001572 | mall -&gt; 300.00lv |

### Problem 16.\*\* Basket Battle 

Simeon likes to play a special basket game with Nakov called Basket Battle. The rules are very simple. Every player tries to score a basket from a different distance and if he succeeds, he wins a certain amount of points (based on the distance he shot from). You will receive the distance from which every player tries to score and the information whether the shot was successful or not.

The players decide who will start shooting first .The game is played in several rounds. Each round consists of the two players shooting. After **each** round, the players **switch turns** (if Simeon was first in the first round, he is shooting second in the second round). A player **wins** if he reaches **500 points**. **If someone reaches 500 points, the game stops and your program should break and print the output.**

A player **can&#39;t** make more than **500 points** in the game. For example if a player has 450 points and he scores successfully 90 points, the player stays with 450 points after that round. You must help Simeon and Nakov calculate their points and determine the winner with a computer program. Example:

Simeon &lt;- The player who starts shooting first.

3 &lt;- The number of possible rounds.

300 &lt;- Simeon tries to score 300 points.
success &lt;- Simeon succeeds and scores.

200 &lt;- Nakov tries to score 200 points.

fail &lt;- Nakov fails and still has 0 points.

400 &lt;- Nakov tries to score 400 points. (New round starts and players switch turns)

success &lt;- Nakov succeeds and scores.

200 &lt;- Simeon tries to score 200 points.
success &lt;- Simeon succeeds and scores.

The game has ended since Simeon has scored a total of 500 points and wins the game.

### Input

The input data should be read from the console. It consists of three input values, each at a separate line:

- The first line holds a string **F** – the name of the player that starts shooting first in the first round
- The second line holds an integer **N** – the number of rounds in the game
- For each round you will receive an input **P** - the amount of points every player tries to score and the string **I** - information about whether the shot was successful or not (each input will be on a separate line).

The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

The output data should be printed on the console. You have 3 cases:

1. If there is a **winner** (someone reaches 500 points), your output should consist of **three lines** :

- On the first line you should print the name of the winner.
- On the second line you should print in which round the player won the game.
- On the third line you should print the points of the player who lost the game

1. If **no one won** the game and the players have the **same score** , you should print out **two lines** :

- On the first line you should print the text: &quot;DRAW&quot;
- On the second line you should print the points that the players have.

1.  If **no one wins** the game and the players have **different amount of points** your output should consist of **two lines** :

- On the first line you should print the name of the player with more points.
- On the second line you should print the difference between the points of the players.

### Constraints

- **F** will be a string, either &quot; **Simeon**&quot; or &quot; **Nakov**&quot;.
- **N** will be an integer number in the range [1...20].
- **P** will be integer in the range [1…500].
- **I** will be a string, either &quot; **success**&quot; or &quot; **fail**&quot;.
- Allowed working time for your program: 0.1 seconds. Allowed memory: 16 MB.

### Examples

![Table](https://github.com/sevdalin/Programming-Basics/blob/master/images/43.PNG)

