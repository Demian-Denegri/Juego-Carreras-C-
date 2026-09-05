namespace Juego_Carrera
{
    internal class Mapa
    {

        private int InicioY { get; set; } = 0;
        private int LargoPared { get; set; } = 10;
        private int LargoEspcios { get; set; } = 15;
        public int InicioX { get; set; } = (Console.WindowWidth / 2) - 18; //establezco el inicio para que el circuitoq eude centrado en la ventana
        private List<(string fila, int x)> filasActuales = new List<(string, int)>();

        private string ConstruirFila(int LargoPared, int LargoEspcios)//Armo el calculo de una sola fila
        {
            string pared = new string('.', LargoPared);
            string espacios = new string(' ', LargoEspcios);
            string fila = pared + espacios + pared;
            return fila;
        }

        #region Lista Circuitos Posibles
        private readonly List<List<int>> circuitosDisponibles = new() //una lista que contiene dentro otra lista que contiene enteros
                                                                      //(los enteros son las didrrecciones de la pista).

        //Tipos: 1 = recta, 2 = giro der, 3 = giro izq, 4 = giro der corto, 5 = giro izq corto
        {
            new() { 2, 3, 4, 5 },
            new() { 2, 3, 5, 4 },
            new() { 2, 4, 3, 5 },
            new() { 2, 4, 5, 3 },
            new() { 2, 5, 3, 4 },
            new() { 2, 5, 4, 3 },
            new() { 3, 2, 4, 5 },
            new() { 3, 2, 5, 4 },
            new() { 3, 4, 2, 5 },
            new() { 3, 4, 5, 2 },
            new() { 3, 5, 2, 4 },
            new() { 3, 5, 4, 2 },
            new() { 1, 5, 2, 5 },
            new() { 1, 4, 3, 4 },
         };
        #endregion Lista Circuitos Posibles

        #region Tipos De Ruta
        private void RutaDerecha()
        {
            for (int i = 0; i < 10; i++)
            {
                string fila = ConstruirFila(LargoPared, LargoEspcios);// genero una fila y la guardo en ua variable fila
                filasActuales.Add((fila, InicioX));

            }

        }//Tramo recto

        private void RutaGiroDerecha()
        {

            for (int i = 0; i < 10; i++)
            {
                string fila = ConstruirFila(LargoPared, LargoEspcios);// creo 1 fila
                filasActuales.Add((fila, InicioX));
                InicioX--; // Avanza a la izquierda en la siguiente fila
            }

        }//Tramo con giro a la derecha

        private void RutaGiroIzquierda()
        {

            for (int i = 0; i < 10; i++)
            {
                string fila = ConstruirFila(LargoPared, LargoEspcios);// creo 1 fila
                filasActuales.Add((fila, InicioX));
                InicioX++; // Avanza a la izquierda en la siguiente fila
            }

        }//Tramo con giro a la izquierda

        private void RutaGiroDerechaCorto()
        {
            for (int i = 0; i < 5; i++)
            {
                string fila = ConstruirFila(LargoPared, LargoEspcios);
                filasActuales.Add((fila, InicioX));
                InicioX--;
            }
        }//Tramo con giro corto a la derecha

        private void RutaGiroIzquierdaCorto()
        {
            for (int i = 0; i < 5; i++)
            {
                string fila = ConstruirFila(LargoPared, LargoEspcios);
                filasActuales.Add((fila, InicioX));
                InicioX++;
            }
        }//Tramo con giro corto a la izquierda
        #endregion

        private List<int> GenerarCircuito()
        {
            Random random = new();
            return circuitosDisponibles[random.Next(circuitosDisponibles.Count)]; // selecciono de manera aleatoria uno de los circuitos disponibles
        }

        public void DibujarFilas(int inicioY, List<(string fila, int x)> filas)
        {

            foreach (var (fila, x) in filas) //desempaqueta cada tupla de la lista en dos variables: "fila"(el string) y "x"(su posición horizontal)
            {
                Console.SetCursorPosition(x, inicioY);
                Console.Write(fila);
                inicioY++;
            }

        }

        public void MostrarCircuito()
        {
            Console.Clear();
            foreach (int c in GenerarCircuito())
            {
                switch (c)
                {
                    case 1:
                        RutaDerecha();
                        break;
                    case 2:
                        RutaGiroDerecha();
                        break;
                    case 3:
                        RutaGiroIzquierda();
                        break;
                    case 4:
                        RutaGiroDerechaCorto();
                        break;
                    case 5:
                        RutaGiroIzquierdaCorto();
                        break;
                }
            }
            DibujarFilas(0, filasActuales);// dibuja en pantalla el circuito completo
                                           // (todas las filas acumuladas de las 3 rutas
                                           // (Filas actuales es la turlpa que tiene el
                                           // string de la fila completo y la cordenada x de inicio)),
                                           // arrancando desde arriba (inicioY = 0)
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
        private void MovimientoMapa()//logica para el movimiento del mapa
        {

            filasActuales.RemoveAt(filasActuales.Count - 1); // elimino la ultima fila la de mayor Y
            int ultimoX = filasActuales[filasActuales.Count - 1].x; // guardo la cordenada de x de la ultima fila que se creo
            filasActuales.Insert(0, (ConstruirFila(LargoPared, LargoEspcios), ultimoX));// agrego la fila nueva arriba, con su config
        }
        public void scroll() //bucle para que se mueva el fondo(esto es temporal para realizar las pruevas)
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