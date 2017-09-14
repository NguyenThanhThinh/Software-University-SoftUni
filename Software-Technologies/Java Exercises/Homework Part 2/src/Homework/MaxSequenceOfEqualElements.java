package Homework;


import java.util.Collections;

public class MaxSequenceOfEqualElements {

    public void MaxSequence(int array[]) {
        int lenght = 1;
        int bestLenght = 0;
        int bestNum = 0;

        for(int i = 0; i < array.length - 1; i++){
            if(array[i] == array[i + 1]) {
                lenght++;
            }
            else {
                if (bestLenght < lenght) {
                    bestLenght = lenght;
                    bestNum = array[i];
                }
                lenght = 1;
            }
        }

        StringBuilder result = new StringBuilder();

        for(int i = 0; i < bestLenght; i++) {
            result.append(Integer.toString(bestNum));
            result.append(" ");
        }

        System.out.println(result.toString());
    }
}
