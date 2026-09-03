namespace Juego_Carrera
{
    internal class Mapa
    {
        private int CarreteraX { get; set; }
        private int CarreteraY { get; set; }
        public int inicioX { get; set; } = 0;

        private void DibujarFilas(int largo, int espacios, int caracteres, int inicioX)
        {
            for (int i = 0; i < largo; i++)
            {

                CarreteraX = inicioX;

                for (int j = 0; j < caracteres; j++)// dibujo pared izquierda
                {

                    Console.SetCursorPosition(CarreteraX, CarreteraY);
                    Console.Write(".");
                    CarreteraX++;
                }

                for (int j = 0; j < espacios; j++)// vacio del centro
                {
                    Console.SetCursorPosition(CarreteraX, CarreteraY);
                    Console.Write(" ");
                    CarreteraX++;
                }
                for (int j = 0; j < caracteres; j++)// dibujo pared derecha
                {

                    Console.SetCursorPosition(CarreteraX, CarreteraY);
                    Console.Write(".");
                    CarreteraX++;
                }

                CarreteraY++;


            }
        }

        public void RutaDerecha()
        {

            DibujarFilas(10, 10, 10, inicioX);

        }

        public void RutaGiroIzquierda()
        {

            for (int i = 0; i < 10; i++)
            {
                DibujarFilas(1, 10, 10, inicioX);
                inicioX++; // Avanza a la izquierda en la siguiente fila
            }

        }
        public void RutaGiroDerecha()
        {
            for (int i = 0; i < 10; i++)
            {
                DibujarFilas(1, 10, 10, inicioX);
                inicioX--; // Avanza a la derecha en la siguiente fila
            }

        }
    }
}



