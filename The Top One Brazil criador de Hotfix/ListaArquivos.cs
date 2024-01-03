using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Top_One_Brazil_criador_de_Hotfix
{
	public partial class ListaArquivos : Form
	{
		public ListaArquivos(List<String> arquivos)
		{
			InitializeComponent();

			infoArquivos.Enabled = false;

			foreach (String arquivo in arquivos) { 
				infoArquivos.Text += arquivo + "\r\n"; 
			}	
		}
	}
}
