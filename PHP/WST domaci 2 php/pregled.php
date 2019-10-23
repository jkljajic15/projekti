<html> 
    <head> 
        <title>Sportski klub - Pregled</title>
    </head>
    <body> 
        <h1 align="center">Pregled</h1>
        <h3>Info o igracima</h3>
        <table border="1" cellspacing="0"> 
            <tr> 
                <th>Ime</th>
                <th>Prezime</th>
                <th>Pozicija</th>
                <th>Broj</th>
            </tr>
            <?php 
                $con = new mysqli("localhost","root","","klub") or die("Connection failed: " . $con->connect_error);
                $query = mysqli_query($con,"SELECT * FROM igraci");
                while($query == true && $fetch = mysqli_fetch_assoc($query)){
                    
                    $ime = $fetch['ime'];
                    $prezime = $fetch['prezime'];
                    $pozicija = $fetch['pozicija'];
                    $broj = $fetch['broj'];
                    
                    echo '<tr>
                         <td>'.$ime.'</td>
                         <td>'.$prezime.'</td>
                         <td>'.$pozicija.'</td>
                         <td>'.$broj.'</td>
                         </tr>';
                }
            ?>
        </table>
        <h3>Takmicenja</h3>
        <table border="1" cellspacing="0">
            <tr>
                <th>Ime takmicenja</th>
                <th>Datum</th>
                <th>Grad</th>
                <th>Osvojeno mesto</th>
            </tr>
            <?php
                $query = mysqli_query($con,"SELECT ime_takmicenja, odrzano, grad, mesto FROM takmicenja");
                    
                while($query == true && $fetch = mysqli_fetch_assoc($query)){
                    
                    echo '<tr>
                            <td>'.$fetch['ime_takmicenja'].'</td>
                            <td>'.$fetch['odrzano'].'</td>
                            <td>'.$fetch['grad'].'</td>
                            <td>'.$fetch['mesto'].'</td>
                         </tr>';
                }
            ?>
        </table>
        <br>
        <a href="index.php">Unos</a>
        <a href="vesti.php">Vesti</a>
    </body>
</html>