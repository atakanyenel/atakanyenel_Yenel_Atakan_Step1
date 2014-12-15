atakanyenel_Yenel_Atakan_Step1
==============================

What we need to do in step 2:

1) Event Management

1.1) [Maybe DONE] Each user can schedule any number of events

1.1.1) Appear to have some bug, reason unknown

1.2) [DONE] Organizer input with GUI

1.3) Invitation to all other users

1.3.1) Implementation: When server recieves event, sent message to all other clients

1.3.1.1) Question: how to make sure every user but the organizer will get the invitation message?

1.4) [50%] Select "Attending" or "Not Attending" with GUI

1.4.1) Server react to response

1.5) Able to modify answer between yes and no only

1.6) Notification on organizer when list of attendance changes in GUI

1.6.1) triggered wheneven setGoing/setNotGoing/setNotReply is triggered

1.6.2) also need function to remove user in all event(s).cs

1.7) [DONE] Send event information only upon request

2) [DONE] Message (in step 1)

Additional tasks

1) [DONE]Remove one of the event/events in client

2) [50% with bugs] complete seeevents.cs

3) [DONE]implement sent request function in seeevents.cs and newevents.cs

4) [DONE]seeevents.cs need to be able to access List<events> stored in client-master

5) [DONE]send event directly from newevents.cs and send request directly from seeevents.cs

6) [50%] Add Refresh (i.e. Request) button (back) to seeevents.cs

6.1) Refresh is not perfect, cbOrganizer combo box got some repetition, but not all. Reason unkonwn

7) Server needs to handle and process attendance update

7.1) most set and get functions have already been implemented.

Known Issues

1) Exception when closing GUI under certain(unknown) circumstances

2) "There is a problem. Try again" keeps poping up when connecting 2+ clients, but the connection is in fact successful
 
3) index out of bound for seeevent (getTitle). The item can not be located.

Step 3:

1) Only friends can communicate, invite, etc 

For more details, please check the pdf.

