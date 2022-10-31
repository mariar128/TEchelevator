namespace HotelReservationsClient
{
    class Program
    {
        private const string ApiUrl = "https://localhost:5001/";
        static void Main()
        {
            HotelApp app = new HotelApp(ApiUrl);
            app.Run();
        }
    }
}
