# <p align="center"> Multidimensional Arrays, Sets, Dictionaries <p>

### Problem 1. Fill the Matrix

Write two programs that **fill** and print a **matrix** of size  **N x N**. Filling a matrix in the regular pattern ( **top to bottom** and **left to right** ) is boring. Fill the matrix as described in both patterns below:

 ![](https://github.com/sevdalin/Software-University-SoftUni/blob/master/Programming-Fundamentals/08.%20Multidimensional%20Arrays%2C%20Sets%2C%20Dictionaries/Images/1.JPG)

### Problem 3. Maximal Sum

Write a program that reads a rectangular integer matrix of size  **N x M**  and finds in it the square  **3 x 3**  that **has maximal sum of its elements**.

On the first line, you will receive the rows **N** and columns **M**. On the next **N lines** you will receive **each row with its columns**.

Print the **elements** of the 3 x 3 square as a matrix, along with their **sum**.

![](https://github.com/sevdalin/Software-University-SoftUni/blob/master/Programming-Fundamentals/08.%20Multidimensional%20Arrays%2C%20Sets%2C%20Dictionaries/Images/2.JPG)

### Problem 4. Matrix shuffling

Write a program which reads a string matrix from the console and performs certain operations with its elements. User input is provided in a similar way like in the problem above – first you read the dimensions and then the data. Remember, you are not required to do this step first, you may add this functionality later.

Your program should then receive commands in format: &quot;swap row1 col1 row2c col2&quot; where row1, row2, col1, col2 are coordinates in the matrix. In order for a command to be valid, it should start with the &quot;swap&quot; keyword along with four valid coordinates (no more, no less). You should swap the values at the given coordinates (cell [row1, col1] with cell [row2, col2]) and print the matrix at each step (thus you&#39;ll be able to check if the operation was performed correctly).

If the command is not valid (doesn&#39;t contain the keyword &quot;swap&quot;, has fewer or more coordinates entered or the given coordinates do not exist), print &quot;Invalid input!&quot; and move on to the next command. Your program should finish when the string &quot;END&quot; is entered. Examples:

![](https://github.com/sevdalin/Software-University-SoftUni/blob/master/Programming-Fundamentals/08.%20Multidimensional%20Arrays%2C%20Sets%2C%20Dictionaries/Images/3.JPG)

### Problem 5. Sequence in Matrix

We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several neighbour elements located on the same **line, column or diagonal**. Write a program that finds the longest sequence of equal strings in the matrix. Examples:

![](https://github.com/sevdalin/Software-University-SoftUni/blob/master/Programming-Fundamentals/08.%20Multidimensional%20Arrays%2C%20Sets%2C%20Dictionaries/Images/4.JPG)

### Problem 6. Collect the Coins

Working with multidimensional arrays can be (and should be) fun. Let&#39;s make a game out of it.

You receive the layout of a **board** from the console. Assume it will always have **4 rows** which you&#39;ll get as strings, each on a separate line. Each character in the strings will represent a **cell** on the board. Note that the strings may be of different length.

You are the player and start at the top-left corner (that would be position **[0, 0]** on the board). On the fifth line of input you&#39;ll receive a string with movement commands which tell you where to go next, it will contain only these four characters – &#39; **&gt;**&#39; (move right), &#39; **&lt;**&#39; (move left), &#39; **^**&#39; (move up) and &#39; **v**&#39; (move down).

You need to keep track of two types of events – collecting coins (represented by the symbol &#39; **$**&#39;, of course) and hitting the walls of the board (when the player tries to move off the board to invalid coordinates). When all moves are over, **print the amount of money** collected and the **number of walls hit**. Example:

![](https://github.com/sevdalin/Software-University-SoftUni/blob/master/Programming-Fundamentals/08.%20Multidimensional%20Arrays%2C%20Sets%2C%20Dictionaries/Images/5.JPG)

### Problem 7. Count Symbols

Write a program that reads some text from the console and counts the occurrences of each character in it. Print the results in **alphabetical** (lexicographical) order. Examples:

![](https://github.com/sevdalin/Software-University-SoftUni/blob/master/Programming-Fundamentals/08.%20Multidimensional%20Arrays%2C%20Sets%2C%20Dictionaries/Images/6.JPG)
![](https://github.com/sevdalin/Software-University-SoftUni/blob/master/Programming-Fundamentals/08.%20Multidimensional%20Arrays%2C%20Sets%2C%20Dictionaries/Images/6.1.JPG)

### Problem 8. Phonebook

Write a program that receives some info from the console about **people** and their **phone numbers**.

You are free to choose the manner in which the data is entered; each **entry** should have just **one name** and **one number** (both of them strings).

After filling this simple phonebook, upon receiving the **command**&quot; **search**&quot;, your program should be able to perform a search of a contact by name and print her details in format &quot; **{name} -&gt; {number}**&quot;. In case the contact isn&#39;t found, print &quot; **Contact {name} does not exist.**&quot; Examples:

![](https://github.com/sevdalin/Software-University-SoftUni/blob/master/Programming-Fundamentals/08.%20Multidimensional%20Arrays%2C%20Sets%2C%20Dictionaries/Images/7.JPG)

\* **Bonus:** What happens if the user enters the same name twice in the phonebook? Modify your program to keep **multiple phone** numbers per contact.

### Problem 9. Night Life

Being a nerd means writing programs about night clubs instead of actually going to ones. Spiro is a nerd and he decided to summarize some info about the most popular night clubs around the world.

He&#39;s come up with the following structure – he&#39;ll summarize the data by **city** , where each city will have a **list of venues** and each **venue** will have a **list of performers**. Help him finish the program, so he can stop staring at the computer screen and go get himself a cold beer.

You&#39;ll receive the input from the console. There will be an **arbitrary** number of lines until you receive the string &quot; **END**&quot;. Each line will contain data in format: &quot; **city;venue;performer**&quot;. If either **city** , **venue** or **performer**** don&#39;t exist **yet in the database,** add them **. If either the city and/or venue** already exist **,** update their info**.

**Cities** should remain in the **order in which they were added** , **venues** should be **sorted alphabetically** and **performers** should be **unique** (per venue) and also **sorted alphabetically**.

Print the data by **listing the cities** and for each city its **venues** (on a new line starting with &quot; **-&gt;**&quot;) and **performers** (separated by comma and space). Check the examples to get the idea. And grab a beer when you&#39;re done, you deserve it. Spiro is buying.

![](https://github.com/sevdalin/Software-University-SoftUni/blob/master/Programming-Fundamentals/08.%20Multidimensional%20Arrays%2C%20Sets%2C%20Dictionaries/Images/8.JPG)
