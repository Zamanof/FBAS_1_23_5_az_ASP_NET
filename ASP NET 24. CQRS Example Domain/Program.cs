//CQRS (Command and Query Responsibility Segregation)

// 1. Read data (Query) - SELECT
// 2. Change data (Command) - INSERT, UPDATE, DELETE

// Hansi hallarda istifadesi meqbuldur:
// 1. Sistemde DB-den chox oxuma bash verir (analitika, hesabat ve s.)
// 2. Mehsuldarliq kritikdir (DB-de komanda ve sorqular uchun)
// 3. Sorqular ayrica keshleme teleb olunursa

// Sade layihelerde ve ya DB-e az yuk dushen layihelerde
// CQRS-in istifadesi artiqliq teshkil edecek

Console.WriteLine();
