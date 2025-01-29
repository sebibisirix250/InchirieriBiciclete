Proiect de gestionare a închirierilor de biciclete 

Descriere generală: Prezentul proiect are ca obiectiv o realizare a sistemului de gestiune pentru închirieri de biciclete cu ajutorul tehnologiei ASP.NET Core Razor Pages. Proiectul cuprinde patru tabele principale, fiecare cu un set de operațiuni CRUD pentru gestionarea datelor sale. Relațiile dintre tabele sunt configurate astfel încât să reflecte o aplicație practică pentru o aplicație de închirieri de biciclete. Tabelele utilizate sunt: Biciclete, Clienți, Închirieri și Plăți.

Aplicația permite adăugarea, vizualizarea și gestionarea datelor pentru fiecare dintre aceste tabele, cu validări corespunzătoare.

Planul de implementare

1.Crearea bazei de date:
2.Crearea tabelelor necesare pentru aplicație.
3.Configurarea relațiilor între tabele: fiecare închiriere este asociată unui client și unei biciclete, iar plățile sunt legate de închirieri.
4.Crearea de fișoare Razor Pages pentru operații CRUD pe toate tabelele din bază. În implementați implementarea validării datelor: adăugarea de validări pentru fiecare câmp al formularului de adăugare/editare. Structurarea: organizați fișoarele de page într-o structură simplă. Detalii fișoare și funcționalități 
5.Implementarea validării datelor:
Adăugarea validărilor pentru fiecare câmp al formularului de adăugare sau editare.
1. Fișierul InchirieriContext.cs
Acest fișaier se află în folderul Data și este responsabil pentru configurarea conexiunii la baza de date și gestionarea entităților (tabelelor). In acesta vom defini seturile de date care vor reprezenta tabelele din baza de date. In cazul nostru, avem entitatile Bicicleta, Client, Inchirieri si Plati.

1.Exemplu fisier pentru crearea bazei de date:
 
public class InchirieriContext : DbContext
{
    public InchirieriContext(DbContextOptions<InchirieriContext> options) : base(options) { }

public DbSet<Bicicleta> Biciclete { get; set; }
    public DbSet<Client> Clienti { get; set; }
    public DbSet<Inchiriere> Inchirieri { get; set; }
    public DbSet<Plata> Plati { get; set; }
}

2. Razor Pages files for CRUD
Fiecare entitate are fișiere corespunzătoare în folderul Pages, organizate astfel încât să reflecte operațiunile de vizualizare, creare, editare și ștergere a datelor. De exemplu, pentru Biciclete avem un folder Biciclete care conține fișierele:

Index.cshtml - pentru vizualizarea tuturor bicicletelor.
Create.cshtml - pentru adăugarea unei biciclete noi.
Edit.cshtml - pentru editarea unei biciclete existente.
Fișierele sunt implementate conform structurii de Razor Pages.

3. Validarea datelor
Validarea are loc la nivel de model, folosind atributele de validare din ASP.NET Core (ex. [Required], [StringLength]). De asemenea, fiecare formular din pagina Razor va include un control al validării, astfel încât datele să fie corecte înainte de a fi trimise la server.

Erori întâmpinate si nerezolvate:

Problema 1: Crearea închirierii nu funcționează corect

Problema 2: Butonul de creere plata nu redirecționează corect
Cauza: Butonul de creare plata nu redirecționa către pagina de creare, dar doar făcea refresh la pagina curentă.

Deși majoritatea funcționalităților funcționează corect, am întâmpinat aceste două probleme care nu au fost rezolvate până la finalul proiectului:

Nu am reușit să implementăm corect crearea închirierilor în ciuda depanării efectuate.

Crearea plăților nu funcționează - De asemenea, implementarea pentru adăugarea plăților nu a fost finalizată corect din cauza unor erori persistente la redirecționarea formularului.

Concluzii
Am reușit să punem în aplicare majoritatea funcționalităților, în ciuda problemelor pe care le-am întâlnit la sfârșitul proiectului, și am putut asigura o interfață foarte simplă și intuitivă pentru controlul închirierii bicicletelor.
