atakanyenel_Yenel_Atakan_Step1
==============================

What we need to do in step 2:

1) Event Management

1.1) [DONE] Each user can schedule any number of events

1.2) [DONE] Organizer input with GUI

1.3) [50%] Invitation to all other existing users

1.3.1) [DONE]When server receives event, sent message to all other clients

1.3.2) When server receives events, add all other existing users into not reply list

1.4) Select "Attending" or "Not Attending" with GUI

1.4.1) [DONE] Server react to response

1.5) Able to modify answer between yes and no only

1.6) Notification on organizer when list of attendance changes in GUI

1.6.1) triggered wheneven setGoing/setNotGoing is triggered

1.7) [DONE] Send event information only upon request

2) [DONE] Message (in step 1)

Additional tasks

1) [DONE]Remove one of the event/events in client

2) [85% with bugs] complete seeevents.cs

3) [DONE]implement sent request function in seeevents.cs and newevents.cs

4) [DONE]seeevents.cs need to be able to access List<events> stored in client-master

5) [DONE]send event directly from newevents.cs and send request directly from seeevents.cs

6) [DONE] Add Refresh (i.e. Request) button (back) to seeevents.cs

7) Server needs to handle and process attendance update

8) Add all other uses to NotReply list (done in srever) when event is created

Known Issues

1) Exception when closing GUI under certain(unknown) circumstances

2) "There is a problem. Try again" keeps popping up when connecting 2+ clients, but the connection is in fact successful

3) Change of attendance is not entirely correct. Correct only when the list of going/not going/not reply is empty in the first place

4) Unable to send message to organizer when going/not going list changes, reason unknown

Step 3:

1) Only friends can communicate, invite, etc

For more details, please check the pdf.
