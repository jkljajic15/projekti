<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Update</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <style>
        table, th, td 
        {
            border: 1px solid black;
            border-collapse: collapse;
            margin:auto;
        }
        th, td 
        {
            padding: 15px;
        }
    </style>
</head>
<body>
        <?php 
            require 'konekcija.php';
            if(!empty($_GET))
            {
                $id= $_GET['id'];
                $stmt = $pdo->prepare("SELECT * FROM studenti WHERE StudentId = :id");
                $stmt->execute(['id' => $id]);
                $student = $stmt->fetch();
                //var_dump($student['StudentId']);
            }
            else
            {
                echo 'Student nije izabran';
                exit();
            }
        ?>

    <h1 align="center">Domaci 1 - Update</h1>
        <div>
            <table id="frmEdit">
                <tr>
                    <th>Ime</th>
                    <th>Prezime</th>
                    <th>Broj upisa</th>
                    <th>Godina upisa</th>
                </tr>
                <tr>
                    <form action = "edit.php?id=<?php echo $student['StudentId']?>" method="post" id= "update_frm"> <!-- edit.php?id=<?//php echo $student['StudentId']?> -->
                        <td><input type="text" name = "ime" value = <?php echo $student['Ime']?> id="polje_ime"><div id="err_ime"></div></td>   
                        <td><input type="text" name = "prezime" value=<?php echo $student['Prezime']?> id="polje_prezime"><div id="err_prezime"></div></td>
                        <td><input type="text" name = "brojUpisa" value=<?php echo $student['BrojUpisa']?> id="polje_broj"><div id="err_broj"></div></td>
                        <td><input type="text" name = "godinaUpisa" value=<?php echo $student['GodinaUpisa']?> id="polje_godina"><div id="err_godina"></div></td>
                        <td><input type="submit" name = "submit" value="Update" id="submit"></td>
                    </form>
                </tr>
            </table>
        </div>

</body>
<script
  src="https://code.jquery.com/jquery-3.3.1.min.js"
  integrity="sha256-FgpCb/KJQlLNfOu91ta32o/NMZxltwRo8QtmkMRdAu8="
  crossorigin="anonymous"></script>
<script src = "/jkljajic15/js/js.js"></script>

</html>