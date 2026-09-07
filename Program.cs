using Juego_Carrera;
using System.Drawing;

Console.BackgroundColor = ConsoleColor.Gray;
Console.Clear();
bool salir = false;
Mapa mapa = new Mapa();
Vehiculo auto = new(mapa.CentroCarril, 25);
mapa.PantallaInicio();
while (!salir)
{
    if (Console.KeyAvailable)
    {
        ConsoleKeyInfo tecla = Console.ReadKey(true);
        switch (tecla.Key)
        {
            case ConsoleKey.Escape:
                salir = true;
                break;
            case ConsoleKey.LeftArrow:
                auto.MoverIzquierda();
                break;
            case ConsoleKey.RightArrow:
                auto.MoverDerecha();
                break;
        }
    }
    mapa.ScrollFrame();// se sige generadno mapa de forma infinita hasta precionar escape
    auto.Mostrar();
    Thread.Sleep(50);// 1fps (2 lineas nueva cada 1 segundo )

}
mapa.PantallaFinal();