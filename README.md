# OPP Bokštų dvikova
Objektinis programų projektavimas

## Žaidimo technologijos

Serverio dalis: C# su naujausiu .NET

Vartotojo sąsaja: React karkasas su Typescript, CSS (SASS)

Komunikacija: SignalR

##  Žaidimo aprašymas

Žaidimas yra bokšto gynimo tipo, skirtas dviem žaidėjams. Žaidėjai turi savo bokštą, kurį turi apginti, bei gali pirkti įvairių tipų karius, kurie kovos su priešininko kariuomene. Žaidėjas, pirmasis prasibrovęs pro priešiniko kariuomenę ir nugriovęs jo bokštą, laimi.  

### Žaidimo grafinės sąsajos pavyzdys

![](https://im.ge/i/11NdTJ)

## Reikalavimai
### Funkciniai

- Paspaudus ant kario paveiksliuko yra sukuriamas karys priešais žaidėjo bokštą
- Pasiekus tam tikrą patirties taškų kiekį žaidėjas gali paspausti mygtuką esantį šalia patirties taškų kiekio, kuris pakels žaidėjo lygį 

### Nefunkciniai

- Žaidėjas gali paspausti ant kario paveiksliuko ir taip sukurti karį
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
