package Homework;


import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;

public class MostFriquentNumber {

    public void mostFriqentNumber(int array[]) {
        ArrayList<Integer> arrayList = new ArrayList<Integer>();

        for(int i = 0; i < array.length; i++){
            arrayList.add(array[i]);
        }

        int counter = 1;
        int backup = 0;
        int num = 0;

        for(int p = 0; p < arrayList.size(); p++) {
            for(int i = 1; i < arrayList.size(); i++){
                if (arrayList.get(p) == arrayList.get(i)) {
                    counter++;
                }
            }
            if(backup < counter) {
                num = arrayList.get(p);
                backup = counter;
            }
            counter = 1;
            arrayList.removeAll(Collections.singleton(arrayList.get(p)));
        }

        System.out.printf("The number %d is the most frequent (occurs %d times)", num, backup);
    }
}
