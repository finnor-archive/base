function addTeacher(myCourse, myBookTitle, myBookPub, myBookEd, myBookDate, myBookTitle2, myBookPub2, myBookEd2, myBookDate2) {
  request = new XMLHttpRequest();
  request.open("GET","bookServer.php?course="+myCourse+"&bookTitle="+myBookTitle+"&bookPub="+myBookPub+"&bookEd="+myBookEd+"&bookDate="+myBookDate+"&bookTitle2="+myBookTitle2+"&bookPub2="+myBookPub2+"&bookEd2="+myBookEd2+"&bookDate2="+myBookDate2);
  request.onreadystatechange = checkData;
  request.send(null);
} // end function

function addStudent(myCourse, myFirst, myLast, myBookTitle, myBookPub, myBookEd, myBookDate, myBookTitle2, myBookPub2, myBookEd2, myBookDate2) {
  request = new XMLHttpRequest();
  request.open("GET","studentServer.php?course="+myCourse+"&first="+myFirst+"&last="+myLast+"&bookTitle="+myBookTitle+"&bookPub="+myBookPub+"&bookEd="+myBookEd+"&bookDate="+myBookDate+"&bookTitle2="+myBookTitle2+"&bookPub2="+myBookPub2+"&bookEd2="+myBookEd2+"&bookDate2="+myBookDate2);
  
  request.onreadystatechange = checkData2;
  request.send(null);
} // end function

function checkData2() {

  if (request.readyState == 4) {
    //if state is finished
    if (request.status == 200) {
      document.getElementById("studentArray").innerHTML=request.responseText;
    } // end if
  } // end if

} // end checkData
    
function checkData() {

  if (request.readyState == 4) {
    //if state is finished
    if (request.status == 200) {
      // and if attempt was successful
       alert(request.responseText);
    } // end if
  } // end if

} // end checkData