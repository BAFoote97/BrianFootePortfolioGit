JUSTLETMESLEEP / NAPJAB

---

Can also be played at https://qjones45000.github.io/JustLetMeSleep/NapJab/

More information can be found on the Global Game Jam page at https://globalgamejam.org/2019/games/nap-jab

Instructions on playing can be found within the game.

---

I worked on this game at the 2019 Pittsburgh Global Game Jam, in which the theme was "Home."

My contribution to this game was that I did most of the programming for the core gameplay mechanics, mainly to the specifications of our team lead, Adam Brant. Basically, your goal is to survive the onslaught of cats attempting to push you off of your bench.

It was my first ever game jam and it was a lot of fun working in a group on a game that, for once, wasn't my idea. It's really great working surrounded by others who have similar aspirations in a friendly yet competitive environment. The experience made me feel like I would do pretty well in a team, although I would definitely like to do more team projects before coming to that decision.

We also won the Diversty Award, so that was a pleasant surprise.



--------------------

SPINNYDOTGAME

(May remove)

---

This was one of my earlier projects that I worked on when I was early into C#. It was done in an evening and the goal was to make a game with only a single button input.

The gist of this game is that you must press the spacebar at just the right moment while the red needle from the center of the screen is not overlapping the black circle around it. For every successful press, and how much time passes, the needle spins faster and faster.

It's an incredibly simplistic game that took very little time to make. With only a fledgling grasp of C#, if that, I had a lot of help. At my current level, however, I could easily replicate the game in an even shorter time than I had before.

What this game's purpose may be trying to demonstrate on the portfolio is that I was able to form an idea under a very narrow restriction in a short amount of time. This would show that I at least have some problem-solving ability.

(If you're reading this part, Chris, and have any suggestions on any better ways that I should word this, please let me know.)

--------------------

OPPOSITESATTRACT

---

CONTROLS

---

Point mouse to direction to aim.

Left mouseclick to shoot.

Shooting will cause the player to move in the opposite direction. This is your primary means of movement.

---

The concept for this game was made for a school assignment which was based on the theme "opposites attract." The game isn't 100% based on the original concept, while also having something of a deceptive title since you want to AVOID opposites.

You must begin the game on "MenuScene". It's here that you will find instructions for how to play the game.

This game once had music, but in case it might be an issue with any copyright, I removed it.

--------------------

CHESSPROJECT

---

CONTROLS

---

Left click on either a piece or the space of a piece to select them. Then click on any highlighted area to move that piece to that spot.

Hold down right click to rotate the camera around the board.

---

It's just Chess, or at least it mostly is. All of the pieces move as desired, but there is no Check state, Checkmate state, pawn replacement, or that maneuver where the king moves around his rooks. Also, each of the pieces are cubes, but I adjusted their scales to make them easier to distinguish from one another visually.

Aside from these issues, it's just Chess. Grab a friend and have at it.

-------------------

STARFIGHTER UNITY GAME 

"Alpha 17"

(May remove this one since it's so unfinished and has a lot of issues, but I included it because it's so large and because it was a really important project for helping me understand Unity and C#)

---

Start this game on the "TestMenu" scene. It's there that you can select one of four levels (Missions, 1, 2, 4 (since I had a different mission planned to take place before it, but I never got to work on it), and a survival mission where waves of enemies spawn one after another, although they're not infinite, despite the name of the script used for that mission. It's also in the TestMenu scene that you can change your loadout before entering a level.

This is my largest and most volatile project yet. Very on-and-off, over the course of about eight or nine months, this project is where a large majority of my Unity and C# knowledge came from. At the time, I considered it really impressive for someone of my inexperience, but I look back at it knowing that there is a lot of things I could have and should have done, some of which listed below. I set out to make a sort of hybrid between games like Ace Combat, Star Fox, and something like Rogue Squadron. The Ace Combat inspiration is especially evident since I added a dialogue system that is exactly like the form in the Ace Combat games (ie. enemies speaking a stock quote in reaction to a certain circumstance).

As far as difficulty goes, if you don't usually play games like Ace Combat, you might find this extremely difficult. Like some of these other games, I adjusted the difficulty for my own skill level rather than the skill level of other players.

KEEP IN MIND

Due to my still developing knowledge of Unity at the time, version control was nonexistent when I was making this game. It WILL NOT build. I believe that, at some point, due to importing from version to version repeatedly, something was messed up along the way, keeping the game from building.

Furthermore, this game has a great deal of issues that I imagine plague a lot of new Unity developers. I was overly reliant on the Update function and rarely ever made separate functions. That, and I have numerous separate scripts which can all easily just be within the same script. Looking through the code, you'd probably going to find a lot of easily solved issues.

When I was working on the game, I also added copyright music. I wasn't sure if this would be an issue for a portfolio piece or not, but just in case, I have removed it and tried to remove each of the audio scripts that I could, but it's very possible that I may have missed some.

---

CONTROLS

---

Mouse to turn the ship. The Y sensitivity is greater than the X sensitivity, so this incentivizes rolling.

Left click to fire equipped primary weapon (nose and wings)

Middle click to fire equipped secondary weapon (side and underside)

Scroll down once to toggle which primary weapon is equipped

Scroll up once to toggle which secondary weapon is equipped

Hold right click to focus camera on current selected target

Aim at another target and press F to select that target

Press R to select random enemy target

W to accelerate

S to decelerate or reverse

A and D to roll

V to toggle between 1st person and 3rd person

P to pause

---



-------------------

VERTICALSHOOTEMUP

---

CONTROLS

---

Players fire automatically

Player 1 - Move with WASD keys

Player 2 - Move with arrow keys

Player 3 - Move with JKLI keys

---

THE GOAL

There isn't really much of a goal here. There is neither a win state nor a lose state programmed. It's a simple demo of a verticel shoot 'em up where the screen scrolls and the players are constantly moving up. If a player runs out of lives, of which each player has a set amount of 10,000, which can be adjusted in the "GameField" object's "GameScrollScript" component, along with the difficulty level, which each enemy detects and adjusts their values based on by picking the a float in a list as determined by the diffictuly int. The difficulty level ranges from 0 to 4.

---

The game plays like any other vertical shooter. It was not difficult to program and was nothing other than a quick little weekend project that I made for fun. The only part I had any difficulty with was that I had originally wanted mouse control, which I quickly scrapped because I just wanted to get a move-on with the project. When I brought my computer to my family's home, I made a few additions to the scripts for multiple players.

One thing that could definitely use improvement is the difficulty. It's a bit unpolished and definitely wouldn't be a level 1 if this was a part of a full game. Initially, I gave myself three lives, then five lives, then ten lives, but even then, I could only ever beat it on the lowest difficulties. But the purpose of the demo here is to demonstrate the programming, not the polish.

-------------------

RACERSHOOTERGAME

---

CONTROLS

---

Turn player with mouse

Roll with A and D

Speed up with W and slow down with S

The higher the speed, the slower you turn

Shoot with left click

---

THE GOAL

In this game, you have HP and a score. The objective of this game is to keep collecting the goals (the red squares) before the opposition. For every goal that one player gets, that player gets one point while all other players lose one point. If a player has a score of 0, that player dies.

To win, get as many goals as you can to maintain your score while also avoiding the obstacles.

---

The idea for this game came about on a whim. I wanted a race to go for a long time, being something of a test of endurance. In order to do this, I created a code which allowed the different sections of the racing field to be random parts while also turning in random directions. This made sure that the race was different every time.

The way the AI players work is that they face either the next available goal or the goal after that. I made this random because the player can easily just skip a goal in so to get ahead of the game. This gives the AI that option. They also adjust their speed based on their distance from the goal they're moving toward, slowing down when they're close to keep themselves from missing it.