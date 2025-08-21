System biblioteczny zbudowany w .NET z użyciem Entity Framework Core.

1. Jeśli nie masz zainstalowanych narzędzi Entity Framework Core, zainstaluj je globalnie:
dotnet tool install --global dotnet-ef

Lub zaktualizuj do najnowszej wersji:
dotnet tool update --global dotnet-ef


2. Utworzenie migracji

Aby utworzyć pierwszą migrację, wykonaj następującą komendę z katalogu głównego rozwiązania:
dotnet ef migrations add InitialCreate --project LibrarySystem.Data --startup-project LibrarySystem


3. Aktualizacja bazy danych

Aby zastosować migracje i utworzyć bazę danych, wykonaj:
dotnet ef database update --project LibrarySystem.Data --startup-project LibrarySystem

