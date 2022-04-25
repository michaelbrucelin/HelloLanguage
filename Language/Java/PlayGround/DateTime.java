import java.time.LocalDate;
import java.time.LocalTime;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

public class DateTime {
    public static void main(String[] args) {
        LocalDate myDate = LocalDate.now();
        System.out.println(myDate);

        LocalTime myTime = LocalTime.now();
        System.out.println(myTime);

        LocalDateTime myDatetime = LocalDateTime.now();
        System.out.println(myDatetime);

        System.out.println("Before formatting: " + myDatetime);
        DateTimeFormatter myFormater = DateTimeFormatter.ofPattern("dd-MM-yyyy HH:mm:ss");
        String fmtDatetime = myDatetime.format(myFormater);
        System.out.println("After formatting: " + fmtDatetime);
    }
}

/*
javac DateTime.java
java DateTime
> 2022-04-25
> 09:53:43.105760
> 2022-04-25T09:53:43.106070
> Before formatting: 2022-04-25T09:53:43.106070
> After formatting: 25-04-2022 09:53:43
*/