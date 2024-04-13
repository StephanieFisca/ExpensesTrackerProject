# ExpensesTracker

This project aims to empower users in efficiently managing their expenses. It boasts features that enable users to visualize their highest, lowest, average, and overall expenses, along with insights into the categories consuming the most and least funds. With both user and admin access levels, the application offers versatile functionality.

User access facilitates the core functionalities of introducing, visualizing, and filtering expenses within the main application interface. On the other hand, admin access elevates the platform by enabling the creation of additional users and admins, while also granting the ability to visualize all user data in any desired filtered format.

In essence, the primary objective of this project is to equip users with comprehensive insights into their spending patterns, empowering them to make informed financial decisions and maintain meticulous expense records.

This project leverages several design patterns to achieve its objectives:

Repository Pattern: Implemented to separate the data access logic from the rest of the application. By defining interfaces like IUserRepository and providing concrete implementations such as UserRepository, the application achieves flexibility and testability in interacting with the database.

Factory Method Pattern: Utilized to create instances of repository objects without exposing their concrete implementations. The RepositoryFactory class abstracts the instantiation of repository objects, promoting loose coupling and enhancing maintainability.

Singleton Pattern: Employed in the SqlConnectionManager class to ensure that only one instance of the SqlConnection object is created and shared throughout the application. This pattern centralizes the management of database connections, improving efficiency and resource utilization.

These design patterns collectively contribute to the modularity, extensibility, and scalability of the application. They promote best practices in software development, such as separation of concerns, abstraction, and dependency inversion, enhancing the overall quality and maintainability of the expense management system.
