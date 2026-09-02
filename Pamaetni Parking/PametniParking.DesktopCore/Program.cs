namespace PametniParking.DesktopCore
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new GlavnaForma());
        }
    }
}