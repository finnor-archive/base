Copy httpd.conf file into a any folder [pathname1]
	Edit httpd.conf file
		Select a pathway for http files, html php etc and set Document Root to "DocumentRoot [pathname2]"
	Copy studentServer.php, bookServer.php, bookClient.html to [pathname2]

Start apache cd c:/program files (x86)\Apache2\bin
	apache -f [pathname1]/httpd.conf

Open Browser
	Type localhost/bookClient.html into url bar
	
	The top form is a form for a teacher to input the correct book information for a course into the database
	The bottom form is for the student to input his book information. Upon entry the database of student books
		will update and denote whether a student has the appropriate book or not and if wrong, what is 
		wrong with it.
	The bottom reflects the database of student entries.

	If you wish to empty either the database of students or database of correct book information
		delete dbStudents or dbClasses file in [pathname2], respectively.


