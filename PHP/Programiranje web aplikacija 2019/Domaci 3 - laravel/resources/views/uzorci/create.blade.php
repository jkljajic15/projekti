@extends('layout')
@section('content')
<h1>Novi Uzorak</h1>
<form method="POST" action="/uzorci">

    @csrf

    <div>
        <input type="text" name="Naziv" placeholder="Naziv" required value="{{$errors->has('Naziv') ? " " : old('Naziv')}}">
    </div>
    <div>
        <input type="number " name="VremePrikupljanja" placeholder="VremePrikupljanja" required
            value="{{$errors->has('VremePrikupljanja') ? " " : old('VremePrikupljanja')}}">
    </div>
    <div>
        <input type="number " name="Sirina" placeholder="Sirina" required value="{{$errors->has('Sirina') ? " " : old('Sirina')}}">
    </div>
    <div>
        <input type="number " name="Visina" placeholder="Visina" required value="{{$errors->has('Visina') ? " " : old('Visina')}}">
    </div>
    <div>
        Status:
        <select name="Status">
            <option value="Na Marsu">Na Marsu</option>
            <option value="U transportu">U transportu</option>
            <option value="Na Zemlji">Na Zemlji</option>
        </select>
    </div>
    <div>
        <button type="submit">Kreiraj</button>
    </div>
    @include('errors')
</form>
@endsection
