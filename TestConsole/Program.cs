using BiometricLibV2;
using Newtonsoft.Json;
using System;
using System.IO;
namespace TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            var operacionBiometrica = new OperacionBiometrica();
            operacionBiometrica.init(5000, "/local", true, 76);

            var isBs64 = Convert.ToBoolean(args[2]);
            string resp = null;
        inicio:
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
            Respuesta resp2 = JsonConvert.DeserializeObject<Respuesta>(resp);
            if (resp2.Result)
            {
                Console.WriteLine("Veriricación exitosa score :->" + resp2.Score);
            }
            else {
                Console.WriteLine("Veriricación fallida score :->" + resp2.Score +" Errores: " + resp2.Error);
            }
            //Console.ReadKey();
            goto inicio;
        }
    }
}
