package HomeworkDataTypesMethods;


public class VowerOrDigit {

    boolean tryParseInt(String value) {
        try {
            Integer.parseInt(value);
            return true;
        } catch (NumberFormatException e) {
            return false;
        }
    }

    public void vowerOrDigit(String input) {
        int digit = 0;

        if(tryParseInt(input)) {
            System.out.println("digit");
        }
        else {
            switch (input.toLowerCase()){
                case "a":
                    System.out.println("vowel");
                    break;
                case "e":
                    System.out.println("vowel");
                    break;
                case "i":
                    System.out.println("vowel");
                    break;
                case "o":
                    System.out.println("vowel");
                    break;
                default:
                    System.out.println("other");
                    break;
            }
        }
    }
}
