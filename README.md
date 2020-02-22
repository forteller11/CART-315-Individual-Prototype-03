## individual design journal three
 
### Inspiration
Last week I played [Macey’s second prototype](https://github.com/weavingmemories/cart315-2020/tree/master/exercises/exercise_2) in which you play as a crab who can only walk sideways via “a” and “d”. You can also pick up seashells, some of which are placed over a minutes walk away from the player. This led to a really interesting dynamic by which to approach shells in the distance you have to position yourself orthogonally to them and then begin walking sideways. Aesthetically this represented a fundamental change to your experience in the game. More than simply meaning that you don’t see the objects you are traveling towards, this sideways approach means that objects are moving past you and your view was constantly changing. It’s the equivalent of looking out the side window of a car on the highway --- colours and shapes streak past you. This represents much more dynamic and interesting visual experience than looking out the front window, through which objects will slowly increase in size and barely move.


### Translating the inspiration into a prototype
Macey’s prototype made me interested to explore other ways to change players' relationships with their peripheries. Crabs and other animals have eyes which are widely set --- I wondered what the effect would be of simulating the lack of perspective vision animals in their peripheral vision. I debated ways of transitioning from a highly perspectived view at the center of the screen to a flattened view at the view’s edge. I dabbled in transitioning between a wide-angle view at the cameras center to an increasingly short-angle (orthographic-esque) view at the FOV’s edge but it became apparent that this would be too technically challenging a prospect to be able to responsibly undertake in a week's time.

Instead, I decided to see what would happen if I explored the crab game’s visual equivalent directly: what if the player simply cannot see in front of them? Through my own playtesting I realized it was really confusing to have two cameras at near 90 degree angles from the front view (180 degrees from each other). It seemed almost impossible to intuitively understand what was happening as you walked forward. Instead I found that blocking out the players front view at a less extreme camera rotations seemed to be intelligible. With this new method of simply blocking out the front view I worried that players would simply turn sideways to look at what they wanted to and then turn back, making the black bar would feel just a frustrating gimmick. Not changing their approach in play but simply adding more meaningless obstacles in their way.

I had to somehow tie this mechanic to the gameplay to make it feel meaningful. Because players can simply look side to side, it doesn’t work really as an information hiding mechanic without adding some other mechanics/caveats. While the mechanic may not have a systemic effect, it definitely has large aesthetic impacts on player experience. Therefore I wanted to tie the mechanic to other aesthetic elements like narrative to make it seem like it feel meaningful in the game.


### Design Questions
Originally I was just interested in the effect a game with only peripheral vision would have on the aesthetic experience and approach of the player. After adding the narrative I was interested if the visual experience paired with the poetic excerpts proved interesting for players at all.

### Questions For Playtesters

Observe: What were the players initial reaction on the separation of the screen into two separate vertical slits.

Q: Did you find the effect disorienting?

Q: Did you understand that movement was tied to vision?

Q: What were you trying to do during the playtest, explore the area, explore the unique vision, look for more text?

Q: What do you think would have made you stand still longer?

Q: What did you think of the visual effect: did you find it interesting, banal, annoying…?


### Post Playtest reflection
All in all I don’t think I got that useful information from the playtests. It was difficult to find out what the players thought, or how they were affected by, the vision mechanic because players were so focused on getting new narrative excerpts. About half the playtesters never realized that movement was tied to the expansion/contraction of their vision as it was too slow (I didn’t properly incorporate delta.time into all my scripts so the low fps on my laptop made parts of the game literally slower) and also most players never stood still as there was nothing to get them to do so. I also found the 5min playtesting format perhaps prevents players from getting into a more walking simulator appropriate mood where players are willing to nonchalantly explore and experience without trying to efficiently complete any goals or maximize some quantified score system. 

The initial splitting of vision into the two seperate slits seemed to elicit an audible and content “ooo” or “ahhh” in most playtesters. So at the very least the mechanic was interesting on some surface, aesthetic level. At the very least it seems a mechanic like this would be interesting enough to explore in a small level of a walking-simulator à la the memories in [*What Remains Of Edith Finch*](https://store.steampowered.com/app/501300/What_Remains_of_Edith_Finch/) or the levels/dreams in [*Awkward Dimensions Redux*](https://store.steampowered.com/app/529110/Awkward_Dimensions_Redux/). More than anything the playtest confirmed how fruitful it can be to present players with abstract/poetic excerpts and gameplay/visual phenomenon which the players are then allowed to create connections between themselves (like in [*Dear Esther*](https://store.steampowered.com/app/203810/Dear_Esther/)).
