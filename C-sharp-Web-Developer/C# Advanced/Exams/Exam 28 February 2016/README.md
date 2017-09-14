## Problem 1 – Collect Resources

Stamat got totally hooked on the newest strategy game and literally can&#39;t stop playing it. The game involves building an army and crushing your opponents, but to build an army, you need resources. The game has a rather unusual resource collection system – you are given the available resources and **several** possible ways to collect them. It&#39;s up to you to decide what the optimal path is.

The resources are handed to you as an array of elements in format [**resource\_quantity**** resource\_quantity **…** resource\_quantity**]. Valid resources are**stone, gold, wood **and** food. **When you step on a resource, you collect it. All of them have the same** value, **so** wood\_3 **is equal to** gold\_3. NOTE: **when there is only** one **piece of a given resource, it can be written as** wood **or** wood\_1** (both are valid).

You are also given several different ways to collect the resources – **start** and **step.** The **start** is the zero-based position you start from, and **step** is the number of elements you move to the right. If you reach the end of the resource field, you go back to its start. If the element you jump on is a valid resource, you collect it. The process ends when you reach an element you have already collected.

For example, you have resource field **stone\_5 gold\_3 water\_2 wood\_7** and **start: 0; step: 2.** You start from **stone\_5** and collect 5 resources. You move two elements to the right and step on **water\_2** , which is not a valid resource, so you collect nothing. You move another two elements to the right, but this is outside of the element field, so you have to start from the beginning, which is **stone\_5** again. It is already **collected** , so you stop with the process. You have gathered 5 resources **total**. **NOTE** : invalid resources are **never**** collected**.

Write a program that examines several possible ways to collect resources from the same field and outputs the maximum possible collectable quantity.

### Input

- On the first line of input, you are given the resource field.
- On the second line, you are given the integer N – the number of collection paths
- On the next N lines you are given the **start** and **step** for the given path – both integers, separated by a space.

### Output

- There is one line of output – the maximum possible quantity that can be collected from any of the patterns

### Constraints

- The quantity is in range [1 … 100]
- The number of lines N is in range [1 … 10]
- The **start** index is always inside the resource field. The **step** is a valid positive integer.
- Allowed time/memory 0.1s (C#) 0.25s (Java)/16MB

| **Input** | **Output** |
| --- | --- |
| stone\_5 gold\_2 wood\_7 metal\_17 <br/> 2 <br/> 0 3 <br/> 0 2 | 14 <br/>  <br/>  // Comment: 14 is the quantity collected by path 1. <br/> //  Path 2 yields **12** resources |




## Problem 2 – Parking System

The parking lot in front of SoftUni is one of the busiest in the country, and it&#39;s a common cause for conflicts between the doorkeeper Bai Tzetzo and the students. The SoftUni team wants to proactively resolve all conflicts, so an automated parking system should be implemented. They are organizing a competition – Parkoniada – and the author of the best parking system will win a romantic dinner with RoYaL. That&#39;s **exactly** what you&#39;ve been dreaming of, so you decide to join in.

The parking lot is a **rectangular** matrix where the **first** column is **always** free and all other cells are parking spots. A car can enter from any cell of the first column and then decides to go to a specific spot. If that spot is **not** free, the car searches for the **closest** free spot on the **same** row. If **all** the cells on that specific row are used, the car cannot park and leaves. If **two** free cells are located at the **same** distance from the **initial** parking spot, the cell which is **closer** to the entrance is preferred. A car can **pass** through a used parking spot.


Your task is to calculate the distance travelled by each car to its parking spot.

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/18.JPG)

A car enters the parking at row 1. It wants to go to cell 2, 2 so it moves through **exactly four** cells to reach its parking spot.

### Input

- On the first line of input, you are given the integers **R** and **C** , defining the dimensions of the parking lot.
- On the next several lines, you are given the integers **Z, X,**** Y **where** Z **is the entry row and** X, Y** are the coordinates of the desired parking spot.
- The input stops with the command &#39; **stop**&#39;. All integers are separated by a **single** space.

### Output

- For each car, print the distance travelled to the desired spot or the first free spot.
- If a car cannot park on its desired row, print the message &#39; **Row {row number} full**&#39;

### Constraints

- 2 ≤ R,C ≤ 10000
- Z, X, Y are inside the dimensions of the matrix. Y is never on the first column.
- There are no more than 1000 input lines
- Allowed time/space: 0.1s (C#) 0.25s (Java)/16MB

| **Input** | **Output** |
| --- | --- |
| 4 4 <br/> 1 2 2 <br/> 2 2 2 <br/> 2 2 2 <br/> 3 2 2 <br/> stop | 4 <br/> 2 <br/> 4 <br/> Row 2 full |



## Problem 3 – Softuni Numerals

The standard decimal numbers are boring as hell, so we at SoftUni never use them. Instead, we use several predefined digits with which we create our own numbers. Those digits are:

| 0 | 1 | 2 | 3 | 4 |
| --- | --- | --- | --- | --- |
| aa | aba | bcc | cc | cdc |

For example, the string **ababcccccdc** is the number **1234**. Your task is to convert a Softuni numeral string to a standard decimal number. ( **1234**** 5 **→** 194 ****10** )

A numeral string can be transformed as exactly **one** decimal number.

### Input

- There is one line of input – the numeral string.

### Output

- On the only output line, print the resulting decimal number.

### Constraints

- The length of the input string is between 2 and 150.
- Allowed time/space 0.1s (C#), 0.25s (Java)/16MB

| **Input** | **Output** |
| --- | --- |
| cdc | 4 |



| **Input** | **Output** |
| --- | --- |
| abaaa | 5 |

| **Input** | **Output** |
| --- | --- |
| ababcccccdc | 194 |



## Problem 4 - Events

Your task is to design a state-of-the-art system for registering and displaying events. Events have **location** , **person** and **time**. Only a **valid** event can be registered. For an event to be valid, a specific format must be followed:

**#person: @location hour:minutes**

- The **person must** start with a &#39; **#**&#39;, can contain **only** English alphabet letters and **must** end with &#39; **:**&#39;
- The **location**** must **start with &#39;** @ **&#39; and can contain** only** English alphabet letters
- The **hour** must be a number between 0 and 23, the **minutes** between 0 and 59.
- **Hour** and **minutes** must be separated with &#39; **:**&#39;
- There **may** be whitespace between **person** , **location** and **time** and **nowhere** else

First, you will receive several lines of input, containing information about events that you need to register. At the end of the input, you will receive several locations, separated by a comma &#39;,&#39;. You need to filter all the events that take place at those locations and print information about them.

**Locations** and **people** must be sorted **alphabetically**. The **event**** times **for each person must be displayed in** increasing** order.

### Input

- On the first line you receive the integer N – the number of events to register.
- On the next N lines, you receive information about a single event in the above described format.
- On the last line, you receive several locations, separated by a comma &#39;,&#39;.

### Output

- Print all requested locations on a new line in format **{location}:**
- For each location, print information about its people and times in format **{person} -&gt; {time1, time2}**
  - **oo** Each person and their times must be on a new line

### Constraints

- All strings are **case** - **sensitive**
- Allowed time/memory: 0.1s/16MB

| **Input** | **Output** |
| --- | --- |
| 6 <br/> #Pesho: @Sofia 16:00 <br/> #Ani: @Sofia 22:00 <br/> #Ani: @Sofia 16:00 <br/> #Mincho: @Plovdiv16:00 <br/> #TriFon: @Plovdiv 22:00 <br/> #TriFon: @Plovd1v 23:00 <br/> Sofia,Plovdiv | Plovdiv: <br/> 1. Mincho -&gt; 16:00 <br/> 2. TriFon -&gt; 22:00 <br/> Sofia: <br/> 1. Ani -&gt; 16:00, 22:00 <br/> 2. Pesho -&gt; 16:00 |



| **Input** | **Output** |
| --- | --- |
| 6 <br/> #Pesho: @Sofia 16:00 <br/> #Minka: @Sofia 22:00 <br/> #Strahil: @Sofia 16:00 <br/> #TriFon: @Plovdiv 22:00 <br/> #trifon: @Plovdiv 23:00 <br/> #trifoN: @Plovdiv 23:00 <br/> Plovdiv,Burgas | Plovdiv: <br/> 1. trifon -&gt; 23:00 <br/> 2. trifoN -&gt; 23:00 <br/> 3. TriFon -&gt; 22:00 |
