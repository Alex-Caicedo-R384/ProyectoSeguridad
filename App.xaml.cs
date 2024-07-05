using ProyectoSeguridad.APIS.BuildWIth_Domain_API;
using ProyectoSeguridad.ViewModels;

namespace ProyectoSeguridad;

public partial class App : Application

{
    public static ApiCaller1 GlobalApiCaller1 { get; } = new ApiCaller1();
    public static ApiCaller2 GlobalApiCaller2 { get; } = new ApiCaller2();

    public App()
	{
		InitializeComponent();
        MainPage = new AppShell();
	}
}
