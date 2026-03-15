1. Student System
Your task is to create a database for the StudentSystem, using the EF Core Code First approach. It should look like this:

Constraints
Your namespaces should be:

* P01_StudentSystem – for your Startup class, if you have one
* P01_StudentSystem.Data – for your DbContext
* P01_StudentSystem.Data.Models – for your models

Your models should be:

* StudentSystemContext – your DbContext
* Student

o StudentId
o Name – up to 100 characters, unicode
o PhoneNumber – exactly 10 characters, not unicode, not required
o RegisteredOn
o Birthday – not required

* Course

o CourseId
o Name – up to 80 characters, unicode
o Description – unicode, not required
o StartDate
o EndDate
o Price

* Resource

o ResourceId
o Name – up to 50 characters, unicode
o Url – not unicode
o ResourceType – enum, can be Video, Presentation, Document or Other
o CourseId

* Homework

o HomeworkId
o Content – string, linking to a file, not unicode
o ContentType - enum, can be Application, Pdf or Zip
o SubmissionTime
o StudentId
o CourseId

* StudentCourse – mapping between Students and Courses

Table relations:	

* One student can have many Courses 
* One student can have many Homeworks 
* One course can have many Students
* One course can have many Resources
* One course can have many Homeworks

You will need a constructor, accepting DbContextOptions to test your solution in Judge!







