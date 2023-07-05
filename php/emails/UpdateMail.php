<?php


if (isset($_GET["filename"])&&isset($_GET["mail_title"]) && isset($_GET["date"]) ) {
	

  $filename = $_GET["filename"];
  $mail_title = $_GET["mail_title"];
  $date_time = $_GET["date"];
  try
  {
  $dest = dirname(__FILE__) ."\media\\" . $filename;


	$SERVER = "localhost";
	$User  = "root";
	$Pass = "";
	$db_name = "emails";
	$connection = new mysqli($SERVER, $User, $Pass, $db_name);

  
	if ($connection->connect_error) {
		die("Connection Failed : " . $connection->connect_error);
	} else {
		$sql  = "update mails set mail_title = '$mail_title',date_mail = '$date_time' WHERE file_name = '$filename' ";
        if($connection->query($sql))
        {
          $tmp_name = $_FILES["file"]["tmp_name"];
          move_uploaded_file($tmp_name,$dest);   
           echo "Done754@";
        }
        else
        {
            echo "Not updated";
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




