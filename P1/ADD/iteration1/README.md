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

| ID | Use Case | Priority | Difficulty |
|-----|---------| ----------|-----------|
| UC1 | Add new item to inventory | High | Low  |
| UC2 | Remove an item from inventory | High | Low |
| UC3 | Produce a management report | High | Medium | 
| UC4 | Add a new meal descriptor | High | High |

**Constraints**

| ID | Constraint |
|----|------------|
| CON-1 | Application accessible from a variety of platforms via web browser |
| CON-2 | Application must be developed by the school´s techincal staff |
| CON-3 | First release planned after two months |
| CON-4 | A PoC should be presented within five weeks|
| CON-5 | Adoption of open-source tecnologies |
| CON-6 | It is intended that the introduction of new  meal descriptors affects very little, or nothing, other components of the application. |
| CON-7 | A change in the meal identification number shouldn´t affect more than one architeture component |
| CON-8 | Change in the generation of this number identification is to be implemented and tested with no side effects in 1 person-day of effort.|
| CON-9|  The school has a database server with a backup policy implemented and it is to be used by the application to be developed |
| CON-10 | user directory server used byother applications in the school and the new application is also to use it |
| CON-11 | Administrator should be able to query user logs and see their activities, all of them, or performed between dates or only some type of activies |
| CON-12 | It should be possible to generate reports in more than one language|

**Concerns**

| ID | Concern  | Importance |  Difficulty |
|-----|---------| ----------- | ----------- |
| CRN-1 | Multilanguage support | Medium | Low |
| CRN-2 | Authentication | High | -- |
| CRN-3 | Authorization | High | -- |
| CRN-4 | Activity Log | High | -- |

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

