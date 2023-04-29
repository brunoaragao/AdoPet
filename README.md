# AdoPet 🐾

AdoPet is a web application that allows users to adopt a new pet. This project was developed during the [Back-end 6 Challenge](https://www.alura.com.br/challenges/back-end-6) of [Alura](https://www.alura.com.br/).

# 🚀 Getting Started

Make sure you have [Docker](https://www.docker.com/) installed on your machine. Then, run from **src** folder the following command to start the application:

```bash
$ docker compose up
```

The API documentation will be available at:

- http://localhost:5000/swagger - Api Gateway
- http://localhost:5001/swagger - Identity Server
- http://localhost:5002/swagger - Adopty API

# 🏗️ Architecture

<img src="https://github.com/brunoaragao/AdoPet/blob/main/img/architecture.drawio.png" alt="Architecture" width="100%">

<dl>
    <dt><strong>Api Gateway</strong></dt>
    <dd>This component serves as the entry point for the application, and is responsible for routing incoming requests from clients to the appropriate services. The Api Gateway typically handles tasks such as authentication, rate limiting, and traffic management, as well as translating requests from external clients into the internal API format used by the microservices.</dd>
    <dt><strong>Identity Server</strong></dt>
    <dd>This component is responsible for authenticating and authorizing users. It typically provides a centralized authentication and authorization mechanism for the entire application, allowing users to log in and access protected resources across different services. It also provides features such as single sign-on (SSO), which allows users to access multiple services without having to log in repeatedly.</dd>
    <dt><strong>Adopty Service</strong></dt>
    <dd>This component is responsible for managing the adoption process. It typically provides functionality such as creating, updating, and deleting adoption requests, as well as handling notifications and updates related to the adoption process. It may also interact with other services, such as a database or a message broker, to store and retrieve data or communicate with other components of the application.</dd>
</dl>

<p>Overall, this architecture follows a microservices-based approach, where the application is broken down into smaller, more manageable services that can be developed and deployed independently. The Api Gateway acts as a central entry point for the application, while the Identity Server provides a centralized mechanism for authentication and authorization. The Adopty Service provides a specific business function related to managing the adoption process, and can interact with other services as needed to provide a complete solution.</p>

# 🛠️ Technologies used

<dl>
    <dt><a href="https://dotnet.microsoft.com/">.NET</a></dt>
    <dd>It is a free, open-source, and cross-platform developer platform for building many different types of applications. It is one of the most widely used technologies for developing enterprise applications on the Windows platform.</dd>
    <dt><a href="https://masstransit.io/">MassTransit</a></dt>
    <dd>It is a free and open-source framework for distributed applications in .NET. It provides an easy way to create message-oriented applications, making communication between applications and services easier and more reliable. It can also be integrated with different message systems.</dd>
    <dt><a href="https://duendesoftware.com/products/identityserver">IdentityServer</a></dt>
    <dd>It is an open-source framework that implements the OpenID Connect and OAuth 2.0 standards. It allows you to configure your own authentication and authorization infrastructure for web applications and APIs.</dd>
    <dt><a href="https://swagger.io/">Swagger</a></dt>
    <dd>It is a tool for documenting APIs in a standardized and easy-to-use way. It allows developers to quickly and efficiently create, document, and test their APIs.</dd>
    <dt><a href="https://www.docker.com/">Docker</a></dt>
    <dd>It is a container virtualization platform that allows applications to run in isolated environments. It simplifies the development and deployment process, allowing applications to be deployed quickly on different platforms.</dd>
    <dt><a href="https://www.rabbitmq.com/">RabbitMQ</a></dt>
    <dd>It is an open-source message broker that implements the Advanced Message Queuing Protocol (AMQP). It allows applications to send and receive messages reliably, scalably, and asynchronously. It is often used in service-oriented architectures (SOA) and microservices systems.</dd>
</dl>