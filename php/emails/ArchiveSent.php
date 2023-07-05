<?php
if (isset($_GET["id"])) {


	$ID = $_GET["id"];

	$sql = "update mails set ArchiveSent = 1   WHERE   id = '$ID' ";

	$SERVER = "localhost";
	$User  = "root";
	$Pass = "";
	$db_name = "emails";



	$connection = new mysqli($SERVER, $User, $Pass, $db_name);
	if ($connection->connect_error) {
		die("Connection Failed : " . $connection->connect_error);
	} else {
		$sth = mysqli_query($connection, $sql);
		if($sth == true)
		{
			echo "Done650@";
		}
		else
		{
			echo "Something Wrong !! Please Try Again";
		}
	}
}
