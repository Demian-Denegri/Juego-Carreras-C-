namespace Juego_Carrera
{
    internal class Mapa
    {

        private int InicioY { get; set; } = 0;
        private int LargoPared { get; set; } = 10;
        private int LargoEspcios { get; set; } = 15;
        public int InicioX { get; set; } = (Console.WindowWidth / 2) - 18;
        private string ConstruirFila(int LargoPared, int LargoEspcios)//Armo el calculo de una sola fila
        {
            string pared = new string('.', LargoPared);
            string espacios = new string(' ', LargoEspcios);
            string fila = pared + espacios + pared;
            return fila;
        }
        //private List<String> GenerarFilas(int LargoPared, int LargoEspcios, int cantFilas)// genero y almaceno X cantidad de filas en una lista
        //{
        //    List<String> filas = new List<String>();// creo una lista

        //    for (int i = 0; i < cantFilas; i++)
        //    {

        //        filas.Add(ConstruirFila(LargoPared, LargoEspcios));//creo una fila y la almaceno en la lista
        //    }
        //    return filas;//devuelvo la lista de filas
        //}
        private List<(string fila, int x)> filasActuales = new List<(string, int)>();
        public void DibujarFilas(int inicioY, List<(string fila, int x)> filas)
        {

            foreach (var (fila, x) in filas) //desempaqueta cada tupla de la lista en dos variables: "fila"(el string) y "x"(su posición horizontal)
            {
                Console.SetCursorPosition(x, inicioY);
                Console.Write(fila);
                inicioY++;
            }

        }
        public void PantallaInicio()
        {
            Console.WriteLine(" $$$$$$\\                            $$$$$$$\\            $$\\                      \r\n$$  __$$\\                           $$  __$$\\           \\__|                     \r\n$$ /  \\__| $$$$$$\\   $$$$$$\\        $$ |  $$ | $$$$$$\\  $$\\ $$\\    $$\\  $$$$$$\\  \r\n$$ |       \\____$$\\ $$  __$$\\       $$ |  $$ |$$  __$$\\ $$ |\\$$\\  $$  |$$  __$$\\ \r\n$$ |       $$$$$$$ |$$ |  \\__|      $$ |  $$ |$$ |  \\__|$$ | \\$$\\$$  / $$$$$$$$ |\r\n$$ |  $$\\ $$  __$$ |$$ |            $$ |  $$ |$$ |      $$ |  \\$$$  /  $$   ____|\r\n\\$$$$$$  |\\$$$$$$$ |$$ |            $$$$$$$  |$$ |      $$ |   \\$  /   \\$$$$$$$\\ \r\n \\______/  \\_______|\\__|            \\_______/ \\__|      \\__|    \\_/     \\_______|\r\n                                                                                 \r\n                                                                                 \r\n                                                                                 ");
            Console.WriteLine("Controles: ");
            Console.WriteLine("Mover Auto Izquierda: « (Left Arrow)");
            Console.WriteLine("Mover Auto Derecha: » (Right Arrow)");
            Console.WriteLine("Preciona cualquier ENTER para comenzar:");
            Console.ReadLine();
        }


        public void MostrarCircuito()
        {
            Console.Clear();
            foreach (int c in GenerarCircuito())
            {
                if (c == 1)
                {
                    RutaDerecha();
                }
                else if (c == 2)
                {
                    RutaGiroDerecha();
                }
                else RutaGiroIzquierda();

            }
            DibujarFilas(0, filasActuales);// dibuja en pantalla el circuito completo
                                           // (todas las filas acumuladas de las 3 rutas
                                           // (Filas actuales es la turlpa que tiene el
                                           // string de la fila completo y la cordenada x de inicio)),
                                           // arrancando desde arriba (inicioY = 0)
        }

        private List<int> GenerarCircuito()
        {

            List<int> CircuitoGenerado = new List<int>();

            Random random = new Random();
            int ultimoGuardado = 0;

            for (int i = 0; i < 3; i++)
            {

                int ultimo = 0;
                do
                {
                    ultimo = random.Next(1, 4);

                } while (ultimoGuardado == ultimo);// rolleo hasta que no se repitan dos valores iguales seguidos.

                CircuitoGenerado.Add(ultimo);
                ultimoGuardado = ultimo;

            }
            return CircuitoGenerado;
        }//genero un circuito aleatorio
        private void RutaDerecha()
        {
            for (int i = 0; i < 10; i++)
            {
                string fila = ConstruirFila(LargoPared, LargoEspcios);// genero una fila y la guardo en ua variable fila
                filasActuales.Add((fila, InicioX));

            }

        }//Tramo recto

        private void RutaGiroIzquierda()
        {

            for (int i = 0; i < 10; i++)
            {
                string fila = ConstruirFila(LargoPared, LargoEspcios);// creo 1 fila
                filasActuales.Add((fila, InicioX));
                InicioX++; // Avanza a la izquierda en la siguiente fila
            }

        }//Tramo con giro a la izquierda
        private void RutaGiroDerecha()
        {

            for (int i = 0; i < 10; i++)
            {
                string fila = ConstruirFila(LargoPared, LargoEspcios);// creo 1 fila
                filasActuales.Add((fila, InicioX));
                InicioX--; // Avanza a la izquierda en la siguiente fila
            }

        }//Tramo con giro a la derecha

        private void MovimientoMapa()
        {
            filasActuales.RemoveAt(filasActuales.Count - 1); // elimino la ultima fila la de mayor Y
            int ultimoX = filasActuales[filasActuales.Count - 1].x; // guardo la cordenada de x de la ultima fila que se creo
            filasActuales.Insert(0, (ConstruirFila(LargoPared, LargoEspcios), ultimoX));// agrego la fila nueva arriba, con su config
        }

        public void scroll()
        {
            for (int i = 0; i < 100; i++)
            {
                MovimientoMapa();
                DibujarFilas(0, filasActuales);
                Thread.Sleep(200);
            }
        }
    }
}



