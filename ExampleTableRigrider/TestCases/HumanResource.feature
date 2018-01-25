Feature: HumanResource
	Create People/Designation/Location in HR maintenance on the web Rigrider

@HR_Maintenance
Scenario: HR_01 Mananger can be access Human Resource Page
	Given Access the rigrider web portal
	And Login as rigrider administrator
	When Navigate to the HR Maintenance Page
	Then The HR Maintenance Page should be displayed

@HR_Maintenance
Scenario: HR_02 Manager can be access all Tab in HR maintenance Page
	Given Navigate to the HR Maintenance Page
	And Click on the Tab People
	When Click on the Tab Designation
	And Click on the Tab Location
	Then All Tabs can be clicked and displayed

@HR_Maintenance
Scenario: HR_03 Manager can be Created People in People Tab - Dictionary
	Given Navigate to the HR Maintenance Page
	And Click on the Tab People
	When Click on the Create People Button 
	And Create name on the people for Dictionary 
	| Key          | Value            |
	| Identifier   | OM-005           |
	| Firstname    | Jhordy           |
	| Lastname     | Biim             |
	| Display Name | Jhordy Biim      |
	| Organization | Operator Machine |
	And Click on the save button for people
	Then the Name People is "Jhordy Biim" can be added and shown in overview list

Scenario: HR_04 Manager can be Created People in People Tab - Table into DataTable
	Given Navigate to the HR Maintenance Page
	And Click on the Tab People
	When Click on the Create People Button 
	And Create name on the people for CreateSet in SpecFlow Table 
	| Identifier | Firstname | Lastname  | Display Name     | Organization |
	| OM-005     | Sherly    | Catherina | Sherly Catherina | Engineering  |
	And Click on the save button for people
	Then the Name People is "Sherly Catherina" can be added and shown in overview list

@HR_Maintenance
Scenario: HR_05 Mananger can be Created Designation in Designation Tab
	Given Navigate to the HR Maintenance Page
	And Click on the Designation Tab
	When Click on the Create Designation Button
	And Fill in the name Designation with "Operator Machine"
	And Click on the save button
	Then the Name Designation is " Operator Machine " can be added and shown in overview list
	
