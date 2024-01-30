# Tréner Program Felhasználói Dokumentáció

## Tartalomjegyzék

1. [Bevezetés](#bevezetés)
2. [Rendszerkövetelmények](#rendszerkövetelmények)
3. [Telepítés](#telepítés)
4. [Használat](#használat)
   1. [Főmenü](#főmenü)
   2. [Új edzés](#új-edzés)
   3. [Edzés történet](#edzés-történet)
   4. [Szűrő](#szűrő)
   5. [Statisztika](#statisztika)
5. [Gyakori kérdések](#gyakori-kérdések)
6. [Kapcsolat](#kapcsolat)

---

## Bevezetés

A Tréner Program egy egyszerű, konzolon futó alkalmazás, amely lehetővé teszi az edzésnapló vezetését és az edzések statisztikájának megtekintését. Az alkalmazás segít a felhasználóknak nyomon követni az edzéseiket, rögzíteni az edzések részleteit és megjeleníteni az edzéstörténetüket.

---

## Rendszerkövetelmények

Az alkalmazás futtatásához szükséges a következők egyike:

- .NET Core 3.1 vagy újabb verzió
- Windows, macOS vagy Linux operációs rendszer

---

## Telepítés

Az alkalmazást nem kell telepíteni, csak a forráskódot kell letölteni és futtatni a megfelelő .NET Core környezetben.

1. Klónozza le a forráskódot a GitHub repository-ból:

   ```bash
   git clone https://github.com/alexluczi/Trener-IKT.git
   ```

2. Navigáljon a projekt könyvtárába:

   ```bash
   cd Trener-IKT
   ```

3. Futtassa az alkalmazást a következő paranccsal:

   ```bash
   dotnet run
   ```

---

## Használat

### Főmenü

A főmenüben válassza ki a kívánt műveletet a nyíl gombok (fel, le) és az Enter billentyű segítségével.

![Főmenü](https://github.com/alexluczi/Trener-IKT/blob/main/img/Screenshot%202024-01-30%20at%2011.49.23%E2%80%AFAM.png?raw=true)

### Új edzés

Az "Új edzés" opcióval rögzítheti az új edzése részleteit, mint például a dátum, az edzés típusa és az edzés időtartama.

![Új edzés](https://github.com/alexluczi/Trener-IKT/blob/main/img/Screenshot%202024-01-30%20at%2011.49.47%E2%80%AFAM.png?raw=true)

### Edzés történet

Az "Edzés történet" menüponttal megtekintheti az összes rögzített edzés részletes adatait.

![Edzés történet](https://github.com/alexluczi/Trener-IKT/blob/main/img/Screenshot%202024-01-30%20at%2011.49.54%E2%80%AFAM.png?raw=true)

### Szűrő

A "Szűrő" opcióval szűrheti az edzéseket edzés típusa alapján, és megtekintheti az eredményeket.

![Szűrő](https://github.com/alexluczi/Trener-IKT/blob/main/img/Screenshot%202024-01-30%20at%2011.49.58%E2%80%AFAM.png?raw=true)

![Szűrő](https://github.com/alexluczi/Trener-IKT/blob/main/img/Screenshot%202024-01-30%20at%2011.50.00%E2%80%AFAM.png?raw=true)

### Statisztika

Az "Statisztika" menüponttal megjelenítheti az edzések statisztikáit, beleértve az összesített edzéseket és az átlagos időtartamot edzéstípusonként.

![Statisztika](https://github.com/alexluczi/Trener-IKT/blob/main/img/Screenshot%202024-01-30%20at%2011.50.06%E2%80%AFAM.png?raw=true)

---

## Gyakori kérdések

#### Hogyan lehet hozzáadni egy új edzést?

Az "Új edzés" menüpontot választva követheti az egyszerű utasításokat a dátum, az edzés típusa és az időtartam megadásához.

#### Hogyan nézhetem meg az összes edzéstörténetemet?

Az "Edzés történet" menüpont alatt megtekintheti az összes rögzített edzés részletes adatait.

#### Hogyan szűrhetem az edzéseimet típus alapján?

Válassza az "Szűrő" menüpontot, majd válassza ki a kívánt edzéstípust a szűréshez.

#### Hogyan jeleníthetem meg az edzéseim statisztikáit?

Az "Statisztika" menüpontot választva megtekintheti az összesített edzéseket és az átlagos időtartamot edzéstípusonként.

---

## Kapcsolat

Ha további kérdése van vagy segítségre van szüksége, lépjen kapcsolatba velünk az alábbi elérhetőségeken:

- Email: support@trenerprogram.com
- Weboldal: [www.trenerprogram.com](https://www.trenerprogram.com)
- GitHub: [TrenerProgramGitHub](https://github.com/trenerprogram)

Köszönjük, hogy a Tréner Programot választotta! Jó edzést!

# Tréner Program Fejlesztői Dokumentáció

## Tartalomjegyzék

1. [Bevezetés](#bevezetés)
2. [Rendszerkövetelmények](#rendszerkövetelmények)
3. [Projekt struktúra](#projekt-struktúra)
4. [Fő komponensek](#fő-komponensek)
   1. [Program osztály](#program-osztály)
   2. [Exercise osztály](#exercise-osztály)
5. [Működési folyamatok](#működési-folyamatok)
   1. [Főmenü megjelenítése](#főmenü-megjelenítése)
   2. [Új edzés hozzáadása](#új-edzés-hozzáadása)
   3. [Edzés történet megjelenítése](#edzés-történet-megjelenítése)
   4. [Szűrés funkció](#szűrés-funkció)
   5. [Statisztika megjelenítése](#statisztika-megjelenítése)
6. [Hibakezelés](#hibakezelés)
7. [Tesztelés](#tesztelés)
8. [Fejlesztői útmutató](#fejlesztői-útmutató)
9. [Kapcsolat](#kapcsolat)

---

## Bevezetés

A Tréner Program egy egyszerű C# konzolalkalmazás, amely lehetővé teszi az edzésnapló vezetését és az edzések statisztikájának megtekintését. A fejlesztői dokumentáció segítséget nyújt azoknak, akik szeretnék megérteni a projekt struktúráját, a fő komponenseket, a működési folyamatokat és a hibakezelést.

---

## Rendszerkövetelmények

A fejlesztéshez a következő eszközökre van szükség:

- Visual Studio vagy más C# fejlesztői környezet
- .NET Core 3.1 vagy újabb verzió

---

## Projekt struktúra

A projekt a következő alapstruktúrával rendelkezik:

- **Trener**
  - **Program.cs**: A fő alkalmazás belépési pontja.
  - **Exercise.cs**: Az `Exercise` osztály leírása.
  - **README.md**: Felhasználói dokumentáció.
  - **img**: Képek a felhasználói dokumentációhoz.

---

## Fő komponensek

### Program osztály

A `Program` osztály a fő alkalmazás belépési pontja. A főbb felelősségek:

- Főmenü kezelése
- Menüpontok feldolgozása és továbbítása a megfelelő kezelőfüggvényeknek
- Különböző menüpontok megjelenítése

```csharp
public class Program
{
    // ... (lásd a kódot a felhasználói dokumentációban)
}
```

### Exercise osztály

Az `Exercise` osztály reprezentálja egy edzés adatait. A főbb tulajdonságok:

- `Date`: Az edzés dátuma.
- `TypeOfExercise`: Az edzés típusa.
- `Length`: Az edzés időtartama percben.

```csharp
public class Exercise
{
    // ... (lásd a kódot a felhasználói dokumentációban)
}
```

---

## Működési folyamatok

### Főmenü megjelenítése

A főmenü megjelenítése és a felhasználói interakció kezelése a `DisplayMenu` és a `HandleMenuSelection` függvényekkel történik.

```csharp
static void DisplayMenu(string[] menuOptions, int selectedIndex)
{
    // ... (lásd a kódot a felhasználói dokumentációban)
}

static void HandleMenuSelection(string selectedOption)
{
    // ... (lásd a kódot a felhasználói dokumentációban)
}
```

### Új edzés hozzáadása

Az "Új edzés" menüpont kiválasztásával az `HandleNewExercise` függvény felelős az új edzés adatainak bekéréséért és rögzítéséért.

```csharp
static void HandleNewExercise()
{
    // ... (lásd a kódot a felhasználói dokumentációban)
}
```

### Edzés történet megjelenítése

Az "Edzés történet" menüpont kiválasztásával a `FillUp` függvény feltölti az `exercise` listát az edzések adataival, majd a `DisplayExerciseHistory` függvény megjeleníti az edzéstörténetet.

```csharp
static void FillUp()
{
    // ... (lásd a kódot a felhasználói dokumentációban)
}

static void DisplayExerciseHistory()
{
    // ... (lásd a kódot a felhasználói dokumentációban)
}
```

### Szűrés funkció

A "Szűrő" menüpont kiválasztásával a `HandleFilter` függvény lehetővé teszi az edzések szűrését típus alapján és a megfelelő eredmények megjelenítését.

```csharp
static void HandleFilter()
{
    // ... (lásd a kódot a felhasználói dokumentációban)
}
```

### Statisztika megjelenítése

Az "Statisztika" menüpont kiválasztásával a `DisplayStatistics` függvény megjeleníti az edzésekre vonatkozó statisztikákat.



```csharp
static void DisplayStatistics()
{
    // ... (lásd a kódot a felhasználói dokumentációban)
}
```

---

## Hibakezelés

Az alkalmazás tartalmaz alapvető hibakezelést, például a nem megfelelő bemenetek kezelése és a kivételek kezelése.

```csharp
try
{
    // ... (lásd a kódot a felhasználói dokumentációban)
}
catch (Exception ex)
{
    Console.WriteLine($"Hiba történt: {ex.Message}");
}
```

---

## Tesztelés

A projekt tartalmazhat egységteszteket, amelyek segítenek ellenőrizni a különböző komponensek helyes működését. A tesztek futtathatók a Visual Studio-ban vagy a .NET Core parancssorban.

---

## Fejlesztői útmutató

1. Klónozza le a projektet a GitHub repository-ból:

   ```bash
   git clone https://github.com/alexluczi/Trener-IKT.git
   ```

2. Nyissa meg a projektet a kiválasztott C# fejlesztői környezetben.

3. Módosítsa a szükséges fájlokat és függvényeket.

4. Futtassa az alkalmazást vagy az egységteszteket tesztelés céljából.

---

## Kapcsolat

Ha további fejlesztői kérdése vagy észrevétele van, lépjen kapcsolatba velünk az alábbi elérhetőségeken:

- Email: dev-support@trenerprogram.com
- GitHub: [TrenerProgramGitHub](https://github.com/trenerprogram)

Köszönjük, hogy hozzájárult a Tréner Program fejlesztéséhez! Jó fejlesztést!