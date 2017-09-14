package StringsMapsStreamAPI;


import java.util.ArrayList;
import java.util.Scanner;

public class ReverseString {

    public void reverseString(){
        Scanner scanner = new Scanner(System.in);
        String input = "";
        System.out.print("Enter some word: ");
        input = scanner.next();
        scanner.close();

        StringBuilder result = new StringBuilder();

        for(int i = input.length() - 1; i >= 0; i--){
            result.append(input.charAt(i));
        }

        System.out.printf("The reversed word is: %s", result.toString());
    }
}
