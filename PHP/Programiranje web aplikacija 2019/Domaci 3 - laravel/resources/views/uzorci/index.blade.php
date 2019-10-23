@extends('layout')
@section('content')
<h2>Povrsinski uzorci</h2>

<table>
    <tr>
        <th>Naziv</th>
        <th>Vreme</th>
        <th>Sirina</th>
        <th>Visina</th>
        <th>Status</th>

    </tr>
    @foreach ($SortiraniUzorciPoVremenu as $uzorak)
    @if ($uzorak['VremePrikupljanja'] < 2) <tr>
        <td>{{$uzorak['Naziv']}}</td>
        <td>{{$uzorak['VremePrikupljanja']}}</td>
        <td>{{$uzorak['Sirina']}}</td>
        <td>{{$uzorak['Visina']}}</td>
        <td>{{$uzorak['Status']}}</td>

        <td>
            <form action="/uzorci/{{ $uzorak['id']}}/edit" method="get">
                @csrf
                <button type="submit">Edit</button>
            </form>
        </td>
        <td>
            <form action="/uzorci/{{ $uzorak['id']}}" method="post">
                @method('delete')
                @csrf
                <button type="submit">Delete</button>
            </form>
        </td>
        @if ($uzorak->Status == 'Na Zemlji' && $uzorak->analiziran == 0)
        <td>
            <form action="/uzorci/{{ $uzorak['id']}}" method="POST">
                @csrf
                <input type="submit" value="Analiziraj">
            </form>
        </td>
        @endif
        @if ($uzorak->Status == 'Na Zemlji' && $uzorak->analiziran == 1)
        <td>Ishod: {{$uzorak->Ishod}}</td>
        <td>Analizirala: {{$uzorak->Laboratorija}}</td>
        @endif
        </tr>
        @endif
        @endforeach
</table>

<h2>Ostali uzorci</h2>

<table>
    <tr>
        <th>Naziv</th>
        <th>Vreme</th>
        <th>Sirina</th>
        <th>Visina</th>
        <th>Status</th>
    </tr>
    @foreach ($SortiraniUzorciPoNazivu as $uzorak)
    @if ($uzorak['VremePrikupljanja']>=2)
    <tr>
        <td>{{$uzorak['Naziv']}}</td>
        <td>{{$uzorak['VremePrikupljanja']}}</td>
        <td>{{$uzorak['Sirina']}}</td>
        <td>{{$uzorak['Visina']}}</td>
        <td>{{$uzorak['Status']}}</td>

        <td>
            <form action="/uzorci/{{ $uzorak['id']}}/edit" method="get">
                @csrf
                <button type="submit">Edit</button>
            </form>
        </td>
        <td>
            <form action="/uzorci/{{ $uzorak['id']}}" method="post">
                @method('delete')
                @csrf
                <button type="submit">Delete</button>
            </form>
        </td>
        @if ($uzorak->Status == 'Na Zemlji' && $uzorak->analiziran == 0)
        <td>
            <form action="/uzorci/{{ $uzorak['id']}}" method="POST">
                @csrf
                <button type="submit">Analiziraj</button>
            </form>
        </td>
        @endif
        @if ($uzorak->Status == 'Na Zemlji' && $uzorak->analiziran == 1)
        <td>Ishod: {{$uzorak->Ishod}}</td>
        <td>Analizirala: {{$uzorak->Laboratorija}}</td>
        @endif
    </tr>
    @endif
    @endforeach
</table>
@endsection
