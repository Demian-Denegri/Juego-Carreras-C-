namespace Juego_Carrera
{
    internal class Vehiculo
    {
        private int X { get; set; } = 10;
        private int Y { get; set; } = 10;

        public void Mostrar()
        {
            
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write("^");
        }
        public void MoverDerecha()
        {
            this.X++;
        }
        public void MoverIzquierda()
        {
            this.X--;
        }
        public void MoverArriba()
        {
            this.Y--;
        }
        public void MoverAbajo()
        {
            this.Y++;
        }
    }
}
