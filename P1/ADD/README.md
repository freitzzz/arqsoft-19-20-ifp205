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