General Information

- Build the solution => Visual Studio should automatically restore the NuGet packages.
- Run the solution => 3 console windows should open, one for each puzzel

The ‘Asl’ solution was developed using Visual Studio 2015 and all the projects use target framework 4.6.1.
The solution contains three solution folders: FizzBuzz, GamesReviews and SuperMarketRegister. In each folder, you can find the code for each puzzle.

Puzzel - FizzBuzz Projects

Asl.Puzzles.FizzBuzz         (tried to avoid if in the code)
Asl.Puzzles.FizzBuzz.Console (run this to display the result for number 1-100)
Asl.Puzzles.FizzBuzz.Integration.Tests
Asl.Puzzles.FizzBuzz.Interfaces
Asl.Puzzles.FizzBuzz.Tests	 (NUnit tests)

Puzzel - GamesReviews

GamesReviews.Console                             (run this to start demo microservice server and client)
GamesReviews.MicroServices.DataAccess            (Enities, Models, Contexts, Repositories, InMemoryDatabase… IContext/IDbContext can be used to switch easily to Entity Framework)
GamesReviews.MicroServices.DataAccess.Interfaces
GamesReviews.MicroServices.Nancy                 (Nancy is used to implement a basic microservice)
GamesReviews.MicroServices.Nancy.Tests


Puzzel - SuperMarketRegister

Asl.Puzzles.SuperMarketRegister
Asl.Puzzles.SuperMarketRegister.Console           (run this to test the Receipt implementation)
Asl.Puzzles.SuperMarketRegister.Integration.Tests
Asl.Puzzles.SuperMarketRegister.Interfaces
Asl.Puzzles.SuperMarketRegister.Tests             (NUnit tests, including given test)
