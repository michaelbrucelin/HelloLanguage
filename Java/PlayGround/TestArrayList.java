package Java.PlayGround;
import java.util.ArrayList;

public class TestArrayList {
    public static void main(String[] args) {
        ArrayList<String> sites = new ArrayList<String>();
        sites.add("Microsoft");
        sites.add("Google");
        sites.add("HuaWei");
        sites.add("Alibaba");
        System.out.println(sites);

        String[] sitesArr = sites.toArray(new String[0]);
        for(int i = 0; i < sitesArr.length; i++){
            System.out.println(sitesArr[i]);
        }
    }
}