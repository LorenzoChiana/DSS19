# DSS19

# Progetto corso Sistemi di Supporto alle Decisioni a.a. 2019 / 2020
Una azienda di distribuzione deve rifornire 38 grossi clienti con merce che ha in giacenza in 3
diversi magazzini. Si richiede di definire il piano di distribuzione (a costo minimo) per il mese
prossimo, anche se i relativi ordini non sono ancora disponibili. 

Sono dati:
1. gli ordinativi storici di ogni cliente negli ultimi 35 mesi
2. i costi di trasporto di una unità di merce da ogni magazzino ad ogni cliente
3. la disponibilità in ogni magazzino.

Nel caso la disponibilità totale non fosse sufficiente a soddisfare la domanda, è possibile
terziarizzare la richiesta, approvvigionando qualunque cliente ad un costo fisso di 550 per unità
di prodotto. Le richieste di un cliente devono essere interamente soddisfatte dal magazzino cui
è stato assegnato, non è possibile spezzare gli ordini.

I dati sono disponibili come segue:
1. Tabella histordini, campi idserie: identificativo della serie storica degli ordinativi di ciascun
cliente, periodo: periodo (mese) in cui è stato effettuato l’ordine, val: ammontare
dell'ordine.
2. Tabella costi, campi cli: identificativo cliente, mag: identificativo magazzino, costo: costo per
trasportare una unità di prodotto dal magazzino al cliente.
3. Tabella giacenze, campi mag: identificativo del magazzino, giacenza: quantitativo di merce
in giacenza.

I dati saranno resi disponibili su database SQLite o SQL Server, a mia discrezione. La soluzione
deve essere proposta come progetto VisualStudio, che richiama un pente predittivo in python,
in cui selezionando l'identificativo di un cliente verrà proposto il magazzino da cui servirlo. 
