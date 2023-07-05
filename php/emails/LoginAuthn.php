<?php  


if (isset($_GET["username"]) && isset($_GET["password"])) {
	$username = $_GET["username"];
	$password = $_GET["password"];
  

	$SERVER = "localhost";
	$User  = "root";
	$Pass = "";
	$db_name = "emails";

	$connection = new mysqli($SERVER, $User, $Pass, $db_name);
	if ($connection->connect_error) {
		die("Connection Failed : " . $connection->connect_error);
	} else {
		$sql  = "select  username,password,type from login where username = '$username' and password = '$password' ";
        $sth = mysqli_query($connection,$sql);
		$row = array();
        if($r = mysqli_fetch_assoc($sth))
        {
           $row[]  =$r;
        }
        else
        {
            echo "username or password incorrect";
        }
        print json_encode($row);
        
	}
	
}
else
{
}

?>
