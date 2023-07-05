<?php


if (isset($_GET["username"]) && isset($_GET["datetimeNow"]) ) {
	$username = $_GET["username"];
	$datetimeNow = $_GET["datetimeNow"];

	$SERVER = "localhost";
	$User  = "root";
	$Pass = "";
	$db_name = "emails";
	
	$sql = "SELECT id,mail_title,username,date_mail,isSigned,UserSigned,file_name FROM `mails` WHERE  date_mail like '%$datetimeNow%' and ArchiveSent = 1  ORDER BY `mails`.`id` ASC ";


	$connection = new mysqli($SERVER, $User, $Pass, $db_name);
	if ($connection->connect_error) {
		die("Connection Failed : " . $connection->connect_error);
	} else {
		$sql  = 
        $sth = mysqli_query($connection,$sql);
		$row = array();
        while($r = mysqli_fetch_assoc($sth))
        {
          $row[]  =$r;
        }
        print json_encode($row);
 
        
	}
	
}
?>

