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

### Iteration1

### Drivers

**Use Cases**

| ID | Use Case | Priority | Difficulty |
|-----|---------| ----------|-----------|
| UC1 | Add new item to inventory | High | Low  |
| UC2 | Remove a item from inventory | High | Low |
| UC3 | Change the identification number of a meal |  High | Medium |
| UC4 | Produce a management report | High | Medium | 
| UC5 | Addition of a new descriptor | High | High |

**Constraints**

| ID | Constraint |
|----|------------|
| CON-1 | Application accessible from a variety of platforms via web browser |
| CON-2 | Application must be developed by the school´s techincal staff |
| CON-3 | First release planned after two months |
| CON-4 | A PoC should be presented within five weeks|
| CON-5 | Adoption of open-source tecnologies |
| CON-6 |  It is intended that the introduction of new ones affects very little, or nothing, other components of the appli
cation. |
| CON-7 | UC6 should be completed and tested in less than 0.5 (1 person for two days?) person-day of effort |
| CON-8 | UC4 shouldn´t affect more than one architeture component |
| CON-9 | Change in the generation of this number identification is to be implemented with no side effects in 1 person-day of effort.
| CON-10|  The school has a database server with a backup policy implemented and it is to be used by the application to be developed | High | Low |
| CON-11 | user directory server used byother applications in the school and the new application is also to use it | -- | -- |
| CON-12 | Administrator should be able to query user logs and see their activities, all of them, or performed between dates or only some type of activies |

**Concerns**

| ID | Concern  | Importance |  Difficulty |
|-----|---------| ----------- | ----------- |
| CRN-1 | Multilanguage support | Medium | Low |
| CRN-2 | Reports multilanguage | High | Medium |
| CRN-3 | Authentication | High | -- |
| CRN-4 | Authorization | High | -- |
| CRN-5 | Activity Log | High | -- |

**Quality Attributes**

| ID | Quality Attribute | Scenario | Associated Use Case |
| QA-1| Portability | The application must be accessible from all devices that provide a web browser | All |
| QA-2 |||
| QA-1 |Auditability|--|
| QA-2 |||



### Kanban Board

| Not Addressed | Partially Addressed | Addressed |
|---------------|---------------------|-----------|
| UC1 |  | 
| UC2 |  |
| UC3 |  |
| UC4 |  |
| UC5 |  |
| CON-1 |  | 
| CON-2 | |
| CON-3 | |
| CON-4 | |
| CON-5 | |
| CON-6 | |
| CON-7 | |
| CON-8 | |
| CON-9 | |
| CON-10 | |
| CON-11 | |
| CRN-1 | |
| CRN-2 | |
| CRN-3 | |
| CRN-4 | |
| CRN-5 | | 