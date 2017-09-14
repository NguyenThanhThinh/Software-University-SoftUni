package HomeworkDataTypesMethods;

public class BooleanVariable {

    public void booleanMethod (String input) {

        boolean trueOrFalse = Boolean.parseBoolean(input);

        if (trueOrFalse) {
            System.out.print("Yes");
        }
        else {
            System.out.println("No");
        }
    }
}
