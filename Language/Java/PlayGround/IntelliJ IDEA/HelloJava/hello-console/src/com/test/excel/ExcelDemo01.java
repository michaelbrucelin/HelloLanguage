package com.test.excel;

import org.apache.poi.ss.usermodel.Cell;
import org.apache.poi.ss.usermodel.Row;
import org.apache.poi.xssf.usermodel.XSSFSheet;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;

/**
 * 需要导入包：apache.poi与apache.poi.ooxml
 * <p>
 * https://www.codejava.net/coding/how-to-write-excel-files-in-java-using-apache-poi
 * Excel 2003: HSSFWorkbook, HSSFSheet, HSSFRow, HSSFCell, etc.
 * Excel 2007: XSSFWorkbook, XSSFSheet, XSSFRow, XSSFCell, etc.
 * <p>
 * Here are the basic steps for writing an Excel file:
 * 1. Create a Workbook.
 * 2. Create a Sheet.
 * 3. Repeat the following steps until all data is processed:
 * a. Create a Row.
 * b. Create Cellsin a Row. Apply formatting using CellStyle.
 * 4. Write to an OutputStream.
 * 5. Close the output stream.
 */

/// A Simple Example to create an Excel file in Java
public class ExcelDemo01 {
    public static void main(String[] args) throws IOException {
        XSSFWorkbook workbook = new XSSFWorkbook();
        XSSFSheet sheet = workbook.createSheet("Java Books");

        Object[][] bookData = {
                {"Head First Java", "Kathy Serria", 79},
                {"Effective Java", "Joshua Bloch", 36},
                {"Clean Code", "Robert martin", 42},
                {"Thinking in Java", "Bruce Eckel", 35}
        };

        int rowCount = 0;
        for (Object[] aBook : bookData) {
            Row row = sheet.createRow(++rowCount);
            int columnCount = 0;
            for (Object field : aBook) {
                Cell cell = row.createCell(++columnCount);
                if (field instanceof String) {
                    cell.setCellValue((String) field);
                } else if (field instanceof Integer) {
                    cell.setCellValue((Integer) field);
                }
            }
        }

        String filePath = new File("").getAbsolutePath();
        try (FileOutputStream outputStream = new FileOutputStream(filePath + "/hello-console/src/com/test/resources/JavaBooks.xlsx")) {
            workbook.write(outputStream);
        }
    }
}
