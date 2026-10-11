# Survey: user guide

Survey sets up a room for shared AR. It measures where the room's AprilTags are,
then saves the result as a file and as a **room code**: a QR code that holds the
whole survey. Locator (and any app built on it, such as PVAR) scans the room
code once, and from then on every device places the room in the same spot.

Survey runs on **Meta Quest 3** and **iPhone**. **Survey with the Quest when
you can.** It measures each tag's orientation several times more consistently
than an iPhone (about 0.2-1.5° against 1-2.6°), and every position in the
survey depends on the first tag's orientation.

You survey a room once. Survey again only if tags are moved, added or removed.

---

## 1. What you need

- **AprilTags** from the **tagStandard41h12** family, printed at the same size.
  Each tag in the room needs a different ID.
- **One tag is required. More are optional, and they help.**
  - **With one tag**, every device anchors the room on that tag alone and must
    get within 1.2 m of it. The room's direction comes from that one tag's
    orientation, which varies by 1-3° between devices and viewpoints. Two
    devices can disagree by several centimeters near the tag, and more farther
    away (a 1° difference is 5 cm at 3 m).
  - **With two or more tags**, devices fit the room to the tags' positions
    instead of one tag's orientation. Devices agree much better, can anchor from
    farther away, and stay anchored as people move around. A device then needs
    to see **any two** of the tags. Spread the tags around the room, on
    different walls if you can.
- **Mount the tags upright on walls** or other vertical surfaces, flat and
  fixed in place. Tags tilted more than 30° from vertical (one lying on a
  table, say) are ignored.
- **A ruler or tape**, to measure the printed size.
- The **Survey** app on the device you'll survey with.

## 2. Measure the tag size

Measure the **edge of the black square**: the outer black border, not the white
margin or the paper. For example, 9.44 cm.

All tags must be printed at that size. Getting it wrong scales the whole survey:
a size 5% too large puts everything 5% too far from the first tag.

## 3. Start the app

**Quest:** in the headset, open **Library → Unknown sources → Survey**. The
first time, allow the **headset camera** permission. The status panel floats in
front of you and follows your head.

**iPhone:** open **Survey** and allow the **camera**. Hold the phone in
landscape. The buttons are along the top and the status below them.

The status shows the room name and tag size on one line:

```
Room: TACC   Tags: 9.44 cm
```

## 4. Set the room name and tag size

Do this before you start looking at tags. Both are remembered for the next time.

| | Quest | iPhone |
|---|---|---|
| Room name | **Left trigger** opens the keyboard. Type the name and press Done. | Type in the **Room name** field. |
| Tag size | **Left grip** opens the keyboard. Type the size in **cm** and press Done. | Type in **Tag size (cm)**, then tap **Set size**. |

- The **name** appears on every device that uses the room ("Room: TACC"). You
  can change it any time before saving.
- **Changing the tag size starts the survey over.** Everything measured so far
  was measured at the old size.

## 5. Survey the room

1. **Look at the first tag** from about **0.5-1 m**, as straight on as you
   can, and hold still for a few seconds. **This tag defines the room:** the
   **center of the tag is the room's origin** (0, 0, 0), so height 0 is the
   tag's center, not the floor. Facing the tag, **+x is to your right**
   along the wall, **+y is up** and **+z points into the wall** behind the
   tag. Apps
   place their content relative to this point, so start on the tag you want
   content placed around. Status:
   ```
   Room: provisional - get within 1.2 m of tag 8 (5/8 close sightings)
   ```
   Once it has 8 close sightings, the room is **anchored**: the Quest
   controllers buzz, and the tag's marker cube turns from **yellow** to
   **red**.
2. **Visit each other tag.** Walk up to it, again about 0.5-1 m away, and look
   at it steadily. Each tag needs **20 sightings** to be learned:
   ```
   tag 3: learning (12/20), 0.8 m away
   ```
   When it reaches 20, it shows as **learned** and gets a **green** marker.
   - **Move slowly.** Frames taken while the camera turns faster than about
     8°/s are dropped, so turning your head or the phone quickly makes no
     progress.
   - **Keep the room anchored while you walk.** Glance back at a tag you have
     already done now and then. If tracking jumps (after you cover the cameras,
     say), the app re-anchors when it sees a known tag again.
   - **With just one tag**, skip this step.
3. **Check your work.** Each marker cube should sit on its tag. If one is
   clearly off, see "Starting over" below.
4. **Save.** **Quest:** right trigger. **iPhone:** **Save**. The status shows
   what was saved:
   ```
   Saved TACC: 4 tags, survey H48CSS, to room_config.json and room_code.png.
   ```
   **Survey H48CSS** is the survey's ID, a short code computed from the tag
   positions. Every device that uses this survey shows the same ID, so it's a
   quick check that two devices have the same room. Only learned (green) tags
   are saved; tags still "learning" are left out.

You can keep going after a save: learn more tags and save again. Each save
replaces the previous one, and a save with different tags gets a new survey ID.

## 6. Get the room code to the other devices

Saving writes three files to the app's own folder on the device:

| File | What it is |
|---|---|
| `room_code.png` | The room code to print or show (QR, 1024 × 1024) |
| `room_code.txt` | The same code as text |
| `room_config.json` | The full survey, readable, for editing or for building into an app |

**From an iPhone:**
- The code **appears on screen** after saving, and other phones can scan it
  there directly.
- To print it, open the **Files** app → **On My iPhone → Survey**, or connect
  the phone to a Mac and open it in Finder → **Files → Survey**.

**From a Quest:** nobody else can see the headset's screen, so copy the file to
a computer. With the Quest connected by USB and developer mode on:

```bash
adb pull /sdcard/Android/data/edu.utexas.tacc.survey/files/room_code.png
```

(The Quest status also shows the folder after saving.) You can also browse to
that folder with Meta Quest Developer Hub or any Android file manager.

**Print the code and put it up in the room**, near the entrance, at about chest
height. Print it at least **8 cm** across; larger reads from farther away. If
you laminate it, avoid glare. Locator reads it from about 40-70 cm.

## 7. Starting over, and extending a survey

- **Re-anchor** (Quest **B**, iPhone **Re-anchor**) forgets this session's
  sightings and anchors again from the next tag you look at. Learned tags are
  kept. Use it if the room looks shifted.
- **New survey** (Quest **X twice** within 2 seconds, iPhone **Start over**)
  forgets everything. The next tag you look at defines a new room. Use it if
  you started on the wrong tag or a learned tag is badly off.
- **Next time you open Survey**, it starts from the last saved survey. The
  first saved tag you look at anchors the room where it was, so the room keeps
  its origin, and new tags can be added. **Every other tag has to be learned
  again before you save**, because only tags learned this session (plus the
  anchor) are saved. To begin a new room instead, use New survey.

## 8. Controls

| Action | Quest | iPhone |
|---|---|---|
| Scan at full speed now | **A** | **Scan now** |
| Re-anchor | **B** | **Re-anchor** |
| New survey (forget everything) | **X** twice | **Start over** |
| Save survey and room code | **Right trigger** | **Save** |
| Edit room name | **Left trigger** | Room name field |
| Edit tag size | **Left grip** | Tag size field + **Set size** |

The app scans for tags on its own all the time. **Scan now** only speeds it up
until the next sighting.

## 9. Tips and troubleshooting

| Problem | What to do |
|---|---|
| A tag is never seen | Get closer and face it squarely, with good light and no glare. Check it is tagStandard41h12 and printed with its white border. |
| "learning" doesn't go up | You're moving too fast. Hold still for a second or two at a time. |
| "get within 1.2 m" | The first tag (or, with one tag, the only one) must be seen from closer than 1.2 m. |
| A tag lying flat isn't learned | That's on purpose: only tags within 30° of vertical count. |
| Markers are off their tags | Check the tag size. Then do a New survey, starting on a tag you can see straight on. |
| Quest keyboard doesn't open | Tell the developers. The app needs the system keyboard, which this build turns on. |
| The survey ID changed | Each save gives a new ID. Devices that scanned the old code are still on the old survey; print the new code and have them scan it. |

## 10. Files the app keeps

All in the app's folder (iPhone: Files → On My iPhone → Survey; Quest:
`/sdcard/Android/data/edu.utexas.tacc.survey/files/`):

- `room_config.json`, `room_code.png`, `room_code.txt`: the last saved survey
  (the previous `room_config.json` is kept as `room_config.prev.json`)
- `survey_tags.json`: tags learned so far, kept between runs
- `survey.log`: the session log, which helps the developers when something goes
  wrong

Deleting the app deletes these files.

## 11. Installing

**Quest:** the app is sideloaded, so the headset needs developer mode on. It
appears under **Library → Unknown sources**.

**iPhone:** the app is installed from Xcode with a development profile. The
first time, trust the developer in **Settings → General → VPN & Device
Management**. With a free Apple developer account, the app **stops opening
after 7 days** and must be reinstalled, and a phone can hold only **three**
such apps at once.
