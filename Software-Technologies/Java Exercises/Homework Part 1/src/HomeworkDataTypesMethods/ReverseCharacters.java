package HomeworkDataTypesMethods;


public class ReverseCharacters {

    public void reverse (String input) {

        StringBuilder result = new StringBuilder();
        char allChars[] = input.toCharArray();
        for (int i = allChars.length - 1; i >= 0; i--) {
            result.append(allChars[i]);
        }

        System.out.println(result.toString());
    }
}
