## TRABAJO  PRÁCTICO  LABORATORIO DE  SOFTWARE  


### PROYECTO HOTEL  ARQUITECTURA  LIMPIA  DDD

* PROFESOR: DANIEL  ALEJANDRO  FERNANDEZ
* ALUMNOS:  JULIA  AVALOS , EDUARDO ARIZA, GONZALO ARIZA , OMAR BAZAR


## Descripción del proyecto

Este proyecto implementa una aplicación de gestión de reservas de hotel utilizando la arquitectura limpia y el patrón Domain-Driven Design (DDD). El objetivo principal es demostrar la modularidad, flexibilidad y escalabilidad que ofrece este enfoque arquitectónico.

Características principales: 

* ```Arquitectura Limpia y DDD:``` El proyecto sigue los principios de la arquitectura limpia y el patrón Domain-Driven-Design, separando claramente las responsabilidades en capas  y promoviendo una alta cohesión y bajo acoplamiento.


* ```Selección de Base de Datos:``` La aplicación permite seleccionar entre diferentes opciones de base de datos (en memoria, MySQL y MongoDB) para almacenar los datos de clientes y reservas. Esto demuestra la facilidad con la que se pueden intercambiar las implementaciones de persistencia sin afectar la lógica de negocio.
  
* ``` Capa de Presentación:``` La capa de presentación maneja la interacción con el usuario a través de una interfaz de línea de comandos. Utiliza las clases ClienteUI y ReservaUI para mostrar menús y permitir la gestión de clientes y reservas.
  
* ```Capa de Aplicación:``` Esta capa contiene la lógica de negocio y orquesta las operaciones relacionadas con clientes y reservas. 
Utiliza objetos de transferencia de datos (DTOs) para comunicarse con otras capas.
  
* ```Capa de Dominio:``` Aquí se definen las entidades del dominio, como Cliente y Reserva, así como los objetos de valor (Value Objects) que encapsulan conceptos relevantes del negocio.
  
* ``` Capa de Infraestructura:``` Esta capa maneja la persistencia de datos y la interacción con las bases de datos. Incluye implementaciones de repositorios para diferentes opciones de persistencia (en memoria, MySQL y MongoDB).


  
## Estructura del proyecto

El proyecto se organiza en las siguientes carpetas principales:

* ```_01_Presentacion:``` Contiene la capa de presentación, incluyendo las clases Program, ClienteUI y ReservaUI.
* ```_02_Aplicacion:``` Alberga la capa de aplicación con servicios y DTOs relacionados con clientes y reservas.
* ```_03_Dominio:``` Aquí se encuentran las entidades del dominio, objetos de valor y repositorios.
* ```_04_PersistenciaDatos:``` Contiene las implementaciones de repositorios y clases de infraestructura para la persistencia de datos en diferentes bases de datos.


  
  
  ## Requisitos

* .NET Core 3.1 o superior
* MySQL (si se elige esta opción de base de datos)
* MongoDB (si se elige esta opción de base de datos)

  
## Instalación y ejecución

1. Clona este repositorio en tu máquina local.
2. Abre el proyecto en tu IDE preferido (Visual Studio, Visual Studio Code, etc.).
3. Configura las cadenas de conexión para MySQL y MongoDB según tus preferencias (si las utilizarás).
4. Ejecuta el proyecto.
5. Sigue las instrucciones en la interfaz de línea de comandos para seleccionar la opción de base de datos y gestionar clientes y reservas.
