# ST10444685_PROG6212_POEPART2

## Part 1
## Explanation of CMCS Program

### Project Plan: Contract Monthly Claim System (CMCS) Prototype
#### Overview
This project plan outlines the development strategy for the non-functional visual prototype of the Contract Monthly Claim System (CMCS), as required for Part 1 of the POE. The plan is structured into phases, detailing all tasks, their sequence, estimated effort, and dependencies to ensure a logical and efficient workflow.

#### Plan Structure & Explanation
The plan is organized in a Gantt-style table with the following columns:

Phase: The high-level stage of the project (e.g., Initiation, GUI Development).

Task ID: A unique identifier for each task (e.g., 3.4) for easy reference.

Task Name: A brief description of the specific activity to be performed.

Description: A more detailed explanation of what the task entails.

Assigned To: The role responsible for the task. For this individual academic project, all tasks are assigned to the Student.

Start/End Date: The planned timeframe for the task, calculated based on dependencies and duration.

Duration (Hours): The estimated effort required to complete the task.

Predecessors: The Task IDs that must be completed before this task can begin. This defines the critical path and workflow sequence (e.g., Task 3.5 cannot start before Task 3.4 is finished).

Dependencies: External factors or deliverables required to start or complete the task (e.g., access to GitHub, software installation).

Status: The current state of the task (all are initially Not Started).

#### Key Development Phases
Initiation & Planning (Day 1): This phase focuses on understanding the project requirements and defining the major milestones and deliverables.

 Design & Documentation (Days 2-3): This critical phase involves creating all required documentation, including the system report, UML class diagram, and this detailed project plan.

GUI Development (Days 4-9): The core implementation phase where the .NET (WPF/MVC) user interface is built. Tasks are sequenced to create the login, dashboards, and forms based on user roles (Lecturer, Coordinator, Manager).

Version Control (Integrated throughout Days 4-9): This is not a separate phase but a continuous process. The plan mandates five separate commits with descriptive messages, ensuring a clear and traceable history of the prototype's development.

Submission (Day 10): The final phase involves compiling all deliverables into a single report and performing the final project submission.

#### How to Interpret the Plan
The plan is designed to be followed sequentially. The Predecessors column is crucial; it dictates the order of operations. For example, the task "Design Lecturer Dashboard View" (3.5) has a predecessor of "Design Login View" (3.4), meaning the login screen must be designed before work on the dashboard can begin.

## Updates Between Part 1 and Part 2

### Part 1 Foundation
Part 1 established the core foundation of the CMCS prototype with:
- Comprehensive project planning and documentation
- Non-functional visual prototype using .NET (WPF/MVC)
- Basic user interface for three user roles (Lecturer, Coordinator, Manager)
- UML class diagram and system design documentation
- Version control implementation with structured commits

### Part 2 Enhancements
Part 2 transformed the prototype from a non-functional UI to a fully functional web application with core business logic, data persistence, and comprehensive user workflows.

#### Major Architectural Changes
- **Technology Stack Migration**: Changed from WPF to ASP.NET Core MVC as required
- **Data Persistence**: Implemented in-memory storage/SQLite with JSON file support
- **Security**: Added file encryption/decryption for secure document storage
- **Validation**: Implemented data annotations and model validation throughout the application

#### New Features Added

##### Lecturer Functionality
- **Enhanced Claim Submission Form**: 
  - Interactive form with fields for hours worked, hourly rate, and additional notes
  - Real-time validation and error messaging
  - Prominent submit button with intuitive user flow

- **Document Upload System**:
  - Secure file upload functionality supporting PDF, DOCX, and XLSX formats
  - File size limitation (5MB per file)
  - Encrypted file storage linked to specific claims
  - File name display after successful upload
  - Comprehensive error handling for upload failures

- **Claim Tracking & Status Updates**:
  - Real-time status tracking (Pending, Approved, Rejected)
  - Status updates visible immediately after coordinator/manager actions
  - Transparent claim progression through approval workflow

##### Administrator Functionality
- **Programme Coordinator View**:
  - Dedicated dashboard for pending claims review
  - Access to all claim details including uploaded documents
  - Verify and Reject action buttons for each claim
  - Document viewing/downloading capability

- **Academic Manager View**:
  - Separate administrative interface
  - Complete claim overview with supporting documentation
  - Approve and Reject decision buttons
  - Real-time status updates

#### Technical Improvements
- **Unit Testing**: Minimum of 5 unit tests covering core application functionality
- **Error Handling**: Comprehensive exception handling throughout the application
- **Input Validation**: Data annotations and model state validation
- **File Management**: Secure document handling with encryption/decryption
- **State Management**: Efficient claim status tracking and updates

#### User Interface Updates
- **Improved Layout & Color Scheme**: Enhanced visual design for better user experience
- **Responsive Design**: Better adaptation to different screen sizes
- **Intuitive Navigation**: Streamlined user flow between different functionalities
- **Status Visualization**: Clear display of claim status using text labels

#### Security Enhancements
- **File Encryption**: Secure storage of uploaded documents
- **Input Sanitization**: Protection against malicious input
- **Access Control**: Logical separation between user roles and functionalities

### Evolution of Development Approach
- **From Visual Prototype to Functional Application**: Transitioned from UI mockups to working software
- **Enhanced Version Control**: Increased commit frequency with more descriptive messages (10+ commits)
- **Test-Driven Development**: Incorporated unit testing as a core development practice
- **Error-First Design**: Built comprehensive error handling from the ground up

### Quality Assurance
- **Comprehensive Testing**: Unit tests covering all major functionalities
- **Error Validation**: Meaningful error messages throughout user interactions
- **File Validation**: Strict file type and size restrictions with user feedback
- **Status Consistency**: Reliable claim status updates across all user views

### Usage

#### For Lecturers:
1. **Submit Claims**: Navigate to "Submit Claim" from the dashboard
2. **Complete Form**: Fill in hours worked, hourly rate, and additional notes
3. **Upload Documents**: Attach supporting files (PDF, DOCX, XLSX) up to 5MB
4. **Track Status**: Monitor claim progression through approval stages in real-time
5. **View History**: Access complete claims history with current status

#### For Programme Coordinators:
1. **Access Dashboard**: Login to coordinator-specific view
2. **Review Claims**: Examine all pending claims with complete details
3. **Inspect Documents**: View or download uploaded supporting files
4. **Take Action**: Verify or reject claims with single-click actions
5. **Update Status**: Real-time status reflection across the system

#### For Academic Managers:
1. **Manager Dashboard**: Access dedicated management interface
2. **Comprehensive Review**: Evaluate all claim information and documentation
3. **Final Approval**: Approve or reject claims with immediate system updates
4. **Oversight**: Monitor overall claim processing and status distribution

### Technical Specifications
- **Framework**: ASP.NET Core MVC
- **Storage**: In-memory/SQLite with JSON file support
- **File Handling**: Encrypted document storage
- **Validation**: Data annotations and model state validation
- **Testing**: xUnit or NUnit for unit testing
- **Version Control**: GitHub with descriptive commit history
