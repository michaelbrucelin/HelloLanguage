import java.time.*;
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
        DateTimeFormatter myFormater = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");
        String fmtDatetime = myDatetime.format(myFormater);
        System.out.println("After formatting: " + fmtDatetime);

        ZonedDateTime myZonedDatetime = ZonedDateTime.now();
        System.out.println(myZonedDatetime);
        System.out.println(myZonedDatetime.getZone());
        System.out.println(myZonedDatetime.getOffset());

        System.out.println(myZonedDatetime.withZoneSameInstant(ZoneId.of("GMT+00:00")));
        System.out.println(myZonedDatetime.withZoneSameInstant(ZoneId.of("GMT+00:00")).format(myFormater));
    }
}

/*
javac DateTime.java
java DateTime
> 2022-04-26
> 16:10:18.335375700
> 2022-04-26T16:10:18.335375700
> Before formatting: 2022-04-26T16:10:18.335375700
> After formatting: 2022-04-26 16:10:18
> 2022-04-26T16:10:18.343375700+08:00[Asia/Shanghai]
> Asia/Shanghai
> +08:00
> 2022-04-26T08:10:18.343375700Z[GMT]
> 2022-04-26 08:10:18
*/