using Juego_Carrera;
Vehiculo auto = new();
//auto.Mostrar();
//bool salir = false;

//do
//{
//    ConsoleKeyInfo tecla = Console.ReadKey(true);
//    switch (tecla.Key)
//    {
//        case ConsoleKey.Escape:
//            salir = true;
//            break;
//        case ConsoleKey.UpArrow:
//            auto.MoverArriba();
//            break;
//        case ConsoleKey.DownArrow:
//            auto.MoverAbajo();
//            break;
//        case ConsoleKey.LeftArrow:
//            auto.MoverIzquierda();
//            break;
//        case ConsoleKey.RightArrow:
//            auto.MoverDerecha();
//            break;
//    }
//    auto.Mostrar();
//} while (!salir);
Mapa mapa = new Mapa();
mapa.PantallaInicio();
mapa.MostrarCircuito();
mapa.scroll();


