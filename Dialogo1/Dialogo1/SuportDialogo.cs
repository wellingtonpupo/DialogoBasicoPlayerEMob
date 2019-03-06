using System;
using System.Text;
using System.IO;


namespace Dialogo1
{
    public static class SuportDialogo
    {

        public static string LerDialogoEspefico(string path, int sizeDialogos, int count, 
                                                string inicioDialogo, char caractereFimDialogo = ';')
        {
            StringBuilder dialogos = new StringBuilder(Encoding.ASCII.GetString(DialogosBytes(path, sizeDialogos, count)));
         
            int inicioDialogoIndice = dialogos.ToString().IndexOf(inicioDialogo);
            int fimDialogoIndice = dialogos.ToString().IndexOf(caractereFimDialogo, inicioDialogoIndice);

            // -- Ajuste na posicão dos índices -- //
            return dialogos.ToString().Substring(inicioDialogoIndice,
                                     dialogos.ToString().IndexOf(caractereFimDialogo, inicioDialogoIndice) - inicioDialogoIndice);     
        }

        private static byte[] DialogosBytes(string path, int sizeDialogos, int count)
        {
            byte[] dialogosB = new byte[sizeDialogos];

            if (File.Exists(path))
                using (FileStream sr = File.OpenRead(path))
                    sr.Read(dialogosB, 0, count);
            //--------------------------------------------------------------------------//
            //-- Se nao existir o caminho cria um e adiciona os dialogos,             --//
            //-- ou seja esse else acontece somente uma vez caso não exista o caminho, --//
            //-- pois na proxima vez que o metodo for invocado o caminho ira existir  --//
            else
            {
                using (FileStream sr = File.Create(path))
                {
                    StringBuilder sb = new StringBuilder(@"D1Seu sofrimento e minha diversao;
                                                           D2A escuridao acalma tudo;
                                                           D3Zero divido por um numero qualquer e sua chance de sobreviver;");
                    int i = 0;
                    foreach (var item in sb.ToString())
                    {
                        dialogosB[i] = Convert.ToByte(sb[i]);
                        i++; 
                    }

                    sr.Write(dialogosB, 0, count);
                }
            }
         
            return dialogosB; 
        }
    }
}
