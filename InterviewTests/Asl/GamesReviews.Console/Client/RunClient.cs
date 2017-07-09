namespace GamesReviews.Console.Client
{
    public class RunClient
    {
        public void Run()
        {
            var one = new UseCaseOne();
            one.Run();

            var two = new UseCaseTwo();
            two.Run();

            var three = new UseCaseThree();
            three.Run();

            System.Console.WriteLine("Press 'Return' to continue...");
            System.Console.ReadLine();
        }
    }
}