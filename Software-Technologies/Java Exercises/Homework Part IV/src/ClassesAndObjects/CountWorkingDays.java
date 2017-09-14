package ClassesAndObjects;


import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.time.Duration;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Date;
import java.util.Locale;
import java.util.Scanner;
import java.lang.Object;


public class CountWorkingDays {


    public void countDays(){
        Scanner scanner = new Scanner(System.in);
        System.out.print("Write your first date: ");

        String string = scanner.nextLine();
        DateTimeFormatter formatter = DateTimeFormatter.ofPattern("dd-MM-yyyy", Locale.ENGLISH);
        LocalDate firstDate = LocalDate.parse(string, formatter);
        System.out.println(firstDate);

        System.out.print("Write your second date: ");
        string = scanner.nextLine();
        LocalDate secondDate = LocalDate.parse(string, formatter);

        //LocalDate[] holidays = new LocalDate[11];
        Duration daysBetweenTwoDates = Duration.between(firstDate, secondDate);
        Days.daysBetween(firstDate.toLocalDate(), secondDate.toLocalDate()).getDays()
        for(int i = 0; i < daysBetweenTwoDates.toDays(); i++){
            System.out.println(firstDate.getDayOfWeek());
        }
    }
}
