=====================================================================================================================
1. Was ist eigentlich das Problem?
    Rezept:
    1. Skizziere das Problem.
        - Was sind die Anforderungen.
2. Lösungsansatz formulieren (durch Nachdenken)
3. Testfälle sammeln
4. Inkrementell vorgehen
    - Wie kann ich möglichst schnell einen kleinen Nutzenzuwachs bieten? 
    - Welchen Schritt kann ich tun, um etwas von Wert herzustellen, zu dem ein Kunde/Anwender Feedback geben kann?
5. Implementierung mittels Red-Green-Refactor
=====================================================================================================================

Vorgehensweise in Phase 1 (Problem skizzieren):

- Wikieintrag gelesen: http://de.wikipedia.org/wiki/Umgekehrte_Polnische_Notation
    -Handschriftliche Notizen gemacht.        
- iPad App RPN-70 Calc heruntergeladen um Verständnis zu stärken.

Vorgehensweise in Phase 2 (Lösungsansatz formulieren):
    - Squenzdiagramm gezeichnet um API für RpnCalculator zu entwerfen.
    - Dafür einen Stack-Spike implementiert um Unterschied zwischen Peek und Pop zu verstehen.

Vorgehensweise in Phase 3 (Testfälle ermittelt):
    - Eine Testklasse erstellt und in diese Testfälle des
      RpnCalculators ermittelt. Dabei bin ich bei Grenztestfällen
      noch einmal in die Analysephase bzw. Lösungsfindungsphase
      gewechselt und habe festgestellt, dass eine Liste für die
      Stack-Realisierung vorteilhafter als ein klassischer Stack wäre.
      Dadurch musste ich erneut die einzelnen Sequenzdiagramme auf die
      neue Datenstruktur anpassen.

Vorgehensweise in Phase 4 (In Inkrementen vorgehen):
    - Ich spiele Kunde.  
      Wenn ich Kunde wäre, würde ich mir möglichst viele Rechenoperationen
      für das erste Inkrement wünschen. Jedoch wird dabei die Stack-Grenze
      noch nicht berücksichtigt.

    - Inkrement 2 wäre die Behandlung von Grenzfällen für einzelne Rechen-
      operationen. Dabei wird eine Stackkapazität der Größe 4 berücksichtigt.
      D.h., der Stack besitzt 4 Stackebenen. Überschreitet man diese, wird
      der Stack von hinten mit dem 4. Element (= letztes Element) zum Zeit-
      punkt des Überschreitens nachgefüllt (nur simuliert). 

    - Inkrement 3 Vertauschen von Stackebenen x und y (= Ebene 1 und 2).
      Dafür müssen alle Phasen noch einmal durchlaufen werden.