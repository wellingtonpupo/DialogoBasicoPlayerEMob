using System;

namespace Dialogo1
{
    class Player
    {
        public void Responder()
        {
            //-- Vocé nunca vai querer estancia um mob aqui isso só serve para teste, --//
            //-- Você deve achar uma outra maneira de fazer isso                      -//
            Mob mob = new Mob();
            Console.WriteLine(mob.Falar(out string fala));

            if (fala == "D1")
                Console.WriteLine("Certo");
            else if (fala == "D2")
                Console.WriteLine("hUM...");
            else
                Console.WriteLine("A Luz prevalecerá");
        }
    }
}
