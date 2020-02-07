# tdd-meres
TDD mérés szakdolgozathoz.

## A feladat
 1. Készíts egy StringCalculator nevű osztályt, amelynek Add metódusa egy stringet vár, és egy integert ad vissza. 
    - A metódus 0, 1, vagy 2 vesszővel elválasztott számot keres a stringben, és összegüket adja vissza, üres string esetén 0-t.
2. Módosítsd a metódust úgy, hogy bármennyi számot fel tudjon dolgozni a stringben!
3. Módosítsd a metódust úgy, hogy vessző helyett újsor (\n) karaktert is elfogadjon elválasztóként a számok között! (Vagy újsor, vagy vessző lehet két szám között. Egy bemenetben mindkettő előfordulhat.) 
4. Tedd lehetővé saját elválasztókarakter megadását. Ha a string két / karakterrel indul, az azokat követő karakter is elfogadott elválasztó karakter legyen a bemenetben. A bemenet elején megadott elválasztókaraktert egy újsor karakter kövesse! 
    - Tehát: //[elválasztó]\n[számok], például: //;\n1;2;3 
5. Ha a bemenet negatív számot tartalmaz, a metódus dobjon egy kivételt az erre vonatkozó üzenettel és benne az első negatív számmal. (Használd az ArgumentException osztályt.)
