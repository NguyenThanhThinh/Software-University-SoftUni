package StringsMapsStreamAPI;


import java.util.Collections;
import java.util.Scanner;

public class CensorEmailAddress {

    public void censorEmail(){

        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter you email: ");
        String email = scanner.nextLine();
        System.out.print("Enter your text: ");
        String text = scanner.nextLine();
        scanner.close();

        String[] split = email.split("@");
        String username = split[0];
        String hiddenUsername = String.join("", Collections.nCopies(username.length(), "*"));
        String domain = split[1];

        String output = text.replaceAll(username + "@" + domain, hiddenUsername + "@" + domain);

        System.out.print(output);
    }
}
