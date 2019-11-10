# Iteration 3

**Step 1**

- Goal: Review Inputs

- Possible Questions:

|Question|Answer|
|--------|------|
|Inputs available and correct?|As far as the feedback of the stakeholder, the defined architectural drivers are correct|
|All drivers available?|As far as what was retained from the domain problem and the stakeholder feedback, all drivers have been defined|
|Is it clearly stablished what is the purpose for the design activities?|Yes, the purpose of this iteration is to structure the software architecture with the remaining not or partially addressed use cases and remaining drivers|
|Have primary functionality and quality attribute scenarios been prioritized (ideally by the most important project stakeholders)?| Yes the primary functionalities are related to adding and removing an item to the inventory |
|Are initial architectural concerns defined?|Yes|

**Step 2**

- Goal: Establish iteration goal by selecting drivers

#### Kanban Board

| Not Addressed | Partially Addressed | Addressed |
|---------------|---------------------|-----------|
| UC1 |||
| UC4 |||
| UC7 |||
| UC8 |||
| UC9 |||
| UC11 |||
| UC12 |||
| UC13 |||
| CON-7 |||
| CON-8 |||
| CON-11 |||
| CON-12 |||
| CRN-4 |||
| QA-3 |||

**Step 3**

- Goal: Choose elements of the system to refine

The goal of this iteration is to support the remaining functionalities of GFA, by designing architecturally the software in a fine grain view. In order to realize this design it is necessary to refine the following elements:

- GFAW (Gorgeous Food Application Web)
- GFAB (Gorgeous Food Application Business)

**Step 4**

- Goal: Choose one or more design concepts that satisfy the selected drivers

Given the iteration goal selected drivers in Step 2, it is necessary to define which design concepts will be taken in account to realize the elements to refine selected in Step 3. The design concents proposed are the following:

|Design Decisions and Location|Rationale|
|-----------------------------|---------|

|||
|||
|Separate business responsibilities by structuring GFAB with the use of DDD and other patterns|The adoption of DDD in GFAB allows to separate business responsibilities. The patterns to adopted are: Aggregate Root, Entity, Value Object, Repository, Service. Repository pattern should also be complemented with Factory creational pattern as the controller is agnostic of what repository implementation to use|


|Alternative|Reason for Discarding|
|-----------|---------------------|


**Step 5**

- Goal: Instantiate architectural elements, allocate responsibilities and define interfaces

To satisfy the structure of the chosen design concepts, the following elements are proposed to be created:

|Design Decisions and Location|Rationale|
|-----------------------------|---------|
|Refine domain model|Domain model allows the identification of business concepts, and needs to be updated to include new use cases changes(UC1, UC4, UC7, UC8, UC9, UC11, UC12, UC13)|
|Refine use cases actors|To establish actors and their responbilities it is necessary to map the use cases being addressed by their actors|
|Map use cases to domain objects|Use cases can help creating domain objects that have these as their responsibilities|
|Define models interface|To understand how models communicate with each other as well as how their functionalities are produced|
|Map domain model using DDD|This helps understanding how DDD should be applied in GFAB|
|Refine GFAB REST API|Introduction of new use cases imply changes in the existing REST API specification|

(FALTA MARCAR QUE ELEMENTOS ABORDAM OS DESIGN CONCEPTS SELECIONADOS, TABELA DE RESPONSABILIDADES)

**Step 6**

- Goal: Sketch views and record design decisions

- Module View:

  **Domain Model**

  ![DomainModel](diagrams/DomainModel.png)

  **Model Objects Class Diagram**

  ![ModelObjectsDiagram](diagrams/ModelObjectsClassDiagram.png)

  **Aggregate Roots Diagram**

  ![AggregateRoots](diagrams/AggregateRoots.png)

  **GFAB Packages Diagram**

  ![GFAB_Packages_Diagram](diagrams/GFAB_Packages.png)


- Allocation View :

  **Use Case Diagram**

Use Cases chosen to implement given the selected drivers:

![UseCaseDiagram](diagrams/UseCasesDiagram.png)

  **Domain Objects for Use Cases**

![UseCasesDomainObjects](diagrams/UseCasesDomainObjects.png)


- Responsability Tables for Defined Elements

|Element|Responsibility|
|-------|--------------|
|||

**Step 7**

- Goal: Perform analysis of current design and review iteration goal and achivements of design purposes

In this iteration GFA was designed architecturally in a fine-grain view, which allowed the team to understand how each component units were being integrated.
A domain model was sketched which allowed to understand the business concepts that exist in GFA. Consecutively a class diagram for the models that represent this business concepts was realized, allowing the representation of the functionalities that these produced, as well as their properties.
It was concluded that the adoption of DDD in GFAB allowed a clean separation of responsibilities, which eases the development process of the component. The definition of the REST API specification produced by GFAB permits the development of GFAW as GFAB is also being developed, as the consumers already now the interface specifications that is being consumed.

The following table represents the update of the kanban board after the iteration:

| Not Addressed | Partially Addressed | Addressed |
|---------------|---------------------|-----------|
||UC1||
|||UC2|
|||UC3|
|||UC5|
|||UC6|
|UC9|||
|||CON-4|
|CRN-4|||
|QA-3|||