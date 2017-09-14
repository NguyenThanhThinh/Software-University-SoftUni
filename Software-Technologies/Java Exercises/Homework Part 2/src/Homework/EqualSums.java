package Homework;


import java.util.ArrayList;
import java.util.Scanner;

public class EqualSums {

    public void equalSums(){

        Scanner input = new Scanner(System.in);
        ArrayList<Integer> nums = new ArrayList<Integer>();

        boolean repeat = true;
        while (repeat) {
            System.out.print("Enter a bunch of integers seperated by space and see if we have the requested condition, or 'q' to quit: ");
            String line = input.nextLine();
            if (line.equals("q"))
                repeat = false;
            else {
                String[] numbers = line.split("\\s+");
                for (String num : numbers) {
                    nums.add(Integer.parseInt(num));
                }
                checkCondition(nums);
                nums.clear();
            }
        }
        input.close();
    }

    public void checkCondition(ArrayList<Integer> nums){
        if (nums.size() == 1){
            System.out.println(0);
        }

        if (nums.size() == 2 ){
            if (nums.get(1) == 0){
                System.out.println("0");
            }
            else {
                System.out.println("no");
            }
            return;
        }

        for(int i = 1; i < nums.size() - 1; i++){
            int leftSum = 0;
            int rightSum = 0;
            for(int p = 0; p < i; p++){
                leftSum += nums.get(p);
            }
            for(int x = i + 1; x < nums.size(); x++){
                rightSum += nums.get(x);
            }

            if (leftSum == rightSum){
                System.out.println(i);
                break;
            }
            else {
                System.out.println("no");
            }
        }
    }
}
