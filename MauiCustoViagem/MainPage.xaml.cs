
using MauiCustoViagem.Models;
using System.Collections.ObjectModel;

namespace MauiCustoViagem
{
    public partial class MainPage : TabbedPage
    {
        string origem ;
        string destino;

        ObservableCollection<Pedagio> pedagios = new ObservableCollection<Pedagio>();

        public MainPage()
        {
            InitializeComponent();
        }

       

        private void CalculoBtn_Clicked(object sender, EventArgs e)
        {
            decimal valor_total_pedagios = PropriedadesApp.ListaPedagios.Sum(item => item.Valor);

            if (string.IsNullOrEmpty(txt_distancia.Text))
                throw new Exception("Por favor, preencha a distância.");

            if (string.IsNullOrEmpty(txt_combustivel.Text))
                throw new Exception("Por favoe, preencha a consumo do veiculo.");

            if (string.IsNullOrEmpty(txt_combustivel.Text))
                throw new Exception("Por favor , preencha o valor do combustível.");

            decimal consumo = Convert.ToDecimal(txt_combustivel.Text);
            decimal preco_combustivel = Convert.ToDecimal(txt_combustivel.Text);
            decimal distancia = Convert.ToDecimal(txt_distancia.Text);

            decimal consumo_carro = (distancia / consumo) * preco_combustivel;

            decimal custo_total = consumo_carro + totalped;

            string origem = txt_origem.Text;
            string destino = txt_destino.Text;

            //DisplayAlert("")
        }

        private async void LimparBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool Confirmar = await DisplayAlert("Tem Certeza?", "Deseja remover?", "Sim", "Não");

                if (Confirmar)
                {
                    txt_origem.Text = "";
                    txt_destino.Text = "";
                    txt_distancia.Text = "";
                    txt_combustivel.Text = "";
                    txt_rendimento.Text = "";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }

        }

        

        private async void LimparpedBtn_Clicked(object sender, EventArgs e)
        {

        }

        private void lst_Pedagio_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            try
            {
                Pedagio p = new Pedagio()
                {
                    local = txtLocal.Text,
                    valor = double.Parse(txtValorPed.Text)
                };
                
            }catch (Exception ex)
            {

            }
          

        }

        private void btnSomarPed_Clicked(object sender, EventArgs e)
        {
            double totalped = lst_Pedagio.Sum(i => (i.Lugar * i));
            string msg = $"O total é{totalped:C}";
            DisplayAlert("Somatória", msg, "Fechar");
        }
    }

}
