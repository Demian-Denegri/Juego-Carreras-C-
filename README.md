# 🏎️ Juego-Carrera (C#)

Un juego de carreras en consola escrito en C# (.NET). Controlás un auto que debe recorrer un circuito por una carretera sin chocarse con los bordes de la pista.

## 🎮 ¿De qué trata?

El jugador maneja un vehículo 🚗 que se mueve sobre un circuito dibujado en la terminal. La carretera se arma con paredes (`.`), y el objetivo es avanzar por la ruta **sin chocarse** con los bordes.

> ⚠️ **Estado del proyecto:** está en una fase inicial de desarrollo. Actualmente se dibuja el recorrido del mapa, y el control del vehículo con las flechas del teclado está implementado pero comentado (a la espera de integrarlo con la detección de choques).

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

- Vincular el control por teclado (flechas) con el vehículo.
- Detectar colisiones con las paredes de la carretera.
- Agregar puntaje, velocidad y dificultad creciente.

## 📄 Licencia

Este proyecto está bajo la licencia [MIT](LICENSE)..
