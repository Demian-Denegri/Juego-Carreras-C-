namespace Juego_Carrera
{
    internal class Mapa
    {

        private int InicioY { get; set; } = 0;
        private int LargoPared { get; set; } = 10;
        private int LargoEspcios { get; set; } = 20;
        public int InicioX { get; set; }
        private int InicioXOriginal;
        private int score = 0;
        public int CentroCarril => InicioXOriginal + LargoPared + LargoEspcios / 2; //para que la nave aparezca ne el centro
        private List<(string fila, int x)> filasActuales = new List<(string, int)>();
        private List<int> circuitoActual;

        public Mapa()
        {
            InicioX = (Console.WindowWidth / 2) - 18;
            InicioXOriginal = InicioX;
            circuitoActual = GenerarCircuito();
        }

        private string ConstruirFila(int LargoPared, int LargoEspcios)//Armo el calculo de una sola fila
        {

            string pared = new string('█', LargoPared);
            string espacios = new string(' ', LargoEspcios);
            string fila = pared + espacios + pared;
            return fila;
        }

        #region Lista Circuitos Posibles
        private readonly List<List<int>> circuitosDisponibles = new() //una lista que contiene dentro otra lista que contiene enteros
                                                                       //(los enteros son las didrrecciones de la pista).

        //Tipos: 1 = recta, 2 = giro der, 3 = giro izq, 4 = giro der corto, 5 = giro izq corto
        {

            new() { 2, 3, 4, 5 },//ok
            new() { 2, 3, 5, 4 },//ok
            new() { 2, 5, 3, 4 },//ok
            new() { 2, 5, 4, 3 },//ok
            new() { 3, 2, 4, 5 },//ok
            new() { 3, 2, 5, 4 },//ok
            new() { 3, 4, 2, 5 },//ok
            new() { 3, 4, 5, 2 },//ok
            new() { 1, 5, 2, 5 },//ok
            new() { 1, 4, 3, 4 },//ok

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

        private void ConstruirFilas(List<int> circuito)
        {
            filasActuales.Clear();
            InicioX = InicioXOriginal;

            foreach (int c in circuito)
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

        private void MostrarCircuito()
        {
            ConstruirFilas(circuitoActual);
            DibujarFilas(0, filasActuales);
        }

        public void PantallaInicio()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(" $$$$$$\\                            $$$$$$$\\            $$\\                      \r\n$$  __$$\\                           $$  __$$\\           \\__|                     \r\n$$ /  \\__| $$$$$$\\   $$$$$$\\        $$ |  $$ | $$$$$$\\  $$\\ $$\\    $$\\  $$$$$$\\  \r\n$$ |       \\____$$\\ $$  __$$\\       $$ |  $$ |$$  __$$\\ $$ |\\$$\\  $$  |$$  __$$\\ \r\n$$ |       $$$$$$$ |$$ |  \\__|      $$ |  $$ |$$ |  \\__|$$ | \\$$\\$$  / $$$$$$$$ |\r\n$$ |  $$\\ $$  __$$ |$$ |            $$ |  $$ |$$ |      $$ |  \\$$$  /  $$   ____|\r\n\\$$$$$$  |\\$$$$$$$ |$$ |            $$$$$$$  |$$ |      $$ |   \\$  /   \\$$$$$$$\\ \r\n \\______/  \\_______|\\__|            \\_______/ \\__|      \\__|    \\_/     \\_______|\r\n                                                                                 \r\n                                                                                 \r\n                                                                                 ");
            Console.WriteLine("Controles: ");
            Console.WriteLine("Mover Auto Izquierda: « (Left Arrow)");
            Console.WriteLine("Mover Auto Derecha: » (Right Arrow)");
            Console.WriteLine("Preciona cualquier ENTER para comenzar:");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            MostrarCircuito();// crea el circuito inicial, para permitir que movimiento mapa comience a crear nuevos circuitos
        }
        public void PantallaFinal()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("  ______    ______   __       __  ________         ______   __     __  ________  _______  \r\n /      \\  /      \\ /  \\     /  |/        |       /      \\ /  |   /  |/        |/       \\ \r\n/$$$$$$  |/$$$$$$  |$$  \\   /$$ |$$$$$$$$/       /$$$$$$  |$$ |   $$ |$$$$$$$$/ $$$$$$$  |\r\n$$ | _$$/ $$ |__$$ |$$$  \\ /$$$ |$$ |__          $$ |  $$ |$$ |   $$ |$$ |__    $$ |__$$ |\r\n$$ |/    |$$    $$ |$$$$  /$$$$ |$$    |         $$ |  $$ |$$  \\ /$$/ $$    |   $$    $$< \r\n$$ |$$$$ |$$$$$$$$ |$$ $$ $$/$$ |$$$$$/          $$ |  $$ | $$  /$$/  $$$$$/    $$$$$$$  |\r\n$$ \\__$$ |$$ |  $$ |$$ |$$$/ $$ |$$ |_____       $$ \\__$$ |  $$ $$/   $$ |_____ $$ |  $$ |\r\n$$    $$/ $$ |  $$ |$$ | $/  $$ |$$       |      $$    $$/    $$$/    $$       |$$ |  $$ |\r\n $$$$$$/  $$/   $$/ $$/      $$/ $$$$$$$$/        $$$$$$/      $/     $$$$$$$$/ $$/   $$/ \r\n                                                                                          \r\n                                                                                          \r\n                                                                                          ");
            Console.Write("PRECIONE CUALQUIER TECLA PARA SALIR");
            MostrarScore();
            Console.ReadLine();
            Environment.Exit(0);
        }
        private void MovimientoMapa()//logica para el movimiento del mapa
        {

            filasActuales.RemoveAt(filasActuales.Count - 1); // elimino la ultima fila la de mayor Y
            int ultimoX = filasActuales[filasActuales.Count - 1].x; // guardo la cordenada de x de la ultima fila que se creo
            filasActuales.Insert(0, (ConstruirFila(LargoPared, LargoEspcios), ultimoX));// agrego la fila nueva arriba, con su config
        }
        public void ScrollFrame() //mueve y dibuja un frame del fondo
        {
            MovimientoMapa();
            DibujarFilas(0, filasActuales);
            Score();//subo un punto por cada frame generado
            MostrarScore();
        }

        private int Score()// sube el puntaje en 1pts cada vez que se lo llama
        {
            score++;
            return score;
        }
        public void MostrarScore()//muestra el score en pantalla
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"SCORE = {score}");
        }

        public bool HayColicion(int x, int y)//x, y = posición del auto en la consola
        {
            bool choque = false;
            var (fila, xFila) = filasActuales[y];// accedo a la tupla de esa fila: el string y la columna donde arranca
            int indice = x - xFila ;
            char caracter = fila[indice];
            
            if (caracter != ' ')
            {
                choque = true;
            }
            return choque;
        }
    }
}




