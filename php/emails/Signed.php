<?php
if (isset($_GET["id"])&& isset($_GET["userSigned"]) ) {


	$ID = $_GET["id"];
    $UserSigned = $_GET["userSigned"];
	$sql = "update mails set isSigned = 1,UserSigned = '$UserSigned'   WHERE   id = $ID ";

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
			echo "Done900@";
		}
		else
		{
			echo "Something Wrong !! Please Try Again";
		}

	}
}
