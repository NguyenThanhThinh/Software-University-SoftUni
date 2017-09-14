
# Importan information:

- Solutions can be checked at: <a href="https://judge.softuni.bg/Contests/#!/List/ByCategory/9/Advanced-CSharp-Exams" > Judge - All EXAMS </a> 

- Some of the **Input or **Output can be different from the "original", because of the hard formatting in README.md file.
  Please check the results in the link above. 

## Problem 1 – Plus-Remove

You are given a sequence of **text lines** , holding symbols, small and capital Latin letters. Your task is to **remove all &quot;plus shapes&quot;** in the text. They may consist of small and capital letters at the same time, or of any symbol. All of the **X shapes** below are **valid** :

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/22.JPG)

Every **&quot;plus shape&quot;** is 3 by 3 symbols crossing each other on 3 lines. Single **&quot;plus shape&quot;** can be part of **multiple****&quot;plus shapes&quot; **. If new**&quot;plus shapes&quot; **are formed after the first removal** you don&#39;t have** to remove them.

### Input

The input data will be received from the console. It consists of variable number of lines. The input ends with the string &quot; **END**&quot;.

### Output

Print at the console the input data after removing all **&quot;plus shapes&quot;**.

### Constraints

- Each input line will hold between 1 and 100 Latin letters.
- The number of input lines will be in the range [1 ... 100].
- Allowed working time: 0.2 seconds. Allowed memory: 16 MB.

### Examples

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/23.JPG)




## Problem 2 – String Matrix Rotation

You are given a **sequence of text lines**. Assume these text lines form a **matrix of characters** (pad the missing positions with spaces to build a rectangular matrix). Write a program to **rotate the matrix** by 90, 180, 270, 360, … degrees. Print the result at the console as sequence of strings. Examples:

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/24.JPG)


### Input

The input is read from the console:

- The first line holds a command in format &quot;**Rotate(X)**&quot; where **X** are the degrees of the requested rotation.
- The next lines contain the **lines of the matrix** for rotation.
- The input ends with the command &quot;END&quot;.

The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

Print at the console the **rotated matrix** as a sequence of text lines.

### Constraints

- The rotation **degrees** is positive integer in the range [0…90000], where **degrees** is **multiple of 90**.
- The number of matrix lines is in the range [1… **1 000**].
- The matrix lines are **strings** of length 1 … 1 000.
- Allowed working time: 0.2 seconds. Allowed memory: 16 MB.

### Examples

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/25.JPG)



## Problem 3 – Extract Hyperlinks

Write a program to **extract all hyperlinks** ( **&lt;href=…&gt;** ) from a given text. The text comes from the console on a variable number of lines and ends with the command &quot;END&quot;. Print at the console the **href** values in the text.

The input text is **standard HTML code**. It may hold many tags and can be formatted in many different forms (with or without whitespace). The **&lt;a&gt;** elements may have many attributes, not only **href**. You should extract only the values of the **href** attributes of all **&lt;a&gt;** elements.

### Input

The input data comes from the console. It ends when the &quot;END&quot; command is received.

### Output

Print at the console the **href** values in the text, each at a separate line, in the order they come from the input.

### Constraints

- The input will be **well formed HTML fragment** (all tags and attributes will be correctly closed).
- Attribute values will never hold tags and hyperlinks, e.g. &quot; **&lt;img alt=&#39;&lt;a href=&quot;hello&quot;&gt;&#39; /&gt;**&quot; is invalid.
- Commented links are also extracted.
- The number of input lines will be in the range [1 ... 100].
- Allowed working time: 0.1 seconds. Allowed memory: 16 MB.

### Examples

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/26.JPG)



## Problem 4 – Query Mess

**Ivancho** participates in a team **project** with colleagues at **SoftUni**.  They have to develop **an application** , but something _mysterious_ happened – at the last moment all team members… disappeared!  And guess what? He is left **alone** to finish the project.  All that is left to do is to parse the input data and store it in a special way, but Ivancho has no idea how to do that! Can you help him?

### Input
The input comes from the console on a variable number of lines and ends when the keyword &quot;END&quot; is received.

For each row of the input, the query string containspairs field=value. Within each pair, the field name and value are separated by an equals sign, &#39;=&#39;. The series of pairs are separated by an ampersand, &#39;&amp;&#39;. The question mark is used as a separator and is not part of the query string. A URL query string may contain another URL as value.The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output
For each input line, print on the console a line containing the processed string as follows:  key=[value]nextkey=[another  value] … etc.
Multiple whitespace characters should be reduced to one inside value/key names, but there shouldn&#39;t be any whitespaces before/after extracted keys and values. If a key already exists, the value is added with comma and space after other values of the existing key in the current string.  See the examples below.

### Constraints

- SPACE is encoded as &#39;+&#39; or &quot;%20&quot;.Letters (A-Z and a-z), numbers (0-9), the characters &#39;\*&#39;, &#39;-&#39;, &#39;.&#39;, &#39;\_&#39; and _other non-special symbols_ are left as-is.
- Allowed working time: 0.1 seconds. Allowed memory: 16 MB.

### Examples

| **Input** | **Output** |
| --- | --- |
| login=student&amp;password=student <br/> END | login=[student]password=[student] |
| **Input** |
| field=value1&amp;field=value2&amp;field=value3  <br/> [http://example.com/over/there?name=ferret](http://example.com/over/there?name=ferret) <br/> END |
| **Output** |
| field=[value1, value2, value3] <br/> name=[ferret] |
| **Input** |
| foo=%20foo&amp;value=+val&amp;foo+=5+%20+203 <br/> foo=poo%20&amp;value=valley&amp;dog=wow+ <br/> url=https://softuni.bg/trainings/coursesinstances/details/1070  <br/> [https://softuni.bg/trainings.asp?trainer=nakov&amp;course=oop&amp;course=php](https://softuni.bg/trainings.asp?trainer=nakov&amp;course=oop&amp;course=php) <br/> END |
| **Output** |
| foo=[foo, 5 203]value=[val] <br/> foo=[poo]value=[valley]dog=[wow] <br/> url=[https://softuni.bg/trainings/coursesinstances/details/1070] <br/> trainer=[nakov]course=[oop, php] |




## Problem 5 – Semantic HTML

You are given an **HTML code** , written in the old **non-semantic** style using tags like **&lt;div id=&quot;header&quot;&gt;** , **&lt;div class=&quot;section&quot;&gt;** , etc. Your task is to write a program that **converts this HTML to semantic HTML** by changing tags like **&lt;div id=&quot;header&quot;&gt;** to their semantic equivalent like **&lt;header&gt;**.

The non-semantic tags that should be converted are **always &lt;div&gt;** s and have either **id** or **class** with one of the following values: &quot; **main**&quot;, &quot; **header**&quot;, &quot; **nav**&quot;, &quot; **article**&quot;, &quot; **section**&quot;, &quot; **aside**&quot; or &quot; **footer**&quot;. Their corresponding closing tags are always followed by a comment like **&lt;!-- header --&gt;** , **&lt;!-- nav --&gt;** , etc. staying at the same line, after the tag.

### Input

The input will be read from the console. It will contain a variable number of lines and will end with the keyword &quot; **END**&quot;.

### Output

The output is the semantic version of the input HTML. In all converted tags you should **replace multiple spaces** (like **&lt;header**  **     **** style=&quot;color:red&quot;&gt;**) with a single space and remove excessive spaces at the end (like &lt;footer        &gt; ). See the examples.

### Constraints

- Each line from the input holds either an HTML **opening tag** or an HTML **closing tag** or HTML **text content**.
- There will be no tags that span several lines and no lines that hold multiple tags.
- Attributes values will always be enclosed in **double quotes****&quot;**.
- Tags will never have **id** and **class** at the same time.
- The HTML will be **valid**. Opening and closing tags will match correctly.
- **Whitespace** may occur between attribute names, values and around comments (see the examples).
- Allowed working time: 0.1 seconds. Allowed memory: 16 MB.

### Examples

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/27.JPG)



## Problem 6 – X-Removal

You are given a sequence of **text lines** , holding only visible symbols, small and capital Latin letters. Your task is to **remove all X shapes** in the text. They may consist of small and capital letters at the same time, or any visible symbol. All of the **X shapes** below are **valid** :

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/28.JPG)

An **X Shape** is 3 by 3 symbols crossing each other on 3 lines. A single **X shape** can be part of **multiple** X shapes. If new X Shapes are formed after the first removal **you don&#39;t have** to remove them.

### Input

The input data comes as **comes from the console on a variable number of lines, ending with the keyword &quot;END&quot;.**

### Output

Print at the console the input data after removing all **X shapes**.

### Constraints

- Each input line will hold between 1 and 100 Latin letters.
- The number of input lines will be in the range [1 ... 100].
- Allowed working time: 0.1 seconds. Allowed memory: 16 MB.

### Examples

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/29.JPG)



## Problem 7 – Vladko&#39;s Notebook

**Vladko Karamfilov** (a.k.a. **SUPER VLADO** or **St.Karamfilov** ) is a very famous **table tennis player**. He is also very organized. In order to become the best tennis player there is, he writes down everything about his opponents in a **pretty notebook, covered in pink flowers**. He is winning all his games, so he has a lot of hostile opponents. One night, one of them crawled into Vladko&#39;s room and tore his notebook apart into separate sheets of paper. Vladko needs your help to gather his information from all the sheets. Fortunately, Vladko writes everything about **a single opponent** on a **sheet**** with a certain color**(for example all information on red sheets is about opponent X, all information on blue sheets is about opponent Y etc.). You are given a**list of colored sheets** given as a text table with the following columns:

- Option 01 – **[color of the sheet]|[win/loss]|[opponent nam****e]**
- Option 02 – **[color of the sheet]|[name]|[player name]**
- Option 03 – **[color of the sheet]|[age]|[player age]**

The different **columns** will always be **separated only by &#39;I&#39;** (there won&#39;t be any whitespaces). The rank of each player is calculated by the formula **rank = (wins+1) / (losses+1)**. If a certain color sheet **has**** no information **about the** name **or the** age **of the player,** you should not **print it in the output. If there is no information about the** opponents **, you must print**&quot;(empty)&quot; **where the opponents list should be. There might be** many opponents with the same name **. If there was** no information recovered (no colors containing name and age) **, print only**&quot;No data recovered.&quot; **Write a program to** aggregate the results** and print them as shown in the example below.

### Input

The input comes from the console on a **variable number of lines** and ends when the keyword &quot; **END**&quot; is received. The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

Print at the console the information for each player ( **sorted by color name** ) that holds the **age** , the **name,** a **list with the opponents** (in alphabetical order) and **rank** of the player. Please follow exactly the format from the example below. The rank of the players should be **rounded to 2 digits** after the decimal point:

- 1.5 -&gt; 1.50; 1 -&gt; 1.00; 1.3214123 -&gt; 1.32

### Constraints

- The numbers of **input lines** is between 1 and 150.
- The names of **colors** and **players** consist of Latin letters and spaces. Their **length** is between 1 and 50 characters.
- The value of **age** will be an integer in the range [0 … 99].
- Allowed working time: 0.3 seconds. Allowed memory: 32 MB.

### Hints

- **The sorting** of the **opponents** array should be done using the **StringComparer.Ordinal** option.

### Examples

| **Input** | **Output** |
| --- | --- |
| purple\|age\|99 <br/> red\|age\|44 <br/> blue\|win\|pesho <br/> blue\|win\|mariya <br/> purple\|loss\|Kiko <br/> purple\|loss\|Kiko <br/> purple\|loss\|Kiko <br/> purple\|loss\|Yana <br/> purple\|loss\|Yana <br/> purple\|loss\|Manov <br/> purple\|loss\|Manov <br/> red\|name\|gosho <br/> blue\|win\|Vladko <br/> purple\|loss\|Yana <br/> purple\|name\|VladoKaramfilov <br/> blue\|age\|21 <br/> blue\|loss\|Pesho <br/> END | Color: purple <br/> -age: 99 <br/> -name: VladoKaramfilov <br/> -opponents: Kiko, Kiko, Kiko, Manov, Manov, Yana, Yana, Yana <br/> -rank: 0.11 <br/> Color: red <br/> -age: 44 <br/> -name: gosho <br/> -opponents: (empty) <br/> -rank: 1.00 |




# Problem 8 – Text Gravity

Write a program that takes as input a **line length** and **text** and formats the text so that it fits inside several rows, each with length equal to the given line length. Once the text is fitted, each character starts dropping as long as there is an empty space below it.

For example, we are given the text &quot;_The Milky Way is the galaxy that contains our star system_&quot; and **line length** of **10**. If we distribute the text characters such that the **text fits in lines with length 10** , the result is:

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/30.JPG)


Text characters start &#39;falling&#39; **until no whitespace remain under any character**. The resulting text should be printed as an HTML table with each character in **&lt;td&gt;&lt;/td&gt;** tags.

### Input

The input will come from the console. It will consist of two lines.

- The first line will hold the **line length**.
- The second input line will hold a **string**.

### Output

The output consists of the HTML table. Everything should be put inside **&lt;table&gt;&lt;/table&gt;** tags. Each line should be printed in **&lt;tr&gt;&lt;/tr&gt;** tags. Each character should be printed in **&lt;td&gt;&lt;/td&gt;** tags (encode the HTML special characters with the **SecurityElement.Escape()** method). Print **space**&quot; &quot; in all empty cells. See the example below.

### Constraints

- The **line length** will be an integer in the range [1 ... 30].
- The **text** will consist of [1 … 1000] ASCII characters.

### Example

| **Input** |
| --- |
| 10 <br/> The Milky Way is the galaxy that contains our star system |
| **Output** |
| &lt;table&gt;&lt;tr&gt;&lt;td&gt; &lt;/td&gt;&lt;td&gt; &lt;/td&gt;&lt;td&gt; &lt;/td&gt;&lt;td&gt; &lt;/td&gt;&lt;td&gt;M&lt;/td&gt;&lt;td&gt; &lt;/td&gt;&lt;td&gt; &lt;/td&gt;&lt;td&gt; &lt;/td&gt;&lt;td&gt; &lt;/td&gt;&lt;td&gt; &lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt; &lt;/td&gt;&lt;td&gt;h&lt;/td&gt;&lt;td&gt;e&lt;/td&gt;&lt;td&gt; &lt;/td&gt;&lt;td&gt;i&lt;/td&gt;&lt;td&gt;i&lt;/td&gt;&lt;td&gt;l&lt;/td&gt;&lt;td&gt; &lt;/td&gt;&lt;td&gt;y&lt;/td&gt;&lt;td&gt; &lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;T&lt;/td&gt;&lt;td&gt;a&lt;/td&gt;&lt;td&gt;y&lt;/td&gt;&lt;td&gt;l&lt;/td&gt;&lt;td&gt;a&lt;/td&gt;&lt;td&gt;s&lt;/td&gt;&lt;td&gt;y&lt;/td&gt;&lt;td&gt;k&lt;/td&gt;&lt;td&gt;h&lt;/td&gt;&lt;td&gt;e&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;W&lt;/td&gt;&lt;td&gt;g&lt;/td&gt;&lt;td&gt;a&lt;/td&gt;&lt;td&gt;c&lt;/td&gt;&lt;td&gt;o&lt;/td&gt;&lt;td&gt;x&lt;/td&gt;&lt;td&gt;t&lt;/td&gt;&lt;td&gt;t&lt;/td&gt;&lt;td&gt;t&lt;/td&gt;&lt;td&gt;h&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;a&lt;/td&gt;&lt;td&gt;t&lt;/td&gt;&lt;td&gt;o&lt;/td&gt;&lt;td&gt;u&lt;/td&gt;&lt;td&gt;r&lt;/td&gt;&lt;td&gt;n&lt;/td&gt;&lt;td&gt;s&lt;/td&gt;&lt;td&gt;a&lt;/td&gt;&lt;td&gt;i&lt;/td&gt;&lt;td&gt;n&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;s&lt;/td&gt;&lt;td&gt;s&lt;/td&gt;&lt;td&gt;y&lt;/td&gt;&lt;td&gt;s&lt;/td&gt;&lt;td&gt;t&lt;/td&gt;&lt;td&gt;e&lt;/td&gt;&lt;td&gt;m&lt;/td&gt;&lt;td&gt;t&lt;/td&gt;&lt;td&gt;a&lt;/td&gt;&lt;td&gt;r&lt;/td&gt;&lt;/tr&gt;&lt;table&gt; |




# Problem 9 – Uppercase Words

Write a program to **reverse the letters of all uppercase words in a text**. In case an uppercase word stays **unchanged** after reversing its letters, then **double each of its letters**. A word is a sequence of Latin letters separated by **non-letter characters** (e.g. punctuation characters or digits). For example, the text &quot;_PHP5 is the latest PHP currently, YES_&quot; consists of the following words: _PHP_, _is_, _the_, _latest_, _PHP_, _currently_, _YES_.

### Input

The input will be read from the console. It will consist of a variable number of lines, ending with the command &quot;END&quot;.

### Output

The output should hold the **result text**. Ensure you escape correctly the HTML special characters in the output with the **SecurityElement.Escape() method**.

### Constraints

- The text will be in **ASCII encoding** (texts in Cyrillic, Arabic, Chinese, etc. are not supported).
- Allowed working time: 0.2 seconds. Allowed memory: 16 MB.

### Examples

| **Input** |
| --- |
| Companies like     <br/> HP, ORACLE and IBM target their platforms for cloud-based environment.     <br/> IList&lt;T&gt; implements IEnumerable&lt;T&gt;. GoPHP is a PHP library. <br/> END |
| **Output** |
| Companies like    <br/>  PH, ELCARO and MBI target their platforms for cloud-based environment.     <br/> IList&amp;lt;TT&amp;gt; implements IEnumerable&amp;lt;TT&amp;gt;. GoPHP is a PPHHPP library. |

| **Input** |
| --- |
| IBM announced it delivered the first shipment of its Enterprise Cloud system to a  <br/> U.K.-based managed service provider.PHP5 is the latest PHP currently, YES <br/> END |
| **Output** |
| MBI announced it delivered the first shipment of its Enterprise Cloud system to a UU.KK.-based managed service provider. PPHHPP5 is the latest PPHHPP currently, SEY |




## Problem 10 – Clearing Commands

As a janitor at SoftUni you have the task to clean all the garbage, left by the students every day. The problem is you can only move through the maze of tables, chairs, internet cables and power plugs following the commands SoftUni team has left at the end of the day.

You are given a matrix, holding 1 or more **strings of ASCII characters**. The strings will come from the console, each on a separate line. These strings will contain all the garbage and commands by the SoftUni team. Your task is to find and execute all the clearing commands within the matrix. The commands are initiated by the following characters:

1. &quot;&gt;&quot; – **Removes** the characters to the **right** and replaces **each** one with **a single space (&quot; &quot;)**.
2. &quot;&lt;&quot; – **Removes** the characters to the **left** and replaces **each** one with **a single space (&quot; &quot;)**.
3. &quot;v&quot; – **Removes** the characters **below** and replaces **each** one with **a single space (&quot; &quot;)**.
4. &quot;^&quot; – **Removes** the characters **above** and replaces **each** one with **a single space (&quot; &quot;)**.

Every command is executed until it reaches another command character or the matrix borders are reached.

### Input

The input will be read from the console. Each line will be a string of equal length, holding ASCII characters. The input will end with the command &quot;END&quot;.

### Output

The output should consist of &lt;p&gt; tags, each holding a row of the matrix (a string).

Note: Make sure you escape all the special characters within the &lt;p&gt; tags with the **SecurityElement.Escape** method.

### Constraints

- The strings will contain any ASCII character.
- Allowed working time: 0.1 seconds. Allowed memory: 16 MB.

### Examples

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/31.JPG)



## Problem 11 – Little John

As you probably know Little John is the right hand of the famous English hero - Robin Hood.A little known fact isthat Little John can&#39;t handle Math very well. Before Robin Hood left to see Marry Ann, he asked John to **count** his hay of arrowsand send him an **encrypted** message containing thearrow&#39;s count **.** The message should be encrypted since it can be intercepted by the Nottingham&#39;s evil Sheriff. Your task is to help Little John before it is too late (0.10 sec).

You are given **4 input** strings(hay). Those strings **may or may not** contain arrows. The arrows can be of different type as follows:

- &quot;&gt;-----&gt;&quot; – a small arrow
- &quot;&gt;&gt;-----&gt;&quot; – a medium arrow
- &quot;&gt;&gt;&gt;-----&gt;&gt;&quot; – a large arrow

Note that the **body** of each arrow will always be **5 dashes long**. The **difference** between the arrows is in their **tip** and **tail**. The given 3 types are the only ones you should count, the **rest should be ignored** (Robin Hood does not like them). You should start searching the hays **from the largest** arrow type down **to the smallest** arrow type.

After you find the **count** of each arrow type you should **concatenate** them into one number in order: small,medium, large arrow(even if the arrow count is 0). Then you **convert** the number in **binary** representation, **reverse** it and **concatenate it again** with the initial binary representation of the number. You **convert** the final binary number again **back to decimal**. This is the encrypted message you should send to Robin Hood.

### Input

The input will be read from the console. The **data** will be received from 4 input **lines containing strings**.

### Output

The output should be a decimal number, representing the encrypted count of arrows.

### Constraints

- The input strings will contain any ASCII character.
- Allowed working time: 0.1 seconds. Allowed memory: 16 MB.

### Examples

| **Input** | **Output** |
| ----------------------- | --- |
| &gt;&gt;&gt;-----&gt;&gt;abc&gt;&gt;&gt;-----&gt;&gt; <br/> &gt;&gt;&gt;-----&gt;&gt; <br/> &gt;-----&gt;s <br/> &gt;&gt;-----&gt; | 14535 <br/>  The count is: 1 small, 1 medium and 3 large arrows__113(dec) = 1110001(bin) -&gt; reversed is 1000111(bin)__1110001 __1000111__ (bin) = 14535(dec)_ |




## Problem 12 – Phone Numbers

You are given a string, holding ASCII characters. Find all **name -&gt; phone number** pairs, format them and print them in an **ordered list** as list items.

The **name** should be at least **one letter long, can contain only letters** and should **always start with an uppercase letter**.

The **phone**** number **should be at least** two digits long **,** should start and end with a digit**(**optionally **, there might be a**&quot;+&quot; in front) **and might** contain **the following symbols in it:**&quot;(&quot;, &quot;)&quot;, &quot;/&quot;, &quot;.&quot;, &quot;-&quot;, &quot; &quot;** (left and right bracket, slash, dot, dash and whitespace).

Between a name and the phone number there might be **any number of symbols, other than letters and &quot;+&quot;**.

Between the name -&gt; phone number pairs there might be **any number of ASCII symbols**.

The output format should be **&lt;b&gt;[name]:&lt;/b&gt; [phone number]** (there is **one**** space between** the name and the phone number). Clear any characters other than digits and &quot;+&quot; from the number when printing the output.

### Input

The input will be read from the console. It will consist of several lines holding the input string. The command &quot; **END**&quot; denotes the end of input.

### Output

The output should hold the **resulting ordered list (on a single line)**, or a single **paragraph,** holding&quot; **No matches!**&quot;

### Constraints

- The **numbers string** will hold only **ASCII** characters (no Unicode).
- Allowed working time: 0.1 seconds. Allowed memory: 16 MB.

### Examples

| **Input** |
| --- |
| **Angel** $(\*^# **029661234**!@# **Pesho** ,.&#39; **+3592/9653241** ;&#39;&quot;:{},.
 <br/> **Ivan**** 0888 123 456 ****John** -=\_ **555.123.4567**         Stoian!@#$#@        Gosho )=\_\*        **Steven**  <br/> #$(\*&amp;**+1-(800)-555-2468** <br/> END |
| **Output (li items are separated on new lines for convenience)** |
| &lt;ol&gt;&lt;li&gt;&lt;b&gt;Angel:&lt;/b&gt; 029661234&lt;/li&gt; <br/> &lt;li&gt;&lt;b&gt;Pesho:&lt;/b&gt; +35929653241&lt;/li&gt;
 <br/> &lt;li&gt;&lt;b&gt;Ivan:&lt;/b&gt; 0888123456&lt;/li&gt;
 <br/> &lt;li&gt;&lt;b&gt;John:&lt;/b&gt; 5551234567&lt;/li&gt;
 <br/> &lt;li&gt;&lt;b&gt;Steven:&lt;/b&gt; +18005552468&lt;/li&gt;&lt;/ol&gt; |

| **Input** |
| --- |
| There are no phone numbers here!!! <br/> END |
| **Output** |
| &lt;p&gt;No matches!&lt;/p&gt; |




# Problem 13 – Sum of All Values

You are given a **keys string** and a **text string**. Write a program that finds the **start key** and the **end key** from the **keys string** and then **applies**** them **to the** text string**.

The **start key** will **always** stay at the **beginning** of the **keys string**. It can contain **only letters and underscore** and **ends** just before the **first found digit**.

The **end key** will **always** stay at the **end** of the **keys string**. It can contain **only letters and underscore** and **starts** just after the **last found digit**.

Print at the console the **sum of all values (only integer and** **floating-point numbers with dot as a separator are considered valid)** in the **text string,** between a **start**** key **and an** end key**. If the value is 0 then print &quot;The total value is: _nothing_&quot;. If no start key or no end key is found then print &quot;A key is missing&quot;.

### Input

The input will be read from the console. The first line will hold the keys string and the second line will hold the text to search.

### Output

The output should hold the **result text** , printed in an HTML paragraph. The actual value of the sum should be **italic.**

### Constraints

- The **keys string and text string** will hold only **ASCII** characters (no Unicode).
- Allowed working time: 0.1 seconds. Allowed memory: 16 MB.

### Examples

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/32.JPG)



## Problem 14 – Matrix Shuffle

You are given an **input string** which you should **fill in a square spiral matrix** with a given **size**. After filling up the matrix you should move through it and **extract** from it **all the letters in a chessboard pattern**.

Your next task is to **check** if the newly formed **sentence** , read in **lowercase** and with all **non-letter characters removed** , is a **palindrome** (reading it from **left to right** is the **same** as reading it from **right to left** ).

**Example** : You are given the string &quot; **Rvioes roi tset**&quot; and a size of **4**. You fill the matrix in **a spiral** as shown below.

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/33.JPG)

After filling it up, **extract** all letters in a **chessboard pattern**. Frist extract all **white squares** , after that all **black squares**.

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/34.JPG)



Result: &quot; **Rise to vote sir**&quot;.

After obtaining the string we must **check** if it is a **palindrome**.  &quot; **ris etov ot esir**&quot; == &quot;rise to vote sir&quot;. They are equal so we found a palindrome. The **output** consists of a single &quot; **&lt;div&gt;**&quot; tag which holds the found sentence. If the sentence **is a palindrome** the &quot;div&quot; tag&#39;s **background** should be set to **#4FE000**. If the sentence is **not** a palindrome its background should be **#E0000F**.

### Input

The input will be read from the console. The first line will hold a number – the **size** of the matrix. The second line will hold the **text**. The input data will always be **valid** and in the format described. There is no need to check it explicitly.

### Output

The output should be an **HTML &lt;div&gt; tag** that shows the newly found sentence, colored by changing its background to **#E0000F** (see the examples below) if the sentence is not a palindrome or **#4FE000** if the sentence is a palindrome. **Follow strictly the sample HTML output format below.**

### Constraints

- The **text** is a non-empty text field.
-  The **size** is an integer in the range [1 … 9].
- Allowed working time: 0.1 seconds. Allowed memory: 16



### Examples

| **Input** |
| --- |
| 4 <br/> Rvioes roi tset |
| **Output** |
| &lt;div style=&#39;background-color:#4FE000&#39;&gt;Rise to vote sir &lt;/div&gt; |

| **Input** |
| --- |
| 7 <br/> Soovfetonetem  sssadroedw atrneahr dyri  aUhi stv |
| **Output** |
| &lt;div style=&#39;background-color:#E0000F&#39;&gt;Software University has moved to another address &lt;/div&gt; |



## Problem 15 – The Numbers

_&quot;The numbers, Mason, what do they mean?&quot;_

We&#39;ve just received a ton of unreadable signals from the International Space Station. We&#39;ve lost all contact with the team up there, and all we got are these messages. Aliens? Might be. Can you please clear up the messages for us, so we can pass them to the decryption team?

Your job is to **clear the text from any unnecessary symbols** (only the numbers are needed) and **convert the remaining number sequences to hex format**. If a hex value has less than 4 characters, you need to **add leading zeros**. Finally, you need toplace a **&quot;0x&quot; prefix before each hex value** and **concatenate them all with dashes**&#39;-&#39;.

For example, we have the following message: &quot;**5tffwj(//\*7837xzc2---34rlxXP%$**&quot;. After trimming the unnecessary data (non-numeric characters), we&#39;ve got the numbers **5** , **7837** , **2** and **34** left. We convert them to hex: **5** , **1E9D** , **2** , **22** ; add leading zeros where needed: **0005, 1E9D, 0002, 0022** , place 0x before each oneand concatenate them with dashes: **0x0005-0x1E9D-0x0002-0x0022**.

(Note: hex values _MUST_ be uppercase)

### Input

The input data will be received from the console. It consists of a single line – the initial message you need to transform.

The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

The output consists of only one line – the transformed message.

### Constraints

- The message will be no longer than 10000 characters.
- The message will consist of ASCII characters only.
- The numbers encoded in the message will be in the range **[0 … 65 535]**.
- Time limit: 0.1 sec. Memory limit: 16 MB.

### Examples

| **Input** | **Output** | 
| --- | --- |
| 5tffwj(//\*7837xz <br/> c2---34rlxXP%$&quot;. | 0x0005-0x1E9D-0x0002-0x0022 |
| **Input** | **Output** | 
482vMWo(\*&amp;^%$213;k!@41341((()&amp;^&gt;&gt;&lt;///]42344p;e312 | 0x01E2-0x00D5-0xA17D-0xA568-0x0138 
| **Input** | **Output** | 
| 20 | 0x0014 |




# Problem 16 – Parachute

You find yourself in training for becoming the **best parachute jumper** in the world. At the beginning of the training you need to understand how **gravity** and **wind** work. You are given all the data from previous jumps of your colleagues. Your task is to determine how the **jumper** will **finish** his jump and **where** he will **land** exactly, based on the gravity and wind parameters.

You are given a layout, consisting of several input strings, representing a matrix. The **jumper** can be **anywhere** in the matrix and is denoted by the **&quot;o&quot; symbol**. You need to determine the **movement** of the jumper in **iterations**. On each iteration, the jumper first moves **one line down** , pulled by **gravity**. Additionally, the jumper moves **sideways** by the **wind** on the **current** line.

- The **&quot;&gt;&quot; symbol** means the wind is moving the jumper **one position** to the **right**.
- The **&quot;&lt;&quot; symbol** means the wind is moving the jumper **one position** to the **left**.

The **total direction** of the wind on a single line may **stack** (e.g. &quot; **&gt;&gt;&gt;**&quot; moves the jumper 3 positions to the right; &quot; **&gt;&lt;&lt;**&quot; moves the jumper 1 position to the left).

See the examples to better understand the motion of the jumper.

The jumper can move only through **air** (the **&quot;-&quot;, &quot;&gt;&quot; and &quot;&lt;&quot; symbols** ). When the jumper hits the **ground** , **water** or a **cliff** , the jump is **finished** and you need to **print the outcome** of the jump.

When checking for a collision, you need to take into account only the destination cell in the matrix (do not check the path the jumper took to get there).

### Input

- The input will be read from the console.
- It consists of strings, representing the rows of the matrix. The **symbols** are **not separated** by anything.
- The input ends with the keyword &quot; **END**&quot;.
- The input data will always be valid and in the format described.

### Output

The output consists of two lines. The first line holds a string **. There are 3 possible outcome messages:**

- If you have landed on the **ground** (&quot;\_&quot; symbol), you are well and alive: **&quot;Landed on the ground like a boss!&quot;**
- If you have landed in the **water** (&quot;~&quot; symbol), you have drowned: &quot; **Drowned in the water like a cat!&quot;**
- If you have landed on **a cliff** (&quot;/&quot;, &quot;\&quot; or &quot;|&quot; symbol), you have died: &quot; **Got smacked on the rock like a dog!**

The second line holds the **position** (the **row** and **col** )of your landing.

### Constraints

- The **row** and **col** of the matrix will be in the range **[0 … 20****]**.
- The jumper will never fly off the map.
- Time limit: 0.1 sec. Memory limit: 16 MB.







### Examples

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/35.JPG)



## Problem 17 – Biggest Table Row

You are given an **HTML table** with 4 columns: **Town** , **Store1** , **Store2** and **Store3**. It consists of sequence of text lines: the &quot; **&lt;table&gt;**&quot; tag, the header row, several data rows, and **&quot;&lt;/table&gt;**&quot; tag (see the examples below). The **Store1** , **Store2** , and **Store3** columns hold either numbers or &quot; **-**&quot; (which means &quot; **no data**&quot;). Your task is to write a program which parses the table data rows and finds the row with a **maximal sum** of its values.

### Input

The input is read from the console on several lines, each holding the table rows.The last row will always hold the string &quot;&lt;/table&gt;&quot;. The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

Print at the console a single line, holding the data row values with **maximal sum** in format: &quot; **sum = value1 + value**** 2 + …**&quot;. Print the values exactly as they were found in the input (no rounding, no reformatting). If all rows contain no data, print &quot;**no data **&quot;. If two rows have the** same maximal sum**, print the first of them.

### Constraints

- The **count** of input rows is in the range [0 … 1 000].
- The columns **Store1** , **Store2** and **Store3** hold numbers in the range [-100 0000 … 100 000].
- There is **no whitespace** anywhere in the data rows.
- Allowed working time: 0.1 seconds. Allowed memory: 16 MB.

### Examples

| **Input** | **Output** |
| --- | --- |
| &lt;table&gt; <br/> &lt;tr&gt;&lt;th&gt;Town&lt;/th&gt;&lt;th&gt;Store1&lt;/th&gt;&lt;th&gt;Store2&lt;/th&gt;&lt;th&gt;Store3&lt;/th&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Sofia&lt;/td&gt;&lt;td&gt;26.2&lt;/td&gt;&lt;td&gt;8.20&lt;/td&gt;&lt;td&gt;-&lt;/td&gt;&lt;/tr&gt; **&lt;tr&gt;&lt;td&gt;Varna&lt;/td&gt;&lt;td&gt;11.2&lt;/td&gt;&lt;td&gt;18.00&lt;/td&gt;&lt;td&gt;36.10&lt;/td&gt;&lt;/tr&gt;** &lt;tr&gt;&lt;td&gt;Plovdiv&lt;/td&gt;&lt;td&gt;17.2&lt;/td&gt;&lt;td&gt;12.3&lt;/td&gt;&lt;td&gt;6.4&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Bourgas&lt;/td&gt;&lt;td&gt;-&lt;/td&gt;&lt;td&gt;24.3&lt;/td&gt;&lt;td&gt;-&lt;/td&gt;&lt;/tr&gt;&lt;/table&gt; | 65.3 = 11.2 + 18.00 + 36.10 |

| **Input** | **Output** |
| --- | --- |
| &lt;table&gt; <br/> &lt;tr&gt;&lt;th&gt;Town&lt;/th&gt;&lt;th&gt;Store1&lt;/th&gt;&lt;th&gt;Store2&lt;/th&gt;&lt;th&gt;Store3&lt;/th&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Sofia&lt;/td&gt;&lt;td&gt;-&lt;/td&gt;&lt;td&gt;-&lt;/td&gt;&lt;td&gt;-&lt;/td&gt;&lt;/tr&gt;&lt;/table&gt; | no data |

| **Input** | **Output** |
| --- | --- |
| &lt;table&gt; <br/> &lt;tr&gt;&lt;th&gt;Town&lt;/th&gt;&lt;th&gt;Store1&lt;/th&gt;&lt;th&gt;Store2&lt;/th&gt;&lt;th&gt;Store3&lt;/th&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Sofia&lt;/td&gt;&lt;td&gt;12850&lt;/td&gt;&lt;td&gt;-560&lt;/td&gt;&lt;td&gt;20833&lt;/td&gt;&lt;/tr&gt; **&lt;tr&gt;&lt;td&gt;Rousse&lt;/td&gt;&lt;td&gt;-&lt;/td&gt;&lt;td&gt;50000.0&lt;/td&gt;&lt;td&gt;-&lt;/td&gt;&lt;/tr&gt;** &lt;tr&gt;&lt;td&gt;Bourgas&lt;/td&gt;&lt;td&gt;25000&lt;/td&gt;&lt;td&gt;25000&lt;/td&gt;&lt;td&gt;-&lt;/td&gt;&lt;/tr&gt;&lt;/table&gt; | 50000 = 50000.0 |



## Problem 18 – PIN Validation

You&#39;re part of a very promising team of specialists, which is hired by the parliament to recreate the new electronic government in Bulgaria.

Your task is to write a program that reads data about the voters in an electronic poll: **first and last name, gender and PIN (EGN in Bulgarian) and then verifies the PIN.** The program should generate **a JSON string** for DB insert **if the data is correct,** or print &quot; **Incorrect data**&quot; in **&lt;h2&gt;&lt;/h2&gt;** heading tags.

The PIN is a 10-digit number, which consists of the following:

- **First 6 digits** are the date of birth of the citizen in format **yymmdd;** if the person is born **before 1900,** the **mm** digits are **+20.** If the person is born **after 2000,** the **mm** digits are **+40**
- **Next 3 digits** show the region, based on the **regional city of birth;**
- **The last of the above 3 digits** shows the gender – **even for male** and **odd for female;**
- **One digit** for **checksum**. In order to get the correct checksum you need to **multiply each of the first 9 digits with [2,4,8,5,10,9,7,3,6]** respectively, **sum all** and then **divide by 11**. The **remainder** is the **checksum**.
**NOTE: if the remainder is 10, then the checksum is 0** (source: [http://www.grao.bg/esgraon.html](http://www.grao.bg/esgraon.html) )

Example: **9912164756** as PIN we check the following:

- **991216** – translates to 16#th December 1999 – **correct date**
  - **995216 –** translates to 16#th December 2099
  - **993216 –** translates to 16#th December 1899
- **475** – shows the regional city is Plovdiv
- **5** – shows the PIN is of a girl – **correct gender**
- 9\*2 + 9\*4 + 1\*8 + 2\*5 + 1\*10 + 6\*9 + 4\*7 + 7\*3 + 5\*6 = 215. 215 / 11 = 19 (remainder **6** ) – **correct checksum**

### Input

The input will be read from the console. The **first and last name** will be received on the first line. The **gender** will be received on the second line. The **PIN** will be received on the third line.

### Output

If the PIN is not correct or the data is not in the format described, &quot; **Incorrect data**&quot; should be printed. Otherwise, **print a JSON string** with all the data (follow the format provided below).

### Constraints

- The name string will contain names. You should check if there are 2 words, each starting with an uppercase letter.
- Gender will always be &#39;male&#39; or &#39;female&#39;.
- PIN will be a number. You should check if it is a 10-digit number.

### Examples

| **Input** | **Output** |
| --- | --- |
| Ana Ivanova <br/> female <br/> 9912164756 | {&quot;name&quot;:&quot;Ana Ivanova&quot;,&quot;gender&quot;:&quot;female&quot;,&quot;pin&quot;:&quot;9912164756&quot;} |
| **Input** | **Output** |
| Ivan Petrov <br/> male <br/> 1234567890 | &lt;h2&gt;Incorrect data&lt;/h2&gt; |





## Problem 19 – Chat Logger

Write a program that receives **several messages** and **the current date** , **sorts those messages by date** and prints **the time from the last message to the current date**.

The messages will be in format **[message] / [date]**, where **date** is in format **dd-mm-YYYY hours:min:secs**. The messages should be **sorted by date** and their text should be printed in **&lt;div&gt;&lt;/div&gt;** tags on a separate line. For example we are given the current date **12-08-2014 10:14:23** and the following messages:

Thanks :) / 11-08-2014 22:54:52

Hey John, happy birthday! / 10-08-2014 00:00:00

After sorting the messages by date in **ascending** order (from **oldest to most recent** ), the result is:

&lt;div&gt;Hey John, happy birthday!&lt;/div&gt;

&lt;div&gt;Thanks :)&lt;/div&gt;

Finally, the time since the most recent message should be printed in the following way:

- **a few moments ago** if it was less than 1 minute ago
- **[full minutes] minute(s) ago** if it was less than 1 hour ago
- **[full hours] hour(s) ago** if it was less than 24 hours ago **on the same day**
- **yesterday** if it was the previous date, regardless of the time difference
- **[date]** if it was earlier than yesterday, where **date** is in format **dd-mm-YYYY**

The resulting timestamp should be printed as follows:  **&lt;p&gt;Last active: &lt;time&gt;[timestamp]&lt;/time&gt;&lt;/p&gt;**. In this case, the difference between the current date and the last message is 11 full hours, but since the message&#39;s day is 1 day before the current day, we print yesterday:

        &lt;p&gt;Last active: &lt;time&gt; **yesterday** &lt;/time&gt;&lt;/p&gt;

### Input

The input will be read from the console. The **current time** will be received on the first line. The **messages** come will be received on the next input lines, **each message on a separate line**. The input ends with the command &quot; **END**&quot;.

### Output

Each message should be printed in its own **&lt;div&gt;&lt;/div&gt;** tags, on a separate line. On the final line, the difference between the current date and the last message date should be printed in the format described above. Ensure the HTML special characters are correctly encoded (use **SecurityElement.Excape** ).

### Constraints

- All input dates will be in format **dd-mm-YYYY hours:min:secs**.
- The received messages will always be in format **[message] / [date] (with space around the delimiter &#39;/&#39;)**.
- There will be exactly one message on a single line.
- There will be no messages with the same date.
- The current date will always be after any message&#39;s date.

### Examples

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/36.JPG)



## Problem 20 – Oh, My Girl!

A painter acquainted a girl programmer. When he invited her to a date, she agreed. But the girl
wanted the boy to take her from home. She handed him a sheet of paper on which **her address was written**. When he looked, he saw a lot of random characters without meaning and without order. After the main text there was a short string - key. The address was **parted in pieces of two to six symbols.** All parts of text are surrounded by **key in the**  **beginning**  **and key in the**  **end**.

**Example**
![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/37.JPG)

The key:   **a7#&quot;F5**

The actual address: **Sofia, 32 Rakovski Str**

The key is not something permanent. It is a string, which meets the following criteria:

- The **first, last** and all other characters **other than numbers and letters** have a hard value as the given key
- The **symbols between them** are of the **same type** as the type of symbol in the original key:
Where there is a **digit** : in its place can sit a **sequence of DIGITS** with **indefinite length or no length**.
Where there is a **letter** : in its place can sit a **sequence of LETTERS** with **indefinite length or no length**.
- The letters are **case-sensitive**.
- Remember to escape all special characters when you want to match them with literal meaning.

### Input

The input will be read from the console. The **key** will be received on the first line. The **text** will be received on the next lines, ending with the keyword &quot; **END**&quot;.

### Output

The resulting paragraph should be printed as output.

### Constraints

- The **text** willbe a stringwith a length of [20 ... 1000]
- The **key** willbe a stringwith a length of [2 ... 10].

### Examples

## Note: Example may not be shown correctly due to formatting of the README.md file

| **Input** | **Output** |
| --- | --- |
| a7#&quot;F5a-.885O,a745#&quot;F5Sofa7#&quot;FFF5a
1#&quot;D5ia, a000#&quot;FFF5a88887#&quot;F532 a123457#&quot;F5a7   #&quot;FGDGSDG
5G.S.a#&quot;5 ma-5.55gghja-.885y8
hgja#&quot;F5Rakoa#&quot;F5a5#&quot;F5vsa9#&quot;F5ghhjkuu867885a7#&quot;FYIYUHUI5ki  a7#&quot;FUIO5 a9997#&quot;F5Stra#&quot;5gia-5.558dft.8.8.a60-6.05hu-h-0yuua-.885rla-5.55yuti-..uioa-.885!a-5.55END | Sofia, 32 Rakovski Str |


# Problem 21 – IT Village

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/38.JPG)

Every Friday night a group of super cool programmers get together and play their favorite board game – &quot;IT Village&quot;. But they are so tired of coding through the week they forget the rules of the game all the time. Also, they find it very difficult to work with paper and roll the dice so they made a very important decision – their game needed to evolve from a board game into a computer game. It is a well-known fact that programmers are lazy. They started programming the game, but they stopped. Your task is to finish the game for them.

You are given a **game board** which is **4 fields high** and **4 fields wide**. You can play **only on the game fields** (the first and the last row, as well as the first and the last column). All **other fields** are always **empty** and you cannot play on them. You **start** the game on an **entering position** (on one of the game fields) and you **roll the dice**. You move on the game fields **clockwise**. You have the following **types of fields** :

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/39.JPG)

You **start**** the game **with** 50 coins **. For every** inn you own **, you gain** 20 coins per inn per move **. When you** skip moves **because of a** storm **you** do not get paid **for inns. The** coins for inns **are added to your money in the** beginning of every move**(from the**next** one you bought the inn).

The **game ends** in the following cases:

![](https://github.com/sevdalin/C-sharp-Web-Developer/blob/master/C%23%20Advanced/Exams/images/40.JPG)

**Note:**** {0} **is how much** coins you have **when the** game ends**.

### Input

The input will be read from the console. The **game board** will be received as a string on the first line. The **entering position** will be received on the second line **.** The numbers on **the dice** for each move will be received on the third line.

### Output

The output consists of a **paragraph** , containing **one of the messages** in the **&#39;Output&#39; column** in the table above.

### Constraints

- The **game board** will always be 4 fields wide and 4 fields high. The **string** for the game board **contains** the letter combinations: **P, I, F, S, V, N,** r **0**. The letter **N is optional**. All the other letters will always be on the game board. The **letter combinations** are separated by a **space**. The **rows** are separated by a **&#39; | &#39;**.
- The **entering position** will consist of **two numbers** , separated by a **space**. The first number is the row number, the second – the column number. For example **&#39;3 4&#39;** means that the entering position is **row 3** , **column 4 (indexing starts from 1).**
- The **dice numbers** are received as a **string of numbers from 2 to 12** , separated by a **space**.

### Examples

| **Input** | **Output** |
| --- | --- |
| P I F S \| P 0 0 F \| N 0 0 V \| I F F I <br/> 2 1 <br/> 5 11 9 8 6 8 4 | &lt;p&gt;You lost! No more moves! You have 500 coins!&lt;p&gt; |
| **Comment** |
| You start on row 2, column 1 – &quot;P&quot;. First move is 5 – you go to &quot;F&quot; – you are paid 20 coins, you have 70 coins now. Second move is 11 – you go to &quot;S&quot; – you miss the next two moves – 9 and 8. Fifth move is 6 – you go to &quot;I&quot; – you have less than 100 coins so you pay 10 coins to sleep, you have 60 coins now. Sixth move is 8 – you go to &quot;V&quot; – Super Vlado multiplies your coins by 10 – you have 600 coins now. Seventh move is 4 – you go to &quot;I&quot; – you have enough coins so you buy it – you have 500 coins now. You have no more moves and you didn&#39;t buy all the inns, so the output is as shown above on the right. |
