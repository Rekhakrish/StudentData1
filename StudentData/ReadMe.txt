StudentData Task:
Part 1:Create a folder in D drive with name as StudentData.
Create 3 folders in it. 
1. Unprocessed
2. Processed
3. ErrorCopy StudentMarks.csv file into Unprocessed folder.
Now, create C# windows application (Those working on C#), Create VB.Net windows application (Those working on VB.Net). 
The screen will have just a button with name Start Processing.
Clicking on it, once the processing over, there should be pop up alert to indicate Folder Empty (If no files available in UnProcessed Folder) or Error or Successfully Processed and show number of rows.
If csv file is succesfully processed, the file should be moved to Processed folder.If there is any error while processing, the file should be moved to Error.

Part 2: (22-Feb-2023)Open Database.xlsx file.
Create 3 tables with data in SQL server Database as shown in excel and enter data to some tables as mentioned in Excel.
Code the logic to Save data that was read from csv file in earlier task to StudentMarks table.
Once successfully saved data to table, show message as no. of students processed (Not no. of rows) in pop up window.
As earlier, the file should be automatically moved to Processed folder. 

Part 3: (24-Feb-23)
Create a Search screen in same application. Provide search option as Student Name, Student Roll No, Subject.
On clicking search, based on optional search criteria show a grid below Search section.
GridView to show Student Name, Student Roll No, Subject Name and Subject Marks.
Provide row wise inline Edit, Delete buttons. Clicking on Edit will show a pop up with that particular student data. 
Subject Marks can be editable in that; all other fields should be non-editable. 
Clicking on Save in that pop up should Save updated marks, show saved message. Refresh the grid with updated marks.
Clicking on Delete should show a confirmation message, on clicking Yes the data to be deleted from Database and Grid to be refreshed.
Add menu or any other provision to navigate between earlier screen (Process Student Data from csv) and this screen to Search Student Data.