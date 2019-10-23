<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>@yield('title','Treci Domaci')</title>
            <!-- Fonts -->
            <link href="https://fonts.googleapis.com/css?family=Nunito:200,600" rel="stylesheet">

            <!-- Styles -->
            <style>
                html, body {
                    background-color: #fff;
                    color: #636b6f;
                    font-family: 'Nunito', sans-serif;
                    font-weight: 200;
                    height: 100vh;
                    margin: 0;
                }

                h1,h2{
                    padding: 0 25px;
                }

                .links > a {
                    color: #636b6f;
                    padding: 0 25px;
                    font-size: 13px;
                    font-weight: 600;
                    letter-spacing: .1rem;
                    text-decoration: none;
                    text-transform: uppercase;
                }

                table{
                    border-collapse: collapse;
                }

                table,th,td{
                    border: 1px solid gray;
                }
            </style>
</head>
<body>
    <div class="links">
        <a href="/uzorci">Uzorci</a> |
        <a href="/uzorci/create">Kreiraj uzorak</a> |
        <a href="/lab">Labaratorije</a> |
        <a href="/lab/create">Dodaj laboratoriju</a> |
        <a href="/lab/analize">Analize</a>
    </div>

    <div class="content">
        @yield('content')
    </div>
</body>
</html>
