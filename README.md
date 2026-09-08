# 🏎️ Juego-Carrera (C#)

Un juego de carreras en consola escrito en C# (.NET). Controlás un auto que debe recorrer un circuito por una carretera sin chocarse con los bordes de la pista.

## 🎮 ¿De qué trata?

El jugador maneja un vehículo 🚗 que se mueve sobre un circuito dibujado en la terminal. La carretera se arma con paredes (`.`), y el objetivo es avanzar por la ruta **sin chocarse** con los bordes.

> ⚠️ **Estado del proyecto:** en fase final de desarrollo. Actualmente el dibujo del recorrido del mapa, el control del vehículo con las flechas del teclado, el sistema de puntuación (score), las pantallas de inicio y de fin de juego, y la detección de colisiones ya están implementados.
>
> Resta únicamente configurar el movimiento continuo del auto hacia los costados para otorgarle mayor dificultad al juego.
## 🚀 Requisitos

- [.NET SDK 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) (o superior)
- Una terminal que soporte salida de consola (Windows, Linux o macOS)

## ▶️ Cómo ejecutarlo

Desde la carpeta del proyecto:

```bash
dotnet run
```

## 🧩 Estructura del proyecto

| Archivo | Descripción |
| --- | --- |
| `Program.cs` | Punto de entrada del juego |
| `Mapa.cs` | Genera el circuito: carretera recta y giros (izquierda/derecha) |
| `Vehiculo.cs` | Define el auto y sus movimientos (arriba, abajo, izquierda, derecha) |

## 🎯 Próximos pasos (ideas)

- Detectar colisiones con las paredes de la carretera.

## 📄 Licencia

Este proyecto está bajo la licencia [MIT](LICENSE).
