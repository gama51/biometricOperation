using BioemtricLib;
using System;
using System.IO;
namespace TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            inicio:
            var operacionBiometrica = new OperacionBiometrica();
            operacionBiometrica.init(5000, "/local", true, 76);

            var isBs64 = Convert.ToBoolean(args[2]);
            IRespuesta resp = null;
            if (!isBs64)
            {
                var file1 = File.ReadAllBytes(args[0]);
                var file2 = File.ReadAllBytes(args[1]);
                resp = operacionBiometrica.Verify(file1, file2);
            }

            else {
                var file1 = args[0];
                var file2 = args[1];
                resp = operacionBiometrica.Verify(file1, file2);
            }
            if (resp.Result)
            {
                Console.WriteLine("Veriricación exitosa score :->" + resp.Score);
            }
            else {
                Console.WriteLine("Veriricación fallida score :->" + resp.Score +" Errores: " + resp.Error);
            }
            //Console.ReadKey();
            goto inicio;
        }
    }
}
