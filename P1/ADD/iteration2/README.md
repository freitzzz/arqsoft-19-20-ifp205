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
| UC2 |||
| UC3 |||
| UC5 |||
| UC6 |||
| UC9 |||
| UC11 |||
| UC12 |||
| UC13 |||
| UC10 |||
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

- Aggregates
- Entities
- Value Objects
- Repositories 
- Services beucase in iteration 1 SOA (Service Oriented Architecture)was defined as a architeture style
- Factories

**Step 5**

- Goal: Instantiate architectural elements, allocate responsibilities and define interfaces

To satisfy the structure of the chosen design concepts, the following elements are proposed to be created:

**Step 6**

- Goal: Sketch views and record design decisions

Use Cases chosen to implement given the selected drivers:

![UseCaseDiagram](artefacts/UsesCaseDiagram.png)

**Step 7**

- Goal: Perform analysis of current design and review iteration goal and achivements of design purposes