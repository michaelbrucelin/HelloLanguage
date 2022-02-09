package com.test.models;

import java.util.ArrayList;

// import com.fasterxml.jackson.databind.ObjectMapper;   // version 2.11.1
// import com.fasterxml.jackson.annotation.JsonProperty; // version 2.11.1
/* ObjectMapper om = new ObjectMapper();
CurrentCallQ currentCallQ = om.readValue(myJsonString), CurrentCallQ.class); */
public class CurrentCallQ {
    public int retCode;
    public String exception;
    public ArrayList<InfoCurrentCallQ> infoCurrentCallQs;
}

class InfoCurrentCallQ{
    public String callerE164;
    public String calleeE164;
    public String callerGatewayId;
    public String calleeGatewayId;
    public long connectedTime;
    public long keepTime;
    public int callId;
}
