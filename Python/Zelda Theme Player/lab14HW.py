noteDictionary = {
  "C":60,
  "C-sharp":61,
  "D":62,
  "D-sharp":63,
  "E":64,
  "F":65,
  "F-sharp":66,
  "G":67,
  "A-flat":68,
  "A":69,
  "A-sharp":70,
  "B":71,
  "C2":72,
  }

def playLetterNote(note, duration):
  midiValue = noteDictionary[note]  
  duration = duration * 1000
  duration = int(duration)
  playNote(midiValue, duration)
  
mySongList = [('A-sharp',.25),('F',.5),
              ('A-sharp',.25),('A-sharp',.25),
              ('C',.25), ('D',.25),
              ('D-sharp',.25), ('F',.25),
              ('F',.25), ('F',.5),
              ('F-sharp',.25), ('A-flat',.25),
              ('A-sharp',.25), ('A-sharp',.25),
              ('A-sharp',.25), ('A-flat',.25),
              ('F-sharp',.25), ('A-flat',.25),
              ('F-sharp',.25), ('F',.5),
              ('F',.25), ('D-sharp',.25),
              ('D-sharp',.25), ('F',.25),
              ('F-sharp',.5), ('F',.25),
              ('D-sharp',.25), ('C-sharp',.25),
              ('C-sharp',.25), ('D-sharp',.25),
              ('F',.5), ('D-sharp',.25),
              ('C-sharp',.25), ('C',.25),
              ('D',.25), ('E',.25),
              ('G',.25), ('F',.5)
              ]

def playSong(songList):
  for noteTuple in songList:
    playLetterNote(noteTuple[0], noteTuple[1])
