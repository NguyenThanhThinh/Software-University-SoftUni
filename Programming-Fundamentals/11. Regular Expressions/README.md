# <p align="center"> Exercises: Regular Expressions (RegEx) <p>


### 1. Extract emails

Write a program to **extract all email addresses from a given text**. The text comes at the only input line. Print the emails on the console, each at a separate line. Emails are considered to be in format **&lt;user&gt;@&lt;host&gt;** , where:

- **&lt;user&gt;** is a sequence of letters and digits, where &#39; **.**&#39;, &#39; **-**&#39; and &#39; **\_**&#39; can appear between them. Examples of valid users: &quot; **stephan**&quot;, &quot; **mike03**&quot;, &quot; **s.johnson**&quot;, &quot; **st\_steward**&quot;, &quot; **softuni-bulgaria**&quot;, &quot; **12345**&quot;. Examples of invalid users: &#39;&#39; **--123**&quot;, &quot;.....&quot;, &quot; **nakov\_-**&quot;, &quot; **\_steve**&quot;, &quot; **.info**&quot;.
- **&lt;host&gt;** is a sequence of at least two words, separated by dots &#39; **.**&#39;. Each word is sequence of letters and can have hyphens &#39; **-**&#39; between the letters. Examples of hosts: &quot; **softuni.bg**&quot;, &quot; **software-university.com**&quot;, &quot; **intoprogramming.info**&quot;, &quot; **mail.softuni.org**&quot;. Examples of invalid hosts: &quot; **helloworld**&quot;, &quot; **.unknown.soft.**&quot;, &quot; **invalid-host-**&quot;, &quot; **invalid-**&quot;.
- Examples of **valid emails** : info@softuni-bulgaria.org, kiki@hotmail.co.uk, no-reply@github.com, s.peterson@mail.uu.net, [info-bg@software-university.software.academy](mailto:info-bg@software-university.software.academy).
- Examples of **invalid emails** : [--123@gmail.com](mailto:--123@gmail.com), …@mail.bg, [.info@info.info](mailto:.info@info.info), [\_steve@yahoo.cn](mailto:_steve@yahoo.cn), mike@helloworld, [mike@.unknown.soft](mailto:mike@.unknown.soft)., [johnson@invalid-](mailto:s.johnson@invalid-).

### Examples:

| **Input** | **Output** |
| --- | --- |
| Please contact us at: support@github.com. | _support@github.com_ |
| Just send email to s.miller@mit.edu and j.hopking@york.ac.uk for more information. | _s.miller@mit.edu__j.hopking@york.ac.uk_ |
| Many users @ SoftUni confuse email addresses. We @ Softuni.BG provide high-quality training @ home or @ class. –- steve.parker@softuni.de. | _steve.parker@softuni.de_ |

### 2. Extract sentences by keyword

Write a program that **extracts from a text all sentences that contain a particular word** (case-sensitive).

- Assume that the **sentences** are separated from each other by the character &quot; **.**&quot; or &quot; **!**&quot; or &quot; **?**&quot;.
- The **words** are separated one from another by a **non-letter character**.
- Notе that appearance as **substring** is different than appearance as **word**.The sentence _&quot;I am a fan of Mo_ **to** _rhead_&quot; does not contain the word &quot; **to**&quot;.It contains the substring &quot; **to**&quot; which is not what we need.
- Print the result **sentence**** text**without the separators between the sentences (&quot;.&quot; or &quot;!&quot; or &quot;?&quot;).

### Example

| **Input** |
| --- |
| **to** |
| Welcome **to** SoftUni! You will learn programming, algorithms, problem solving and software technologies. You need **to** allocate for study 20-30 hours weekly. Good luck! I am fan of Motorhead. To be or not **to** be - that is the question. TO DO OR NOT? |
| **Output** |
| Welcome **to** SoftUniYou need **to** allocate for study 20-30 hours weeklyTo be or not **to** be - that is the question |

### 3. \*Valid Usernames

**This problem is from the Java Basics Exam (21 September 2014 Evening). You may check your solution** [**here**](https://judge.softuni.bg/Contests/Practice/Index/34#2) **.**

You are part of the back-end development team of the next Facebook. You are given **a line of usernames** , between one of the following symbols: space, &quot;/&quot; , &quot;\\&quot; , &quot;(&quot; , &quot;)&quot; . First you have to export all **valid** usernames. A valid username **starts with a letter** and can contain **only letters, digits and &quot;\_&quot;**. It cannot be **less than 3 or more than 25 symbols** long. Your task is to **sum** the length of **every**** 2 consecutive ****valid** usernames and print on the console the 2 valid usernames with **biggest**** sum **of their** lengths,** each on a separate line.

### Input

The input comes from the console. One line will hold all the data. It will hold **usernames,** divided by the symbols: **space, &quot;/&quot;, &quot;\\&quot;, &quot;(&quot;, &quot;)&quot;.**

The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

Print at the console the 2 **consecutive**** valid usernames **with the** biggest ****sum** of their lengths each on a separate line. If there are **2 or more couples** of usernames with the same sum of their lengths, print he **left most**.

### Constraints

- The input line will hold characters in the range [0 … 9999].
- The usernames should **start with a letter** and can contain **only letters, digits and &quot;\_&quot;**.
- The username cannot be **less than 3 or**** more than 25 symbols** long.
- Time limit: 0.5 sec. Memory limit: 16 MB.

### Examples

| **Input** | **Output** |
| --- | --- |
| ds3bhj y1ter/wfsdg 1nh\_jgf ds2c\_vbg\4htref | wfsdg |
| | ds2c\_vbg |

| **Input** | **Output** |
| --- | --- |
| min23/ace hahah21 (    sasa  )  att3454/a/a2/abc | hahah21 |
| | sasa |

| **Input** | **Output** |
| --- | --- |
| chico/ gosho \ sapunerka (3sas) mazut  lelQ\_Van4e | mazut |
| | lelQ\_Van4e |

### 4. \*Query Mess

**This problem is originally from the JavaScript Basics Exam (22 November 2014). You may check your solution** [**here**](https://judge.softuni.bg/Contests/Practice/Index/84#3) **.**

**Ivancho** participates in a team **project** with colleagues at **SoftUni**.  They have to develop **an application** , but something _mysterious_ happened – at the last moment all team members… disappeared!  And guess what? He is left **alone** to finish the project.  All that is left to do is to parse the input data and store it in a special way, but Ivancho has no idea how to do that! Can you help him?

### Input

The input comes from the console on a variable number of lines and ends when the keyword &quot;END&quot; is received.

For each row of the input, the query string contains pairs field=value. Within each pair, the field name and value are separated by an equals sign, &#39;=&#39;. The series of pairs are separated by an ampersand, &#39;&amp;&#39;. The question mark is used as a separator and is not part of the query string. A URL query string may contain another URL as value. The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

**For each input line, print** on the console a line containing the **processed string as follows** :  key=[value]nextkey=[another  value] … etc.

**Multiple whitespace** characters should be reduced to one inside value/key names, but there shouldn&#39;t be any whitespaces before/after extracted **keys** and **values**. If a key **already exists** , the value is added with comma and space after other values of the existing key in the current string.  See the **examples** below.

### Constraints

- SPACE is encoded as &#39;+&#39; or &quot;%20&quot;.Letters (A-Z and a-z), numbers (0-9), the characters &#39;\*&#39;, &#39;-&#39;, &#39;.&#39;, &#39;\_&#39; and _other non-special symbols_ are left as-is.
- Allowed working time: 0.1 seconds. Allowed memory: 16 MB.

### Examples

| **Input** | **Output** |
| --- | --- |
| login=student&password=student | login=[student]password=[student] |
| END |

| **Input** |
| --- |
| field=value1&field=value2&field=value3 |
| http://example.com/over/there?name=ferret |
| END |
| **Output** |
| --- |
| field=[value1, value2, value3] |
| name=[ferret] |

| **Input** |
| --- |
| foo=%20foo&value=+val&foo+=5+%20+203 |
| foo=poo%20&value=valley&dog=wow+ |
| url=https://softuni.bg/trainings/coursesinstances/details/1070 |
| https://softuni.bg/trainings.asp?trainer=nakov&course=oop&course=php |
| END |

| **Output** |
| --- |
| foo=[foo, 5 203]value=[val] |
| foo=[poo]value=[valley]dog=[wow] |
| url=[https://softuni.bg/trainings/coursesinstances/details/1070] |
| trainer=[nakov]course=[oop, php] |


### 5. \*Use Your Chains, Buddy

![](https://github.com/sevdalin/Programming-Fundamentals/blob/master/11.%20Regular%20Expressions/Images/5.JPG)

### Input

The input is read from the console and consists of just one line – the **string** with the **HTML document**.

The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

**Print** on a single line the decrypted text of the manual. See the given **examples** below.

### Constraints

- Allowed working time: 0.2 seconds. Allowed memory: 16 MB.

### Examples

| **Input** |
| --- |
| &lt;html&gt;&lt;head&gt;&lt;title&gt;&lt;/title&gt;&lt;/head&gt;&lt;body&gt;&lt;h1&gt;hello&lt;/h1&gt;&lt;p&gt; **znahny!@#%&amp;&amp;&amp;&amp;\*\*\*\*** &lt;/p&gt;&lt;div&gt;&lt;button&gt;dsad&lt;/button&gt;&lt;/div&gt;&lt;p&gt;**grkg^^^^%%%)))([]12**&lt;/p&gt;&lt;/body&gt;&lt;/html&gt; |
| **Output** |
| manual text 12 |
|   |
| **Input** |
| &lt;html&gt;&lt;head&gt;&lt;title&gt;&lt;/title&gt;&lt;/head&gt;&lt;body&gt;&lt;h1&gt;Intro&lt;/h1&gt;&lt;ul&gt;&lt;li&gt;Item01&lt;/li&gt;&lt;li&gt;Item02&lt;/li&gt;&lt;li&gt;Item03&lt;/li&gt;&lt;/ul&gt;&lt;p&gt; **jura qevivat va jrg fyvccrel fabjl** &lt;/p&gt;&lt;div&gt;&lt;button&gt;Click me, baby!&lt;/button&gt;&lt;/div&gt;&lt;p&gt; **pbaqvgvbaf fabj  qpunvaf ner no**** fbyhgryl rffragvny sbe fnsr unaqyvat nygubhtu fabj punvaf znl ybbx **&lt;/p&gt;&lt;span&gt;This manual is false, do not trust it! The illuminati wrote it down to trick you!&lt;/span&gt;&lt;p&gt;** vagvzvqngvat gur onfvp vqrn vf ernyyl fvzcyr svg gurz bire lbhe gverf qevir sbejneq fybjyl naq gvtugra gurz hc va pbyq jrg **&lt;/p&gt;&lt;p&gt;** pbaqvgvbaf guvf vf rnfvre fnvq guna qbar ohg vs lbh chg ba lbhe gverf**&lt;/p&gt;&lt;/body&gt; |
| **Output** |
| when driving in wet slippery snowy conditions snow dchains are absolutely essential for safe handling although snow chains may look intimidating the basic idea is really simple fit them over your tires drive forward slowly and tighten them up in cold wet conditions this is easier said than done but if you put on your tires |
