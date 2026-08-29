# The Legendary Sword

*A Wildfrost mod*

## Lore

Deep beneath the frost, in a forge that hadn't seen a decent commission in
three winters, a blacksmith named Grimhilde finally snapped.

For years she'd bashed out Scrappy Swords by the crate — bent nails, a
sharpened spoon, whatever didn't clatter too loudly in the scrap bin — and
watched heroes limp back from battle complaining that their "weapon" had
folded like a lawn chair against the first Snowdweller that looked at it
funny. "It's *scrappy*," she'd tell them. "That's the whole brand." They did
not find this reassuring.

Then one Tuesday, a particularly polite young hero returned her Scrappy
Sword in three pieces, thanked her for her service, and asked — very
gently — if perhaps a weapon that didn't disassemble itself mid-swing was
too much to ask.

Grimhilde stared at the pieces for a long moment. Then she threw her
sharpening stone through the window, fired every apprentice, and locked
herself in the forge for six days. She emerged with singed eyebrows, a
haunted expression, and *this*.

She did not name it. She just handed it over and said, "Try folding
*that*, hotshot."

It has not folded.

## What this mod actually does

Patches the base game's `Sword` card (display name "Scrappy Sword") the
moment it's cloned into play:

- Damage bumped up to something a hero can respect
- Renamed via `forceTitle` so it stops undercutting itself
- New foreground/background art (`card-foreground.png` /
  `card-background.png`) so it doesn't look like scrap anymore
- Applies 2 stacks of Frost on hit, because Grimhilde has a flair for the
  dramatic now

## Building & installing

```bash
./deploy.sh
```

Builds the mod in Release and copies the DLL + art into Wildfrost's local
`Mods/TheLegendarySword/` folder for testing. No Steam Workshop upload
needed.

## Requirements

- .NET SDK (targets `net472`)
- A local Wildfrost install with the Modded (Mono) build present

## How to publish on Linux

You can only publish if you are running the game from the user that owns the licence. Family shared accounts cannot publish.
A bug in how path is treated expects the mod to be located in \ directories.
For this reason the Steam workshop button never renders.
The game has a console command that calls the exact same code the button would (Console+PublishMod → WildfrostMod.UpdateOrPublishWorkshop()), bypassing the button entirely:

1. In game, open the console with ` (backquote) or F12.
2. Run:
publish logan.wildfrost.thelegendarysword <tag>
3. Look for Upload result ... in the log.
