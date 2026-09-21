# One Night at Triangeln - exempelversion

En liten, körbar exempelversion för en objektorienterad C#-code-along.

## Centrala idéer

- Kartan är en array av arrayer: `Location?[][]`.
- `Game` innehåller en central spelloop.
- `Player` flyttas genom att rad och kolumn ändras.
- Varje konkret plats deklarerar sina egna giltiga riktningar.
- Alla platser använder samma numrerade meny.
- Föremål kan flyttas från en plats till spelarens `Inventory`.
- `Location`, `Item` och `Npc` är abstrakta basklasser.
- Varje faktisk plats och varje föremål har en egen `sealed`-klass.
- `Outside` har en `Stranger`, som hanterar byteshandeln.
- `Chest` är en behållare på en plats, inte ett föremål i inventory.

## Starta spelet

```bash
dotnet run
```

## Avsedd pusselkedja

1. Hitta den lilla nyckeln i toalettbåset.
2. Hitta flaskan på damernas toalett.
3. Gå via andra våningen och rulltrappan till den stängda butiken.
4. Öppna kistan och ta brandlarmsverktyget.
5. Aktivera brandlarmet på första våningen.
6. Gå ut och byt flaskan mot smokingjackan.
7. Gå till stationen och ta tåget.

Kartan ser ut så här:

```text
Toalettbås       Damernas toalett   Andra våningen
tom ruta         tom ruta           Rulltrappa
Stängd butik     Förråd             Första våningen
tom ruta         tom ruta           Utanför           Station
```

Alla rader har fyra positioner. Den tomma rutan under förrådet gör att spelaren
inte kan gå direkt från förrådet till stationen. Stationen kan bara nås genom
att först gå ut.

## Hur förflyttningen hör ihop med kartan

Kartan använder två koordinater: `row` och `column`. Uttrycket
`locations[row][column]` väljer först en rad och därefter en plats i raden.

Varje `Location` deklarerar de riktningar som ska visas i menyn. `Game` översätter
sedan den valda riktningen till en förändring av spelarens koordinater:

- norr: `(-1, 0)`
- söder: `(1, 0)`
- väster: `(0, -1)`
- öster: `(0, 1)`

`TryMovePlayer()` kontrollerar dessutom den nya positionen mot kartan innan
spelarens `Row` och `Column` ändras. Nästa anrop till `CurrentLocation()` hämtar
då platsen från den nya rutan i kartan.

## Arv, komposition och polymorfism

- `ToiletStall`, `Outside` och övriga platser ärver från `Location`.
- `SmallKey`, `Bottle` och övriga föremål ärver från `Item`.
- `Stranger` ärver från `Npc`.
- `Outside` **har en** `Stranger`: detta är komposition.
- `location.Interact(player)` anropar rätt subklass genom polymorfism.
