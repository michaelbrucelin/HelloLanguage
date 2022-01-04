-- xml读取

declare @xmlret as xml
set @xmlret = '<Test_Status>
  <Test_Overview>
    <Name>HONG KONG CMHK</Name>
    <Supplier>P00901</Supplier>
    <InitBy>guanwei.lin</InitBy>
    <Init>1571652734</Init>
    <Type>110</Type>
    <Test_ID>2019102110000001864</Test_ID>
  </Test_Overview>
  <SMS>
    <iTest_ID>2019102110000009344</iTest_ID>
    <Message_ID>5d3aa6c2-1b4c-cf19-ea2c-03b97562f693</Message_ID>
    <SMSC_Accepted>SMSC has acknowledged the message</SMSC_Accepted>
    <DLR_Receive>DLR received looks good</DLR_Receive>
    <DLR_Delay>18.00</DLR_Delay>
    <MSG_Receive>Message received on remote network</MSG_Receive>
    <MSG_Delay>13.10</MSG_Delay>
    <Receiving_SMSC>+85292040026</Receiving_SMSC>
    <Sent_Sender_ID>Google</Sent_Sender_ID>
    <Received_Sender_ID>Google</Received_Sender_ID>
    <Sent_Content>G-670195 is your Google verification code.</Sent_Content>
    <Received_Content>G-670195 is your Google verification code.</Received_Content>
    <F-DLR>0</F-DLR>
  </SMS>
  <SMS>
    <iTest_ID>2019102110000009345</iTest_ID>
    <Message_ID>5d3aa6c2-1b4c-cf19-ea2c-03b97562f694</Message_ID>
    <SMSC_Accepted>SMSC has acknowledged the message</SMSC_Accepted>
    <DLR_Receive>DLR received looks good</DLR_Receive>
    <DLR_Delay>18.00</DLR_Delay>
    <MSG_Receive>Message received on remote network</MSG_Receive>
    <MSG_Delay>13.10</MSG_Delay>
    <Receiving_SMSC>+85292040026</Receiving_SMSC>
    <Sent_Sender_ID>Google</Sent_Sender_ID>
    <Received_Sender_ID>Google</Received_Sender_ID>
    <Sent_Content>G-670195 is your Google verification code.</Sent_Content>
    <Received_Content>G-670195 is your Google verification code.</Received_Content>
    <F-DLR>0</F-DLR>
  </SMS>
</Test_Status>'

-- 1. xml自身
select @xmlret

-- 2. xml的一个节点，含节点标签
-- <Name>HONG KONG CMHK</Name>
select @xmlret.query('/Test_Status/Test_Overview/Name')

-- 3. xml的一个节点，但不含节点标签，数据类型仍然是xml
-- HONG KONG CMHK
select @xmlret.query('/Test_Status/Test_Overview/Name/text()')

-- 4. xml的一个节点的值
-- HONG KONG CMHK
select @xmlret.value('(/Test_Status/Test_Overview/Name)[1]', 'varchar(max)')

-- 5. 总共有几个/Test_Status/SMS节点
-- 2
select @xmlret.value('count(/Test_Status/SMS)', 'int')

-- 6.总共有几个/Test_Status/SMS节点的子节点
-- 26
select @xmlret.value('count(/Test_Status/SMS/*)', 'int')

-- 7. /Test_Status/SMS节点有多少个子节点
-- 13
select @xmlret.value('count((/Test_Status/SMS)[1]/*)', 'int')
