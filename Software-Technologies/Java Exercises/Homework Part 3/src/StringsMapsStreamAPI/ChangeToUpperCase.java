package StringsMapsStreamAPI;


import com.sun.org.apache.xerces.internal.impl.xpath.regex.Match;
import org.omg.PortableInterceptor.SYSTEM_EXCEPTION;

import java.util.Scanner;
import java.util.regex.*;

public class ChangeToUpperCase {

    public void toUpper() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter your text: ");
        String text = scanner.nextLine();
        scanner.close();

        Pattern p = Pattern.compile("(?<=<upcase>)(.*?)(?=</upcase>)");
        Matcher highlightedText = p.matcher(text);

        StringBuffer s = new StringBuffer();

        while (highlightedText.find()){
            highlightedText.appendReplacement(s, String.valueOf(highlightedText.group().toUpperCase()));

        }
        highlightedText.appendTail(s);
        System.out.println(s.toString());
    }
}
