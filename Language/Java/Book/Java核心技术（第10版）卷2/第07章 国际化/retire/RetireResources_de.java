package retire;

import java.awt.*;

/**
 * These are the German non-string resources for the retirement calculator.
 */
public class RetireResources_de extends java.util.ListResourceBundle {
    private static final Object[][] contents = {
            // BEGIN LOCALIZE
            { "colorPre", Color.yellow }, { "colorGain", Color.black }, { "colorLoss", Color.red }
            // END LOCALIZE
    };

    public Object[][] getContents() {
        return contents;
    }
}
