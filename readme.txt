# Projekt Zaliczeniowy Finance App 

Finance App to prosta aplikacja służąca do zarządzania finansami. 
Jej główne funkcjonalności to przechowywanie aktualnego stanu pieniędzy na koncie, saldo przychodów i rozchodów 
jak również możliwość dodawania kolejnych użytkowników. Projekt realizowany jest w .Net Core przy użyciu 
javascriptowego frameworka React.
W skład aplikacji wchodzą następujące kontrolery:
- AccountController służący do wyświetlania aktualnej kwoty pieniędzy na koncie
- ExpensesController pokazuje rozchody z konta
- IncomeController służy do wyświetlania przychodów na konto
- UsersController służy do tworzenia nowych i wyświetlania aktualnych użytkowników
- MoneyBoxesController to skarbonka do przechowywania oszczędności. Można tworzyć nowe skarbonki, wpłacać
i wypłacać z nich pieniądze. 
- CategoriesController tworzy, usuwa i daje możliwość pobrania kategorii dodanych przez użytkownika

Frontend aplikacji został napisany przy użyciu:
- React
- Axios
- Scss
- React-router
- Webpack
- Yarn

Baza danych została wykonana w MS SQL.

# Co trzeba mieć: 
* Visual Studio 2019 Community
* SDK .Net Core 3.0.0
* SQL server 2017
* SQL Server Managment Studio
* NodeJS 10.9 ^ 
* Yarn globalnie (przez npm)

# Jak odpalić projekt:

 - Włączamy projekt w Viusal Studio i pobieramy paczki Nuget
 - Tworzymy sobie własną baze w SQL (i server jeśli nie mamy) i nazywamy ją FinacepApp
 - Wchodzimy w plik appsetting.json(w projekcie) i dodajemy podmieniamy 
  ```
 "ConnectionString": "Server=TNAZWA_SERWERA;Database=NAZWA_BAZY;
 MultipleActiveResultSets=True; App=EntityFrameworkCore; Trusted_Connection=True; 	Integrated Security=true;" 
 ```
 
- Powiniśmy mieć połączenie z bazą - F5  - serwer powinien się włączyć
- Teraz wystarczy włączyć clienta - w folderze ClientApp komenda - yarn start.