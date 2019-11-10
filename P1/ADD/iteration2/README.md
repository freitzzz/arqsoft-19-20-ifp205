# Iteration 2

**Step 1**

- Goal: Review Inputs

- Possible Questions:

|Question|Answer|
|--------|------|
|Inputs available and correct?|As far as the feedback of the stakeholder, the defined architectural drivers are correct|
|All drivers available?|As far as what was retained from the domain problem and the stakeholder feedback, all drivers have been defined|
|Is it clearly stablished what is the purpose for the design activities?|Yes, the purpose of this iteration is to structure the software architecture in a coarse-view|
|Have primary functionality and quality attribute scenarios been prioritized (ideally by the most important project stakeholders)?| Yes the primary functionalities are related to adding and removing an item to the inventory |
|Are initial architectural concerns defined?|Yes|

**Step 2**

- Goal: Establish iteration goal by selecting drivers

#### Kanban Board

| Not Addressed | Partially Addressed | Addressed |
|---------------|---------------------|-----------|
| UC1 |||
| UC2 |||
| UC3 |||
| UC5 |||
| UC6 |||
| UC9 |||
| CON-4 |||
| CRN-4 |||
| QA-3 |||

**Step 3**

- Goal: Choose elements of the system to refine

The goal of this iteration is to support the primary functionalities of GFA, by designing architecturally the software in a fine grain view. In order to realize this design it is necessary to refine the following elements:

- GFAW (Gorgeous Food Application Web)
- GFAB (Gorgeous Food Application Business)

**Step 4**

- Goal: Choose one or more design concepts that satisfy the selected drivers

Given the iteration goal selected drivers in Step 2, it is necessary to define which design concepts will be taken in account to realize the elements to refine selected in Step 3. The design concents proposed are the following:

|Design Decisions and Location|Rationale|
|-----------------------------|---------|
|Architecturally structure GFAB and GFAW components with the adoption of MVC|MVC (Model-View-Controller) architectural pattern which allows a clean separation of responsibilities in GFAB and GFAW components. Model will hold responsibilities regarding business logic functionalities and definitions, while controller handles the produced interface requests as well as any other external component communication. View will have the responsibility to define passive views that represent state of requests and responses using models data. In GFAW the controller handles events that are emitted from the view, and the model are model definitions that are consumed of GFAB component. This satisfies all requirements necessary to produce use cases functionalities, both from a server and client side perspective (UC1, UC2, UC3, UC5 and UC6).|
|Separate business responsibilities by structuring GFAB with the use of DDD and other patterns|The adoption of DDD in GFAB allows to separate business responsibilities. The patterns to adopted are: Aggregate Root, Entity, Value Object, Repository, Service. Repository pattern should also be complemented with Factory creational pattern as the controller is agnostic of what repository implementation to use|


|Alternative|Reason for Discarding|
|-----------|---------------------|
|MVP (Model View Presenter) architectural pattern for GFAB|MVP implies that the view can only communicate with the controller, where the presenter acts as a controller interacting with the model directly. Using this architectural pattern would require the controller to have the responsibility to know how to build the view using model|
|MVVM (Model View View Model) architectural pattern for GFAW|Models in GFAW are pure objects that represent the request and response bodies defined by the REST API specification. Using an architectural pattern that implies that the model has the responsibility to send notifications regarding model data changes, would have no benefits for GFAW|


**Step 5**

- Goal: Instantiate architectural elements, allocate responsibilities and define interfaces

To satisfy the structure of the chosen design concepts, the following elements are proposed to be created:

|Design Decisions and Location|Rationale|
|-----------------------------|---------|
|Elaborate domain model|Domain model allows the identification of business concepts, which are necessary to address use cases (UC1, UC2, UC3, UC5, UC6, UC9)|
|Elaborate use cases by actors|To establish actors and their responbilities it is necessary to map the use cases being addressed by their actors|
|Map use cases to domain objects|Use cases can help creating domain objects that have these as their responsibilities|
|Define models interface|To understand how models communicate with each other as well as how their functionalities are produced|
|Decompose GFAB and GFAW in little modules|To explicit all dependencies existent in each component|
|Map domain model using DDD|This helps understanding how DDD should be applied in GFAB|
|Elaborate GFAB REST API|To explicit the specification of the produced functionalities so consumers can understand how requests and responses are performed and structured|
|Explicit sequence of REST API functionalities in GFAB component|To understand the flux of each module interaction each time a functionality is requested|

(FALTA MARCAR QUE ELEMENTOS ABORDAM OS DESIGN CONCEPTS SELECIONADOS, TABELA DE RESPONSABILIDADES)

**Step 6**

- Goal: Sketch views and record design decisions

- Module View:

  **Domain Model**

  ![DomainModel](diagrams/DomainModel.png)

  **Model Objects Class Diagram**

  ![ModelObjectsDiagram](diagrams/ModelObjectsDiagram.png)

  **Aggregate Roots Diagram**

  ![AggregateRoots](diagrams/AggregateRoots.png)

  **GFAB Packages Diagram**

  ![GFAB_Packages_Diagram](diagrams/GFAB_Packages.png)

- Component & Connector View :

 **GFAB Components Diagram Fine-Grain View**

 ![GFAB_Components](diagrams/GFABComponentsDiagramFineGrainView.png)

 **GBAW Components Diagram Fine-Grain View**
 
 ![GFAWComponentDiagram](diagrams/GFAWComponentsDiagramFineGrainView.png)


- Allocation View :

  **Use Case Diagram**

Use Cases chosen to implement given the selected drivers:

![UseCaseDiagram](diagrams/UsesCaseDiagram.png)

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