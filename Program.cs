using Juego_Carrera;

Console.BackgroundColor = ConsoleColor.Gray;
Console.Clear();
bool salir = false;
Mapa mapa = new Mapa();
Vehiculo auto = new(mapa.CentroCarril, 25);
mapa.PantallaInicio();
bool derecha = false;
bool izquierda = false;
while (!salir)
{
    if (derecha == true)
    {
        auto.MoverDerecha();
    }
    else if (izquierda == true)
        auto.MoverIzquierda();
    if (Console.KeyAvailable)
    {
        ConsoleKeyInfo tecla = Console.ReadKey(true);
        switch (tecla.Key)
        {
            case ConsoleKey.Escape:
                salir = true;
                break;
            case ConsoleKey.LeftArrow:
                izquierda = true;
                derecha = false;
                break;
            case ConsoleKey.RightArrow:
                derecha = true;
                izquierda = false;
                break;

        }
    }
    if (mapa.HayColicion(auto.X, auto.Y))
    {
        break;
    }

    mapa.ScrollFrame();// se sige generadno mapa de forma infinita hasta precionar escape
    auto.Mostrar();
    mapa.VelocidadMapa();

   
}
mapa.PantallaFinal();