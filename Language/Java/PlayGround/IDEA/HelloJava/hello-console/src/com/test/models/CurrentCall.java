package com.test.models;

import java.util.ArrayList;

// import com.fasterxml.jackson.databind.ObjectMapper;   // version 2.11.1
// import com.fasterxml.jackson.annotation.JsonProperty; // version 2.11.1
/* ObjectMapper om = new ObjectMapper();
CurrentCall currentCall = om.readValue(myJsonString), CurrentCall.class); */
public class CurrentCall {
    public int retCode;
    public String exception;
    public ArrayList<InfoCurrentCall> infoCurrentCalls;
}

class InfoCurrentCall{
    public String callerE164;
    public String calleeE164;
    public String callerGatewayId;
    public String calleeGatewayId;
    public long connectedTime;
    public long keepTime;
    public String callCodec;
    public String callerCodec;
    public String calleeCodec;
    public String callerRtpIp;
    public String calleeRtpIp;
    public int callerReceiveDtmf;
    public int callerSendDtmf;
    public int calleeReceiveDtmf;
    public int calleeSendDtmf;
    public boolean rtpRouted;
    public InfoRtpFlow callerInfoRtpFlowAudio;
    public InfoRtpFlow calleeInfoRtpFlowAudio;
    public InfoRtpFlow callerInfoRtpFlowVideo;
    public InfoRtpFlow calleeInfoRtpFlowVideo;
    public String callerTerminal;
    public String calleeTerminal;
    public int callerCryptoType;
    public int calleeCryptoType;
    public String callerLocalIp;
    public String calleeLocalIp;
    public int callId;
}

class InfoRtpFlow{
    public int rtpPackets;
    public int rtpBytes;
    public long rtpDuration;
}
