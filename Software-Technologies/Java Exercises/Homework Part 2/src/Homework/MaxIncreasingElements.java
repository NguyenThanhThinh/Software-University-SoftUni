package Homework;


public class MaxIncreasingElements {

    public void maxElements(int array[]){
        StringBuilder result = new StringBuilder();
        StringBuilder resultBackup = new StringBuilder();

        for(int i = 0; i < array.length - 1; i++){
            if(array[i] < array[i + 1]) {
                result.append(Integer.toString(array[i]));
                result.append(" ");

                if(i + 1 == array.length - 1){
                    result.append(Integer.toString(array[i + 1]));
                }
            }
            else {
                result.append(Integer.toString(array[i]));
                resultBackup = compareStringBuilders(result, resultBackup);
            }
        }

        resultBackup = compareStringBuilders(result, resultBackup);

        System.out.println(resultBackup.toString());
    }

    public StringBuilder compareStringBuilders(StringBuilder result, StringBuilder resultBackup){
        if (resultBackup.length() < result.length()) {
            resultBackup.setLength(0);
            resultBackup.append(result);
        }
        result.setLength(0);
        return  resultBackup;
    }
}
