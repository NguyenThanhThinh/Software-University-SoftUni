package Homework;


public class CompareCharArrays {

    public void compareArrays() {
        char charArrayOne[] = {'a', 'n', 'n', 'i', 'e'};
        char charArrayTwo[] = {'a', 'n'};

        String first =  String.valueOf(charArrayOne);
        String second =  String.valueOf(charArrayTwo);

        if (first.compareToIgnoreCase(second) == -1) {
            System.out.println(first);
            System.out.println(second);
        }
        else if (first.compareToIgnoreCase(second) == 1){
            System.out.println(second);
            System.out.println(first);
        }
        else {
            if (first.length() > second.length()) {
                System.out.println(second);
                System.out.println(first);
            }
            else {
                System.out.println(first);
                System.out.println(second);
            }
        }
    }

}
