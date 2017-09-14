package StringsMapsStreamAPI;


import java.util.Scanner;

public class UrlParser {
        public String protocol = "";
        public String server = "";
        public String resource = "";

        public void parser(){
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter URL address: ");
        String input = scanner.nextLine();

        String[] splitProtocol = input.split("://");

        if (splitProtocol.length == 1){
            splitServerAndResourse(splitProtocol[0]);
        }
        else {
            protocol = splitProtocol[0];
            splitServerAndResourse(splitProtocol[1]);
        }

        System.out.printf("[protocol] = \"%s\" %n", protocol.trim());
        System.out.printf("[server] = \"%s\" %n", server.trim());
        System.out.printf("[resource] = \"%s\" %n", resource.replaceAll(" /", ""));

    }

    public void splitServerAndResourse(String serverAndResource){
        String[] splitServerAndResourse = serverAndResource.split("/");

        if (splitServerAndResourse.length == 1){
            server = splitServerAndResourse[0];
        }
        else {
            server = splitServerAndResourse[0];
            for(int i = 1; i < splitServerAndResourse.length; i++){
                resource += splitServerAndResourse[i] + "/";
            }
        }
    }
}
