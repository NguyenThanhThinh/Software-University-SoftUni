# <p align="center"> Files, Directories and Exceptions (RegEx) <p>


This exercise does NOT have Judge Contest. That means that you will need to create input and output files from the examples and test the solutions on your own.

### 1. Most Frequent Number

Write a program that finds the **most frequent number** in a given sequence of numbers.

- Numbers will be in the range [0…65535].
- In case of multiple numbers with the same maximal frequency, print the left most of them.

### Examples

| **Input** | **Output** | **Output** |
| --- | --- | --- |
| **4** 1 1 **4** 2 3 **4 4** 1 2 **4** 9 3 | 4 | The number **4** is the most frequent (occurs 5 times) |
| **2 2 2 2** 1 **2 2 2** | 2 | The number **2** is the most frequent (occurs 7 times) |
| **7 7 7** 0 2 2 2 0 10 10 10 | 7 | The numbers **2** , **7** and **10** have the same maximal frequence (each occurs 3 times). The leftmost of them is **7**. |

### 2. Index of Letters

Write a program that creates an array containing all letters from the alphabet ( **a** - **z** ). Read a lowercase word from the console and print the **index of each of its letters in the letters array**.

### Examples

![](https://github.com/sevdalin/Software-University-SoftUni/blob/master/Programming-Fundamentals/12.%20Files%20And%20Exceptions/Images/2.JPG)

### 3. Equal Sums

Write a program that determines if there **exists an element in the array** such that the **sum of the elements on its left** is **equal** to the **sum of the elements on its right**. If there are **no elements to the left / right** , their **sum is considered to be 0**. Print the **index** that satisfies the required condition or **&quot;no&quot;** if there is no such index.

### Examples

![](https://github.com/sevdalin/Software-University-SoftUni/blob/master/Programming-Fundamentals/12.%20Files%20And%20Exceptions/Images/3.JPG)

### 4. Max Sequence of Equal Elements

Read a **list of integers** and find the **longest sequence of equal elements**. If several exist, print the **leftmost**.

### Examples

| **Input** | **Output** |
| --- | --- |
| 3 4 4 **5 5 5** 2 2 | 5 5 5 |
| **7 7** 4 4 5 5 3 3 | 7 7 |
| 1 2 **3 3** | 3 3 |

### Hints

- Scan positions **p** from left to right and keep the **start** and **length** of the current sequence of equal numbers ending at **p**.
- Keep also the currently best (longest) sequence ( **bestStart** + **bestLength** ) and update it after each step.

### 5. A Miner Task

You are given a sequence of strings, each on a new line. Every odd line on the console is representing a resource (e.g. Gold, Silver, Copper, and so on) , and every even – quantity. Your task is to collect the resources and print them each on a new line.

**Print the resources and their quantities in format:**

**{resource} –&gt; {quantity}**

The quantities inputs will be in the range [1 … 2 000 000 000]

### Examples

![](https://github.com/sevdalin/Software-University-SoftUni/blob/master/Programming-Fundamentals/12.%20Files%20And%20Exceptions/Images/5.JPG)

### 6. Fix Emails

You are given a sequence of strings, each on a new line, **until you receive &quot;stop&quot; command**. First string is a name of a person. On the second line you receive his email. Your task is to collect their names and emails, and remove emails whose domain ends with &quot;us&quot; or &quot;uk&quot; (case insensitive). Print:

**{name} – &gt; {email}**

### Examples

| **Input** | **Output** |
| --- | --- |
| Ivan | Ivan -&gt; [ivanivan@abv.bg](mailto:ivanivan@abv.bg) |
| [ivanivan@abv.bg](mailto:ivanivan@abv.bg)| Petar Ivanov -&gt; petartudjarov@abv.bg |
| Petar Ivanov | |
| petartudjarov@abv.bg | |
| Mike Tyson | |
[myke@gmail.us](mailto:myke@gmail.us) | |
| stop | |

### 7. Advertisement Message

Write a program that **generate random fake advertisement message** to extol some product. The messages must consist of 4 parts: laudatory **phrase** + **event** + **author** + **city**. Use the following predefined parts:

- **Phrases** – {&quot;Excellent product.&quot;, &quot;Such a great product.&quot;, &quot;I always use that product.&quot;, &quot;Best product of its category.&quot;, &quot;Exceptional product.&quot;, &quot;I can&#39;t live without this product.&quot;}
- **Events** – {&quot;Now I feel good.&quot;, &quot;I have succeeded with this product.&quot;, &quot;Makes miracles.I am happy of the results!&quot;, &quot;I cannot believe but now I feel awesome.&quot;, &quot;Try it yourself, I am very satisfied.&quot;, &quot;I feel great!&quot;}
- **Author** – {&quot;Diana&quot;, &quot;Petya&quot;, &quot;Stella&quot;, &quot;Elena&quot;, &quot;Katya&quot;, &quot;Iva&quot;, &quot;Annie&quot;, &quot;Eva&quot;}
- **Cities** – {&quot;Burgas&quot;, &quot;Sofia&quot;, &quot;Plovdiv&quot;, &quot;Varna&quot;, &quot;Ruse&quot;}

The format of the output message is: **{phrase} {event} {author} – {city}**.

As an input you take the **number of messages** to be generated. Print each random message at a separate line.

### Examples

| **Input** | **Output** |
| --- | --- |
| 3 | Such a great product. Now I feel good. Elena – RuseExcelent product. Makes miracles. I am happy of the results! Katya – VarnaBest product of its category. That makes miracles. Eva - Sofia |

### Hints

- Hold the **phrases** , **events** , **authors** and **towns** in 4 arrays of strings.
- Create **Random** object and **generate**** 4 random numbers** each in its range:
  - phraseIndex ­[0, phrases.Length)
  - eventIndex [0, events.Length)
  - authorIndex [0, authors.Length)
  - townIndex [0, towns.Length)
- Get one **random element** from each of the four arrays and **compose a message** in the required format.

### 8. Average Grades

Define a class **Student** , which holds the following information about students: **name** , **list of grades** and **average grade** (calculated property, read-only). A single grade will be in range [2…6], e.g. 3.25 or 5.50.

Read a **list of students** and print the students that have **average grade ? 5.00** ordered **by name** (ascending), then by **average**** grade** (descending). Print the student name and the calculated average grade.

### Examples

| **Input** | **Output** |
| --- | --- |
| 3 | Diana -&gt; 5.75 |
| Ivan 3 | Todor -&gt; 5.33 |
| Todor 5 5 6 | 
| Diana 6 5.50 | 

| **Input** | **Output** |
| --- | --- |
| 6 | Ani -&gt; 5.58 |
| Petar 3 5 4 3 2 5 6 2 6 | Ani -&gt; 5.50 |
| Mitko 6 6 5 6 5 6 | Gosho -&gt; 6.00 |
| Gosho 6 6 6 6 6 6 | Mitko -&gt; 5.67 |
| Ani 6 5 6 5 6 5 6 5 | 
| Iva 4 5 4 3 4 5 2 2 4 |
| Ani 5.50 5.25 6.00 | 

### Hints

- Create class **Student** with properties **Name** ( **string** ), **Grades** (**double[]**), and property **AverageGrade** (calculated by LINQ as **Grades.Average()**, read-only).
- Make a **list of students** and **filter with LINQ** all students that has average **grade**** &gt;= ****5.00**.
- Print the filtered students **ordered by name** in ascending order, then by **average grade** in descending order.

### 9. Book Library

To model a **book library** , define classes to hold a **book** and a **library**. The library must have a **name** and a **list of books**. The books must contain the **title** , **author** , **publisher** , **release date** , **ISBN-number** and **price.**

Read a **list of books** , add them to the library and print the **total sum of prices by author** ,ordered **descending by price** and **then by author&#39;s name lexicographically**.

Books in the input will be in format **{title} {author} {publisher} {release date} {ISBN} {price}**.

### Examples

| **Input** | **Output** |
| --- | --- |
| 5 |
| LOTR Tolkien GeorgeAllen 29.07.1954 0395082999 30.00 | Tolkien -&gt; 40.25 |
| Hobbit Tolkien GeorgeAll 21.09.1937 0395082888 10.25 | JKRowling -&gt; 35.50 |
| HP1 JKRowling Bloomsbury 26.06.1997 0395082777 15.50 | OBowden -&gt; 14.00 |
| HP7 JKRowling Bloomsbury 21.07.2007 0395082666 20.00 |
| AC OBowden PenguinBooks 20.11.2009 0395082555 14.00 | 

### Hints

- Create classes **Book** and **Library** with all the mentioned above properties: 
![](https://github.com/sevdalin/Software-University-SoftUni/blob/master/Programming-Fundamentals/12.%20Files%20And%20Exceptions/Images/9.JPG)
- **Create** an object of type **Library**.
- **Read the input** and create a **Book** object for each book in the input.
- Create a **LINQ** query that will **sum the prices by author** , **order the results** as requested.
- **Print** the results.

### 10. Book Library Modification

Use the classes from the previous problem and make a program that **read a list of books** and **print all titles**** released after given date **ordered** by date **and then** by ****title lexicographically**. The date is given if format &quot; **day-month-year**&quot; at the last line in the input.

### Examples

| **Input** | **Output** |
| --- | --- |
| 5 | 
| LOTR Tolkien GeorgeAllen 29.07.1954 0395082999 30.00 | HP1 -&gt; 26.06.1997 |
| Hobbit Tolkien GeorgeAll 21.09.1937 0395082888 10.25 | HP7 -&gt; 21.07.2007 |
| HP1 JKRowling Bloomsbury 26.06.1997 0395082777 15.50 | AC -&gt; 20.11.2009 |
| HP7 JKRowling Bloomsbury 21.07.2007 0395082666 20.00 | 
| AC OBowden PenguinBooks 20.11.2009 0395082555 14.00 | 
| 30.07.1954 | 
