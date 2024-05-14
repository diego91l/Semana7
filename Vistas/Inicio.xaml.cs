using Newtonsoft.Json;
using Semana7.Modelos;
using System.Collections.ObjectModel;


namespace Semana7.Vistas;

public partial class Inicio : ContentPage
{
	private const string Url = "http://localhost:8080/appmovil/post.php";

	private readonly HttpClient cliente = new HttpClient();

	private ObservableCollection<Estudiante> estud;
    public Inicio()
	{
		InitializeComponent();
		Obtener();
	}

	public async void Obtener()
	{
		var content = await cliente.GetStringAsync(Url);
		List<Estudiante> mostrarEst = JsonConvert.DeserializeObject<List<Estudiante>>(content);
		estud = new ObservableCollection<Estudiante>(mostrarEst);
		listaestudiantes.ItemsSource = estud;
	}
    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new vAgregar());	
    }

    private void listaestudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var objestudiante = (Estudiante)e.SelectedItem;
		Navigation.PushAsync(new vActualizar(objestudiante));
    }
}