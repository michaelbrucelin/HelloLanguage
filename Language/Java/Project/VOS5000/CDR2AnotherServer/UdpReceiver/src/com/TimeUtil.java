package com;

import java.io.InputStream;
import java.net.Socket;
import java.text.DateFormat;
import java.text.Format;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;
import java.util.List;
import java.util.Locale;
import java.util.TimeZone;
import java.util.Vector;

/**
 * ��������ʱ�䴦��Ĺ�����
 * 
 */
public final class TimeUtil {
	public static final int DEFAULT_PORT = 37;// NTP服务器端口

	public static final String DEFAULT_HOST = "time-nw.nist.gov";// NTP服务器地址

	private TimeUtil() {

	}

	public static long currentTimeMillis(Boolean sync) {

		if (sync != null && sync.booleanValue() != true)

			return System.currentTimeMillis();

		try {

			return syncCurrentTime();

		} catch (Exception e) {

			return System.currentTimeMillis();

		}

	}

	public static long syncCurrentTime() throws Exception { // 同步网络时间

		// The time protocol sets the epoch at 1900,

		// the java Date class at 1970. This number

		// converts between them.

		long differenceBetweenEpochs = 2208988800L;

		// If you'd rather not use the magic number uncomment

		// the following section which calculates it directly.

		/*
		 * 
		 * TimeZone gmt = TimeZone.getTimeZone("GMT"); Calendar epoch1900 =
		 * 
		 * Calendar.getInstance(gmt); epoch1900.set(1900, 01, 01, 00, 00, 00);
		 * 
		 * long epoch1900ms = epoch1900.getTime().getTime(); Calendar epoch1970
		 * 
		 * = Calendar.getInstance(gmt); epoch1970.set(1970, 01, 01, 00, 00, 00);
		 * 
		 * long epoch1970ms = epoch1970.getTime().getTime();
		 * 
		 * 
		 * 
		 * long differenceInMS = epoch1970ms - epoch1900ms; long
		 * 
		 * differenceBetweenEpochs = differenceInMS/1000;
		 */

		InputStream raw = null;

		try {

			Socket theSocket = new Socket(DEFAULT_HOST, DEFAULT_PORT);

			raw = theSocket.getInputStream();

			long secondsSince1900 = 0;

			for (int i = 0; i < 4; i++) {

				secondsSince1900 = (secondsSince1900 << 8) | raw.read();

			}

			if (raw != null)

				raw.close();

			long secondsSince1970 = secondsSince1900 - differenceBetweenEpochs;

			long msSince1970 = secondsSince1970 * 1000;

			return msSince1970;

		} catch (Exception e) {

			throw new Exception(e);

		}

	}

	public static String getEnglishDate(String datestr) {// 返回指定字符串的英文格式
		Locale l = new Locale("en");

		SimpleDateFormat sdf = new SimpleDateFormat("yyyyMMdd");
		Date date;
		try {
			date = sdf.parse(datestr);
			String day = String.format("%td", date);
			String month = String.format(l, "%tb", date);
			String year = String.format("%ty", date);
			System.out.println(day + " " + month + " " + year);
			return day + " " + month + " " + year;
		} catch (ParseException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			return "Ex cep tion";
		}

	}

	public static Date getZeroDateTime() {
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss.SSS");
		final TimeZone tz = TimeZone.getTimeZone("GMT+0");
		sdf.setTimeZone(tz);
		Date dt = new Date();
		return stringToFullDate(sdf.format(dt));
	}

	public static String getZeroDateTimes() {
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss.SSS");
		final TimeZone tz = TimeZone.getTimeZone("GMT+0");
		sdf.setTimeZone(tz);
		Date dt = new Date();
		return sdf.format(dt);
	}

	public static Date stringToFullDate(String dateStr) {
		DateFormat formatter = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		try {
			return formatter.parse(dateStr);
		} catch (ParseException e) {
			e.printStackTrace();
			return null;
		}
	}

	public static String getShortCurrDateTime() {
		Date date = new Date();
		Format formatter = new SimpleDateFormat("yyyyMMddHHmmss");
		return formatter.format(date);
	}

	public static String getTomorrow()// 获取明天日期
	{
		Date now = new Date();
		SimpleDateFormat dateFormat = new SimpleDateFormat("yyyyMMdd");// 可以方便地修改日期格式

		Calendar starttime1 = Calendar.getInstance();

		starttime1.setTime(now);
		starttime1.add(Calendar.DAY_OF_YEAR, 1);

		Date dt11 = starttime1.getTime();
		return dateFormat.format(dt11);
	}

	public static String getTomorrowSpecial()// 获取明天日期dd/mm/yyyy格式用于费率日期
	{
		Date now = new Date();
		SimpleDateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy");// 可以方便地修改日期格式

		Calendar starttime1 = Calendar.getInstance();

		starttime1.setTime(now);
		starttime1.add(Calendar.DAY_OF_YEAR, 1);

		Date dt11 = starttime1.getTime();
		return dateFormat.format(dt11);
	}

	/**
	 * ȡ�õ�ǰ����ʱ��
	 */
	public static String getCurrDateTime() {
		Date date = new Date();
		Format formatter = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		return formatter.format(date);
	}

	public static Date stringToDate(String dateStr) {
		DateFormat formatter = new SimpleDateFormat("YY-MM-dd");
		try {
			return formatter.parse(dateStr);
		} catch (ParseException e) {
			e.printStackTrace();
			return null;
		}
	}

	//
	// public static Date getDateForStyle(String dateStr,String style) {
	//
	// DateFormat formatter = new SimpleDateFormat(style);
	// try {
	// return formatter.parse(dateStr);
	// } catch (ParseException e) {
	// // TODO Auto-generated catch block
	// e.printStackTrace();
	// return null;
	// }
	// }

	public static Date stringToDateOne(String dateStr) {
		DateFormat formatter = new SimpleDateFormat("yyyy-MM-dd");
		try {
			return formatter.parse(dateStr);
		} catch (ParseException e) {
			e.printStackTrace();
			return null;
		}
	}

	public static Date stringToDateTwo(String dateStr) {
		DateFormat formatter = new SimpleDateFormat("MM/dd/yy");
		try {
			return formatter.parse(dateStr);
		} catch (ParseException e) {
			e.printStackTrace();
			return null;
		}
	}

	public static Date stringToDateThr(String dateStr) {
		DateFormat formatter = new SimpleDateFormat("yyyyMMdd");
		try {
			return formatter.parse(dateStr);
		} catch (ParseException e) {
			e.printStackTrace();
			return null;
		}
	}

	public static String getDateYMD(Date date) {
		Format formatter = new SimpleDateFormat("yyyy-MM-dd");
		return formatter.format(date);
	}

	public static String getDateYMDSec(Date date) {
		Format formatter = new SimpleDateFormat("yyyyMMdd");
		return formatter.format(date);
	}

	public static String getDateYMDDHS(Date date) {// 不指定时区时，默认使用的是本地时区
		Format formatter = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		return formatter.format(date);
	}

	/**
	 * ȡ�õ�ǰ����
	 */
	public static String getCurrentDate() {
		Date date = new Date();
		Format formatter = new SimpleDateFormat("yyyy-MM-dd");
		return formatter.format(date);
	}

	public static String getTodayDate() {
		Date date = new Date();
		Format formatter = new SimpleDateFormat("yyyyMMdd");
		return formatter.format(date);
	}

	/**
	 * ȡ�õ�ǰ���+�·�
	 */
	public static String getCurrentYearMonth() {
		Date date = new Date();
		Format formatter = new SimpleDateFormat("yyyy-MM");
		return formatter.format(date);
	}

	/**
	 * ȡ�õ�ǰ����
	 */
	public static String getCurrDate() {
		Date date = new Date();
		Format formatter = new SimpleDateFormat("yyyy-M-d");// /为供应商/客户信息更新
															// 文件日期修改程序
															// 2014-1-12
		return formatter.format(date);
	}

	public static String getCurrDate(Date date) {
		Format formatter = new SimpleDateFormat("yyyy-MM-dd");
		return formatter.format(date);
	}

	public static String getVOSDate(Date date) {
		Format formatter = new SimpleDateFormat("yyyyMMdd");
		return formatter.format(date);
	}

	public static String getNowDate(Date date) {
		Format formatter = new SimpleDateFormat("yyyyMMdd");
		return formatter.format(date);
	}

	/**
	 * ȡ�õ�ǰʱ��
	 */
	public static String getCurrTime() {
		Date date = new Date();
		Format formatter = new SimpleDateFormat("HH-mm-ss");
		return formatter.format(date);
	}
	public static String getCurrTimeS() {
		Date date = new Date();
		Format formatter = new SimpleDateFormat("HH-mm-ss:SSS");
		return formatter.format(date);
	}
	/**
	 * ȡ�õ�ǰ����
	 */
	public static String getCurrMonth() {
		Date date = new Date();
		Format formatter = new SimpleDateFormat("yyyy-MM-dd");
		return formatter.format(date);
	}

	/**
	 * �����µĻ��ϼ��ϻ��ȥ�·ݵõ�������
	 */
	@SuppressWarnings("deprecation")
	public static String getChangedDate(String strMonth, int monthCount) {
		SimpleDateFormat myFormatter = new SimpleDateFormat("yyyy-MM");

		try {
			java.util.Date date = myFormatter.parse(strMonth);
			date.setMonth(date.getMonth() + monthCount);

			Format formatter = new SimpleDateFormat("yyyy-MM");
			return formatter.format(date);
		} catch (Exception ex) {
			return null;
		}
	}

	public static Long convDStrToL(String nowdatetime) {
		DateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		final TimeZone tz = TimeZone.getTimeZone("GMT+0");
		sdf.setTimeZone(tz);
		try {
			Date d1 = sdf.parse(nowdatetime);
			long diff = d1.getTime();
			return diff;
		} catch (ParseException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			return null;
		}
	}

	public static Long convDStrToL(String nowdatetime, String timezone) {
		DateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		final TimeZone tz = TimeZone.getTimeZone(timezone);
		sdf.setTimeZone(tz);
		try {
			Date d1 = sdf.parse(nowdatetime);
			long diff = d1.getTime();
			return diff;
		} catch (ParseException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			return null;
		}
	}

	public static Long convDStrToLf(String nowdatetimestring) {// 将日期截串规范格式
																// 20140610000000
																// --2014-06-10
																// 00:00:00
		String nowdatetime = nowdatetimestring.substring(0, 4) + "-"
				+ nowdatetimestring.substring(4, 6) + "-"
				+ nowdatetimestring.substring(6, 8) + " "
				+ nowdatetimestring.substring(8, 10) + ":"
				+ nowdatetimestring.substring(10, 11) + ":"
				+ nowdatetimestring.substring(11, 14);
		System.out.println(nowdatetime);
		DateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		final TimeZone tz = TimeZone.getTimeZone("GMT+0");
		sdf.setTimeZone(tz);
		try {
			Date d1 = sdf.parse(nowdatetime);
			long diff = d1.getTime();
			return diff;
		} catch (ParseException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			return null;
		}
	}

	public static String convDStrToLStr(String nowdatetime) {
		DateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		final TimeZone tz = TimeZone.getTimeZone("GMT+0");
		sdf.setTimeZone(tz);
		try {
			Date d1 = sdf.parse(nowdatetime);
			long diff = d1.getTime();
			return String.valueOf(diff);
		} catch (ParseException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			return null;
		}
	}

	public static long delaytime(String nowdatetime, long switchTime) {
		DateFormat df = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");

		try {
			Date d1 = df.parse(nowdatetime);
			long diff = d1.getTime() - switchTime;
			return diff;
		} catch (ParseException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			return 0;
		}
		// //long days = diff / (1000 * 60 * 60 * 24);
		// SimpleDateFormat sdf= new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		// //前面的lSysTime是秒数，先乘1000得到毫秒数，再转为java.util.Date类型
		// Date dt = new Date(diff);
		// Date dt2 = new Date(d1.getTime());
		// String sDateTime = sdf.format(dt);
		// String sDateTime2 = sdf.format(dt2);//得到精确到秒的表示：08/31/2006 21:08:00
		// System.out.println(sDateTime);
		// System.out.println(sDateTime2);

		// System.out.print(d1.getTime());
	}

	public static String convLtoStrZero(long thelongdatetime) {
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss.SSS");
		final TimeZone tz = TimeZone.getTimeZone("GMT+0");
		sdf.setTimeZone(tz);
		Date dt = new Date(thelongdatetime);
		return sdf.format(dt);
	}

	public static String convLtoStrZeroNoTime(long thelongdatetime) {
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
		final TimeZone tz = TimeZone.getTimeZone("GMT+0");
		sdf.setTimeZone(tz);
		Date dt = new Date(thelongdatetime);
		return sdf.format(dt);
	}

	public static String convLtoStrForTimezone(long thelongdatetime,
			String timezone) {
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss.SSS");
		final TimeZone tz = TimeZone.getTimeZone(timezone);
		sdf.setTimeZone(tz);
		Date dt = new Date(thelongdatetime);
		return sdf.format(dt);
	}
	public static String convLtoStrForTimezoneD(long thelongdatetime,//获取指定格式  时区
			String timezone) {
		SimpleDateFormat sdf = new SimpleDateFormat("yyyyMMdd");
		final TimeZone tz = TimeZone.getTimeZone(timezone);
		sdf.setTimeZone(tz);
		Date dt = new Date(thelongdatetime);
		return sdf.format(dt);
	}
	public static String convLtoStrZeroNoDate(long thelongdatetime) {

		SimpleDateFormat sdf = new SimpleDateFormat("HH:mm:ss.SSS");
		final TimeZone tz = TimeZone.getTimeZone("GMT+0");
		sdf.setTimeZone(tz);
		Date dt = new Date(thelongdatetime);
		return sdf.format(dt);

	}

	public static String convLtoStrNoDate(long thelongdatetime, String timezone) {// 指定时区的只显示
																					// 时间没有日期

		SimpleDateFormat sdf = new SimpleDateFormat("HH:mm:ss.SSS");
		final TimeZone tz = TimeZone.getTimeZone(timezone);
		sdf.setTimeZone(tz);
		Date dt = new Date(thelongdatetime);
		return sdf.format(dt);

	}

	public static String convLtoStrEight(long thelongdatetime) {
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss.SSS");
		Date dt = new Date(thelongdatetime);
		return sdf.format(dt);
	}

	public static int convLtoSecond(String time) {// 将00:27:35转换为秒数
		String[] t = time.split(":");
		return Integer.parseInt(t[0]) * 3600 + Integer.parseInt(t[1]) * 60
				+ Integer.parseInt(t[3]);

	}

	/**
	 * ȡ��һ�������ж�����
	 * 
	 * @param strMonth
	 * @return
	 */
	public static int getDaysInAMonth(String strMonth) {
		String[] arr = strMonth.split("[-]");
		Calendar cal = new GregorianCalendar(Integer.parseInt(arr[0]),
				Integer.parseInt(arr[1]) - 1, 1);
		int days = cal.getActualMaximum(Calendar.DAY_OF_MONTH);
		return days;
	}

	/**
	 * ȡ��ÿ���µĵ�һ�����ܼ�
	 * 
	 * @param strMonth
	 * @return
	 */
	public static int getWeekOfFirstDay(String strMonth) {
		String[] arr = strMonth.split("[-]");

		Calendar xmas = new GregorianCalendar(Integer.parseInt(arr[0]),
				Integer.parseInt(arr[1]) - 1, 1);
		int dayOfWeek = xmas.get(Calendar.DAY_OF_WEEK) - 1;
		return dayOfWeek;
	}

	public static String getYesterday() {
		Calendar calendar = Calendar.getInstance();
		calendar.add(Calendar.DATE, -1);
		return new SimpleDateFormat("yyyyMMdd").format(calendar.getTime());

	}

	/**
	 * 取得两个日期之间的天数
	 * 
	 * @param date
	 * @throws ParseException
	 * @resin-ejb
	 * @return String
	 */

	public static String getDateDiff(String startDay, String endDay) {
		long diff = 0;
		try {
			Date date1 = new SimpleDateFormat("yyyyMMdd").parse(startDay);
			Date date2 = new SimpleDateFormat("yyyyMMdd").parse(endDay);

			diff = (date1.getTime() - date2.getTime()) / (24 * 60 * 60 * 1000) > 0 ? (date1
					.getTime() - date2.getTime()) / (24 * 60 * 60 * 1000)
					: (date2.getTime() - date1.getTime())
							/ (24 * 60 * 60 * 1000);
		} catch (ParseException e) {
		}
		return Long.toString(diff);
	}

	// 两个日期之间的间隔月数
	public static int getMonthDiff(String startDay, String endDay) {
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");

		try {
			Date dt = sdf.parse(startDay);
			Calendar calendar = Calendar.getInstance();
			calendar.setTime(dt);
			Date dt1 = sdf.parse(endDay);
			Calendar calendar2 = Calendar.getInstance();
			calendar2.setTime(dt1);

			return (calendar.get(Calendar.YEAR) - calendar2.get(Calendar.YEAR))
					* 12 + calendar.get(Calendar.MONTH)
					- calendar2.get(Calendar.MONTH);

		} catch (ParseException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			return 9999;
		}

	}

	// 两个日期之间的间隔月数
	public static int calculateMonthIn(Date date1, Date date2) {
		Calendar cal1 = new GregorianCalendar();
		cal1.setTime(date1);
		Calendar cal2 = new GregorianCalendar();
		cal2.setTime(date2);
		int c = (cal1.get(Calendar.YEAR) - cal2.get(Calendar.YEAR)) * 12
				+ cal1.get(Calendar.MONTH) - cal2.get(Calendar.MONTH);
		return c;
	}

	// 两个日期之间的间隔月数
	public static int calculateMonth(Date date1, String date2) {
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");

		try {
			Calendar cal1 = new GregorianCalendar();
			cal1.setTime(date1);
			Calendar cal2 = new GregorianCalendar();
			cal2.setTime(sdf.parse(date2));
			int c = (cal1.get(Calendar.YEAR) - cal2.get(Calendar.YEAR)) * 12
					+ cal1.get(Calendar.MONTH) - cal2.get(Calendar.MONTH);
			return c;
		} catch (ParseException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			return 9999;
		}
	}

	/**
	 * 取得两个日期之间的日期
	 * 
	 * @param String
	 * @throws ParseException
	 * @return GregorianCalendar[]
	 */
	public static GregorianCalendar[] getBetweenDate(String d1, String d2)
			throws ParseException {
		Vector<GregorianCalendar> v = new Vector<GregorianCalendar>();
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
		GregorianCalendar gc1 = new GregorianCalendar(), gc2 = new GregorianCalendar();
		gc1.setTime(sdf.parse(d1));
		gc2.setTime(sdf.parse(d2));
		do {
			GregorianCalendar gc3 = (GregorianCalendar) gc1.clone();
			v.add(gc3);
			gc1.add(Calendar.DAY_OF_MONTH, 1);
		} while (!gc1.after(gc2));
		return v.toArray(new GregorianCalendar[v.size()]);
	}

	public static List<String> getBetweenDateStr(String d1, String d2) {
		try {
			GregorianCalendar[] a = getBetweenDate(d1, d2);
			List<String> dateStr = new ArrayList<String>();
			for (int i = 0; i < a.length; i++) {
				dateStr.add(getVOSDate(a[i].getTime()));
			}
			return dateStr;
		} catch (ParseException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return null;
	}

	public static Integer getBetweenDateNum(String d1, String d2) {
		try {
			GregorianCalendar[] a = getBetweenDate(d1, d2);
			return a.length;

		} catch (ParseException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return null;
	}

	// 以某日期为准，的间隔几天的日期
	public static String getDateJiaJian(String dateStr, Integer addDay) {
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");

		try {
			Date dt = sdf.parse(dateStr);
			Calendar calendar = Calendar.getInstance();
			calendar.setTime(dt);
			calendar.add(Calendar.DAY_OF_YEAR, addDay);
			Date thedate = calendar.getTime();
			String thedateStr = sdf.format(thedate);
			return thedateStr;
		} catch (ParseException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return null;
	}

	public static String getMinuteJiaJian(String dateStr, Integer addMinute) {
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");

		try {
			Date dt = sdf.parse(dateStr);
			Calendar calendar = Calendar.getInstance();
			calendar.setTime(dt);
			calendar.add(Calendar.MINUTE, addMinute);
			Date thedate = calendar.getTime();
			String thedateStr = sdf.format(thedate);
			return thedateStr;
		} catch (ParseException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return null;
	}

	public static String timezoneGet() {//获取当前系统时区 GMT
		Calendar cal = Calendar.getInstance();
		TimeZone timeZone = cal.getTimeZone();
		// System.out.println(timeZone);
		// System.out.println(timeZone.getID());
		String zone = "";
		int va = timeZone.getRawOffset() / 3600000;

		if (va >= 0)
			zone = "GMT+" + va;
		else
			zone = "GMT-" + va;
		return zone;
		//
	}

	public static String formatTime(long ms) {// 秒数对应的分钟数 应对当前通话功能
		Integer ss = 1000;
		Integer mi = ss * 60;
		Integer hh = mi * 60;
		Integer dd = hh * 24;

		Long day = ms / dd;
		Long hour = (ms - day * dd) / hh;
		Long minute = (ms - day * dd - hour * hh) / mi;
		Long second = (ms - day * dd - hour * hh - minute * mi) / ss;
		Long milliSecond = ms - day * dd - hour * hh - minute * mi - second
				* ss;

		StringBuffer sb = new StringBuffer();
		if (day > 0) {
			sb.append(day + "天");
		}
		if (hour > 0) {
			if (hour.toString().length() > 1)
				sb.append(hour + ":");
			else {
				sb.append("0" + hour + ":");
			}
		} else {
			sb.append("00:");
		}
		if (minute > 0) {
			if (minute.toString().length() > 1)
				sb.append(minute + ":");
			else {
				sb.append("0" + minute + ":");
			}
		} else {
			sb.append("00:");
		}
		if (second > 0) {
			if (second.toString().length() > 1)
				sb.append(second + "");
			else {
				sb.append("0" + second + "");
			}
		} else {
			sb.append("00");
		}
		// if(milliSecond > 0) {
		// sb.append(milliSecond+"毫秒");
		// }
		return sb.toString();
	}

//	 public static void main(String[] args) throws ParseException {
//		 
//			String now=TimeUtil.getCurrDateTime();
//			String timezone=TimeUtil.timezoneGet();//获取时区
//			Long longtime=TimeUtil.convDStrToL(now,timezone);
//			String today=TimeUtil.convLtoStrForTimezoneD(longtime,"GMT+0");//本机时间 --0时区
//		
////	 Calendar cal = Calendar.getInstance();
////	 TimeZone timeZone = cal.getTimeZone();
////	 System.out.println(timeZone);
////	 System.out.println(timeZone.getID());
////	 System.out.println(timeZone.getRawOffset()/3600000);
////	
////	 SimpleDateFormat dateFormat = new SimpleDateFormat("Z",Locale.CHINA);
////	 System.out.println( dateFormat);
//	 }
	// public static void main(String[] args) throws ParseException {
	// try {
	// SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
	// Date dt = sdf.parse( "2013-09-02");
	// System.out.println( getMonthDiff("2014-01-01", "2013-9-02"));
	// System.out.println(calculateMonthIn(new Date(),dt));
	// GregorianCalendar[] a=getBetweenDate("2012年10月05日","2012年10月25日");
	// for(int i=0;i<a.length;i++){
	// System.out.println(getCurrDate(a[i].getTime()));
	// }
	// } catch (ParseException e) {
	// // TODO Auto-generated catch block
	// e.printStackTrace();
	// }
	// System.out.println(getDateJiaJian("2012-01-16",20));

	// String value=TimeUtil.getDateYMD(TimeUtil.stringToDateTwo("1/7/12"));
	// System.out.println(value);
	// stringToDate("2012-11-25");
	// Date date = stringToDateTwo("25-11-2012");
	// String s = getDateYMD(TimeUtil.stringToDateTwo("12-28-12"));
	// //Date date2 = stringToDate("2012-11-25");
	// SimpleDateFormat sdf=new SimpleDateFormat("yyyyMMdd");
	// String str="20110823";
	// Date dt=sdf.parse(str);
	// Calendar rightNow = Calendar.getInstance();
	// rightNow.setTime(dt);
	// //rightNow.add(Calendar.YEAR,-1);//日期减1年
	// //rightNow.add(Calendar.MONTH,3);//日期加3个月
	// rightNow.add(Calendar.DAY_OF_YEAR,10);//日期加10天
	// Date dt1=rightNow.getTime();
	// String reStr = sdf.format(dt1);
	// System.out.println(reStr);
	// System.out.println(s);
	// System.out.println("1111");
	// System.out.println(date2);
	// try {
	// List<String> ss = getBetweenDateStr("20130405","20130425");
	// for(String temp:ss){
	// System.out.println("e_cdr_"+temp);
	// }
	// } catch (Exception e) {
	// // TODO Auto-generated catch block
	// e.printStackTrace();
	// }
	// int a=20*60*1000;
	// System.out.print(a);
	// short pdd = (short)(1476331171 & 0xFFFF);
	// double s = pdd > 30000 ? (pdd - 30000.0) : pdd / 1000.0;
	// System.out.println( s);
	// System.out.println( convLtoStrZero(Long.parseLong("2158927")));
	// System.out.println(convLtoStrZero( Long.parseLong("1399842429733")));
	// System.out.println(
	// convLtoStrForTimezone(convDStrToL("2014-05-20 07:00:00"),"GMT+4") );
	// System.out.println( getMinuteJiaJian("2014-05-20 07:05:00" ,5) );
	// List<String> list =
	// getBetweenDateStr("2014-05-20 07:05:00","2014-05-24 07:05:00");
	// for(int i=0;i<list.size();i++){
	// System.out.println( list.get(i));
	// }
	// System.out.println( convDStrToLStr("2014-06-02 07:00:00")) ;
	// System.out.println( convDStrToLStr("2014-06-02 24:00:00")) ;
	// String theNowDateTime = TimeUtil.getCurrDateTime();
	// // long theStartTime = TimeUtil.delaytime(theNowDateTime, 1200000);
	// long theEndTime = TimeUtil.convDStrToL(theNowDateTime,"GMT+8");
	// System.out.println( theEndTime) ;
	// System.out.println(getTomorrowSpecial());
	// System.out.println( convDStrToLStr("2014-06-02 07:00:00")) ;
	// System.out.println(convLtoStr(
	// delaytime("2013-08-27 08:00:12.752",Long.parseLong("3600000"))));
	// }

}