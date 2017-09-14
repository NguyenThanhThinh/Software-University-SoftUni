package StringsMapsStreamAPI;


import java.util.*;

public class Phonebook {

    public void phonebook() {
        Map<String, String> phonebook = new HashMap<>();

        boolean play = true;
        Scanner scanner = new Scanner(System.in);
        String[] input = new String[3];
        String name = "";
        String number = "";
        String command = "";

        while (play) {
            System.out.print("Please write your command: ");
            input = scanner.nextLine().split("\\s");
            command = input[0];

            if (command.equals("A")){
                name = input[1];
                number = input[2];
                phonebook.containsKey(name);
                phonebook.put(name, number);
            }
            else if (command.equals("S")){
                name = input[1];
                if (!phonebook.containsKey(name)){
                    System.out.printf("Contact %s does not exist. %n", name);
                }
                else {
                    System.out.printf("%s -> %s %n", name, phonebook.get(name));
                }
            }
            else if (command.equals("END")){
                play = false;
                break;
            }
        }
        scanner.close();
    }
}
