<?php
$db_name = "zkeulenm001";
$server_name= "localhost";
$server_username = "keulenm001";
$server_password = "GXu+B3rgaRw1u#";

$key = $_POST['key'];
$value = $_POST['value'];

$conn = new mysqli($server_name, $server_username, $server_password, $db_name);

if(!$conn){
    die("Connection Failed. ". mysqli_connect_error());
}

$sql = "SELECT 1 FROM Users WHERE '$key' = '$value'";
$result = mysqli_query($conn, $sql);
echo $result;

if($result && mysqli_num_rows($result) > 0){
    echo 'Username already exists';
}
else{
    echo $result;
    echo 'Username not taken';
}
mysqli_close($conn);
?>