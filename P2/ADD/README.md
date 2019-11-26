# README

## ARQSOFT 2019 / 2020 (Part 2)

### Roadmap

The software being developed is a brownfield system, so it is proposed the following roadmap for each ADD iteration

**Iteration 1**

- Goal: Refine software architecture

- Description: In this iteration it is intended that the design of the previously developed software architecture is refined to include new architectural drivers

- Design Concepts:
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

| ID | Use Case | Description | Priority | Difficulty | Appeared in | Addressed in |
|-----|---------| ----------- | -------- | ---------- | ----------- | ------------ |
| UC1 | Register Item Purchase | Without taking payment into account, a meal's purchase has to be registered in order to maintain an updated inventory of the available meals | Low | High |Stakeholder Feedback (Pre-iteration 1)| Iteration 3 |
| UC2 | Register Item to Inventory | The unserved meal (item) is labeled with designation, identification number, production and expiration dates, with its quantity specified | High | High |Stakeholder Feedback (Pre-iteration 1)| Iteration 2 |
| UC3 | Remove Existing Item from Inventory | It should be possible to remove an existing unserved meal (item) from the inventory | High | Medium |Stakeholder Feedback (Pre-iteration 1)|Iteration 2|
| UC4 | Create new Meal Descriptor | Every meal can have descriptors (ex: 2g of Vitamin D for every 100g or 300 calories for every 100g), but must be extensible | Low | High |Stakeholder Feedback (Pre-iteration 1)|Iteration 3|
| UC5 | View Meal Details | View a characterization regarding the meal's designation, type, nutritional data, ingredients and alergens | Medium | Low |Stakeholder Feedback (Pre-iteration 1)|Iteration 2|
| UC6 | Create Meal | Create new meal with type, description, ingredients and allergens | High | High |Stakeholder Feedback (Pre-iteration 1)|Iteration 2|
| UC7 | Generate Management Reports | Should provide reports such as the number of meals, grouped by type, sold between a period of time in a day (ex: 2pm to 9pm) or days of the week | Low | High |Stakeholder Feedback (Pre-iteration 1)|--|
| UC8 | View User Logs/Activities | The administrator can see every executed operation and can be filtered by date or type of operation | Low | High |Stakeholder Feedback (Pre-iteration 1)|Iteration 3|
| UC9 | Edit Meal | The kitchen workers can update any information at any given time of a meal | Medium | Medium |Stakeholder Feedback (Pre-iteration 1)|--|
| UC10 | Edit Item Quantity | The kitchen workers can correct the available quantity in inventory of an item at any given time | High | Medium |Stakeholder Feedback (Pre-iteration 1)|--|
| UC11 | Add Allergens | The kitchen workers can insert allergens | Medium | High |Stakeholder Feedback (Pre-iteration 1)|Iteration 3|
| UC12 | Add Meal Types | The kitchen workers can insert meal types | Medium | High |Stakeholder Feedback (Pre-iteration 1)|Iteration 3|
| UC13 | Add Ingredients | The kitchen workers can insert ingredients | Medium | High |Stakeholder Feedback (Pre-iteration 1)|Iteration 3|
| UC14 | Consult meal allergens | It is necessary to provide a mechanism that allows the retrieval of the allergens of a specific meal. This use of this mechanism should be available to everyone without the need of authentication | High |Low| Pre-iteration 4 | -- |
| UC15 | Consult meal ingredients | It is necessary to provide a mechanism that allows the retrieval of the ingredients of a specific meal. This use of this mechanism should be available to everyone without the need of authentication | High |Low| Pre-iteration 4 | -- |
| UC16 | Consult meal nutritional data | It is necessary to provide a mechanism that allows the retrieval of the nutritional data of a specific meal. This use of this mechanism should be available to everyone without the need of authentication | High |Low| Pre-iteration 4 | -- |
| UC17 | Specify new PoS (Point of Sell) | It is necessary to specify the existing PoS as items are only available in each PoS | High | Medium | Pre-iteration 4 | -- |
| UC18 | Transfer item between PoS | It is possible that an item is transfered from one point of sell to other point of sell | Medium | High | Pre-iteration 4 | -- |
| UC19 | Query item quantity availability | It is necessary to provide a mechanism that allows the retrieval of the available items for a specific meal | High | Medium | Pre-iteration 4 | -- |


**Constraints**

| ID | Constraint | Appeared in | Addressed in |
|----|------------| ----------- | ------------ |
| CON-1 | Application accessible from a variety of platforms via web browser |Stakeholder Feedback (Pre-iteration 1)| Iteration 1 |
| CON-2 | Application must be developed by the schools technical staff |Stakeholder Feedback (Pre-iteration 1)|--|
| CON-3 | First release planned after two months |Stakeholder Feedback (Pre-iteration 1)|--|
| CON-4 | A PoC should be presented within five weeks|Stakeholder Feedback (Pre-iteration 1)|Iteration 2|
| CON-5 | Adoption of open-source tecnologies |Stakeholder Feedback (Pre-iteration 1)|Iteration 1|
| CON-6 | It is intended that the introduction of new  meal descriptors affects very little, or nothing, other components of the application. |Stakeholder Feedback (Pre-iteration 1)|Iteration 2|
| CON-7 | A change in the meal identification number should not affect more than one architeture component |Stakeholder Feedback (Pre-iteration 1)|Iteration 3|
| CON-8 | Change in the generation of this number identification is to be implemented and tested with no side effects in 1 person-day of effort.|Stakeholder Feedback (Pre-iteration 1)|Iteration 3|
| CON-9|  The school has a database server with a backup policy implemented and it is to be used by the application to be developed |Stakeholder Feedback (Pre-iteration 1)|--|
| CON-10 | User directory server used by other applications in the school and the new application is also to use it |Stakeholder Feedback (Pre-iteration 1)|--|
| CON-11 | Administrator should be able to query user logs and see their activities, all of them, or performed between dates or only some type of activies |Stakeholder Feedback (Pre-iteration 1)|Iteration 3|
| CON-12 | It should be possible to generate reports in more than one language|Stakeholder Feedback (Pre-iteration 1)|--|
| CON-13 | Ingredients, allergens and nutrition data for meals are to be accessible without the need for authentication |Pre-iteration 4|--|
| CON-14 | This application must be developed by the school’s technical sta and should be available in nine months |Pre-iteration 4|--|
| CON-15 | Within four weeks queries related to the number of available items for specific meals,but also adding and removing new items to inventory (microservices) should be demonstrated to many stakeholders |Pre-iteration 4|--|
| CON-16 | Aware of these dificulties, this very initial prototype does not need to use service discov-ery registries, but local method calls need to be replaced by synchronous remote calls,or better options. |Pre-iteration 4|--|
| CON-17 | Direct dependencies in the database are to be eliminated depending on the adopted data management strategies |Pre-iteration 4|--|
| CON-18 | For the nutritional descriptors, it is necessary to consider their designation, measureunit, but also the maximum reasonable amount to be used for validation purposes |Pre-iteration 4|--|


**Concerns**

| ID | Concern | Importance | Difficulty | Appeared in | Addressed in |
|--- | ------- | ---------- | ---------- | ----------- | ------------ |
| CRN-1 | Multilanguage support | Medium | Medium |Stakeholder Feedback (Pre-iteration 1)|--|
| CRN-2 | Authentication | Medium | High |Stakeholder Feedback (Pre-iteration 1)|--|
| CRN-3 | Authorization | Medium | High |Stakeholder Feedback (Pre-iteration 1)|--|
| CRN-4 | Activity Log | High | Medium |Stakeholder Feedback (Pre-iteration 1)|Iteration 3|
| CRN-5 | Team difficulty with the implementation of Update functionalities | Medium | High |Stakeholder Feedback (Pre-iteration 1)|--|

**Quality Attributes**

| ID | Quality Attribute | Scenario | Associated Use Case | Appeared in | Addressed in |
|----|-------------------|----------|---------------------| ----------- | ----------- |
| QA-1| Portability | The application must be accessible from all devices that provide a web browser | All |Stakeholder Feedback (Pre-iteration 1)|Iteration 1|
| QA-2 | Localizability | Multilanguage support is desirable as the school accepts foreign students on a regular base, as well as it can attract tourists | All |Stakeholder Feedback (Pre-iteration 1)|--|
| QA-3 | Auditability | The application should be able to provide management reports in more than one language. Activity logging is also considered | All |Stakeholder Feedback (Pre-iteration 1)|--|
| QA-4 |  | The application should provide fast responses in comparison to inventory updates |Pre-iteration 4|--|