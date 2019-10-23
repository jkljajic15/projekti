<?php
    
    $username = $_POST['username'];
    $password = $_POST['password'];
    $mail = $_POST['email'];
    $kod = md5(rand(0,1000));
 
    $con = new mysqli('localhost','root','','moja_baza');
    $sql = "INSERT INTO `korisnici`(`Username`, `Password`, `email`,`Kod`) VALUES ('$username','$password','$mail','$kod')";

    if($con -> query($sql)){
        echo 'Registracija je uspesna! Verifikujte svoj nalog! <a href=index.html>Nazad</a>';
        $to = $mail;
        $subject = 'Verifikacija naloga';
        $poruka = '
        
        Uspesno ste se registrovali!
        Username: ' . $username . '
        Password: ' . $password . '
        Kliknite na link da bi ste verifikovali svoj nalog:
        http://localhost/projekat/potvrda.php?email=' . $mail . '&Kod=' . $kod . '
        
        ';
        mail($to,$subject,$poruka);
    }
    else{
        echo 'Doslo je do greske: ' . $con -> error . ' ' . '<a href=index.html>Nazad</a>';
    }
    
    
        

  
    
        
        
        
   
    
?>