<Query Kind="Statements" />


DateTime time1 = Convert.ToDateTime("1900-01-01 12:20:00");
DateTime time2 = Convert.ToDateTime("1900-01-01 13:32:00");

(time2 - time1).Minutes.Dump(".Minutes");            // 12
(time2 - time1).TotalMinutes.Dump(".TotalMinutes");  // 72
