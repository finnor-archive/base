<?php       
		//gets data
		$c = $_GET['course'];
        $f = $_GET['first'];
		$l = $_GET['last'];
        $t = $_GET['bookTitle'];
        $p = $_GET['bookPub'];
        $e = $_GET['bookEd'];
		$d = $_GET['bookDate'];
        $t2 = $_GET['bookTitle2'];
        $p2 = $_GET['bookPub2'];
        $e2 = $_GET['bookEd2'];
		$d2 = $_GET['bookDate2'];
 
 
 
 
 
		//Gets Correct Book Info from Teacher DB
		$bookArray = unserialize(file_get_contents('dbClasses'));
		$temp = $bookArray[$c];
		$bookInfo = explode("|", $temp);
		
		
		
		
		
		
		//Determines if the student has the correct books
		if ($t!=$bookInfo[0])
		{
			$err = "Wrong Book 1";
		}
		else if ($p!=$bookInfo[1])
		{
			$err = "Wrong Book 1";
		}
		else if ($e!=$bookInfo[2])
		{
			$err = "Wrong Edition 1";
		}
		else if ($d!=$bookInfo[3])
		{
			$err = "Wrong Date 1";
		}
		else if ($t2!="")
		{
				if ($t2!=$bookInfo[4])
				{
					$err = "Wrong Book 2";
				}
				else if ($p2!=$bookInfo[5])
				{				
					$err = "Wrong Book 2";
				}
				else if ($e2!=$bookInfo[6])
				{
					$err = "Wrong Edition 2";
				}
				else if ($d2!=$bookInfo[7])
				{
					$err = "Wrong Date 2";
				}
				else
				{
					$err = "Correct Books";
				}
		}
		else
		{
			$err = "Correct Books";
		}
		

		
		//Gets database of student info and adds the new entry
		$db = unserialize(file_get_contents('dbStudents'));
		$myEntry = $c . "|" . $t . "|" . $p . "|" . $e . "|" . $d . "|" . $t2 . "|" . $p2 . "|" . $e2 . "|" . $d2 . "|" . $err;
		$name = $l . ", " . $f;
		$db[$name] = $myEntry;
		file_put_contents('dbStudents', serialize($db));

		
		//Create Table to Display Student Book Information
		$table = "<table>";
		$table .= "<tr>";
		$table .=  "<td>Name</td>";
		$table .=  "<td>Course</td>";
		$table .=  "<td>Book Title 1</td>";
		$table .=  "<td>Book Publisher 1</td>";
		$table .=  "<td>Book Edition 1</td>";
		$table .=  "<td>Book Date 1</td>";
		$table .=  "<td>Book Title 2</td>";
		$table .=  "<td>Book Publisher 2</td>";
		$table .=  "<td>Book Edition 2</td>";
		$table .=  "<td>Book Date 2</td>";
		$table .=  "<td>Book Status</td>";
		$table .= "</tr>";			
		
		//Prints info to table
		foreach($db as $key => $array) 
		{
			$table .= "<tr>";
			$table .=  "<td>$key</td>";
			$array = explode("|", $array);
			foreach($array as $element) 
			{
				$table .= "<td>$element</td>";
			}
			$table .= "</tr>";
		}
		$table .= "</table>";
        echo $table;
?>
