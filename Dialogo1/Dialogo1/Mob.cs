using System;

namespace Dialogo1
{
    class Mob
    {
        //--------------------------------------------------------------------------------------------//
        //-- Usa o método LerDialogoEspecifico da clase statica SuportDialogo ,                     --//
        //-- E mantem o controle de qual dialogo foi gerado através da variavel de saida(out) fala, --//
        //-- Para que o Player(Classe que ira responder ao dialogo) saiba como responder            --//
        public string Falar(out string fala)
        {
            string path1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Dialogos\MobDialogos.txt";
            fala = "";

            // -- Dialogos  de 0 a 3 nesse caso--//
            Random r = new Random();
            int nFala = r.Next(0, 3);

            switch (nFala)
            {
                case 0: fala = "D1";
                    break;
                case 1:
                    fala = "D2";
                    break;
                case 2:
                    fala = "D3";
                    break;
            }

            // -- O Replace() Metodo serve para Excluir o D1,D2,...,DN do dialogo, pos isso só serve para identificação , --//
            // -- Não queremos isso na hora do dialogo
            string falaMob = SuportDialogo.LerDialogoEspefico(path1, 400, 400, fala).Replace(fala, "");

            return falaMob;
        }
    }
}
