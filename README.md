# Survey

Sets up a room for the [Locator](https://github.com/GregAbram/Locator) apps.
It measures the room's wall-mounted AprilTags (tagStandard41h12) and saves
`room_config.json` plus a **room code**, a QR code holding the whole survey, for
the other devices to scan. Quest 3 and iPhone. **Survey with the Quest when you
can**: it measures tag orientation several times more consistently than an
iPhone.

**[User guide](USER_GUIDE.md)** - how to use the app on Quest and iPhone.

Unity 6000.3.10f1, with [edu.tacc.apriltags](https://github.com/GregAbram/AprilTags).

## Surveying a room

1. Set the room name and the printed tag size (the black square's edge, in cm).
   On Quest, left trigger edits the name and left grip edits the size, using
   the system keyboard. On iPhone, use the fields at the top.
2. Look at a tag from about 0.5-1 m away. The first tag you see defines the room.
3. Walk around and look at every other tag from close up until each is learned
   (green).
4. Save (Quest: right trigger; iPhone: Save). This writes `room_config.json`,
   `room_code.png` and `room_code.txt` to the app's files:
   - Quest: `adb pull /sdcard/Android/data/edu.utexas.tacc.survey/files/room_code.png`
   - iPhone: Files app > On My iPhone > Survey (the code also shows on screen
     for other phones to scan)
5. Print the code and put it up in the room.

Changing the tag size, or **New survey** (Quest: X twice; iPhone: Start
over), starts again from nothing. Otherwise, the next run extends the saved
survey.

## Building

Menu **Tools > Survey**, or batchmode `SurveyApp.BuildIOS` / `SurveyApp.BuildQuest`
(see the Locator README). Bundle ID `edu.utexas.tacc.survey`.
