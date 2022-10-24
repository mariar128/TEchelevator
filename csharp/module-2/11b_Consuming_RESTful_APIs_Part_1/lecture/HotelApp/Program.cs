namespace HotelApp
{
    class Program
    {
        private const string ApiUrl = "http://localhost:3000/"; // the URL of the API we want to get 
        static void Main()
        {
            HotelApp app = new HotelApp(ApiUrl);
            app.Run();
        }
    }
}
