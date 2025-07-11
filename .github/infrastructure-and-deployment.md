# Infrastructure and Deployment Principles

## What is considered to be Infrastructure?
When we talk about infrastructure, we refer to the underlying services 
and hardware that support the application, such as databases, servers, and cloud services.
In modern software development, where applications are often deployed in the cloud, 
we dont cosider the physical hardware, but rather the services that run on top of it.

For example, infrastructure can include:
- Databases, and their provisioning (but not the database schema creation)
- Message queues like RabbitMQ or Kafka, Azure Service Bus, etc.
- Kubernetes clusters, Container services, or other container orchestration platforms
- Creating environments, envronment secrets, and configuration management
- etc

## What is considered to be Deployment
When we talk about deployment, we refer to the process of getting the application from development to production, 
including how it is configured and managed in different environments.
The difference to infrastructure is, the deployment can not provision new hardware or services, 
but rather configures and manages the existing ones.

This includes:
- Updating database schemas
- Creating queues for message processing
- Creating containers images, and deploying them to container orchestration platforms
- etc

## Key Principles
Deployment of application should be done in a way that is consistent and repeatable, 
from scratch to production.
 
- **Infrastructure as Code**: Use infrastructure as code (IaC) tools to define and manage the deployment environment.
- **Environment Consistency**: Ensure that the development, testing, 
and production environments are consistent to avoid deployment issues. 
Try to use same services in local development and production environments.
- **Automated Deployment**: Use automated deployment pipelines to ensure that deployments are repeatable and reliable.
- **Monitoring and Logging**: Implement monitoring and logging to track the health of the application 
and diagnose issues in each environment, to catch issues before they reach production.
- **Security and Compliance**: Never share credentials and secrets between the environments. 
Give as little permissions as possible to each step of the deployment process. 
For example, deployment pipeline should have management access, to configure database schemas. 
But the application should not change the database schema, it should only read and write data.
- Ensure the whole environment can be run locally, and that it is debuggable. 

## Why This Approach Is Good
When you have exactly the same infrastructure, it is easier to debug issues that arise in production, 
as you can reproduce the same environment locally.
Many times, we have issues that only occur in production, 
because the environment is different from the development environment.
This approach gives you confidence that the application will behave the same way in production as it does in development.


It is also a good practice to have as little permissions as possible.
If your application somehow leaks database credentials, the attacker will not be able to change the database schema.
Of course, leaking credentials will allow the attacker to read and write data.

## Why Violating It Is Bad
- **Difficult Testing:** Many engineering hours are wasted trying to reproduce problem locally.

---

### When to Consider Other Approaches
The approach described above is suitable for most applications, 
and does not really reduce the complexity of the code.

However, in some cases when you have a very simple application, you can do the deployment process at startup of application.

---

