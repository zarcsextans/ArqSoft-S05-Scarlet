#  CitasApp - Arquitectura Hexagonal

## Descripción

CitasApp es una aplicación web desarrollada en ASP.NET Core MVC para la gestión de citas médicas. El proyecto fue refactorizado desde una arquitectura MVC tradicional hacia una **arquitectura hexagonal (Ports & Adapters)** con el objetivo de mejorar el desacoplamiento, la escalabilidad y la mantenibilidad del sistema.

---

## Arquitectura Hexagonal Implementada

La solución se reorganizó en cuatro capas principales, separando el núcleo de negocio de las dependencias externas:

```text id="hex01"
CitasApp.Domain
CitasApp.Application
CitasApp.Infrastructure
CitasApp.Web
```

---

##  CitasApp.Domain (Núcleo del negocio)

Esta es la capa central de la arquitectura hexagonal. No depende de ninguna otra capa.

Contiene:

### Modelos (Entidades)

* Paciente
* Medico
* Cita

### Interfaces (Ports)

* IPacienteRepository
* IMedicoRepository
* ICitaRepository

 Define las reglas del negocio y los contratos que deben cumplir las capas externas.

---

## ⚙️ CitasApp.Application (Casos de uso)

Contiene la lógica de aplicación que coordina las operaciones del sistema.

### Servicios

* PacienteService
* MedicoService
* CitaService

 Esta capa actúa como intermediario entre la Web y el dominio, consumiendo los repositorios a través de interfaces.

---

##  CitasApp.Infrastructure (Adaptadores)

Implementa el acceso a datos y servicios externos.

### Repositorios JSON

* JsonPacienteRepository
* JsonMedicoRepository
* JsonCitaRepository

 Esta capa implementa las interfaces del Domain y maneja la persistencia usando archivos JSON.

---

##  CitasApp.Web (Adaptador de entrada)

Es la capa de presentación basada en ASP.NET Core MVC.

### Controladores

* HomeController
* PacienteController
* MedicoController
* CitaController

### Vistas

* Pacientes
* Médicos
* Citas

### Datos

* archivos JSON para persistencia

 Es el punto de entrada del usuario y consume la capa Application.

---

##  Migración a Arquitectura Hexagonal

Durante el desarrollo se realizó la transformación del proyecto:

### Antes:

* Todo estaba acoplado en un solo proyecto MVC
* Controllers accedían directamente a servicios de archivos JSON
* Dependencias rígidas

### Después:

* Separación en capas independientes
* Uso de interfaces (Ports) en Domain
* Implementación de repositorios (Adapters) en Infrastructure
* Lógica de negocio aislada en Application
* Web solo como interfaz de entrada

---

##  Principios aplicados

* Inversión de dependencias (Dependency Inversion)
* Separación de responsabilidades (SoC)
* Bajo acoplamiento
* Alta cohesión
* Arquitectura hexagonal (Ports & Adapters)

---

##  Tecnologías

* ASP.NET Core MVC
* C#
* .NET 10
* JSON como almacenamiento
* Inyección de dependencias

---

##  Objetivo del proyecto

El objetivo principal fue practicar la migración de una arquitectura MVC tradicional hacia una arquitectura hexagonal, entendiendo cómo el dominio debe permanecer independiente de frameworks, bases de datos o detalles de infraestructura.

---
