package StringsMapsStreamAPI;


import java.util.Collections;
import java.util.Scanner;

public class FitStringInTwenyChars {


    public void fitString(String input){

        if (input.length() == 20){
            System.out.print(input);
        }
        else if (input.length() < 20){
            int counter = 20 - input.length();
            input += String.join("", Collections.nCopies(counter, "*"));
            System.out.print(input);
        }
        else {
            StringBuilder result = new StringBuilder();
            for(int i = 0; i < 20; i++){
                result.append(input.charAt(i));
            }
            System.out.print(result);
        }
    }
}
