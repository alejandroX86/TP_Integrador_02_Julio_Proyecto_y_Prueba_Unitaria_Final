TRABAJO  PRÁCTICO  LABORATORIO DE  SOFTWARE  
PROYECTO HOTEL  ARQUITECTURA  LIMPIA  DDD
PROFESOR: DANIEL  ALEJANDRO  FERNANDEZ
ALUMNOS:  JULIA  AVALOS , EDUARDO ARIZA, GONZALO ARIZA , OMAR BAZAR

Proyecto Hotel Arquitectura Limpia DDD
Este proyecto implementa una aplicación de gestión de reservas de hotel utilizando la arquitectura limpia y el patrón Domain-Driven Design (DDD). El objetivo principal es demostrar la modularidad, flexibilidad y escalabilidad que ofrece este enfoque arquitectónico.
Características principales
•	Arquitectura Limpia y DDD: El proyecto sigue los principios de la arquitectura limpia y el patrón Domain-Driven Design, separando claramente las responsabilidades en capas y promoviendo una alta cohesión y bajo acoplamiento.
•	Selección de Base de Datos: La aplicación permite seleccionar entre diferentes opciones de base de datos (en memoria, MySQL y MongoDB) para almacenar los datos de clientes y reservas. Esto demuestra la facilidad con la que se pueden intercambiar las implementaciones de persistencia sin afectar la lógica de negocio.
•	Capa de Presentación: La capa de presentación maneja la interacción con el usuario a través de una interfaz de línea de comandos. Utiliza las clases ClienteUI y ReservaUI para mostrar menús y permitir la gestión de clientes y reservas.
•	Capa de Aplicación: Esta capa contiene la lógica de negocio y orquesta las operaciones relacionadas con clientes y reservas. Utiliza objetos de transferencia de datos (DTOs) para comunicarse con otras capas.
•	Capa de Dominio: Aquí se definen las entidades del dominio, como Cliente y Reserva, así como los objetos de valor (Value Objects) que encapsulan conceptos relevantes del negocio.
•	Capa de Infraestructura: Esta capa maneja la persistencia de datos y la interacción con las bases de datos. Incluye implementaciones de repositorios para diferentes opciones de persistencia (en memoria, MySQL y MongoDB).
Estructura del proyecto
El proyecto se organiza en las siguientes carpetas principales:
