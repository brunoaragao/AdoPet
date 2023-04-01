# AdoPet 🐾

AdoPet is a web application that allows users to adopt a new pet.

This project was developed during the [Back-end 6 Challenge](https://www.alura.com.br/challenges/back-end-6) of [Alura](https://www.alura.com.br/).

## 📋 Prerequisites

To run this project, you will need to have [Docker Desktop](https://www.docker.com/products/docker-desktop) or [Docker Compose](https://docs.docker.com/compose/install/) installed on your machine.

## 🚀 Running the project

Open the **AdoPet/src/Docker** folder in the terminal and run the following command:

```bash
$ docker compose up
```

<!-- ## 🛠️ Tecnologias utilizadas -->
## 🛠️ Technologies used

- [React](https://pt-br.reactjs.org/) - JavaScript library for creating the web interface
- [.NET](https://dotnet.microsoft.com/) - Back-end framework for developing microservices
- [Swagger](https://swagger.io/) - Tool for API documentation
- [Docker](https://www.docker.com/) - Platform for creating and running containers
- [RabitMQ](https://www.rabbitmq.com/) - Tool for communication between microservices

## 🏗️ Architecture

 The project was developed using the microservices architecture.

<!-- TODO: change src link to main branch -->
<img src="https://github.com/brunoaragao/AdoPet/blob/develop/img/architecture.drawio.png" alt="Architecture" width="600"/>

## 📋 Checklist
- [ ] Adoption service
- [ ] Identity service
  - [ ] Authentication
  - [ ] Registration
- [ ] Profile service
- [ ] Web Gateway
- [ ] Web Client