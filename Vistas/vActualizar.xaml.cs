using Semana7.Modelos;
using System.Net;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using Microsoft.Maui.Controls;
using System.Reflection.Metadata;


namespace Semana7.Vistas;

public partial class vActualizar : ContentPage
{
    private Estudiante estudiante;
    public vActualizar(Estudiante datos)
	{
		InitializeComponent();
        estudiante = datos;
        txtCodigo.Text = datos.codigo.ToString();
		txtNombre.Text = datos.nombre;
        txtApellido.Text = datos.apellido;
		txtEdad.Text = datos.edad.ToString();

        btnActualizar.Clicked += btnActualizar_Clicked;
        btnEliminar.Clicked += btnEliminar_Clicked;
    }

    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            estudiante.codigo = Convert.ToInt32(txtCodigo.Text);
            estudiante.nombre = txtNombre.Text;
            estudiante.apellido = txtApellido.Text;
            estudiante.edad = Convert.ToInt32(txtEdad.Text);

            string jsonEstudiante = JsonConvert.SerializeObject(estudiante);
            StringContent content = new StringContent(jsonEstudiante, Encoding.UTF8, "application/json");

            HttpClient cliente = new HttpClient();
            HttpResponseMessage response = await cliente.PutAsync("http://localhost:8080/appmovil/post.php", content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Éxito", "Registro actualizado correctamente", "Cerrar");
                await Navigation.PopAsync(); // Regresa a la página anterior
            }
            else
            {
                await DisplayAlert("Error", "No se pudo actualizar el registro", "Cerrar");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Alerta", ex.Message, "cerrar");
        }

    }



    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var uri = new Uri($"http://localhost:8080/appmovil/post.php?codigo={txtCodigo.Text}");

            cliente.UploadStringCompleted += (s, ev) =>
            {
                if (ev.Error == null)
                {
                    DisplayAlert("Éxito", "Registro eliminado correctamente", "Cerrar");
                    Navigation.PushAsync(new Inicio());
                }
                else
                {
                    DisplayAlert("Error", "No se pudo eliminar el registro", "Cerrar");
                }
            };

            cliente.UploadStringAsync(uri, "DELETE", string.Empty);
        }
        catch (Exception ex)
        {
            DisplayAlert("Alerta", ex.Message, "cerrar");
        }
    }

}
