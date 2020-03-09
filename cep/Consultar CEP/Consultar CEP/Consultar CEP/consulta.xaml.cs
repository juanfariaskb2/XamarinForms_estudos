using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultar_CEP.Servico.Modelo;
using Consultar_CEP.Servico;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Consultar_CEP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class consulta : ContentPage
{
    public consulta()
    {
        InitializeComponent();

            Botao.Clicked += BuscarCEP;
    }
        private void BuscarCEP(object sender, EventArgs args)
        {
            string cep = CEP.Text.Trim();


            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                    if(end != null)
                        {
                        txtResultado.Text = string.Format("(Endereço): {3} / {0}, {1}-{2}", end.bairro, end.localidade, end.uf, end.logradouro);
                    } else
                    {
                        DisplayAlert("ERRO", "O CEP não foi encontrado =( :" + cep, "OK");
                    }




                    
                                             
                }
                catch (Exception e)
                {
                    DisplayAlert("ERRO CRITICO", e.Message, "OK");
                }
            }
                
        }


        private bool isValidCEP(string cep)
        {
            bool valido = true;
            if (cep.Length != 8)
            {
                //ERRO
                DisplayAlert("ERRO", "CEP inválido! O CEP deve conter 8 caracteres ;-;", "OK");
                valido = false;
            }
            int NovoCEP = 0;

            if(!int.TryParse(cep, out NovoCEP))
            {
                //ERRO
                DisplayAlert("ERRO", "O CEP deve conter somente numeros", "OK");
                valido = false;
            }


            return valido;
        }
    
    
    
    }
}