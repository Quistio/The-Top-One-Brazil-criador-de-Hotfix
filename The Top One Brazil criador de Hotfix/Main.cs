using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Collections;
using System.DirectoryServices;

namespace The_Top_One_Brazil_criador_de_Hotfix
{
    public partial class Main : Form
    {
        public List<String> arquivosEncontrados = new List<String>();

        public Main()
        {
            InitializeComponent();

            PorNomePrograma.Checked = true;
            PorDataHora.Checked = false;
            NomesProgramas.Enabled = true;
            DataHoraModificao.Enabled = false;

            Total.Text = "";
            NumeroProtocolo.Text = "FIX";
            try
            {
                ArquivoPadraoLer();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
        }

			private void PorDataHora_CheckedChanged(object sender, EventArgs e)
        {
            if (PorDataHora.Checked)
            {
                NomesProgramas.Enabled = false;
                PorNomePrograma.Checked = false;
                DataHoraModificao.Enabled = true;
                NomesProgramas.Text = "";
                DataHoraModificao.Text = DateTime.Now.AddMinutes(-10).ToString();
            }

            if (!PorDataHora.Checked)
            {
                DataHoraModificao.Enabled = false;
                DataHoraModificao.Text = "";
            }
        }

        private void PorNomePrograma_CheckedChanged(object sender, EventArgs e)
        {
            if (PorNomePrograma.Checked)
            {
                DataHoraModificao.Enabled = false;
                PorDataHora.Checked = false;
                NomesProgramas.Enabled = true;
                DataHoraModificao.Text = "";
            }

            if (!PorNomePrograma.Checked)
            {
                NomesProgramas.Enabled = false;
                NomesProgramas.Text = "";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                ArquivoPadraoGravar();
            }
            catch (Exception ex)
            {
				MessageBox.Show("Erro: " + ex.ToString());
			}

			if (CamposValidar())
            {

				pastaTemporaria.Text = pastaTemporaria.Text.Trim();
                NomesProgramas.Text = NomesProgramas.Text.Trim();
                CaminhoApp.Text = CaminhoApp.Text.Trim();


				Total.Text = "";

                DateTime dateTime = DateTime.Now;
                if (DataHoraModificao.Text != "")
                {
                    dateTime = Convert.ToDateTime(DataHoraModificao.Text);
                }

                int opacao = 0;

                if (PorDataHora.Checked)
                {
                    opacao = 1;
                }
                else
                {
                    opacao = 2;
                }

                arquivosEncontrados.Clear();

                HotfixGerar hotfix = new HotfixGerar();

                try
                {
                    arquivosEncontrados = hotfix.HotfixGerenciar(CaminhoApp.Text, NumeroProtocolo.Text, dateTime, NomesProgramas.Text, pastaTemporaria.Text, opacao);
					Total.Text = "Foram encontrados " + arquivosEncontrados.Count.ToString() + " arquivos.";
					MessageBox.Show("Gerado Hotfix");
				}
                catch (Exception ex)
                {
					MessageBox.Show("Erro: "+ ex.ToString());
				}
				
            }
        }

        private bool CamposValidar()
        {
            error.Clear();

            if(pastaTemporaria.Text == "")
            {
				error.SetError(pastaTemporaria, "Deve ser informado o caminho da pasta temporária");
				return false;
            }
            else
            {
                if (!CaminhoExiste(pastaTemporaria.Text))
                {
					error.SetError(pastaTemporaria, "Caminho não encontrado");
					return false;
				}
			}

            if (CaminhoApp.Text == "")
            {
               error.SetError(CaminhoApp, "Deve ser informado o caminho da aplicação");
                return false;
            }
            else
            {
				if (!CaminhoExiste(CaminhoApp.Text))
				{
					error.SetError(CaminhoApp, "Caminho não encontrado");
					return false;
				}
			}

            if (NumeroProtocolo.Text == "")
            {
                error.SetError(NumeroProtocolo, "Deve ser informado o nome do Hotfix");
                return false;
            }

            if(NomesProgramas.Text == "" && PorNomePrograma.Checked)
            {
                error.SetError(NomesProgramas, "Deve ser informado o nome dos programas");
                return false;
            }

            if (DataHoraModificao.Text == "" && PorDataHora.Checked)
            {
                error.SetError(DataHoraModificao, "Deve ser informado o nome dos programas");
                return false;
            }

			if (PorDataHora.Checked && DataHoraModificao.Text != "")
			{
				DateTime value;
				if (!DateTime.TryParse(DataHoraModificao.Text, out value)) {
					error.SetError(DataHoraModificao, "Data hora informada incorretamente");
					return false;
				}
			}
            

            return true;
        }

        private void ArquivoPadraoLer()
        {

            String caminho = System.Environment.CurrentDirectory + @"\config.xml";
            FileInfo xmlConfigArquivo = new FileInfo(caminho);
            StreamWriter xmlConfig;

            if (!xmlConfigArquivo.Exists)
            {
                xmlConfigArquivo.Create().Dispose();
                
                xmlConfig = File.CreateText(caminho);
                xmlConfig.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                xmlConfig.WriteLine("<padrao>");
                xmlConfig.WriteLine("<pastaTemporaria></pastaTemporaria>");
                xmlConfig.WriteLine("<aplicacao></aplicacao>");
                xmlConfig.WriteLine("</padrao>");
                xmlConfig.Close();
            }

            if (xmlConfigArquivo.Exists)
            {
                XmlTextReader xmlReader = new XmlTextReader(caminho);

                while (xmlReader.Read())
                {
                    switch (xmlReader.Name)
                    {
                        case "pastaTemporaria":
                            pastaTemporaria.Text = xmlReader.ReadString();
                            break;

                        case "aplicacao":
                            CaminhoApp.Text = xmlReader.ReadString();
                            break;
                    }
                }

                xmlReader.Close();
            }
        }

		private void ArquivoPadraoGravar()
        {

            String caminho = System.Environment.CurrentDirectory + @"\config.xml";
            FileInfo xmlConfigArquivo = new FileInfo(caminho);
            StreamWriter xmlConfig;

            if (xmlConfigArquivo.Exists)
            {
                xmlConfigArquivo.Delete();
                xmlConfigArquivo.Create().Dispose();

                xmlConfig = File.CreateText(caminho);
                xmlConfig.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                xmlConfig.WriteLine("<padrao>");
                xmlConfig.WriteLine("<pastaTemporaria>"+pastaTemporaria.Text+"</pastaTemporaria>");
                xmlConfig.WriteLine("<aplicacao>"+CaminhoApp.Text+"</aplicacao>");
                xmlConfig.WriteLine("</padrao>");
                xmlConfig.Close();
            }

        }

		private void Total_Click(object sender, EventArgs e)
		{
            ListaArquivos listaArquivos = new ListaArquivos(arquivosEncontrados);
            listaArquivos.Show();
		}

		private void searchDiretory_Click(object sender, EventArgs e)
		{

		}

        private bool CaminhoExiste(String caminho)
        {
			DirectoryInfo directorio = new DirectoryInfo(caminho);

            if (!directorio.Exists)
            {
				return false;
			}

            return true;
		}
	}
}
