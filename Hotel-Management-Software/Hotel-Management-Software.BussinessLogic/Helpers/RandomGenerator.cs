namespace Hotel_Management_Software.BussinessLogic.Helpers;

public static class RandomGenerator
{
    private static readonly Random random = new Random();

    public static int Generate()
    {
        return random.Next(100000, 1000000); 
    }
}
