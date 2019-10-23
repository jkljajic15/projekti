<?php

    $con = new mysqli('localhost','root','','moja_baza');
    
    $mail = $_GET['email'];
    $kod = $_GET['Kod'];

    $sql = "SELECT * FROM korisnici WHERE email = '$mail' AND Kod = '$kod'";
    $result = $con -> query($sql) or die('Greska :' . $con -> error);
    $line = $result -> fetch_assoc();
    //print_r($line);

    
    if( $line > 0){
        //potvrdi acc
        mysqli_query($con,"UPDATE korisnici SET Potvrdjen = '1'");
        echo 'email verifikovan <a href=index.html>Nazad</a>';
    }
    else{
        echo 'Pogresan url';
        
    }
?>