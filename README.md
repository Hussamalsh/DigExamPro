
# DigExamPro

A digital examination platform built with .NET Core to create, administer, and grade exams. The system is split into a backend web API and a frontend built using .NET 6 Blazor Server. It supports various types of questions such as multiple choice, true/false, fill-in-the-blank, and essay questions. The platform aims to simplify the examination process while providing a secure environment for both the administrators and the students.

## Features

- **Admin Dashboard**: Enables administrators to create, edit, and delete exams. They can also add, edit, or delete questions for each exam.
- **Question Types**: Supports multiple question types including multiple choice, true/false, fill-in-the-blank, and essay.
- **Secure Authentication**: Ensures only authenticated users can access the dashboard and take exams.
- **Reports**: Track the progress of each student and generate reports on their performance.
- **Dapper ORM**: Used Dapper for efficient database operations and queries.

## Prerequisites

- .NET Core SDK
- SQL Server
- Any modern web browser (e.g., Chrome, Firefox)

## Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/Hussamalsh/DigExamPro.git
    ```

2. Navigate to the project directory:
    ```bash
    cd DigExamPro
    ```

3. Restore the required packages:
    ```bash
    dotnet restore
    ```

4. Set up your database connection in the `appsettings.json` file.

5. Run the application:
    ```bash
    dotnet run
    ```

6. Open your web browser and navigate to `https://localhost:5000`.

## Usage

1. **Admin Dashboard**: Log in using your admin credentials. Once logged in, you'll have the ability to manage exams and questions.
2. **Taking an Exam**: Students can log in and select the available exam to start.

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License

This project is licensed under the MIT License.