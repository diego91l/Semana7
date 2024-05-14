using System.Net;

namespace Semana7.Vistas;

public partial class vAgregar : ContentPage
{
	public vAgregar()
	{
		InitializeComponent();
	}

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
		try
		{
			WebClient cliente = new WebClient();
			var parametro = new System.Collections.Specialized.NameValueCollection();
            parametro.Add("codigo", txtCodigo.Text);
			parametro.Add("nombre", txtNombre.Text);
			parametro.Add("apellido", txtApellido.Text);
            parametro.Add("edad", txtEdad.Text);
			cliente.UploadValues("http://localhost:8080/appmovil/post.php", "POST", parametro);
			Navigation.PushAsync(new Inicio());


        }
		catch (Exception ex)
		{

			DisplayAlert("Alerta", ex.Message, "cerrar");
		}
		
    }
}