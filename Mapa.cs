namespace Juego_Carrera
{
    internal class Mapa
    {
        
        private int InicioY { get; set; } = 0;
        private int LargoPared { get; set; } = 10;
        private int LargoEspcios { get; set; } = 15;
        public int InicioX { get; set; } = (Console.WindowWidth / 2) - 18;
        private string CalcularFilas(int LargoPared, int LargoEspcios)//Armo el calculo de una sola fila
        {
            string pared = new string('.', LargoPared);
            string espacios = new string(' ', LargoEspcios);
            string fila = pared + espacios + pared;
            return fila;
        }
        private List<String> filasMapa(int LargoPared, int LargoEspcios, int cantFilas)// almaceno X cantidad de filas en una lista
        {
            List<String> filas = new List<String>();// creo una lista

            for (int i = 0; i < cantFilas; i++)
            {

                filas.Add(CalcularFilas(LargoPared, LargoEspcios));//creo una fila y la almaceno en la lista
            }
            return filas;//devuelvo la lista de filas
        }
        public void DibujarFilas(int inicioX, int inicioY, List<string> filas)
        {

            foreach (string f in filas)
            {
                Console.SetCursorPosition(inicioX, inicioY);
                Console.Write(f);
                inicioY++;
            }

        }
        public void PantallaInicio()
        {
            Console.WriteLine(" $$$$$$\\                            $$$$$$$\\            $$\\                      \r\n$$  __$$\\                           $$  __$$\\           \\__|                     \r\n$$ /  \\__| $$$$$$\\   $$$$$$\\        $$ |  $$ | $$$$$$\\  $$\\ $$\\    $$\\  $$$$$$\\  \r\n$$ |       \\____$$\\ $$  __$$\\       $$ |  $$ |$$  __$$\\ $$ |\\$$\\  $$  |$$  __$$\\ \r\n$$ |       $$$$$$$ |$$ |  \\__|      $$ |  $$ |$$ |  \\__|$$ | \\$$\\$$  / $$$$$$$$ |\r\n$$ |  $$\\ $$  __$$ |$$ |            $$ |  $$ |$$ |      $$ |  \\$$$  /  $$   ____|\r\n\\$$$$$$  |\\$$$$$$$ |$$ |            $$$$$$$  |$$ |      $$ |   \\$  /   \\$$$$$$$\\ \r\n \\______/  \\_______|\\__|            \\_______/ \\__|      \\__|    \\_/     \\_______|\r\n                                                                                 \r\n                                                                                 \r\n                                                                                 ");
            Console.WriteLine("Controles: ");
            Console.WriteLine("Mover Auto Izquierda: « (Left Arrow)");
            Console.WriteLine("Mover Auto Derecha: » (Right Arrow)");

            Console.WriteLine("Preciona cualquier tecla para comenzar:");
            Console.ReadLine();
        }


        public void MostrarCircuito()
        {
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
                } while (ultimoGuardado == ultimo);// rolleo hasta que no se repitan dos valores iguales seguidos

                CircuitoGenerado.Add(ultimo);
                ultimoGuardado = ultimo;

            }
            return CircuitoGenerado;
        }//genero un circuito aleatorio
        private void RutaDerecha()
        {
            for (int i = 0; i < 10; i++)
            {
                List<string> filas = filasMapa(LargoPared, LargoEspcios, 1); // creo 10 filas
                DibujarFilas(InicioX, InicioY, filas);
                InicioY++;
            }

        }//Tramo recto

        private void RutaGiroIzquierda()
        {

            for (int i = 0; i < 10; i++)
            {
                List<string> filas = filasMapa(LargoPared, LargoEspcios, 1);// creo 1 fila
                DibujarFilas(InicioX, InicioY, filas);
                InicioY++;
                InicioX++; // Avanza a la izquierda en la siguiente fila
            }

        }//Tramo con giro a la izquierda
        private void RutaGiroDerecha()
        {

            for (int i = 0; i < 10; i++)
            {
                List<string> filas = filasMapa(LargoPared, LargoEspcios, 1);// creo 1 fila
                DibujarFilas(InicioX, InicioY, filas);
                InicioY++;
                InicioX--; // Avanza a la izquierda en la siguiente fila
            }

        }//Tramo con giro a la derecha
    }
}



