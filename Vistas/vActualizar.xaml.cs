using Semana7.Modelos;
using System.Net;

namespace Semana7.Vistas;

public partial class vActualizar : ContentPage
{
	public vActualizar(Estudiante datos)
	{
		InitializeComponent();
		txtCodigo.Text = datos.codigo.ToString();
		txtNombre.Text = datos.nombre;
        txtApellido.Text = datos.apellido;
		txtEdad.Text = datos.edad.ToString();
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {

    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {

    }
}