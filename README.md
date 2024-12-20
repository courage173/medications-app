# Application Documentation

## Architecture

### Backend

The backend of this application is designed using a structured and normalized data model. After analyzing the provided sample data, the following entities were created to ensure data normalization and integrity:

- **TherapeuticClass**: Represents the therapeutic classifications.
- **ATCCodes**: Contains the Anatomical Therapeutic Chemical classification codes.
- **ActiveIngredients**: Represents active ingredients used in medications.
- **PharmaceuticalForms**: Defines the different pharmaceutical forms (e.g., tablets, capsules).
- **Medications**: Represents the medications, linking to all dependent entities.
- **MedicationActiveIngredients**: Establishes a many-to-many relationship between medications and active ingredients.

#### Repository Pattern

To promote separation of concerns and make the backend maintainable, the Repository Pattern was adopted. This approach abstracts data access through interfaces, which define the contract for data operations. This abstraction ensures:

- A clear separation between data access logic and business logic.
- Ease of unit testing, as repositories can be mocked.
- Scalability and flexibility for future changes to the data access layer.

### Frontend

The frontend was built using Angular and designed with usability in mind. It consists of multiple tabs, each corresponding to the main entities. The workflow ensures that dependencies between entities are respected:

- To create a Medication, users must first create all its dependencies (e.g., TherapeuticClass, ATCCodes, ActiveIngredients, and PharmaceuticalForms).

---

## Testing

Tests have been added to verify the functionality and stability of the application. These include:

- **Unit tests** for repository methods and business logic.
- **Component and service tests** in the Angular frontend.

---

## Setup Instructions

### Prerequisites

#### Backend:

- Install .NET SDK.
- Ensure a supported version of a database system is available (e.g., SQL Server or PostgreSQL).

#### Frontend:

- Install Node.js and npm.
- Install Angular CLI globally:
  ```bash
  npm install -g @angular/cli
  ```
- (Optional) Install Docker if you want to run the frontend in a containerized environment.

#### Database:

- Set up the database and apply migrations as per the provided scripts or configuration.

---

### Installation

1. Clone the repository:
   ```bash
   git clone <repository-url>
   cd <project-directory>
   ```

#### Backend:

2. Navigate to the backend directory:

   ```bash
   cd Backend
   ```

3. Restore dependencies:

   ```bash
   dotnet restore
   ```

4. Update the `appsettings.json` file with your database connection string.

5. Run the application:
   ```bash
   dotnet run
   ```

#### Frontend:

6. Navigate to the frontend directory:

   ```bash
   cd Frontend
   ```

7. Install dependencies:

   ```bash
   npm install
   ```

8. Start the development server:

   ```bash
   ng serve
   ```

   Alternatively, run the frontend using Docker:

   - Build the Docker image:
     ```bash
     docker build -t frontend-app .
     ```
   - Run the container:
     ```bash
     docker run -p 4200:4200 frontend-app
     ```

9. Open your browser and navigate to [http://localhost:4200](http://localhost:4200).

---

## Usage Guidelines

### Creating Entities:

- Use the provided tabs to navigate through entity creation.
- Start by creating foundational entities like TherapeuticClass, ATCCodes, ActiveIngredients, and PharmaceuticalForms.
- Finally, create Medications by linking them to the previously created entities.

### Validation:

- The application includes client-side validation to ensure proper data entry.
- Error messages will guide users if any required fields are missing or incorrect.

### Testing:

- To run tests for the backend:
  ```bash
  dotnet test
  ```
- To run tests for the frontend:
  ```bash
  ng test
  ```

---

## Additional Notes

- The repository pattern in the backend makes it easier to switch between different database technologies if needed.
- The frontend design ensures an intuitive workflow for end-users, reducing the learning curve.
- Consider extending the application with additional features like user authentication and role-based access control for enhanced security.
