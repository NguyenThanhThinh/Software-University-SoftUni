package HomeworkDataTypesMethods;


public class IntegerToHexAndBinary {

    public void printHexAndBinary(String decimalNum) {

        System.out.println(Integer.toHexString(Integer.parseInt(decimalNum)));
        System.out.println(Integer.toBinaryString(Integer.parseInt(decimalNum)));
    }
}
