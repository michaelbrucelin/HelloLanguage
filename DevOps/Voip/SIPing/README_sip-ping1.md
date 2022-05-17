# SIP Ping

### A Utility for Pinpoint VoIP Diagnostics

## Purpose

SIP Ping is a tool for monitoring a SIP gateway (PBX, SBC, phone) for deep dive diagnostics. Most tools for VoIP monitoring are based on meeting SLA figures and providing general "network availability" statistics. SIP Ping is for granular troubleshooting.

Say you work in the NOC of a cloud-hosted VoIP provider. A high-profile customer states that every day their entire VoIP network goes down for ten to fifteen minutes. The packet captures from your session border controller confirm the gaps in registration, but ping tests show no loss throughout the day.

You could be looking at an overloaded or flaky SIP gateway at the customer site, a problem with a network element in your core network or trouble with a firewall at the customer site, among other things.

A key diagnostic datum is whether SIP traffic is able to transit to and from the customers site. ICMP is not SIP - you need to send real SIP packets, from different locations, and see if data can get through even when registration is failing. SIP Ping does that.

## Disclaimers & Caveats

I'm not a professional software developer. I created this tool to assist in my job as a VoIP tech, and as far as I can tell it works for me. I cannot make any assurances about the accuracy and reliability of this tool.

If you need a serious, enterprise-grade tool, you're free to download and modify SIP Ping.

Every packet that SIP Ping sends originates from a new source port. I don't know what will happen if you set the interval very low. Depending on your OS and how it handles ephemeral UDP ports, you could end up depleting your port pool.

## Needs & Can'ts

SIP Ping needs a working Python 2.x environment. It should work on anything that can provide that.

The host you're pinging needs to respond to OPTIONS packets. It doesn't matter what it responds with - 200, 403, even 501 are all fine as long as something is returned with the Call-ID intact.

If you're pinging a device that filters SIP traffic by the domain name (e.g. only accepts packets that look like `From: user@**company.com**`) you may need to use -d to set the correct domain name.

SIP Ping is UDP-only, it can't do TCP or TLS.

## Download

[sipping.py](https://gekk.info/sipping/sipping.py) - V1.0, updated 2015-05-15

## Usage

[Show/hide commandline syntax](https://gekk.info/sipping/#)

Here's all the options, **but I'll talk down below in human words.**

```
usage: sipping.py [-h] [-I interval] [-u userid] [-i ip] [-d domain] [-p port]
                  [--ttl ttl] [-w file] [-t timeout] [-c count] [-x [X]]
                  [-X [X]] [-q [Q]] [-S [S]]
                  host

Send SIP OPTIONS messages to a host and measure response time. Results are
logged continuously to CSV.

positional arguments:
  host         Target SIP device to ping

optional arguments:
  -h, --help   show this help message and exit
  -I interval  Interval in milliseconds between pings (default 1000)
  -u userid    User part of the From header (default sipping)
  -i ip        IP to send in the Via header (will TRY to get local IP by
               default)
  -d domain    Domain part of the From header (needed if your device filters
               based on domain)
  -p port      Destination port (default 5060)
  --ttl ttl    Value to use for the Max-Forwards field (default 70)
  -w file      File to write results to. (default logs/[ip] - * to disable.
  -t timeout   Time (ms) to wait for response (default 1000)
  -c count     Number of pings to send (default infinite)
  -x [X]       Print raw transmitted packets
  -X [X]       Print raw received responses
  -q [Q]       Do not print status messages (-x and -X ignore this)
  -S [S]       Do not print loss statistics

```

### Installation

Download **sipping.py**. Now you're installed. For this doc, we'll just assume you have it in /home/fred

### Use

The simplest way to use this is: `python sipping.py 192.168.1.10`

This will start sending OPTIONS packets once every second to 192.168.1.10. It will wait up to a second for each response. Every five packets loss statistics will be printed to the screen, and the stats on those five pings will be written to /home/fred/sipping-logs/192.168.1.10.csv.

The output looks like this:

```
dt@shell:sipping$ ./sipping.py 192.168.1.10 -t 40
Press Ctrl+C to abort
> (15/05/15 02:08:07:230895) Sending to 192.168.1.10:5060 [id: 9437147350]
< (15/05/15 02:08:07:268631) Reply from 192.168.1.10 (37.58ms): SIP/2.0 403 Forbidden
> (15/05/15 02:08:08:270195) Sending to 192.168.1.10:5060 [id: 6142922627]
X (15/05/15 02:08:08:309415) Timed out waiting for response from 192.168.1.10
> (15/05/15 02:08:09:310890) Sending to 192.168.1.10:5060 [id: 1143193559]
< (15/05/15 02:08:09:348649) Reply from 192.168.1.10 (37.61ms): SIP/2.0 403 Forbidden
> (15/05/15 02:08:10:350181) Sending to 192.168.1.10:5060 [id: 1569110399]
X (15/05/15 02:08:10:389392) Timed out waiting for response from 192.168.1.10
> (15/05/15 02:08:11:390844) Sending to 192.168.1.10:5060 [id: 3661471762]
X (15/05/15 02:08:11:430038) Timed out waiting for response from 192.168.1.10
        [Recd: 3 | Lost: 2]     [loss stats: longest run: 2  length of last run: 1  length of current run: 2 ]
        [min/max/avg 37.58/39.13/38.10]
```

In the above, five packets were transmitted, two were received back, and three were lost. The two that responded came back with 403 and latencies of about 38 milliseconds.

### Options

Most of the things mentioned there can be changed. For instance, if you're working with a SIP gateway that uses a port other than 5060, you can do: `python sipping.py -p 5080 192.168.1.10`, assuming it's on port 5080.

To ping at 300ms intervals: `python sipping.py -I 300 192.168.1.10`

If you don't want to get a message for every single ping sent, do `python sipping.py -q 192.168.1.10`. This mutes the send/receive messages, but **still shows** the statistics summary every five pings.

Conversely, if you don't like the stats: `python sipping.py -S 192.168.1.10`

If you need to know if an ALG is mangling your packets, try `python sipping.py -X 192.168.1.10`. This shows return traffic, so you might be able to see if unexpected changes are appearing in the responses.

### Using Logfiles

SIP Ping outputs logfiles in CSV format. If you are a programmer you can probably use this with little difficulty.

If you aren't a programmer, the easiest way to use the data is to load it into Microsoft Excel, which natively understands CSV. OpenOffice likely does as well, though I haven't tested it.

The CSV files are human-readable if you know what to ignore. An example file looks like:

```
time,timestamp,host,latency,callid,response
15/05/15 08:18:48:383775,1431703128.38,192.168.10.10,3,0762101642,SIP/2.0 200 OK
15/05/15 08:18:49:387328,1431703129.39,192.168.10.10,drop,1257707506,drop
15/05/15 08:18:50:390695,1431703130.39,192.168.10.10,2,9081881016,SIP/2.0 200 OK
```

Each line represents a single ping attempt. Here are the fields, and how you would read the first line above:

<table><tbody><tr><td>Time</td><td>15/05/15 08:18:48:383775</td></tr><tr><td>UNIX timestamp</td><td>1431703129.39</td></tr><tr><td>Host that responded <small>(for drops, the host that was pinged)</small></td><td>192.168.10.10</td></tr><tr><td>Latency</td><td>3 milliseconds</td></tr><tr><td>SIP response code</td><td>200 OK</td></tr></tbody></table>

### Using Call IDs

SIP Ping uses a unique call ID for every OPTIONS packet. The purpose is to allow you to follow a single packet for its entire lifetime.

Say you have a log that says that a packet transmitted to a PBX was dropped at 11:17 PM. Three things could have happened:

-   The packet was dropped on its way to the PBX (inbound internet issues)
-   The packet was received but not responded to (PBX issues)
-   The packet was recieved, responded to, but the response never arrived (outbound internet issues)

If you left a packet capture running on the PBX then you can find out which of the three it was. Examine the CSV log from SIP Ping and locate the drop:

```
15/05/15 08:18:49:387328,1431703129.39,192.168.10.10,drop,1257707506,drop
```

The Call-ID is 1257707506. Now pull up the packet capture from the PBX.

The packet capture shows an OPTIONS packet coming in with a Call-ID of 1257707506, and a 501 Not Implemented going back - but that 501 doesn't show up in the packet capture from your core network.

You have now identified an instance of one-way signaling failure; the packet came in, the PBX tried to respond, but the response didn't arrive. You now have a much more specific definition of the problem.

## Bugs / Known Issues

-   On Windows every line in the CSV is double-spaced. Excel will still read the file and a quick sort by the time column will strip the empty rows.

If you find anything else, email me at [articles@gekk.info](mailto:articles@gekk.info) and I'd be happy to look into it. I do not have a QA team, so there could be lots of bugs I don't know about.

## Future Development

There are a lot of things I could do with this, but one of the big changes I intend to implement is **register-based** testing, where the tool runs at the "client" end and registers repeatedly against a server.

## Why?

There are at least two other SIP diagnostic tools that can send ping-esque messages that I can think of, but the problem is that, like all network diagnostic tools, they're only designed to answer the question, "is anything wrong right now?"

In the real world, problems can often be intermittent, and their unpredictability certainly makes them no less serious. Hours or days might elapse between service outages, but when they occur they're showstoppers.

I found that there was no tool available in this industry that could prove the integrity of the connection between two SIP devices, in full duplex, at high speed.

I also found that a lot of techs in my field of work were using ping to do long-term monitoring, and ping just doesn't cut it for a wide variety of reasons, not the least being that ICMP is deprioritized on many routers and servers. Purpose-built tools decrease false positives.

Additionally, while ping gives packet loss stats over time, it doesn't allow you to look back and say "two weeks ago at 11:31:43 voice traffic stopped passing for three minutes," and in this job, you sometimes need data with that level of precision.
