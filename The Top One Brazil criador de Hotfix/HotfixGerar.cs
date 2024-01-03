using System;
using System.Collections.Generic;
using System.IO;
using Ionic.Zip;


namespace The_Top_One_Brazil_criador_de_Hotfix
{
    internal class HotfixGerar
    {

        public List<String> HotfixGerenciar(String caminhoApp, String numeroProtocolo, DateTime datahoraModificacao, String NomesProgramas, String pastaTemporaria, int opcao)
        {
            List<String> arquivosEncontrados = new List<String>();

            NomesProgramas = NomesProgramas.Replace("\r\n", "");
            NomesProgramas = NomesProgramas.Replace("\r", "");
            NomesProgramas = NomesProgramas.Replace("\n", "");


            if (pastaTemporaria.EndsWith("\\"))
            {
                pastaTemporaria.Substring(0, pastaTemporaria.Length - 1);
            }

            DirectoryInfo diretorioTemporario = new DirectoryInfo(pastaTemporaria);
            DirectoryInfo diretorioHotfix = new DirectoryInfo(pastaTemporaria + "\\" + numeroProtocolo);

            if (!diretorioTemporario.Exists)
            {
                diretorioTemporario.Create();
            }

            if (!diretorioHotfix.Exists)
            {
                diretorioHotfix.Create();
            }

            if (opcao == 1)
            {
                PorDataModificacao(caminhoApp, diretorioHotfix, datahoraModificacao);
            }
            else
            {
                PorNomeArquivo(NomesProgramas, caminhoApp, diretorioHotfix);
            }

            String nomeZip = diretorioHotfix.FullName;

            bool isExiste = true, isPrimera = true;
            int i = 0;
            while (isExiste)
            {
                i++;
                FileInfo arquivoZip = new FileInfo(nomeZip + ".zip");
                if (arquivoZip.Exists)
                {
                    if (isPrimera)
                    {
                        nomeZip = nomeZip + "_";
                        isPrimera = false;
                    }

                    nomeZip = nomeZip + i;
                }
                else
                {
                    isExiste = false;
                }
            }

            DeletarArquivos(diretorioHotfix.FullName);
            DeletarPastas(diretorioHotfix.FullName);

            nomeZip = nomeZip + ".zip";

            CriarZip(diretorioHotfix.FullName, nomeZip, numeroProtocolo);

            return BuscaArquivosEncontrados(diretorioHotfix.FullName);
        }

        public void CriarZip(String diretorio, String nomeArquivoZip, String senha)
        {
			senha = senha.ToLower();
			senha = senha.Replace("fix", "");
			using (ZipFile zip = new ZipFile())
			{
                Console.WriteLine("Senha: " + senha);
				zip.Password = senha;
				zip.AddDirectory(diretorio);
				zip.Save(nomeArquivoZip);
			}
		}

        public void PorNomeArquivo(String NomesProgramas, String caminhoApp, DirectoryInfo diretorioHotfix)
        {

            DirectoryInfo diretorio = new DirectoryInfo(caminhoApp);

            String[] NomesProgramasCollection = NomesProgramas.Split(
                    new string[] { ";" },
                    StringSplitOptions.None
                );

            foreach (String NomePrograma in NomesProgramasCollection)
            {
                if (diretorio.Exists && NomePrograma != "")
                {
                    foreach (FileInfo arquivo in diretorio.EnumerateFiles(string.Format("*{0}*", NomePrograma), SearchOption.AllDirectories))
                    {

                        if (ArquivoValidar(arquivo.Name, NomePrograma))
                        {
                            String novoDiretorio = arquivo.FullName;
                            novoDiretorio = novoDiretorio.Replace(caminhoApp, "");

                            if (novoDiretorio.StartsWith("\\"))
                            {
                                novoDiretorio = novoDiretorio.Substring(1);
                            }

                            CriarPastas(novoDiretorio, diretorioHotfix.FullName);

                            novoDiretorio = diretorioHotfix + "\\" + novoDiretorio;

                            FileInfo novoArquivo = new FileInfo(novoDiretorio);

                            if (!novoArquivo.Exists)
                            {
                                arquivo.CopyTo(novoDiretorio);
                            }
                        }
                    }
                }
            }
        }

        public void PorDataModificacao(String caminhoApp, DirectoryInfo diretorioHotfix, DateTime dataHoraModificacao)
        {

            string[] arquivos = Directory.GetFiles(caminhoApp, "*", SearchOption.AllDirectories);

            foreach (string arquivo in arquivos)
            {
                FileInfo arquivoInfo = new FileInfo(arquivo);


                if (arquivoInfo.LastWriteTime >= dataHoraModificacao)
                {
                    String novoDiretorio = arquivoInfo.FullName;
                    novoDiretorio = novoDiretorio.Replace(caminhoApp, "");

                    if (novoDiretorio.StartsWith("\\"))
                    {
                        novoDiretorio = novoDiretorio.Substring(1);
                    }

                    CriarPastas(novoDiretorio, diretorioHotfix.FullName);

                    novoDiretorio = diretorioHotfix + "\\" + novoDiretorio;

                    FileInfo novoArquivo = new FileInfo(novoDiretorio);

                    if (!novoArquivo.Exists)
                    {
                        arquivoInfo.CopyTo(novoDiretorio);
                    }
                }
            }
        }

        public void CriarPastas(String diretorio, String diretorioHotfix)
        {
            String pastaCriada = "";
            String pastaFaltante = diretorio;
            while (pastaFaltante.Contains("\\"))
            {
                int index = pastaFaltante.IndexOf("\\");
                if (index == -1)
                {
                    break;
                }

                DirectoryInfo directoryInfo = new DirectoryInfo(diretorioHotfix + "\\" + pastaCriada + "\\" + pastaFaltante.Substring(0, index));

                if (!directoryInfo.Exists)
                {

                    directoryInfo.Create();
                }

                pastaCriada = pastaCriada + "\\" + pastaFaltante.Substring(0, index);

                pastaFaltante = pastaFaltante.Replace(pastaFaltante.Substring(0, index + 1), "");
            }
        }

        public void DeletarArquivos(String caminho)
        {
            DirectoryInfo diretorio = new DirectoryInfo(caminho);

            if (diretorio.Exists)
            {
                String[] arquivos = { "*.jar*", "index.html", "manifest-worker.js", "gxprint.js", "keystore.jks", "*.html", ".dll*", ".xls*", "client.cfg", "*erp.db.connections.xml*", "LastTimeCopy*", "CloudServices*", "log4j2*" };

                foreach (String arquivo in arquivos)
                {
                    foreach (FileInfo arquivoDeletar in diretorio.EnumerateFiles(arquivo, SearchOption.AllDirectories))
                    {
                        arquivoDeletar.Delete();
                    }
                }
            }
        }

        public void DeletarPastas(String caminho)
        {
            String[] pastas = { "Debug", "logs", "gxmetadata", "LayoutMetadata", "Metadata", "META-INF", "PublicTempStorage", "NFe", "themes", "drivers", @"static\Resources", @"WEB-INF\private", @"static\Relatorios", @"NFe\Certificado" };

            foreach (String pasta in pastas)
            {

                DirectoryInfo diretorio = new DirectoryInfo(caminho + @"\" + pasta);
                if (diretorio.Exists)
                {
                    diretorio.Delete(true);
                }
            }

            DirectoryInfo diretorioStatic = new DirectoryInfo(caminho + @"\static");
            if (diretorioStatic.Exists)
            {
                if (diretorioStatic.GetFiles().Length == 0 && diretorioStatic.GetDirectories().Length == 0)
                {
                    diretorioStatic.Delete();
                }
            }
        }

        public List<String> BuscaArquivosEncontrados(String caminhoHotfix)
        {
            List<String> arquivos = new List<String>();

            DirectoryInfo hotfix = new DirectoryInfo(caminhoHotfix);

            if (hotfix.Exists)
            {
                String[] CaminhoArquivos = Directory.GetFiles(caminhoHotfix, "*", SearchOption.AllDirectories);

                foreach (String caminho in CaminhoArquivos)
                {
                    arquivos.Add(caminho);
                }
            }

            return arquivos;

        }

        public bool ArquivoValidar(String arquivo, String NomePrograma)
        {

            arquivo = arquivo.ToLower();
			NomePrograma = NomePrograma.ToLower();

			if (arquivo.StartsWith(NomePrograma + "_impl") || arquivo.StartsWith(NomePrograma + ".") || arquivo.StartsWith(NomePrograma + "__default") || arquivo.StartsWith("a" + NomePrograma + ".") || arquivo.StartsWith(NomePrograma + "__api") || arquivo.StartsWith(NomePrograma + "_rest") || arquivo.StartsWith(NomePrograma + "_services") || arquivo.StartsWith(NomePrograma + "_bc") || arquivo.StartsWith("structsdt" + NomePrograma + ".") || arquivo.StartsWith("sdt" + NomePrograma + ".") || arquivo.StartsWith("a" + NomePrograma + "__default") || arquivo.StartsWith("a" + NomePrograma + "__api") || arquivo.StartsWith("a" + NomePrograma + "_rest") || arquivo.StartsWith("a" + NomePrograma + "_services") || arquivo.StartsWith("a" + NomePrograma + "_bc") || arquivo.StartsWith( "a" + NomePrograma + "_impl"))
			{
                return true;
            }

            return false;
        }
    }
}
