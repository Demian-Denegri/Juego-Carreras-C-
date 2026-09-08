namespace Juego_Carrera
{
    internal class Vehiculo
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Vehiculo(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Mostrar()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write("^");
            Console.ResetColor();
        }
        public void MoverDerecha()
        {

            this.X++;

        }
        public void MoverIzquierda()
        {
            this.X--;
        }

    }
}
