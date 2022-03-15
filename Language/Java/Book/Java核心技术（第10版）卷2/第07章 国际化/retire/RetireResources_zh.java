package retire;

import java.awt.*;

/**
 * These are the Chinese non-string resources for the retirement calculator.
 */
public class RetireResources_zh extends java.util.ListResourceBundle {
    private static final Object[][] contents = {
            // BEGIN LOCALIZE
            { "colorPre", Color.red }, { "colorGain", Color.blue }, { "colorLoss", Color.yellow }
            // END LOCALIZE
    };

    public Object[][] getContents() {
        return contents;
    }
}
