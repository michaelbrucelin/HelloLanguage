package com.itheima.day24_xml_app.d1_dom4j;

import org.dom4j.Document;
import org.dom4j.Element;
import org.dom4j.io.SAXReader;
import org.junit.Test;

import java.util.ArrayList;
import java.util.List;

public class Dom4JTest2 {
    @Test
    public void parseToList() throws Exception {
        // 需求：解析XML中的数据成为一个List集合对象。
        // 1、导入框架（做过）
        // 2、创建SaxReader对象
        SAXReader saxReader = new SAXReader();
        // 3、加载XML文件成为文档对象Document对象。
        Document document =
                saxReader.read(Dom4JTest2.class.getResourceAsStream("/Contacts.xml"));
        // 4、先拿根元素
        Element root = document.getRootElement();
        // 5、提取contact子元素
        List<Element> contactEles = root.elements("contact");
        // 6、准备一个ArrayList集合封装联系人信息
        List<Contact> contacts = new ArrayList<>();
        // 7、遍历Contact子元素
        for (Element contactEle : contactEles) {
            // 8、每个子元素都是一个联系人对象
            Contact contact = new Contact();
            contact.setId(Integer.valueOf(contactEle.attributeValue("id")));
            contact.setVip(Boolean.valueOf(contactEle.attributeValue("vip")));
            contact.setName(contactEle.elementTextTrim("name"));
            contact.setGender(contactEle.elementTextTrim("gender").charAt(0));
            contact.setEmail(contactEle.elementText("email"));
            // 9、把联系人对象数据加入到List集合
            contacts.add(contact);
        }
        // 10、遍历List集合
        for (Contact contact : contacts) {
            System.out.println(contact);
        }
    }
}
