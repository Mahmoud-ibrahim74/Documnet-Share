<?php


if (isset($_POST["file_path"])&&isset($_POST["signed"])&&isset($_POST["user_name"])&&isset($_POST["userType"])&&isset($_POST["filename"])&&isset($_POST["mail_title"])) {
	
  $file_path = $_POST["file_path"];
  $signed = $_POST["signed"];
  $user_name = $_POST["user_name"];
  $userType = $_POST["userType"];
  $filename = $_POST["filename"];
  $mail_title = $_POST["mail_title"];
  $date_time = $_POST["date"];

  
  try
  {
  $dest = dirname(__FILE__) ."\media\\" . $filename;
  copy($file_path,$dest);
	$SERVER = "localhost";
	$User  = "root";
	$Pass = "";
	$db_name = "emails";
	$connection = new mysqli($SERVER, $User, $Pass, $db_name);
	if ($connection->connect_error) {
		die("Connection Failed : " . $connection->connect_error);
	} else {
		$sql  = "INSERT INTO mails(mail_title, user_type, username, date_mail, isSigned, file_name) VALUES ('$mail_title','$userType','$user_name','$date_time','$signed','$filename')";
        if($connection->query($sql))
        {

           echo "Done742@";
        }
        else
        {
            echo "Not inserted";
        }
        
	}
  }
    catch(Exception $e)
    {
       echo "error : " . $e->getMessage();
    }
	
}
else
{
}
 


?>




