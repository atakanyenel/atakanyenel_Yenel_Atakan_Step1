atakanyenel_Yenel_Atakan_Step1
==============================

How to save time:

1. Maybe we should ditch remove friend functionality

2. Maybe we should ditch the add + accept friends to just add

What we need to fix:

1. Dynamic buffer size

2. "Someone just responded to your event" error

3. Reconnect event with no attendance record error

Step 3:

1) Only friends can communicate, invite, etc

1.1) create new form "editFriends"

1.1.1) print list of clients ("name only")

1.2) check it he's friends function in server

2) Events @ Step 2

3) Messaging @ Step 1

-----------------------------

How things works:

1. Server starts up

2. Server start listening

3. Client starts up

4. Client connect to to server

5. Client request server to send data(events + client)

Create Events:

1. Show new Form of newevents.cs

2. Set Organizer to username

3. User input data

4. Click Create to create

5. Encode data into a single string

6. send that string to server

7. Server receives event string

8. Server decodes event string into pieces

9. add that event into List of event in Server

10. Broadcast event to every existing clients

11. client receives events

12. client decodes events

13. client stores events into List of event in each client

See Events:

1. Show new Form of seeevents.cs

2. get name of events one by one from client-master

3. add each of them into comboBox

4. user select a event

5. show info of that event to user(including attendance)

6. user select yes or no

7. encode answer into a string

8. send that string to server

9. server decodes it

10. server find that event

11. server remove that username from all lists

12. server adds that username to correspondent list

13. server broadcast that attendance update to everyone

14. client receives attendance update

15. client find that event

16. client remove that username from all lists

17. client adds that username to correspondent list

[Not done yet] Friends:

1. Show new Form of editFriends.cs

2. get name of requested clients one by one from client-master

3. add each of them into listBox3

4. get name of friends one by one from client-master

5. add each of them into listBox2

6. get name of clients one by one from client-master

7. if that name does not exist in either requested list nor friends list + now myself

8. add each of them into listBox1

[Not done yet] Add Friends

9. user add another user as friends

10. client encode it into message

11. client sends it to server

12. server receives message of friend request

13. server decodes it

14. iff that name does not exist in request list & friend list & himself

15. add username to request list

16. server sends it to client 1 and client 2

17. client receives message of friend request

18. client decodes it

14. iff that name does not exist in request list & friend list & himself

15. add username to request list

19. refresh everything

[Not done yet] Accept Friends

9. user accept another user's friend request

10. remove that username from requested list

11. add that username into friends list

12. client encode it into message

13. client sends it to server

14. server receives message of acceptance of friend request

15. server decodes it

16. iff that name exist in its requested list

17. remove that username from requested list

18. add that username into friends list in both client 1 and client 2

19. send friend request have been accepted message to client 1

20. client 1 receives message

21. client 1 decodes message

22. client 1 add client 2 into friends list

-----------------------------

List of Symbols:

1 = % = event ("%" + date + "%" + title + "%" + place + "%" + description + "%" + organizer + "%")

2 = # = message ("#" + tbname.Text + ": " + tbsendTextBox + "\r\n")

3 = & = attendance ("&"+{enent id}"&"{username}&{yes or no}"&")

4 = $ = request ($)

[Not done yet] 5 = @ = add friend (@client1@client2@)

[Not done yet] 6 = ^ = get all usernames(^username^)

[Not done yet] 7 = ? = accept friend request (?client2?client1?)

[Not done yet] 8 = < = friend request have been accepted(<client1<client2<)

more can be added in the future

-----------------------------

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

1.7) [90% DONE] Send event information only upon request

1.7.1) send attendance

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

1) [Maybe DONE] Exception when closing GUI under certain(unknown) circumstances

2) "There is a problem. Try again" keeps popping up when connecting 2+ clients, but the connection is in fact successful

3) Change of attendance is not entirely correct. Correct only when the list of going/not going/not reply is empty in the first place

4) Unable to send message to organizer when going/not going list changes, reason unknown

5) [DONE] Organiser got clear after clicking create button in newevent.cs

6) closing server / connected client closes everything else

For more details, please check the pdf.
