<?php       
		//gets data
        $c = $_GET['course'];
        $t = $_GET['bookTitle'];
        $p = $_GET['bookPub'];
        $e = $_GET['bookEd'];
		$d = $_GET['bookDate'];
        $t2 = $_GET['bookTitle2'];
        $p2 = $_GET['bookPub2'];
        $e2 = $_GET['bookEd2'];
		$d2 = $_GET['bookDate2'];
 
		//opens database and loads into array
		$array = unserialize(file_get_contents('dbClasses'));
		
		
		//create and add the new book information
		$myEntry = $t . "|" . $p . "|" . $e . "|" . $d . "|" . $t2 . "|" . $p2 . "|" . $e2 . "|" . $d2;
		$array[$c] = $myEntry;
		
		//saves database
		file_put_contents('dbClasses', serialize($array));
		
		
        echo "Following Book Info Added: " . $myEntry;
?>

