<?php
if (isset($_GET["LoadMore"]) && isset($_GET["username"])&& isset($_GET["userType"])) {


	$LoadMore = $_GET["LoadMore"];
	$username = $_GET["username"];
	$UserType = $_GET["userType"];


	if (isset($_GET["QueryFilter"])) {
		$query = $_GET["QueryFilter"];
		$sql  = "SELECT id,mail_title,username,date_mail,isSigned,UserSigned,file_name FROM mails $query  ";
	} else {
		if ($UserType == "3")
			$sql  = "SELECT id,mail_title,username,date_mail,isSigned,UserSigned,file_name FROM mails where username = '$username' ORDER BY mails.id ASC LIMIT $LoadMore  ";
		else
			$sql  = "SELECT id,mail_title,username,date_mail,isSigned,UserSigned,file_name FROM mails  ORDER BY mails.id ASC LIMIT $LoadMore  ";
	}

	$SERVER = "localhost";
	$User  = "root";
	$Pass = "";
	$db_name = "emails";
	$connection = new mysqli($SERVER, $User, $Pass, $db_name);
	if ($connection->connect_error) {
		die("Connection Failed : " . $connection->connect_error);
	} else {
		$sth = mysqli_query($connection, $sql);
		$row = array();
		while ($r = mysqli_fetch_assoc($sth)) {
			$row[]  = $r;
		}
		print json_encode($row);
	}
}
