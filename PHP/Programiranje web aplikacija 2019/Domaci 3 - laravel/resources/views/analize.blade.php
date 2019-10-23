@extends('layout')

@section('content')
    <h1>Analize</h1>
    <p>
        @if ($analize == null)
            Nema novih uzoraka za analizu
        @endif
    </p>
    <ul>
        @if ($analize != null)
            @foreach ($analize as $analiza)
            <li>{{$analiza}}</li>
            @endforeach
        @endif
    </ul>

@endsection