<?php
    session_start();
    $con = new mysqli("localhost","root","","moja_baza");
    $nalog = $_SESSION['username'];

    if(null == $nalog){
        header('location:index.html');
    }
?>
<html>
<head>
</head>
<body>
    <h4>Cao, <?php echo $nalog ?></h4>
    <form action="upload.php" method="POST" enctype="multipart/form-data">
        <table border="1">
            <tr>
                <th>Profilna slika</th>
                <th>Prijatelji</th>
                <th>Clanovi</th>
                <th>Zahtevi</th>
            </tr>
            <tr>
                <td> <!--profilna -->
                    <?php
                        $q2 = mysqli_query($con,"SELECT * FROM korisnici WHERE Username = '$nalog'");
                        $r2 = mysqli_fetch_assoc($q2);
                        if($r2['Profilna'] == ""){
                            echo '<img width="150" height="150" src="slike/default.png">';
                        }
                        else{
                            $ime = $r2['Profilna'];
                            
                            echo '<img width="200" height="150" src="slike/'.$ime.'">';
                        } 
                    ?>
                </td>
                <td> <!--prijatelji -->
                    <?php
                        $q3 = mysqli_query($con,"SELECT * FROM prijatelji WHERE user1='$nalog'");
                        while($s = mysqli_fetch_assoc($q3)){
                        $us1 = $s['user2'];
                        echo ''.$us1.'<br>';
                        }
                        $q4 = mysqli_query($con,"SELECT * FROM prijatelji WHERE user2='$nalog'");
                        while($s2 = mysqli_fetch_assoc($q4)){
                        $us2 = $s2['user1'];
                        echo ''.$us2.'<br>';
                        }
                    ?>
                </td> 
                <td> <!-- clanovi -->   
                    <ul >
                        <?php
                            $q5 = mysqli_query($con,"SELECT Username FROM korisnici");
                            while($r3 = mysqli_fetch_assoc($q5)){
                                $username = $r3['Username'];
                                echo '<li><a href=vidiprofil.php?korisnik='.$username.'>'.$username.'</a></li>';
                            }
                        ?>
                    </ul>
                </td>
                <td> <!-- zahtevi --> 
                    <?php
                        $q6 = mysqli_query($con,"SELECT * FROM zahtevi WHERE ka = '$nalog'");
                        while($r4 = mysqli_fetch_assoc($q6)){
                        $z = $r4['od'];
                        echo ''.$z.' <a href="profil.php?action=prihvati&user='.$z.'">prihvati</a> | <a href="profil.php?action=ignorisi&user='.$z.'">ignorisi</a> <br> ';
                        }  
                        
                        if(isset($_GET['action']) && isset($_GET['user'])){
                            $action = $_GET['action'];
                            $user = $_GET['user'];
                            if($action == 'prihvati'){
                                mysqli_query($con,"DELETE FROM zahtevi WHERE od = '$user' AND ka = '$nalog'");
                                $q7 = mysqli_query($con,"SELECT * FROM prijatelji WHERE (user1='$nalog' AND user2='$user') OR (user1='$user' AND user2='$nalog')");
                                $r5 = mysqli_num_rows($q7);
                                if($r5 == 0){
                                    mysqli_query($con,"INSERT INTO prijatelji VALUES('','$nalog','$user')");
                                    header('location:profil.php');
                                }
                            }
                        
                            if($action == 'ignorisi'){
                                mysqli_query($con,"DELETE FROM zahtevi WHERE od = '$user' AND ka = '$nalog'");
                                header('location:profil.php');
                            }
                        }    
                    ?>
                </td>
            </tr>
            <tr>
                <td><input type="file" name="file" value="promeni"/></td>
            </tr>
            <tr>
                <td><input type="submit" name="upload" value="Upload"/></td>
            </tr>
        
        </table>
    </form>
    <a href=logout.php>Odjavi se</a>
</body>    
</html>