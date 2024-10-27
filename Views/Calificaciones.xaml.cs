namespace TAREA2.Views;

public partial class Calificaciones : ContentPage
{
    public Calificaciones()
    {
        InitializeComponent();
    }

    private async void btnCalcularNota_Clicked(object? sender, EventArgs e)
    {
        if (pickerEstudiante.SelectedIndex == -1 ||
            !double.TryParse(txtSeguimiento1.Text, out double seguimiento1) ||
            !double.TryParse(txtExamen1.Text, out double examen1) ||
            !double.TryParse(txtSeguimiento2.Text, out double seguimiento2) ||
            !double.TryParse(txtExamen2.Text, out double examen2) ||
            seguimiento1 < 0 || seguimiento1 > 10 ||
            examen1 < 0 || examen1 > 10 ||
            seguimiento2 < 0 || seguimiento2 > 10 ||
            examen2 < 0 || examen2 > 10)
        {
            await DisplayAlert("Error", "Por favor, ingrese todos los datos correctamente. Las notas deben estar entre 0 y 10.", "OK");
            return;
        }

        double notaParcial1 = (seguimiento1 * 0.3) + (examen1 * 0.2);
        double notaParcial2 = (seguimiento2 * 0.3) + (examen2 * 0.2);
        double notaFinal = notaParcial1 + notaParcial2;

        lblParcial1.Text = notaParcial1.ToString("F2");
        lblParcial2.Text = notaParcial2.ToString("F2");
        lblNotaFinal.Text = notaFinal.ToString("F2");

        string estado;
        if (notaFinal >= 7)
            estado = "Aprobado";
        else if (notaFinal >= 5 && notaFinal <= 6.9)
            estado = "Complementario";
        else
            estado = "Reprobado";

        lblEstado.Text = estado;
        lblEstado.TextColor = estado == "Aprobado" ? Colors.Green : (estado == "Complementario" ? Colors.Orange : Colors.Red);

        DateTime fecha = datePickerFecha.Date;

        string mensaje = $"Nombre: {pickerEstudiante.SelectedItem}\n" +
                         $"Fecha: {fecha:dd/MM/yyyy}\n" +
                         $"Nota Parcial 1: {notaParcial1:F2}\n" +
                         $"Nota Parcial 2: {notaParcial2:F2}\n" +
                         $"Nota Final: {notaFinal:F2}\n" +
                         $"Estado: {estado}";

        await DisplayAlert("Resumen", mensaje, "OK");
    }
}


