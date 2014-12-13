atakanyenel_Yenel_Atakan_Step1
==============================
<<<<<<< HEAD
=======

What we need to do in step 2:

1) Event Management

1.1) [DONE] Each user can schedule any number of events

1.2) [DONE] Organizer input with GUI

1.3) Invitation to all other users

1.4) Select "Attending" or "Not Attending" with GUI

1.5) Able to modify answer between yes and no only

1.6) Notification on organizer when list of attendance changes in GUI

1.7) Send event information only upon request

2) Message (in step 1)

To-Do

1) Remove one of the event/events in client

2) complete seeevents.cs

3) implement sent request function in seeevents.cs (and may client-master.cs as well)

4) seeevents.cs need to be able to access List<events> stored in client-master

5) (If we have enough time) send event directly from newevents.cs and send request from seeevents.cs

6) (If we know how) fix the exception when closing GUI under certain circumstances


>>>>>>> parent of 70367f5... Just a lot of get and set functions
Project Step 2:
Second step of the project is built on the first step. In this step, in addition to the message transfer feature of step 1, event management feature is added to the application.
￼￼￼￼￼￼￼￼￼
Each user can schedule any number of events. Organizing user enters the details of the event (such as time, place and description of the event) as free text via the GUI. The event details are sent to the server. After that, server forwards the event to all other connected clients by sending the event's time, place, description and organizing user's name. In other words, all other clients are invited automatically to the event by the organizer. Invitees may answer as “attending” or “not attending” using the GUI, or they may not answer. Invitee's participation status remains as “not answered”, until he/she answers the invitation. Any invitee can answer or change his/her answer at any time using the GUI, but once it gives an answer, it cannot change its status back to “not answered”. Answers and participation status changes are sent to the organizer as notifications by the server as soon as a change occurs. These notifications must be shown in the organizer’s GUI. On the other hand, event participation details are not automatically fed to other users; other users (invitees) should be able to explicitly request a particular event's up-to-date invitee list and their participation status from the server; once such a request is received, the server sends the requested information to the requesting user only (not to everyone).
A particular user can organize and attend any number of events. Moreover, the event management operations can be performed at any time while the user is connected to the server.
As in the step 1, all of the operations must be clearly shown on the client and server GUIs.
For programming rules and submission specifications, please read the corresponding sections at the end of this document.
