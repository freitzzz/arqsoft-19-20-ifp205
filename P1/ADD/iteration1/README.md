# README

## ARQSOFT 2019 / 2020

## Roadmap

The software being developed is a greenfield system, so it is proposed the following roadmap for each ADD iteration

**Iteration 1**

- Goal: Structure the system (coarse architectural view)

- Description: In this iteration it is intended that the design of the software being developed is settled in a coarse architectural view

- Design Concepts:
  - Choose Reference Architectures
  - Choose Deployment Patterns
  - Choose Externally Developed Components (e.g. Frameworks)

**Iteration 2**

- Goal: Support primary functionality (fine-grain architectural view)

- Description: In this iteration it is intended that the design of the functional requirements and restrictions is settled in a fine-grain architectural view 

- Design Concepts:
  - Choose Architectural Patterns
  - Relate Externaly Developed Components with chosen Architectural Patterns

**Iteration 3**

- Goal: Support quality attribute scenarios and concerns

- Description: In this iteration it is intended that the design of the quality attribute scenarios and concerns is settled

- Design Concepts:
  - Analyze, and choose Tactics
  - Relate Architectural and Deployment Patterns with choosen Tactics
  - Relate Externally Developed Components with choosen Tactics

### Drivers

**Use Cases**

| ID | Use Case | Description | Priority | Difficulty |
|-----|---------| ----------- | -------- | ---------- | 
| UC1 | Purchase Item | Without taking payment into account, a meal's purchase has to be registered in order to maintain an updated inventory of the available meals | Low | High  |
| UC2 | Register Item to Inventory | The unserved meal (item) is labeled with designation, identification number, production and expiration dates, with its quantity specified | High | High |
| UC3 | Remove Existing Item from Inventory | It should be possible to remove an existing unserved meal (item) from the inventory | High | Medium |
| UC4 | Create new Meal Descriptor | Every meal can have descriptors (ex: 2g of Vitamin D for every 100g or 300 calories for every 100g), but must be extensible | Low | High | 
| UC5 | View Meal Details | View a characterization regarding the meal's designation, type, nutritional data, ingredients and alergens | Medium | Low |
| UC6 | Create Meal | Create new meal with type, description, ingredients and allergens | High | High |
| UC7 | Generate Management Reports | Should provide reports such as the number of meals, grouped by type, sold between a period of time in a day (ex: 2pm to 9pm) or days of the week | Low | High |
| UC8 | View User Logs/Activities | The administrator can see every executed operation and can be filtered by date or type of operation | Low | High |
| UC9 | Edit Meal | The kitchen workers can update any information at any given time of a meal | Medium | Medium |
| UC10 | Edit Item Quantity | The kitchen workers can correct the available quantity in inventory of an item at any given time | High | Medium |
| UC11 | Add Allergens | The kitchen workers can insert allergens | Medium | High |
| UC12 | Add Meal Types | The kitchen workers can insert meal types | Medium | High |
| UC13 | Add Ingredients | The kitchen workers can insert ingredients | Medium | High |

**Constraints**

| ID | Constraint |
|----|------------|
| CON-1 | Application accessible from a variety of platforms via web browser |
| CON-2 | Application must be developed by the schools technical staff |
| CON-3 | First release planned after two months |
| CON-4 | A PoC should be presented within five weeks|
| CON-5 | Adoption of open-source tecnologies |
| CON-6 | It is intended that the introduction of new  meal descriptors affects very little, or nothing, other components of the application. |
| CON-7 | A change in the meal identification number should not affect more than one architeture component |
| CON-8 | Change in the generation of this number identification is to be implemented and tested with no side effects in 1 person-day of effort.|
| CON-9|  The school has a database server with a backup policy implemented and it is to be used by the application to be developed |
| CON-10 | User directory server used by other applications in the school and the new application is also to use it |
| CON-11 | Administrator should be able to query user logs and see their activities, all of them, or performed between dates or only some type of activies |
| CON-12 | It should be possible to generate reports in more than one language|

**Concerns**

| ID | Concern  | Importance |  Difficulty |
|-----|---------| ----------- | ----------- |
| CRN-1 | Multilanguage support | Medium | Medium |
| CRN-2 | Authentication | Medium | High |
| CRN-3 | Authorization | Medium | High |
| CRN-4 | Activity Log | High | Medium |
| CRN-5 | Team difficulty with the implementation of Update functionalities | Medium | High |

**Quality Attributes**

| ID | Quality Attribute | Scenario | Associated Use Case |
|----|-------------------|----------|---------------------|
| QA-1| Portability | The application must be accessible from all devices that provide a web browser | All |
| QA-2 | Localizability | Multilanguage support is desirable as the school accepts foreign students on a regular base, as well as it can attract tourists | All |
| QA-3 | Auditability | The application should be able to provide management reports in more than one language. Activity logging is also considered | All |


### Iteration 1

**Step 1**

- Goal: Review Inputs

- Possible Questions:

|Question|Answer|
|--------|------|
|Inputs available and correct?|As far as the feedback of the stakeholder, the defined architectural drivers are correct|
|All drivers available?|As far as what was retained from the domain problem and the stakeholder feedback, all drivers have been defined|
|Is it clearly stablished what is the purpose for the design activities?|Yes, the purpose of this iteration is to structure the software architecture in a coarse-view|
|Have primary functionality and quality attribute scenarios been prioritized (ideally by the most important project stakeholders)?|---|
|Are initial architectural concerns defined?|Yes|

**Step 2**

- Goal: Establish iteration goal by selection drivers

#### Kanban Board

| Not Addressed | Partially Addressed | Addressed |
|---------------|---------------------|-----------|
| UC2 |||
| UC3 |||
| UC6 |||
| UC10 |||
| CON-1 ||| 
| CON-4 |||
| CON-5 |||
| CRN-4 |||
| QA-1 |||
| QA-3 |||

**Step 3**

- Goal: Choose elements of the system to refine

As this is the first iteration of a greenfield system, it is necessary to define the first element of the system which is the system itself. The system is composed by four components, which are:

- GFAW (Gorgeous Food Application Web), which is the frontend of GFA, producing a graphic interface that will be consumed by the users. This element represents a SPA (Single Page Application), which consumes GFAB produced functionalities
- GFAB (Gorgeous Food Application Business), which is the backend of GFA, producing an interface that allows the consume of business logic functionalities.
- Database, which produces an interface that allows the store of information
- User Directory Server, which produces an interface that allows the fetch of users information

**Step 4**

- Goal: Choose one or more design concepts that satisfy the selected drivers

Given the iteration goal selected drivers in Step 2, it is necessary to define which design concepts will be taken in account to realize the elements to refine selected in Step 3. The design concents proposed are the following:

- Reference Architectures:
   - Three Layer Application
- Deployment Patterns:
   - 4 Tier Deployment Pattern fits perfectly the requirements for the selected elements to refine
- Architectural Patterns:
   - MVC (Model-View-Controller) architectural pattern which allows a clean separation of responsibilities in GFAB. Model will hold responsibilities regarding business logic functionalities and definitions, while controller handles the produced interface requests as well as any other external component communication. View will have the responsibility to define passive views that represent state of requests and responses using models data.
   - MVVM (ModelView ViewModel) architectural pattern as React.js implies an active view in which the view needs to change its state over the time, using data bindings and computed properties
- Architectural Styles:
  - REST (Representational State Transfer) architectural style will allow the structure of GFAB API by defining collections. Each of these collections represent a domain responsibility and hold resources which are entities of that domain.
  - Client Server as GFAB produces an API ready to be consumed by external clients
  - Component-Based
  - Layer-Architecture
  - SOA (Service Oriented Architecture)
- Technologies and Frameworks:
  - React.JS will allow the build of GFAW
  - .NET Core + Entity Framework will allow the build of GFAB

**Step 5**

- Goal: Instantiate architectural elements, allocate responsibilities and define interfaces

To satisfy the structure of the chosen design concepts, the following elements are proposed to be created:

- Create component-and-connector structures to represent system elements integrations
- Create allocation structures diagram to represent system elements allocations

**Step 6**

- Goal: Sketch views and record design decisions

- Component-and-connector View : 

   **Component Diagram**

   With a component diagram its possible to visualize all components of the system integrations, by representing the interfaces that these produce as well as the consume of these interfaces. GFAB was designed to produce an interface that is represented by a REST API which will allow the consume of the business logic functionalities by GFAW and other components. GFAW also produces an interface that allows the consume of HTML/Javascript/CSS as this a web application. Database and User Directory were designed to produce a SQL and LDAP interface respectively, although these API definitions still need to be refined with the feedback of the stakeholders.

   ![ComponentDiagram](diagrams/component_diagram_coarse_granularity.png)

- Allocation View :

   **Deployment Diagram**

   With a deployment diagram its possible to visualize the allocation of the system in each tier. For an initial iteration it was decided that HTTP is used over HTTPS as the goal is to create a prototype to demonstrate a set of functionalities to the stakeholders. GFAW component was designed to be deployed on the cloud using [Heroku](https://www.heroku.com) services. GFAB was also designed to be deployed on the cloud using Azure services.

   ![DeploymentDiagram](diagrams/deployment_diagram_coarse_granularity.png)

**Step 7**

- Goal: Perform analysis of current design and review iteration goal and achivements of design purposes

In this iteration GFA was designed architecturally in a coarse view, which allowed the team to understand the integration of each system component. It was concluded that there are four components, in which two of these need to be developed by the team (GFAW and GFAB). These two components represent the web application which the users will be able to consume the user interface and the business logic functionalities which are consumed by the web application, and will be deployed on the cloud. A set of design concepts were also realized which will architecture these components.

The following table represents the update of the kanban board after the iteration:

| Not Addressed | Partially Addressed | Addressed |
|---------------|---------------------|-----------|
| UC2 |||
| UC3 |||
| UC6 |||
| UC10 |||
||| CON-1 | 
|| CON-4 ||
||| CON-5 |
| CRN-4 |||
||| QA-1 |
| QA-3 |||