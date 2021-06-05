from twilio.rest import Client

accountSID = 'ACxxxxxxxxxxxxxxxx'
authToken = 'xxxxxxxxxxxxxxxx'
twilioCli = Client(accountSID, authToken)
myTwilioNumber = '+14955551234'
myCellPhone = '+14955558888'
message = twilioCli.messages.create(body='Mr. Watson - Come here - I want to see you.',
                                    from_=myTwilioNumber, to=myCellPhone)

message.to
message.from_
message.body
message.status
message.date_created
message.date_sent

message.sid
updatedMessage = twilioCli.messages.get(message.sid)
updatedMessage.status
updatedMessage.date_sent
