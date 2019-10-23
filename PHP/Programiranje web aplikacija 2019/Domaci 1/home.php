<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Domaci 1</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <style>
        table, th, td 
        {
            
            border-collapse: collapse;
        }
        th, td 
        {
            padding: 15px;
        }
        #frmView
        {
            border: 1px solid black;
            margin: auto;
        }
        #frmInsert
        {
            margin: auto;
        }
    </style>
</head>
<body>
    <h1 align="center">Domaci 1 - Home</h1>
        <div>

            <form action="insert.php" method="post"> 
                <table id=frmInsert>
                    <tr>
                        <td><label for="ime">Ime</label></td>
                        <td><input type="text" name="ime" id="insert_ime"></td>
                        <td><span><?php if(isset($_GET['imeErr'])) {
                        echo $_GET['imeErr'];
                    }
                    ?></span></td>
                 
                    </tr>
                    <tr>
                        <td><label for="prezime">Prezime</label></td>
                        <td><input type="text" name="prezime" id="insert_prezime"></td>
                        <td><span><?php if(isset($_GET['prezimeErr'])) {
                        echo $_GET['prezimeErr'];
                    }
                ?></span></td>
                    </tr>
                    <tr>
                        <td><label for="broj">Broj upisa</label></td>
                        <td><input type="text" name="broj" id="inser_broj"></td>
                        <td><span><?php if(isset($_GET['brojErr'])) {
                        echo $_GET['brojErr'];
                    }
                 ?></span></td>
                    </tr>
                    <tr>
                        <td><label for="godina">Godina</label></td>
                        <td><input type="text" name="godina" id="insert_godina"></td>
                        <td><span><?php if(isset($_GET['godinaErr'])) {
                        echo $_GET['godinaErr'];
                    }
                 ?></span></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><input type="submit" value="Insert"></td>
                    </tr>
                
                </table>
            </form>

        </div>
        <div>
            <table id='frmView'>
                <tr>
                    <th>Ime</th>
                    <th>Prezime</th>
                    <th>Broj upisa</th>
                    <th>Godina upisa</th>
                    <th>Delete</th>
                    <th>Edit</th>
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