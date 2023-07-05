<?php


if (isset($_GET["filename"])) {
	

  $filename = $_GET["filename"];

  try
  {

	$SERVER = "localhost";
	$User  = "root";
	$Pass = "";
	$db_name = "emails";
	$connection = new mysqli($SERVER, $User, $Pass, $db_name);
	if ($connection->connect_error) {
		die("Connection Failed : " . $connection->connect_error);
	} else {
		$sql  = "DELETE FROM mails WHERE file_name ='$filename'";
        if($connection->query($sql))
        {
           $filename = $_GET["filename"];
           $dest = "../emails/media/" . $filename;
           if(unlink($dest))
           {
            echo "Done790@";
          }
          else
          {
            echo "error to delete file";
          }

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




