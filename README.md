# 🏥 CitasApp - API REST de Citas Médicas

## 📌 Descripción del proyecto

CitasApp es una aplicación desarrollada con **ASP.NET Core Web API (.NET)** que permite la gestión de un sistema de citas médicas.  
El sistema está basado en una arquitectura **hexagonal (Ports & Adapters)**, lo que permite separar la lógica de negocio de la infraestructura y facilitar el mantenimiento y escalabilidad.

La API permite gestionar pacientes, médicos y citas mediante endpoints REST y está documentada con Swagger.

---

## 🧱 Arquitectura del proyecto

El sistema está dividido en varias capas:

- **CitasApp.Domain** → Modelos e interfaces (reglas de negocio)
- **CitasApp.Application** → Servicios de aplicación (lógica de negocio)
- **CitasApp.Infrastructure** → Repositorios (persistencia en JSON)
- **CitasApp.Api** → Exposición de la API REST

---

## 🔗 Flujo de la arquitectura

API → Application → Domain ← Infrastructure

---

## ⚙️ Tecnologías utilizadas

- ASP.NET Core Web API
- .NET
- C#
- Swagger (Swashbuckle)
- JSON como persistencia de datos
- Arquitectura Hexagonal

---

## 📡 Endpoints disponibles

### 👤 Pacientes

- `GET /api/Pacientes` → Lista todos los pacientes
- `GET /api/Pacientes/{id}` → Obtiene un paciente por ID

---

### 🩺 Médicos

- `GET /api/Medicos` → Lista todos los médicos
- `GET /api/Medicos/{id}` → Obtiene un médico por ID

---

### 📅 Citas

- `GET /api/Citas` → Lista todas las citas
- `GET /api/Citas/porpaciente/{pacienteId}` → Citas de un paciente

---

## 🚀 Ejecución del proyecto

1. Clonar el repositorio:
```bash
git clone https://github.com/tu-usuario/CitasApp.git
Abrir la solución en Visual Studio
Ejecutar el proyecto CitasApp.Api
Abrir Swagger:
```


## Capturas

<img width="1920" height="1080" alt="Captura de pantalla 2026-06-19 204314" src="https://github.com/user-attachments/assets/548cb3dc-3c66-4eca-b125-e87e12e4f6b7" />
<img width="1920" height="1080" alt="Captura de pantalla 2026-06-19 204337" src="https://github.com/user-attachments/assets/b7e069b4-7b61-465f-b5c8-4c583f7ff1cd" />
<img width="1920" height="1080" alt="Captura de pantalla 2026-06-19 204205" src="https://github.com/user-attachments/assets/fe1bdc60-16f2-4726-845f-b26cd3b34f9b" />
<img width="1920" height="1080" alt="Captura de pantalla 2026-06-19 204243" src="https://github.com/user-attachments/assets/a833224e-9e67-4003-b874-167a932f1b45" />

## 🤖 Declaración de uso de IA

Este proyecto fue desarrollado con apoyo de herramientas de inteligencia artificial (IA) para asistencia en la resolución de errores, explicación de conceptos y mejora del código.  
Todo el diseño, implementación y comprensión del sistema fue realizado por el estudiante como parte de la práctica académica.
