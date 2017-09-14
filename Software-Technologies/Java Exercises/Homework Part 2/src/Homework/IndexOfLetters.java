package Homework;


import java.util.ArrayList;

public class IndexOfLetters {

    public void indexOfLetters(String word){
        ArrayList<Character> alphabet = new ArrayList<>();
        StringBuilder result = new StringBuilder();

        for (int i = 97; i < 123; i++){
            alphabet.add(((char) i));
        }

        for(int i = 0; i < word.length(); i++){
            if(alphabet.contains(word.charAt(i))){
                char stringResult = word.charAt(i);
                int index = alphabet.indexOf(word.charAt(i));
                result.append(stringResult + " -> " + index);
                result.append(System.getProperty("line.separator"));
            }
        }
        System.out.print(result.toString());
    }
}
