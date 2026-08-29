using Deadpan.Enums.Engine.Components.Modding;
using UnityEngine;

public class TheLegendarySword : WildfrostMod
{
     public TheLegendarySword(string modDirectory) : base(modDirectory) { }

     public override string GUID => "logan.wildfrost.thelegendarysword";
     public override string[] Depends => new string[] { };
     public override string Title => "The Legendary Sword";
     public override string Description => "The sword a hero deserves! Changes the Scrappy Sword's damage and gives it Frost on hit.";

     protected override void Load()
     {
          base.Load();
          Events.OnCardDataCreated += OnCardDataCreated;
     }

     protected override void Unload()
     {
          base.Unload();
          Events.OnCardDataCreated -= OnCardDataCreated;
     }

     private void OnCardDataCreated(CardData card)
     {
          if (card.name != "Sword") return; // <-- replace with the real internal name

          Debug.Log($"[The Legendary Sword] Patching {card.name}, was damage={card.damage}");

          // 1) Change the damage number
          card.damage = 5;
          card.forceTitle = "Legendary Sword";

          // 1b) Swap the card art: foreground (the character/item art) + background (the frame art)
          card.mainSprite = GetImageSprite("card-foreground.png");
          card.backgroundSprite = GetImageSprite("card-background.png");

          // 2) Make it also apply a status effect when it hits (Frost, as an example)
          var frost = Get<StatusEffectData>("Frost");
          card.attackEffects = card.attackEffects ?? new CardData.StatusEffectStacks[0];
          var effects = new System.Collections.Generic.List<CardData.StatusEffectStacks>(card.attackEffects);
          effects.Add(new CardData.StatusEffectStacks(frost, 2)); // apply 2 stacks of Frost on hit
          card.attackEffects = effects.ToArray();
     }
}
