=====================================================================================================================
1. Was ist eigentlich das Problem?
    Rezept:
    1. Skizziere das Problem.
        - Was sind die Anforderungen.
2. L�sungsansatz formulieren (durch Nachdenken)
3. Testf�lle sammeln
4. Inkrementell vorgehen
    - Wie kann ich m�glichst schnell einen kleinen Nutzenzuwachs bieten? 
    - Welchen Schritt kann ich tun, um etwas von Wert herzustellen, zu dem ein Kunde/Anwender Feedback geben kann?
5. Implementierung mittels Red-Green-Refactor
=====================================================================================================================

Vorgehensweise in Phase 1 (Problem skizzieren):

- Wikieintrag gelesen: http://de.wikipedia.org/wiki/Umgekehrte_Polnische_Notation
    -Handschriftliche Notizen gemacht.        
- iPad App RPN-70 Calc heruntergeladen um Verst�ndnis zu st�rken.

Vorgehensweise in Phase 2 (L�sungsansatz formulieren):
    - Squenzdiagramm gezeichnet um API f�r RpnCalculator zu entwerfen.
    - Daf�r einen Stack-Spike implementiert um Unterschied zwischen Peek und Pop zu verstehen.

Vorgehensweise in Phase 3 (Testf�lle ermittelt):
    - Eine Testklasse erstellt und in diese Testf�lle des
      RpnCalculators ermittelt. Dabei bin ich bei Grenztestf�llen
      noch einmal in die Analysephase bzw. L�sungsfindungsphase
      gewechselt und habe festgestellt, dass eine Liste f�r die
      Stack-Realisierung vorteilhafter als ein klassischer Stack w�re.
      Dadurch musste ich erneut die einzelnen Sequenzdiagramme auf die
      neue Datenstruktur anpassen.

Vorgehensweise in Phase 4 (In Inkrementen vorgehen):
    - Ich spiele Kunde.  
      Wenn ich Kunde w�re, w�rde ich mir m�glichst viele Rechenoperationen
      f�r das erste Inkrement w�nschen. Jedoch wird dabei die Stack-Grenze
      noch nicht ber�cksichtigt.

    - Inkrement 2 w�re die Behandlung von Grenzf�llen f�r einzelne Rechen-
      operationen. Dabei wird eine Stackkapazit�t der Gr��e 4 ber�cksichtigt.
      D.h., der Stack besitzt 4 Stackebenen. �berschreitet man diese, wird
      der Stack von hinten mit dem 4. Element (= letztes Element) zum Zeit-
      punkt des �berschreitens nachgef�llt (nur simuliert). 

    - Inkrement 3 Vertauschen von Stackebenen x und y (= Ebene 1 und 2).
      Daf�r m�ssen alle Phasen noch einmal durchlaufen werden.