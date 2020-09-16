using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranscribirMontos
{
    class Transcribir
    {
        public Transcribir(string monto)
        {
            this.monto = monto;
            this.digitos = monto.Length;
        }

        public static void LeerMonto(string monto)
        {

            if (IsDecimal(monto))
            {
                Console.WriteLine("Este número tiene decimales.");
                if (EsSeparable(monto))
                {
                    Console.WriteLine("Este número es separable.");
                    var cifras = SepDigitosConDecimales(monto);
                    Imprimir(cifras);
                    Console.WriteLine(SepDecimales(monto));
                    Console.WriteLine("Cantidad de digitos {0} y cantidad de partes {1}",CantidadDigitos(monto),CantidadPartes(cifras));
                    ImprimirDigitos(monto);


                    var SalidaEnteros = LeerDigitos(cifras, CantidadPartes(cifras));

                    var Decimales = SepDecimales(monto);
                    if(Decimales.Length > 3)
                    {
                        throw new Exception("El número de Cifras Decimales excedió 3 cifras.");
                    }

                    var SalidaDecimales = LeerDigitos(Decimales);

                    Console.WriteLine(SalidaEnteros + " PESOS CON " + SalidaDecimales + " CENTAVOS");

                }
                else
                {
                    Console.WriteLine("Este número no es separable.");
                    var cifras = SepDigitosDecimal(monto);
                    Console.WriteLine(cifras);
                    Console.WriteLine(SepDecimales(monto));
                    Console.WriteLine("Cantidad de digitos {0}", CantidadDigitos(monto));
                    ImprimirDigitos(monto);

                    var SalidaEnteros = LeerDigitos(cifras);

                    var Decimales = SepDecimales(monto);
                    if (Decimales.Length > 3)
                    {
                        throw new Exception("El número de Cifras Decimales excedió 3 cifras.");
                    }

                    var SalidaDecimales = LeerDigitos(Decimales);

                    Console.WriteLine(SalidaEnteros + " PESOS CON "+ SalidaDecimales+" CENTAVOS");

                }             

            }
            else
            {
                Console.WriteLine("Este número no tiene decimales.");
                if (EsSeparable(monto))
                {
                    Console.WriteLine("Este número es separable.");
                    var cifras = SepDigitos(monto);
                    Imprimir(cifras);
                    Console.WriteLine("Cantidad de digitos {0} y cantidad de partes {1}", CantidadDigitos(monto), CantidadPartes(cifras));
                    ImprimirDigitos(monto);

                    var Salida = LeerDigitos(cifras, CantidadPartes(cifras));

                    Console.WriteLine(Salida + " PESOS");

                }
                else
                {
                    Console.WriteLine("Este número no es separable.");
                    Console.WriteLine(monto);
                    Console.WriteLine("Cantidad de digitos {0}", CantidadDigitos(monto));
                    ImprimirDigitos(monto);

                    var Salida = LeerDigitos(monto);

                    Console.WriteLine(Salida + " PESOS");


                }
                
            }
        }

        private static bool IsDecimal(string monto)
        {
            bool response = false;

            if (monto.Contains("."))
                response = true;

            return response;
        }

        private static bool EsSeparable(string monto)
        {
            bool decision = false;
            if (monto.Contains(','))
            {
                int index = monto.IndexOf(',');
                var prueba = monto.Substring(index + 1, 3);

                if (prueba.Length == 3 && (!prueba.Contains('.')))
                {
                    decision = true;
                }
                else
                {
                    throw new Exception("Necesita separar con ',' despues de cada 3 digitos.");
                }

            }
            //else
            //{
            //    if (IsDecimal(monto))
            //    {
            //        int index = monto.IndexOf('.');
            //        var prueba = monto.Remove(index);
            //        if (prueba.Length > 3)
            //        {
            //            throw new Exception("Necesita separar con ',' despues de cada 3 digitos.");
            //        }
            //    }
            //    if(monto.Length > 3)
            //    {
            //        throw new Exception("Necesita separar con ',' despues de cada 3 digitos."); 
            //    }
            //}

            return decision;
        }

        private static string[] SepDigitosConDecimales(string cifras)
        {
            var numeros = cifras.Split(',');
            string[] Numeros = new string[numeros.Length];

            for(int i = 0; i < numeros.Length; i++)
            {
                if (!numeros[i].Contains('.'))
                {
                    Numeros[i] = numeros[i];
                }
                else
                {
                    int index = numeros[i].IndexOf('.');
                    Numeros[i] = numeros[i].Remove(index);
                }
            }

            return Numeros;
        }

        private static string[] SepDigitos(string cifras)
        {
            var numeros = cifras.Split(',');

            return numeros;
        }

        private static string SepDigitosDecimal(string cifras)
        {
            var numeros = cifras.Split('.');
            var numero = numeros[0];
            return numero;
        }

        private static string SepDecimales(string decimales)
        {
            string Decimales = "";
            var numeros = SepDigitos(decimales);
            for(int i = 0; i < numeros.Length; i++)
            {
                if (numeros[i].Contains('.'))
                {
                    int index = numeros[i].IndexOf('.');
                   Decimales = numeros[i].Substring(index+1);
                }
            }

            return Decimales;
        }

        private static void Imprimir(string[] partes)
        {
            for(int i = 0; i < partes.Length; i++)
            {
                Console.WriteLine(partes[i]);
            }
        }

        private static void ImprimirDigitos(string partes)
        {
            for (int i = 0; i < partes.Length; i++)
            {
                if(!(partes[i] == ',' | partes[i] == '.'))
                Console.WriteLine(partes[i]);
            }
        }

        private static int CantidadDigitos(string partes)
        {
            int numDigitos = 0;

            for (int i = 0; i < partes.Length; i++)
            {
                if (!(partes[i] == ',' | partes[i] == '.'))
                    numDigitos++;
            }

            return numDigitos;
        }

        private static int CantidadPartes(string[] partes)
        {
            return partes.Length;
        }

        private static string ConvertirUnidades(char unidad)
        {
            Dictionary<char, string> Unidades = new Dictionary<char, string>();
            Unidades.Add('0', "");
            Unidades.Add('1', "UN");
            Unidades.Add('2', "DOS");
            Unidades.Add('3', "TRES");
            Unidades.Add('4', "CUATRO");
            Unidades.Add('5', "CINCO");
            Unidades.Add('6', "SEIS");
            Unidades.Add('7', "SIETE");
            Unidades.Add('8', "OCHO");
            Unidades.Add('9', "NUEVE");

            return Unidades[unidad];
        }

        private static string ConvertirDecenasPerfectas(string decena)
        {
            Dictionary<string, string> Decenas = new Dictionary<string, string>();
            Decenas.Add("10", "DIEZ");
            Decenas.Add("20", "VEINTE");
            Decenas.Add("30", "TRENTA");
            Decenas.Add("40", "CUARENTE");
            Decenas.Add("50", "CINCUENTA");
            Decenas.Add("60", "SESENTA");
            Decenas.Add("70", "SETENTA");
            Decenas.Add("80", "OCHENTA");
            Decenas.Add("90", "NOVENTA");

            return Decenas[decena];
        }

        private static string ConvertirDecenas(char decena)
        {
            Dictionary<char, string> Decenas = new Dictionary<char, string>();
            Decenas.Add('0', "");
            Decenas.Add('2', "VENTI");
            Decenas.Add('3', "TRENTA");
            Decenas.Add('4', "CUARENTA");
            Decenas.Add('5', "CINCUENTA");
            Decenas.Add('6', "SESENTA");
            Decenas.Add('7', "SETENTA");
            Decenas.Add('8', "OCHENTA");
            Decenas.Add('9', "NOVENTA");

            return Decenas[decena];
        }

        private static string ConvertirDecenasEspecial(string unidad)
        {
            Dictionary<string, string> DecenasEspeciales = new Dictionary<string, string>();
            DecenasEspeciales.Add("11", "ONCE");
            DecenasEspeciales.Add("12", "DOCE");
            DecenasEspeciales.Add("13", "TRECE");
            DecenasEspeciales.Add("14", "CATORCE");
            DecenasEspeciales.Add("15", "QUINCE");
            DecenasEspeciales.Add("16", "DIECISEIS");
            DecenasEspeciales.Add("17", "DIECISIETE");
            DecenasEspeciales.Add("18", "DIECIOCHO");
            DecenasEspeciales.Add("19", "DIECINUEVE");

            return DecenasEspeciales[unidad];
        }

        private static string ConvertirCentenasPerfectas(string unidad)
        {
            Dictionary<string, string> Unidades = new Dictionary<string, string>();
            Unidades.Add("100", "CIEN");
            Unidades.Add("200", "DOCIENTOS");
            Unidades.Add("300", "TRESIENTOS");
            Unidades.Add("400", "CUATROCIENTOS");
            Unidades.Add("500", "QUINIENTOS");
            Unidades.Add("600", "SEISIENTOS");
            Unidades.Add("700", "SETECIENTOS");
            Unidades.Add("800", "OCHOCIENTOS");
            Unidades.Add("900", "NOVECIENTOS");

            return Unidades[unidad];
        }

        private static string ConvertirCentenas(char unidad)
        {
            Dictionary<char, string> Unidades = new Dictionary<char, string>();
            Unidades.Add('1', "CIENTO");
            Unidades.Add('2', "DOCIENTO");
            Unidades.Add('3', "TRESIENTO");
            Unidades.Add('4', "CUATROCIENTO");
            Unidades.Add('5', "QUINIENTO");
            Unidades.Add('6', "SEISIENTO");
            Unidades.Add('7', "SETECIENTO");
            Unidades.Add('8', "OCHOCIENTO");
            Unidades.Add('9', "NOVECIENTO");

            try
            {
                return Unidades[unidad];
            }
            catch (KeyNotFoundException)
            {
                return "";
            }
        }

        private static string LeerDigitos(string[] partes,int cantPartes)
        {
            string Transcipcion = "";


            switch (cantPartes)
            {
                case 1:
                    Transcipcion += LeerDigitos(partes[0]);
                    break;
                case 2:
                    if (partes[0] == "1")
                    {
                        Transcipcion += "MIL ";
                        Transcipcion += LeerDigitos(partes[1]);
                    }
                    else
                    {
                        for (int i = 0; i < cantPartes; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    Transcipcion += (LeerDigitos(partes[i]) + " MIL ");
                                    break;
                                case 1:
                                    Transcipcion += (LeerDigitos(partes[i]));
                                    break;
                            }
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < cantPartes; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                Transcipcion += (LeerDigitos(partes[i]) + " MILLONES ");
                                break;
                            case 1:
                                var numero = partes[i];
                                if (numero[0] == '0' && numero[1] == '0' && numero[2] == '0')
                                {
                                    Transcipcion += " ";
                                }
                                else
                                {
                                    Transcipcion += (LeerDigitos(partes[i]) + " MIL ");
                                }
                                break;
                            case 2:
                                Transcipcion += (LeerDigitos(partes[i]));
                                break;
                        }
                    }
                    break;
            }

            return Transcipcion;
        }

        private static string LeerDigitos(string numeros)
        {
            var numDigitos = CantidadDigitos(numeros);
            string Transcipcion = "";

            switch (numDigitos)
            {
                case 1:
                    foreach (var num in numeros)
                    {
                        Transcipcion += (ConvertirUnidades(num) + " ");
                    }
                    break;
                case 2:
                    if (numeros[0] == '0')
                    {
                        Transcipcion +=  "";
                        ///////------------///////AGREGAR A LA LISTA DEDECNAS MAS CASOS DE DECENAS///////------------///////
                    }
                    else if (numeros[1] == '0')
                    {
                        Transcipcion += (ConvertirDecenasPerfectas(numeros) + " ");
                    }
                    else if (DecenasEspeciales.Contains(numeros))
                    {
                        Transcipcion += (ConvertirDecenasEspecial (numeros) + " ");
                    }
                    else
                    {
                        for (int i = 0; i < numeros.Length; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    Transcipcion += (ConvertirDecenas(numeros[i]) + " ");
                                    break;
                                case 1:
                                    Transcipcion += (" Y "+ConvertirUnidades(numeros[i]) + " ");
                                    break;
                            }
                        }
                    }
                    break;
                case 3:
                    if (numeros[0] == '0' && numeros[1] == '0' && numeros[2] == '0')
                    {
                        Transcipcion += "";
                    }
                    else if (numeros[1] == '0' && numeros[2] == '0')
                    {
                        Transcipcion += (ConvertirCentenasPerfectas(numeros) +" ");
                    }
                    else
                    {
                        Transcipcion += (ConvertirCentenas(numeros[0]) + " ");
                        if (numeros[1] == '0')
                        {
                            Transcipcion += "";
                            Transcipcion += LeerDigitos(numeros.Substring(2));
                        }
                        else
                        {
                            var numeros2 = numeros.Substring(1);
                            Transcipcion += LeerDigitos(numeros2);
                        }

                    }
                    break;
            }

            return Transcipcion;
        }

        public string monto { get; set; }
        public string[] numeros { get; set; }
        public int digitos;
        public static List<string> DecenasEspeciales = new List<string>() { "10", "11", "12", "13", "14", "15", "16", "17", "18", "19" };
    }
}
