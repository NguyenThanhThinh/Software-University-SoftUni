## Problem 1 – Arrange Integers

You are given an array of integer numbers which you need to rearrange by their **name** in the English language. For example, the integers **0, 1, 2, 3, 4, 5, 6, 7, 8, 9** must be ordered as **8, 5, 4, 9, 1, 7, 6, 3, 2, 0.** (eight, five, four, nine,one, seven, six, three, two, zero, i.e. sorted alphabetically)

Integers larger than ten are represented in a simplified way, for example **88** is &#39; **eight-eight**&#39; and **1234** is &#39; **one-two-three-four&#39;.** That means that **88** comes before **85.** If the name of one integer starts with the name of another integer, such as in **11** ( **one-one** ) and **111** ( **one-one-one** ), the smaller integer comes first.

There are no negative integers in the input.

### Input

- The input is on a single line – the integers to be rearranged, separated by a comma and space.

### Output

- On the only output line, print the rearranged integers, in format { **n1, n2, n3 … n** }

### Constraints

- The input numbers are positive signed integers
- There are no more than 50 integers in the input
- Allowed time/memory: 100ms/16MB

| **Input** | **Output** |
| --- | --- |
| 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 | 8, 5, 4, 9, 1, 7, 6, 3, 2, 0 |



| **Input** | **Output** |
| --- | --- |
| 1111, 1, 111, 11 | 1, 11, 111, 1111 |

| **Input** | **Output** |
| --- | --- |
| 17, 32, 45, 88, 44 | 88, 45, 44, 17, 32 |



# Problem 2 – Monopoly

Monopoly is such a fun game but you&#39;ve always been looking for something more. Besides, you want it to be fun even in single player mode. So you came up with a really nice idea which needs to be tested.

The rules are quite simple – there is a rectangular game field in which the **player** starts with 50 **money** at the **top**** left **corner. He** always** moves in the following way:

                        If he is moving **right** , he follows the row to the **last** column. Then he gets to the last column

                        in the row **next** row and starts **moving** left until he reaches the **first** column. The pattern

                        **repeats** to the end of the game field.

He moves one step at a time. On his way down, he will encounter one of the following objects:

- **H (hotel)** – the player spends **all** his money to buy the hotel. He then gets **10 money per turn** for it. A new hotel contributes to the income from the turn it is bought.
- **J (Jail)** – the player **cannot** move for **two** turns
- **F (Free)** – nothing happens here, the game just advances with one step
- **S (Shop)** – the player has to spend money equal to the **product** of the current **row** and **column** number (assume the first row/col is at position 1). If he doesn&#39;t have enough money, he spends all that he has.

For each of the objects except **F** you need to print a corresponding message to the console. At the end of the output, print the **total** turns done in the game and the **final** amount of money. Consider a **turn** to be an **iteration** of the game loop. **Note** that **contrary** to logic, a player can buy a hotel for 0 money.

### Input

- On the first line of input you receive integers **R** and **C** – the dimensions of the field
- On the next **R** lines – you are given a string with length **C** containing only one of the valid objects ( **H, J, F, S** )

### Output

- On the first several lines print a message that describes what happened to the player:
  - **oo** Buys a hotel – { **Bought a hotel for &lt;money&gt;. Total hotels: &lt;hotels&gt;.** }
  - **oo** Goes to jail – { **Gone to jail at turn &lt;turn&gt;.** }
  - **oo** Enters to shop – { **Spent &lt;money&gt; at the shop.** }
- On the last two lines after the player has reached the last cell:
  - **oo** { **Turns &lt;turns&gt;** }
  - **oo** { **Money &lt;money&gt;** }

### Constraints

- 1 ≤ R,C ≤ 10
- Time/memory allowed: 100ms/16MB

| **Input** | **Output** |
| --- | --- |
| 4 4 <br/> HHHF <br/> FFFF <br/> SFFF <br/> FFFF | Bought a hotel for 50. Total hotels: 1. <br/> Bought a hotel for 10. Total hotels: 2. <br/> Bought a hotel for 20. Total hotels: 3. <br/> Spent 3 money at the shop. <br/> Turns 16 <br/> Money 417 |


| **Input** | **Output** |
| --- | --- |
| 1 3 <br/> HJF | Bought a hotel for 50. Total hotels: 1. <br/> Gone to jail at turn 1. <br/> Turns 5 <br/> Money 50 |

| **Input** | **Output** |
| --- | --- |
| 2 4 <br/> FFFF <br/> SFFH  | Bought a hotel for 50. Total hotels: 1. <br/> Spent 2 money at the shop. <br/> Turns 8 <br/> Money 38 |



# Problem 3 – Basic Mark-up Language

HTML is old and clumsy so a group of highly motivated Softuni students decided to create a new language for the web. It&#39;s basically the same in terms of clumsiness, but supports several revolutionary tags:

- **Inverse –** transforms its content&#39;s lowercase letters to uppercase and vice-versa.
  - &lt;inverse content=&quot; **HelloWorlD**&quot;/&gt; outputs **hELLOwORLd**
- **Reverse –** reverses its content
  - **&lt;** reverse content=&quot; **helloworld**&quot;/&gt; outputs **dlrowolleh**
- **Repeat –** repeats its content a specified amount of times
  - **&lt;** repeat value=&quot; **2**&quot; content=&quot; **helloworld**&quot;/&gt; outputs **helloworldhelloworld**
- **Stop –** &lt;stop/&gt; - marks the end of the **BML** file.

Your task is to write a program that correctly parses all currently supported BML tags and outputs the result to the console.

You should **not** output empty lines. For the content tag to be considered non-empty, it must contain **at least one character**.

### Input

- Until the **stop** tag is reached you receive **one** basic mark-up language tag per line
- There are **no invalid** tags or attributes. There may be whitespace **anywhere** in the input

### Output

- Print the correctly formatted output to the console according to the above described rules.
- Each line must have a number, starting from 1, in format &quot;&lt;number&gt;. &lt;output&gt;&quot;
- The &lt;repeat/&gt; tag outputs each string on a new line

### Constraints

- There are no more than 15 lines of input
- The **content** length is in range [0 … 50]. It will not contain double quotes &#39; &quot; &#39;
- The **value** attribute is in range [0 … 10]
- Allowed time/memory: 100ms/16MB

| **Input** | **Output** |
| --- | --- |
|&lt;inverse content=&quot;HelloWorlD&quot;/&gt;<br/>&lt;reverse content=&quot;helloworld&quot;/&gt;<br/>&lt;reverse content=&quot;helloworld&quot;/&gt;<br/>&lt;repeat value=&quot;2&quot; content=&quot;helloworld&quot;/&gt;<br/> &lt;stop/&gt; | 1. hELLOwORLd <br/> 2. dlrowolleh <br/> 3. dlrowolleh <br/> 4. helloworld <br/> 5. helloworld |



| **Input** | **Output** |
| --- | --- |
| **&lt;** repeat value=&quot;2&quot; content=&quot;12345&quot;/&gt;  <br/> **&lt;** repeat value=&quot;5&quot; content=&quot;12346&quot;/&gt; <br/> &lt;stop/&gt; | 1. 12345 <br/> 2. 12345 <br/> 3. 12346 <br/> 4. 12346 <br/> 5. 12346 <br/> 6. 12346 <br/> 7. 12346 |



# Problem 4 – Champion&#39;s League

The Champion&#39;s League is well under way and their team needs a person who can aggregate some data for them. Actually, that person is you. The data you receive will be in format:

**&lt;team1&gt; | &lt;team2&gt; | &lt;team1 goals&gt;:&lt;team2 goals&gt; | &lt;team2 goals&gt;:&lt;team1 goals&gt;**

For example: **Barcelona | Real Madrid | 2:1 | 3:2**. In that case, **Barcelona** have scored 4 goals total, **Real**** Madrid **have also scored 4 goals, but** Barcelona** is the overall winner because they have more goals on away soil. For each team, you need to keep the names of all teams they have played against. You also have to count the total wins.

There will be **no** matches with a score such as **2:2 | 2:2** where the winner must be decided by a penalty shootout. All pairs will be **unique**.

### Input

- You will receive several lines in the above described format. There is no redundant whitespace.
- The input ends with the command &#39; **stop**&#39;
- There is no invalid input.

### Output

- For each team print information in format:

**&lt;team name&gt;**

**- Wins: &lt;total wins&gt;**

**- Opponents: &lt;opponent\_1, opponent\_2, … opponent\_N&gt;**

- The teams must be ordered by total wins in descending order. If two teams have the same number of wins, keep in alphabetical order by team name.
- The opponents must be printed in alphabetical order.

### Constraints

- There are no more than 50 lines of input.
- The team names will consist of several words containing only English alphabet letters.
- The goals are integers in range [0 … 10].
- Allowed time/memory: 100ms/16MB

| **Input** | **Output** |
| --- | --- |
| Real Madrid \| Barcelona \| 0:0 \| 1:1 <br/> Barcelona \| Arsenal \| 2:0 \| 0:2 <br/> Liverpool \| Manchester United \| 2:0 \| 0:0 <br/> Bayern Munich \| Juventus \| 2:1 \| 3:2 <br/> stop | Barcelona <br/> - Wins: 1 <br/> - Opponents: Arsenal, Real Madrid <br/> Bayern Munich <br/> - Wins: 1 <br/> - Opponents: Juventus <br/> Liverpool <br/> - Wins: 1 <br/> - Opponents: Manchester United <br/> Real Madrid <br/> - Wins: 1 <br/> - Opponents: Barcelona <br/> Arsenal <br/> - Wins: 0 <br/> - Opponents: Barcelona <br/> Juventus <br/> - Wins: 0 <br/> - Opponents: Bayern Munich <br/> Manchester United <br/> - Wins: 0 <br/> - Opponents: Liverpool  |





