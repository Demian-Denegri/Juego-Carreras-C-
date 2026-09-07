namespace Juego_Carrera
{
    internal class Vehiculo
    {
        private int X { get; set; }
        private int Y { get; set; }

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
