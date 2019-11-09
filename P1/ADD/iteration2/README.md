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

- Architectural Patterns:
    - MVC (Model-View-Controller) architectural pattern which allows a clean separation of responsibilities in GFAB and GFAW components. Model will hold responsibilities regarding business logic functionalities and definitions, while controller handles the produced interface requests as well as any other external component communication. View will have the responsibility to define passive views that represent state of requests and responses using models data. In GFAW the controller handles events that are emitted from the view, and the model are model definitions that are consumed of GFAB component.

- Adoption of **DDD** in GFAB component, by defining:
    - Aggregate Roots for entities
    - Entities for models that have identity
    - Value Objects for concepts that add value to domain
    - Repositories for aggregate roots
    - Services in order to hide complex domain logic
- Other Design Patterns:
    - Factories (Creational Pattern)


(FALTA ALTERNATIVAS + RAZOES PARA NAO ADOPTAR ESTAS, MARCAR NOS DESIGN CONCEPTS SELECIONADOS QUE DRIVERS ESTES SATISFAZEM)


**Step 5**

- Goal: Instantiate architectural elements, allocate responsibilities and define interfaces

To satisfy the structure of the chosen design concepts, the following elements are proposed to be created:

- Domain Model
- Use Case Diagram
- Models Objects Class Diagram
- Aggregate Roots Diagram
- Package Diagram of each GFAB sub-component
- End-To-End Generic Sequence Diagram of a functionality in GFAB component
- Fine-Grain GFAB Components Diagram
- Fine-Grain GFAW Components Diagram
- GFAB REST API Specification

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

- Component & Connector View :

 **GFAB Components Diagram Fine-Grain View**

 ![GFAB_Components](diagrams/GFABComponentsDiagramFineGrainView.png)

 **GBAW Components Diagram Fine-Grain View**
 
 ![GFAWComponentDiagram](diagrams/GFAWComponentsDiagramFineGrainView.png)


- Allocation View :

  **Use Case Diagram**

Use Cases chosen to implement given the selected drivers:

![UseCaseDiagram](diagrams/UsesCaseDiagram.png)

(FALTAM DOMAIN OBJECTS A ILUSTRAR RESPONSABILIDADES)

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