# OPP Bokštų dvikova
Objektinis programų projektavimas

## Žaidimo technologijos

Serverio dalis: C# su .NET 6 ir ASP.NET Core

Vartotojo sąsaja: React karkasas su Typescript, CSS

Komunikacija: SignalR

##  Žaidimo aprašymas

Žaidimas yra bokšto gynimo tipo, skirtas dviem žaidėjams. Žaidėjai turi savo bokštą, kurį turi apginti, bei gali pirkti įvairių tipų karius, kurie kovos su priešininko kariuomene. Žaidėjas, pirmasis prasibrovęs pro priešiniko kariuomenę ir nugriovęs jo bokštą, laimi.  

### Žaidimo grafinės sąsajos pavyzdys

![](https://i.im.ge/2022/09/17/11Pngf.bokstai2.jpg)

## Reikalavimai
### Funkciniai

- Paspaudus ant kario paveiksliuko yra sukuriamas karys priešais žaidėjo bokštą
- Pasiekus tam tikrą patirties taškų kiekį žaidėjas gali paspausti mygtuką esantį šalia patirties taškų kiekio, kuris pakels žaidėjo lygį 

### Nefunkciniai

- Žaidėjų bokštai turi po 1000 gyvybės taškų
- Žaidėjas pradeda turėdamas 500 pinigų
- Žaidėjas turi galimybę pasirinkti kario sukūrimą iš 3 skirtingų karių tipų
- Kariai tarpusavyje skiriasi savo kaina, daroma žala, gyvybės taškais. Pigiausias karys kainuoja 100, turi 80 gyvybės taškų ir daro 20 žalos, miręs išmeta 110 pinigų. Kitas karys kainuoja 250, turi 150 gyvybių ir daro 40 žalos, miręs išmeta 170 pinigų. Trečias karys kainuoja 500, turi 200 gyvybių ir daro  80 žalos, miręs išmeta 550 pinigų
- Sukurtas karys pradeda eiti link priešo bokšto
- Karys pasiekęs priešininko karį arba bokštą sustoja
- Karys taip pat sustoja jei priešais jį stovi to paties žaidėjo sukurtas karys
- Jeigu priešais karį stovi priešo sukurtas karys arba priešo bokštas - karys pradeda kautis su objektu priešais save
- Karys gavęs smūgį praranda dalį gyvybės taškų priklausomai nuo kokio priešininko gavo smūgį
- Kario gyvybėms nukritus iki 0 - karys išnyksta
- Jeigu priešais karį išnyksta priešas, karys pradeda eiti vėl link priešininko bokšto arba kario
- Kai karys prieina priešininko bokštą, jis pradeda mušti priešininko bokštą
- Jeigu karys trenkia bokštui - bokštas gauna žalos taškų
- Bokšto gyvybėms nukritus iki 0 - žaidimas baigiamas
- Nužudžius priešininko karį žaidėjas gauna pinigų kiekį, kuris priklauso nuo nužudyto priešininko kainos
- Nesugriauto bokšto savininkas yra žaidimo nugalėtojas
- Nužudžius priešininko karį žaidėjas gauna patirties taškų kiekį, kuris priklauso nuo nužudyto priešininko kainos
- Žaidėjas žaidimo viršuje gali matyti savo turimą pinigų kiekį bei patirties taškų kiekį
- Žaidėjui pasiekus kitą lygį, jo bokštas atsinaujina ir jis gali pradėti gaminti naujus karius
