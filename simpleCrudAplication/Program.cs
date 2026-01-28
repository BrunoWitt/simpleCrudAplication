using DotNetEnv;
using simpleCrudAplication;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        Env.Load();

        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}
